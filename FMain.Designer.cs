namespace EncRotator
{
    partial class fMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.ofdMap = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miParams = new System.Windows.Forms.ToolStripMenuItem();
            this.miConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.miMaps = new System.Windows.Forms.ToolStripMenuItem();
            this.miMapAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miMapRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.miSetNorth = new System.Windows.Forms.ToolStripMenuItem();
            this.miCalibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.miClearStops = new System.Windows.Forms.ToolStripMenuItem();
            this.miModuleSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pMap = new System.Windows.Forms.PictureBox();
            this.slMvt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lAngle = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slCalibration = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bSizeM = new System.Windows.Forms.ToolStripButton();
            this.bSizeP = new System.Windows.Forms.ToolStripButton();
            this.bStop = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMap)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miParams});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip";
            // 
            // miParams
            // 
            this.miParams.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConnections,
            this.miMaps,
            this.miSetNorth,
            this.miCalibrate,
            this.miClearStops,
            this.miModuleSettings});
            this.miParams.Name = "miParams";
            this.miParams.Size = new System.Drawing.Size(73, 20);
            this.miParams.Text = "Настройки";
            // 
            // miConnections
            // 
            this.miConnections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewConnection,
            this.miEditConnections});
            this.miConnections.Name = "miConnections";
            this.miConnections.Size = new System.Drawing.Size(186, 22);
            this.miConnections.Text = "Соединения";
            this.miConnections.Click += new System.EventHandler(this.miConnections_Click);
            // 
            // miNewConnection
            // 
            this.miNewConnection.Name = "miNewConnection";
            this.miNewConnection.Size = new System.Drawing.Size(201, 22);
            this.miNewConnection.Text = "Новое";
            this.miNewConnection.Click += new System.EventHandler(this.miNewConnection_Click);
            // 
            // miEditConnections
            // 
            this.miEditConnections.Name = "miEditConnections";
            this.miEditConnections.Size = new System.Drawing.Size(201, 22);
            this.miEditConnections.Text = "Редактировать список";
            this.miEditConnections.Click += new System.EventHandler(this.miEditConnections_Click);
            // 
            // miMaps
            // 
            this.miMaps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMapAdd,
            this.miMapRemove});
            this.miMaps.Name = "miMaps";
            this.miMaps.Size = new System.Drawing.Size(186, 22);
            this.miMaps.Text = "Карты";
            // 
            // miMapAdd
            // 
            this.miMapAdd.Name = "miMapAdd";
            this.miMapAdd.Size = new System.Drawing.Size(135, 22);
            this.miMapAdd.Text = "Добавить";
            this.miMapAdd.Click += new System.EventHandler(this.miMapAdd_Click);
            // 
            // miMapRemove
            // 
            this.miMapRemove.Name = "miMapRemove";
            this.miMapRemove.Size = new System.Drawing.Size(135, 22);
            this.miMapRemove.Text = "Удалить";
            this.miMapRemove.Click += new System.EventHandler(this.miMapRemove_Click);
            // 
            // miSetNorth
            // 
            this.miSetNorth.Name = "miSetNorth";
            this.miSetNorth.Size = new System.Drawing.Size(186, 22);
            this.miSetNorth.Text = "Установить Север";
            this.miSetNorth.Visible = false;
            this.miSetNorth.Click += new System.EventHandler(this.miSetNorth_Click);
            // 
            // miCalibrate
            // 
            this.miCalibrate.Name = "miCalibrate";
            this.miCalibrate.Size = new System.Drawing.Size(186, 22);
            this.miCalibrate.Text = "Калибровать";
            this.miCalibrate.Visible = false;
            this.miCalibrate.Click += new System.EventHandler(this.miCalibrate_Click);
            // 
            // miClearStops
            // 
            this.miClearStops.Name = "miClearStops";
            this.miClearStops.Size = new System.Drawing.Size(186, 22);
            this.miClearStops.Text = "Удалить концевики";
            this.miClearStops.Visible = false;
            this.miClearStops.Click += new System.EventHandler(this.miClearStops_Click);
            // 
            // miModuleSettings
            // 
            this.miModuleSettings.Name = "miModuleSettings";
            this.miModuleSettings.Size = new System.Drawing.Size(186, 22);
            this.miModuleSettings.Text = "Настройки модуля";
            this.miModuleSettings.Click += new System.EventHandler(this.miModuleSettings_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pMap
            // 
            this.pMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pMap.Location = new System.Drawing.Point(0, 52);
            this.pMap.Name = "pMap";
            this.pMap.Size = new System.Drawing.Size(526, 377);
            this.pMap.TabIndex = 16;
            this.pMap.TabStop = false;
            this.pMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pMap_Paint);
            this.pMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pMap_MouseClick);
            this.pMap.Resize += new System.EventHandler(this.pMap_Resize);
            // 
            // slMvt
            // 
            this.slMvt.AutoSize = false;
            this.slMvt.Name = "slMvt";
            this.slMvt.Size = new System.Drawing.Size(17, 19);
            // 
            // lAngle
            // 
            this.lAngle.AutoSize = false;
            this.lAngle.Name = "lAngle";
            this.lAngle.Size = new System.Drawing.Size(40, 19);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slMvt,
            this.lAngle,
            this.slCalibration});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(526, 24);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip";
            // 
            // slCalibration
            // 
            this.slCalibration.AutoSize = false;
            this.slCalibration.Name = "slCalibration";
            this.slCalibration.Size = new System.Drawing.Size(80, 19);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSizeM,
            this.bSizeP,
            this.bStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 26);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bSizeM
            // 
            this.bSizeM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bSizeM.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSizeM.Image = ((System.Drawing.Image)(resources.GetObject("bSizeM.Image")));
            this.bSizeM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSizeM.Name = "bSizeM";
            this.bSizeM.Size = new System.Drawing.Size(23, 23);
            this.bSizeM.Text = "-";
            this.bSizeM.Click += new System.EventHandler(this.lSizeM_Click);
            // 
            // bSizeP
            // 
            this.bSizeP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bSizeP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSizeP.Image = ((System.Drawing.Image)(resources.GetObject("bSizeP.Image")));
            this.bSizeP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSizeP.Name = "bSizeP";
            this.bSizeP.Size = new System.Drawing.Size(25, 23);
            this.bSizeP.Text = "+";
            this.bSizeP.Click += new System.EventHandler(this.lSizeP_Click);
            // 
            // bStop
            // 
            this.bStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bStop.ForeColor = System.Drawing.Color.Red;
            this.bStop.Image = ((System.Drawing.Image)(resources.GetObject("bStop.Image")));
            this.bStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(53, 23);
            this.bStop.Text = "STOP";
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 453);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pMap);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "Нет соединения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Resize += new System.EventHandler(this.fMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMap)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdMap;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miParams;
        private System.Windows.Forms.ToolStripMenuItem miModuleSettings;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem miConnections;
        private System.Windows.Forms.ToolStripMenuItem miEditConnections;
        private System.Windows.Forms.ToolStripMenuItem miSetNorth;
        private System.Windows.Forms.ToolStripMenuItem miNewConnection;
        private System.Windows.Forms.ToolStripMenuItem miCalibrate;
        private System.Windows.Forms.PictureBox pMap;
        private System.Windows.Forms.ToolStripMenuItem miClearStops;
        private System.Windows.Forms.ToolStripMenuItem miMaps;
        private System.Windows.Forms.ToolStripMenuItem miMapAdd;
        private System.Windows.Forms.ToolStripMenuItem miMapRemove;
        private System.Windows.Forms.ToolStripStatusLabel slMvt;
        private System.Windows.Forms.ToolStripStatusLabel lAngle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slCalibration;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bSizeM;
        private System.Windows.Forms.ToolStripButton bSizeP;
        private System.Windows.Forms.ToolStripButton bStop;
    }
}

