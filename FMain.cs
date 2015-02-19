using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using EncRotator.Properties;
using System.Threading.Tasks;


namespace EncRotator
{

    public partial class fMain : Form
    {
        static DeviceTemplate[] templates = { 
                    new DeviceTemplate { engineLines = new Dictionary<int,string>{ {1, "15"}, {-1, "19"} }, 
                                            encLines = new String[] { "21", "22", "1", "2", "3", "4", "5", "6", "11", "12" },
                                            ledLine = "20",
                                            slowLine = "13" },
                    new DeviceTemplate { engineLines = new Dictionary<int,string>{ {1, "16"}, {-1, "19"} }, 
                                            encLines = new String[] { "21", "22", "1", "2", "3", "4", "5", "6", "11", "12" },
                                            ledLine = "20" },
                    new DeviceTemplate { engineLines = new Dictionary<int,string>{ {1, "5"}, {-1, "4"} }, slowLine = "3",
                                            relays = new String[] { "1", "2", "6", "9" },
                                            adc = "1" } 
                                    };
        DeviceTemplate currentTemplate;
        volatile TcpClient socket;
        volatile bool socketBusy;
        FormState formState = new FormState();
        int[] encLineVals = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        string host = "192.168.0.101";
        string password = "Jerome";
        string port = "2424";
        Dictionary<int,int> limits;
        int currentAngle = -1;
        int targetAngle = -1;
        int engineStatus = 0;
        int mapAngle = -1;
        int startAngle = -1;
        bool slowState = false;
        bool angleChanged = false;
        bool mvtBlink = false;
        List<Bitmap> maps = new List<Bitmap>();
        Regex rEVT = new Regex( @"#EVT,IN,\d+,(\d+),(\d)" );
        ToolStripMenuItem[] connectionsDropdown;
        int prevHeight;
        double mapRatio = 0;
        ConnectionSettings currentConnection;
        int noMoveTime = 0;
        const int adcDataLength = 10;
        int[] adcData = new int[adcDataLength];
        int adcDataCount = 0;
        bool calibration = false;
        int curADCVal;
        int calCount = 0;
        bool awaitingLimitConfirmation = false;
        FRelays fr = null;

        public int getCurrentAngle() {
            return currentAngle;
        }

        public fMain()
        {
            InitializeComponent();
            if (File.Exists( Application.StartupPath + "\\config.xml"))
            {
                loadConfig();
                updateConnectionsMenu();
                string currentMapStr = "";
                if ( formState.currentMap != -1 )
                    currentMapStr = formState.maps[ formState.currentMap ];
                formState.maps.RemoveAll( item => !File.Exists(item) );
                if (!currentMapStr.Equals(string.Empty))
                    formState.currentMap = formState.maps.IndexOf( currentMapStr );
                formState.maps.ForEach( item => loadMap( item ) );
                if (formState.currentMap != -1)
                    setCurrentMap(formState.currentMap);
                else if (formState.maps.Count > 0 )
                    setCurrentMap(0);
                prevHeight = Height;
            }
        }

        private void setCurrentMap(int val)
        {
            formState.currentMap = val;
            pMap.BackgroundImage = maps[val];
            writeConfig();
            mapRatio = (double)maps[val].Width / (double)maps[val].Height;
            adjustToMap();
        }

        private void updateConnectionsMenu() {
            while ( miConnections.DropDownItems.Count > 2 ) {
                miConnections.DropDownItems.RemoveAt(0);

            }
            for (int co = 0; co < formState.connections.Count; co++)
                createConnectionMenuItem(co);
        }

        private void loadConnection(int index)
        {
            currentConnection = formState.connections[index];
            formState.currentConnection = index;
            if (!String.Empty.Equals(currentConnection.host))
            {
                host = currentConnection.host;
            }
            if (!String.Empty.Equals(currentConnection.password))
            {
                password = currentConnection.password;
            }
            if (!String.Empty.Equals(currentConnection.port))
            {
                port = currentConnection.port;
            }

            limits = new Dictionary<int,int>
                { { -1, currentConnection.limits[0] }, 
                {1, currentConnection.limits[1] } };

            currentTemplate = getTemplate( currentConnection.deviceType );
            for (int co = currentConnection.relayLabels.Count(); co < currentTemplate.relays.Count(); co++)
                currentConnection.relayLabels.Add("");
            writeConfig();


            connect();
            pMap.Refresh();
        }

        private DeviceTemplate getTemplate(int deviceType)
        {
            if (deviceType == 0)
                return templates[currentConnection.soft ? 0 : 1];
            else
                return templates[2];
        }


        private void miModuleSettings_Click(object sender, EventArgs e)
        {
            (new fModuleSettings()).ShowDialog();
        }

        private void socketWrite(string cmd)
        {
            if (socket != null)
            {
                byte[] byteCmd = System.Text.ASCIIEncoding.ASCII.GetBytes("$KE," + cmd + "\r\n");
                if (!cmd.Contains("ADC"))
                {
                    //System.Diagnostics.Debug.WriteLine("$KE," + cmd + "\r\n");
                }
                try
                {
                    socket.GetStream().Write(byteCmd, 0, byteCmd.Length);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Сетевая ошибка: " + e.Message);
                    doDisconnect();

                }
            }

        }

        public void engine(int val)
        {
            if ( val != engineStatus ) {
                this.UseWaitCursor = true;
                /*Cursor tmpCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;*/
                if (val == 0 || engineStatus != 0)
                {
                    if (currentConnection.deviceType == 0 && currentConnection.soft)
                    {
                        setSlow(false);
                        Thread.Sleep(3000);
                    }
                    else if (currentConnection.deviceType == 1)
                        setSlow(false);
                    toggleLine(currentTemplate.engineLines[engineStatus], "0");
                }
                if ( val != 0 ) {
                    if (currentConnection.deviceType == 1)
                        setSlow(true);
                    toggleLine(currentTemplate.engineLines[val], "1");
                    if (currentConnection.deviceType == 0 && currentConnection.soft)
                    {
                        Thread.Sleep(500);
                        setSlow(true);
                    }
                }
                engineStatus = val;
                System.Diagnostics.Debug.WriteLine("engine " + val.ToString());
                this.UseWaitCursor = false;
                //Cursor.Current = tmpCursor;
            }
        }

        private void setSlow(bool val)
        {
            toggleLine(currentTemplate.slowLine, val ? "1" : "0");
            slowState = val;
        }

        private void doDisconnect() {
            Text = "Нет соединения";
            Icon = (Icon)Resources.ResourceManager.GetObject(CommonInf.icons[0]);
            miConnections.Text = "Соединения";
            if ( connectionsDropdown != null )
                miConnections.DropDownItems.AddRange(connectionsDropdown);
            miSetNorth.Visible = false;
            miCalibrate.Visible = false;
            miClearStops.Visible = false;
            timer.Enabled = false;
            if (socket != null)
            {
                if (currentConnection.deviceType == 0)
                    toggleLine(currentTemplate.ledLine, "0");                
                bgWorker.CancelAsync();                
                if (socket.Connected)
                    socket.Close();
                socket = null;
            }
            currentConnection = null;
            pMap.Invalidate();
        }

        private string _socketRead()
        {
            string result = "";
            while (!result.Contains("\n"))
            {
                while (socket != null && socket.Available > 0 && !result.Contains("\n") )
                {
                    try {
                        result += (char)socket.GetStream().ReadByte();
                    } catch ( Exception e ) {
                        MessageBox.Show( "Сетевая ошибка: " + e.Message );
                        doDisconnect();
                        return "";
                    }
                }
                if (result.Contains("EVT") && !result.Contains("OK"))
                {
                    processEVT(result);
                    result = "";
                }
            }
            //System.Diagnostics.Debug.WriteLine(result);
            return result;
        }

        private string socketRead()
        {
            return socketRead(false);
        }

        private string socketRead(bool asyncExit)
        {
            var tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            int timeOut = 500; // 1000 ms

            Task<string> task = Task.Factory.StartNew<string>(() => _socketRead(), token);

            if (!task.Wait(timeOut, token))
            {
                MessageBox.Show("Превышено время ожидания ответа от устройства");
                tokenSource.Cancel();
                socket = null;
                socketBusy = false;
                if (asyncExit)
                    bgWorker.CancelAsync();
                else
                    doDisconnect();
                return "";
            }
            else
            {
                return task.Result;
            }
        }

        private void processEVT(string msg)
        {
            Match match = rEVT.Match(msg);
            string line = match.Groups[1].Value;
            int lineState = match.Groups[2].Value == "0" ? 1 : 0;
            if ( currentConnection.deviceType == 0 && currentTemplate.encLines.Contains(line))
            {
                int bit = Array.FindIndex(currentTemplate.encLines, item => item == line);
                encLineVals[bit] = lineState;
                updateEncVal();
            }
        }

        public void writeConfig()
        {
            using (StreamWriter sw = new StreamWriter( Application.StartupPath + "\\config.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(FormState));
                ser.Serialize(sw, formState);
            }

        }

        private void socketConnect()
        {
            if (socket != null)
            {
                socket.Close();
            }
            Action fail = () =>
                {
                    socket = null;
                    doDisconnect();
                    MessageBox.Show("Соединение не удалось");
                };
            try
            {
                socket = new TcpClient();
                IAsyncResult connResult = socket.BeginConnect(host, Convert.ToInt32(port), null, null);
                if (connResult.AsyncWaitHandle.WaitOne(3000, true))
                {
                    socket.SendTimeout = 50;
                    socket.ReceiveTimeout = 50;
                }
                else
                {
                    fail();
                }
            }
            catch (Exception ex)
            {
                fail();
            }
        }

        private void setLine(string line, string dir)
        {
            while (socketBusy) { continue; }
            socketBusy = true;
            socketWrite("IO,SET," + line + "," + dir );
            socketRead();
            socketBusy = false;
        }

        private void toggleLine(string line, string state)
        {
            while (socketBusy) { continue; }
            socketBusy = true;
            socketWrite("WR," + line + "," + state);
            socketRead();
            socketBusy = false;
        }

        private void loadConfig()
        {
            XmlSerializer ser = new XmlSerializer(typeof(FormState));
            using (FileStream fs = File.OpenRead( Application.StartupPath + "\\config.xml"))
            {
                try
                {
                    formState = (FormState)ser.Deserialize(fs);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void connect()
        {
            miConnections.Enabled = false;
            if (Convert.ToInt32(port) > 0 && host.Length > 0)
            {
                Cursor tmpCursor = Cursor;
                Cursor = Cursors.WaitCursor;
                socketConnect();
                if ( socket != null ) {
                    socketWrite("PSW,SET," + password);
                    if (socketRead().Contains("OK"))
                    {
                        socketWrite("EVT,ON");
                        socketRead();
                        formState.connections[formState.currentConnection].host = host;
                        formState.connections[formState.currentConnection].port = port;
                        formState.connections[formState.currentConnection].password = password;
                        writeConfig();
                            
                        miConnections.Text = "Отключиться";
                        connectionsDropdown = new ToolStripMenuItem[miConnections.DropDownItems.Count];
                        miConnections.DropDownItems.CopyTo(connectionsDropdown,0);
                        miConnections.DropDownItems.Clear();
                        //miConnectionParams.Enabled = false;

                        if (currentConnection.deviceType == 0)
                        {
                            setLine(currentTemplate.ledLine, "0");
                            if (currentConnection.soft)
                            {
                                setLine(currentTemplate.slowLine, "0");
                                toggleLine(currentTemplate.slowLine, "0");
                            }

                            for (int co = 0; co < 10; co++)
                                setLine(currentTemplate.encLines[co], "1");
                        }

                        foreach (string line in currentTemplate.engineLines.Values)
                        {
                            setLine( line, "0" );
                            toggleLine( line, "0" );
                        }

                        if (currentConnection.deviceType == 0)
                        {
                            socketWrite("RD,ALL");
                            string linesData = socketRead();
                            for (int co = 0; co < 10; co++)
                            {
                                int lineNo = Convert.ToInt16(currentTemplate.encLines[co]);
                                if (linesData[lineNo + 3] == '0')
                                    encLineVals[co] = 1;
                            }
                            updateEncVal();
                        }
                            
                        bgWorker.RunWorkerAsync();
                        timer.Enabled = true;
                        miSetNorth.Visible = true;

                        if (currentConnection.deviceType == 0)
                        {
                            miSetNorth.Enabled = true;
                            miCalibrate.Visible = false;
                            miClearStops.Visible = true;
                            updateMiClearStopsEnabled();
                        }
                        else if (currentConnection.deviceType == 1)
                        {
                            miCalibrate.Visible = true;
                            miCalibrate.Text = "Калибровать";
                            miSetNorth.Enabled = currentConnection.calibrated;
                            miClearStops.Visible = false;
                            miRelays.Visible = true;
                        }

                        Text = currentConnection.name;
                        Icon = (Icon) Resources.ResourceManager.GetObject(CommonInf.icons[currentConnection.icon]);
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!");
                        doDisconnect();
                    }
                }
                Cursor = tmpCursor;
            }
            else
            {
                MessageBox.Show("Не заполнены поля адрес и порт");
            }
            miConnections.Enabled = true;
        }

        private void updateEncVal()
        {
            int num = 0;
            for (int co = 0; co < 10; co++)
                num |= encLineVals[co] << co;
            for (int mask = num >> 1; mask != 0; mask = mask >> 1)
            {
                num = num ^ mask;
            }
            setCurrentAngle(num);
        }

        private int aD(int a, int b)
        {
            int r = a - b;
            if (r > 180)
                r -= 360;
            else if (r < -180)
                r += 360;
            return r;
        }

        private void rotateToAngle(int angle)
        {
            if ( socket != null ) {
                targetAngle = currentConnection.northAngle + angle - (currentConnection.northAngle + angle > 360 ? 360 : 0);
                pMap.Invalidate();
                System.Diagnostics.Debug.WriteLine("start " + currentAngle.ToString() + " - " + angle.ToString());
                if (targetAngle != currentAngle)
                {
                    int d = aD(targetAngle, currentAngle);
                    int dir = Math.Sign( d );
                    if (currentConnection.deviceType == 0)
                    {
                        int nStop = getNearestStop(dir);
                        if (nStop != -1)
                        {
                            int dS = aD(nStop, currentAngle);
                            if (Math.Sign(dS) == dir && Math.Abs(dS) < Math.Abs(d))
                                dir = -dir;
                        }
                    }
                    else if (currentConnection.deviceType == 1)
                    {
                        int rt = currentAngle + d;
                        if (rt < 0 || rt > 450)
                            dir = -dir;
                    }
                    engine(dir);
                }
            }
        }

        private int getNearestStop(int dir)
        {
            int nStop = dir;
            if (limits[nStop] == -1)
                nStop = -nStop;
            return limits[nStop];
        }


        private void setCurrentAngle(int num)
        {
            int newAngle = currentConnection.deviceType == 0 ? (int)(((double)num) * 0.3515625) : num;
            if (newAngle != currentAngle)
            {
               /* if (currentAngle != -1 && engineStatus != 0)
                {
                    if (Math.Sign(aD(newAngle, currentAngle)) != engineStatus)
                    {
                        System.Diagnostics.Debug.WriteLine("engine lines swap: " + engineStatus.ToString() + " - " + currentAngle.ToString() +
                            " -> " + newAngle.ToString());
                        string t = engineLines[-1];
                        engineLines[-1] = engineLines[1];
                        engineLines[1] = t;
                        engineStatus = -engineStatus;
                    }
                }*/
                if (engineStatus != 0)
                {
                    if (currentConnection.deviceType == 0)
                    {
                        int nStop = getNearestStop(engineStatus);
                        if (nStop != -1)
                        {
                            int dS = aD(nStop, currentAngle);
                            if (Math.Sign(dS) == engineStatus && Math.Abs(dS) < 7)
                                engine(0);
                        }

                    }
                    else 
                    {
                        if (slowState && Math.Abs(startAngle - currentAngle) > currentConnection.slowInt)
                            setSlow(false);
                        else if (!slowState && Math.Abs(currentAngle - startAngle) < currentConnection.slowInt)
                            setSlow(true);
                    }
                }
                currentAngle = newAngle;
                angleChanged = true;
                if (currentConnection.northAngle != -1 && engineStatus != 0 && targetAngle != -1)
                {
                    /*mapAngle = currentAngle - northAngle + (currentAngle < northAngle ? 360 : 0);
                    pMap.Refresh();*/
                    int tD = aD(targetAngle, currentAngle);
                    if (Math.Sign(tD) == engineStatus && Math.Abs(tD) < currentConnection.slowInt)
                    {
                        engine(0);
                        targetAngle = -1;
                        pMap.Invalidate();
                    }
                }
                int displayAngle = currentAngle;
                if (currentConnection.northAngle != -1)
                    displayAngle += ( displayAngle < currentConnection.northAngle ? 360 : 0 ) - currentConnection.northAngle;
                lAngle.Text = displayAngle.ToString();
              /*  if (targetAngle != -1)
                    System.Diagnostics.Debug.WriteLine("target: " + targetAngle.ToString() + " current: " + currentAngle.ToString());*/
            }
        }

        private void loadMap(string fMap)
        {
            if (File.Exists(fMap))
            {
                maps.Add( new Bitmap(fMap) );
                if (formState.maps.IndexOf(fMap) == -1)
                    formState.maps.Add(fMap);
            }
        }

        private void adjustToMap()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                int tmpHeight = Height;
                WindowState = FormWindowState.Normal;
                Height = tmpHeight;
                Top = 0;
                Left = 0;
            }
            if (Math.Abs(mapRatio - (double)pMap.Width / (double)pMap.Height) > 0.01)
            {
                Width = (int)(mapRatio * pMap.Height) + Width - pMap.Width;
                //pMap.Refresh();
            }
        }

        private void pMap_Paint(object sender, PaintEventArgs e)
        {
            if (formState.currentMap != -1 && currentConnection != null && currentConnection.northAngle != -1 && 
                ( currentConnection.deviceType == 0 || ( currentConnection.deviceType == 1 && currentConnection.calibrated ) ) )
            {
                Action<int,Color> drawAngle = (int angle, Color color) =>
                    {
                        if (angle == -1)
                            return;
                        double rAngle = (((double)(angle - currentConnection.northAngle)) / 180) * Math.PI;
                        e.Graphics.DrawLine(new Pen(color, 2), pMap.Width / 2, pMap.Height / 2,
                            pMap.Width / 2 + (int)(Math.Sin(rAngle) * (pMap.Height / 2)), 
                            pMap.Height / 2 - (int)(Math.Cos(rAngle) * ( pMap.Height / 2 ) ) );

                    };
                drawAngle(currentAngle, Color.Red );
                drawAngle(targetAngle, Color.Green );
                if ( currentConnection.deviceType == 0 )
                    limits.Values.ToList<int>().ForEach(item => drawAngle(item, Color.Gray));
                //e.Graphics.DrawImage(bmpMap, new Rectangle( 0, 0, pMap.Width, pMap.Height) );
                mapAngle = currentAngle;
            }
        }

        private void pMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (maps.Count > 1)
                    if (formState.currentMap < maps.Count - 1)
                        setCurrentMap(++formState.currentMap);
                    else
                        setCurrentMap(0);
            }
            else if (currentConnection.northAngle != -1 && currentAngle != -1)
            {
                int angle;
                if (e.X == pMap.Width / 2)
                {
                    if (e.Y < pMap.Height / 2)
                    {
                        angle = 90;
                    }
                    else
                    {
                        angle = 270;
                    }
                }
                else
                {
                    double y = pMap.Height / 2 - e.Y;
                    double x = e.X - pMap.Width / 2;
                    angle = (int)((Math.Atan( y / x ) / Math.PI) * 180);
                    if (x < 0)
                    {
                        if (y > 0)
                        {
                            angle = 180 + angle;
                        }
                        else
                        {
                            angle = angle - 180;
                        }
                    }
                }
                angle = 90 - angle;
                if (angle < 0) { angle += 360; }
                rotateToAngle(angle);
            }
        }

        private void orderStops()
        {
            if (limits[-1] != -1 && limits[1] != -1)
            {
                if (aD(limits[1], limits[-1]) < 0)
                {
                    int t = limits[-1];
                    limits[-1] = limits[1];
                    limits[1] = t;
                }
            }

        }

        private void miSetNorth_Click(object sender, EventArgs e)
        {
            FSetNorth fSNorth = new FSetNorth();
            if (fSNorth.ShowDialog(this) == DialogResult.OK)
            {
                if ( fSNorth.northAngle != -1 )
                    currentConnection.northAngle = fSNorth.northAngle;
                if (currentConnection.deviceType == 0)
                {
                    if (fSNorth.stopAngles[-1] != -1)
                        limits[-1] = fSNorth.stopAngles[-1];
                    if (fSNorth.stopAngles[1] != -1)
                        limits[-1] = fSNorth.stopAngles[-1];
                    orderStops();
                    currentConnection.limits[0] = limits[-1];
                    currentConnection.limits[1] = limits[1];
                    updateMiClearStopsEnabled();
                }
                writeConfig();
                pMap.Invalidate();
            }
        }

        private void updateMiClearStopsEnabled()
        {
            miClearStops.Enabled = limits.Values.ToList<int>().Exists(item => item != -1);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int co = 0;
            bool ledFl = false;
            while (socket != null)
            {
                if (bgWorker.CancellationPending)
                    return;
                if (!socketBusy)
                {
                    socketBusy = true;
                    if (currentConnection.deviceType == 0)
                    {
                        if (co++ > 9)
                        {
                            ledFl = !ledFl;
                            try
                            {
                                socketWrite("WR," + currentTemplate.ledLine + "," + (ledFl ? "0" : "1"));
                            }
                            catch (Exception ex)
                            {
                                return;
                            }
                            co = 0;
                        }
                        string result = "";
                        while (socket.Available > 0)
                        {
                            while (!result.Contains("\n"))
                            {
                                try
                                {
                                    result += (char)socket.GetStream().ReadByte();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Сетевая ошибка: " + ex.Message);
                                }
                            }
                            if (result.Contains("EVT") && !result.Contains("OK"))
                            {
                                bgWorker.ReportProgress(0, result);
                            }
                            result = "";
                        }
                    }
                    else if (currentConnection.deviceType == 1)
                    {
                        string result = "";
                        try 
                        {
                            socketWrite("ADC," + currentTemplate.adc);
                            result = socketRead(true);
                            if (result.Equals(string.Empty))
                                return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Сетевая ошибка: " + ex.Message);
                        }

                        if (result.Contains("ADC") && result.Length == 13)
                        {
                            bgWorker.ReportProgress( 0,  result);
                        }
                    }
                    socketBusy = false;

                    Thread.Sleep(100);
                }
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (currentConnection == null)
                return;
            if (currentConnection.deviceType == 0)
                processEVT((string)e.UserState);
            else if (currentConnection.deviceType == 1)
            {
                processADC(Convert.ToInt16(((string)e.UserState).Substring(7, 4)));
            }
        }

        private void processADC(int adcVal)
        {
            if (adcDataCount < adcDataLength - 1)
            {
                adcData[adcDataCount++] = adcVal;
            }
            else
            {
                Array.Copy(adcData, 1, adcData, 0, adcDataLength - 1);
                adcData[adcDataLength - 1] = adcVal;
            }
            int newADCVal = 0;
            for (int co = 0; co < adcDataCount; co++)
            {
                newADCVal += adcData[co];
            }
            newADCVal = Convert.ToInt16(newADCVal / adcDataCount);
            if (currentConnection.calibrated)
                setCurrentAngle( Convert.ToInt16(((double)(adcVal - limits[-1]) / (double)(limits[1] - limits[-1])) * 450) );
            else
            {
                lAngle.Text = Convert.ToString(newADCVal);
                if (calibration)
                {
                    if (curADCVal < newADCVal - 5 || curADCVal > newADCVal + 5)
                    {
                        curADCVal = newADCVal;
                        calCount = 0;
                    }
                    else
                    {
                        if (calCount++ > 50)
                        {
                            calibration = false;
                            calCount = 0;
                            if (engineStatus==1)
                            {
                                calibrationStop();
                                limits[1] = newADCVal;
                                currentConnection.calibrated = true;
                                currentConnection.limits[0] = limits[-1];
                                currentConnection.limits[1] = limits[1];
                                writeConfig();
                                miSetNorth.Enabled = true;
                                MessageBox.Show("Калибровка завершена.");
                            }
                            else
                            {
                                limits[-1] = newADCVal;
                                engine(1);
                                calibrationStart(1);
                            }
                        }
                    }
                }
            }


        }

        private void calibrationStart(int dir)
        {
            currentConnection.calibrated = false;
            writeConfig();
            calibration = true;
            miSetNorth.Enabled = false;
            miCalibrate.Text = "Остановить калибровку";
            slCalibration.Visible = true;
            engine(dir);
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket != null && socket.Connected)
            {
                while (socketBusy) continue;
                doDisconnect();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (angleChanged)
            {
                pMap.Invalidate();
                angleChanged = false;
                mvtBlink = !mvtBlink;
                slMvt.DisplayStyle = mvtBlink ? ToolStripItemDisplayStyle.Image : ToolStripItemDisplayStyle.Text;
                noMoveTime = 0;
            }
            else
            {
                slMvt.DisplayStyle = ToolStripItemDisplayStyle.Text;
                if ( engineStatus != 0 && currentConnection != null && currentConnection.deviceType == 0 && !awaitingLimitConfirmation)
                    if (++noMoveTime > 5 )
                    {
                        awaitingLimitConfirmation = true;
                        if ( MessageBox.Show( "Антенна не движется. В этой точке находится концевик?", currentConnection.name, MessageBoxButtons.YesNo ) 
                            == DialogResult.Yes ) 
                        {
                            limits[engineStatus] = currentAngle;
                            orderStops();
                            currentConnection.limits[ engineStatus == -1 ? 0 : 1 ] = limits[engineStatus];
                            writeConfig();
                            updateMiClearStopsEnabled();
                            pMap.Invalidate();
                            engine(-engineStatus);
                        } else 
                            engine(0);
                        awaitingLimitConfirmation = false;
                        noMoveTime = 0;
                    }
            }
        }

        private void miMapAdd_Click(object sender, EventArgs e)
        {
            if (ofdMap.ShowDialog() == DialogResult.OK)
            {
                loadMap(ofdMap.FileName);
                setCurrentMap(maps.Count - 1);
                writeConfig();
            }
        }

        private void pMap_Resize(object sender, EventArgs e)
        {
            //pMap.Refresh();
        }

     
        private void miConnections_Click(object sender, EventArgs e)
        {
            if (socket != null)
            {
                while (socketBusy) continue;
                doDisconnect();
            }

        }

        private void miNewConnection_Click(object sender, EventArgs e)
        {
            ConnectionSettings nConn = new ConnectionSettings();
            if (editConnection(nConn))
            {
                formState.connections.Add(nConn);
                createConnectionMenuItem(formState.connections.IndexOf(nConn));
                writeConfig();
            }
        }

        private void createConnectionMenuItem(int index)
        {
            ToolStripMenuItem miConn = new ToolStripMenuItem();
            miConn.Text = formState.connections[ index ].name;
            miConn.Click += delegate(object sender, EventArgs e)
            {
                loadConnection(index);
            };
            miConnections.DropDownItems.Insert(index, miConn);
        }

        public bool editConnection(ConnectionSettings conn)
        {
            fConnectionParams fParams = new fConnectionParams(conn);
            fParams.ShowDialog(this);
            bool result = fParams.DialogResult == DialogResult.OK;
            if (result)
            {
                conn.host = fParams.data.host;
                conn.port = fParams.data.port;
                conn.name = fParams.data.name;
                conn.usartPort = fParams.data.usartPort;
                conn.slowInt = fParams.data.slowInt;
                conn.deviceType = fParams.data.deviceType;
                conn.soft = fParams.data.soft;
                conn.icon = fParams.data.icon;
                writeConfig();
                if ( conn.Equals( currentConnection ) )
                {
                    Icon = (Icon) Resources.ResourceManager.GetObject(CommonInf.icons[conn.icon]);
                }
            }
            return result;
        }

        private void miEditConnections_Click(object sender, EventArgs e)
        {
            new FConnectionsList(formState).ShowDialog(this);
            updateConnectionsMenu();
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            doDisconnect();
        }

        private void fMain_Resize(object sender, EventArgs e)
        {
            if (mapRatio != 0)
                adjustToMap();
        }


        private void lSizeM_Click(object sender, EventArgs e)
        {
            Height = 300;
        }

        private void lSizeP_Click(object sender, EventArgs e)
        {
            Height = 800;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            engine(0);
            if (targetAngle != -1)
            {
                targetAngle = -1;
                pMap.Invalidate();
            }
            if (calibration)
                calibrationStop();
        }

        private void calibrationStop()
        {
            calibration = false;
            engine(0);
            miCalibrate.Text = "Калибровать";
            slCalibration.Visible = false;
        }

        private void miCalibrate_Click(object sender, EventArgs e)
        {
            if (calibration)
                calibrationStop();
            else
            {
                calibrationStart(-1);
            }
        }

        private void miMapRemove_Click(object sender, EventArgs e)
        {
            maps.RemoveAt(formState.currentMap);
            formState.maps.RemoveAt(formState.currentMap);
            if (maps.Count > 0)
            {
                if (formState.currentMap > 0)
                    setCurrentMap(--formState.currentMap);
                else
                    setCurrentMap(1);
            }
            else
            {
                formState.currentMap = -1;
                pMap.BackgroundImage = null;
                pMap.Refresh();
                writeConfig();
            }
        }

        private void miClearStops_Click(object sender, EventArgs e)
        {
            limits.Keys.ToList<int>().ForEach(item => limits[item] = -1);
            currentConnection.limits[0] = -1;
            currentConnection.limits[1] = -1;
            writeConfig();
            pMap.Invalidate();
        }

        private void miRelays_CheckStateChanged(object sender, EventArgs e)
        {
            if (miRelays.Checked)
            {
                fr = new FRelays(currentConnection.relayLabels);
                fr.StartPosition = FormStartPosition.Manual;
                fr.Top = Top;
                fr.Left = Left + Width;
                fr.FormClosed += new FormClosedEventHandler(delegate(object obj, FormClosedEventArgs ee)
                {
                    miRelays.Checked = false;
                });
                fr.RelayButtonStateChanged += relayButtonStateChanged;
                fr.RelayLabelChanged += relayLabelChanged;
                fr.Show(this);
            }
            else 
            {
                fr.Close();
            }
        }

        private void relayButtonStateChanged(object obj, RelayButtonStateChangedEventArgs e)
        {
            toggleLine(currentTemplate.relays[e.relay], e.state ? "1" : "0");
        }

        private void relayLabelChanged(object obj, RelayLabelChangedEventArgs e)
        {
            currentConnection.relayLabels[e.relay] = e.value;
            writeConfig();
        }

    }

    class DeviceTemplate
    {
        internal Dictionary<int, string> engineLines;
        internal string[] encLines;
        internal string[] relays;
        internal string ledLine;
        internal string slowLine;
        internal string adc;
    }

    public class ConnectionSettings
    {
        public string name = "";
        public string host = "192.168.0.101";
        public string port = "2424";
        public string usartPort = "2525";
        public string password = "Jerome";
        public int[] limits = { -1, -1 };
        public int northAngle = -1;
        public int slowInt = 10;
        public int deviceType = 0;
        public bool soft = true;
        public int icon = 0;
        public bool calibrated = false;
        public List<String> relayLabels = new List<String>();
    }

    public class FormState
    {
        public int currentConnection = -1;
        public List<string> maps = new List<string>();
        public int currentMap = -1;
        public List<ConnectionSettings> connections = new List<ConnectionSettings>();        
    }

    public static class CommonInf
    {
        public static string[] icons = { "icon_ant1", "icon_10", "icon_40", "icon_left", "icon_right", "icon_up" };
    }

}
