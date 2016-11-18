﻿namespace EncRotator
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
            this.miConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.miMaps = new System.Windows.Forms.ToolStripMenuItem();
            this.miMapAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miMapRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.miSetNorth = new System.Windows.Forms.ToolStripMenuItem();
            this.miCalibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.miModuleSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pMap = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bSizeM = new System.Windows.Forms.ToolStripButton();
            this.bSizeP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.slMvt = new System.Windows.Forms.ToolStripLabel();
            this.lAngle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bStop = new System.Windows.Forms.ToolStripButton();
            this.ddSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.miConnectionGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.miConnectionGroupsList = new System.Windows.Forms.ToolStripMenuItem();
            this.miRelays = new System.Windows.Forms.ToolStripMenuItem();
            this.miIngnoreEngineOffMovement = new System.Windows.Forms.ToolStripMenuItem();
            this.miExpertSync = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.slCalibration = new System.Windows.Forms.ToolStripLabel();
            this.lCaption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pMap)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // miConnections
            // 
            this.miConnections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewConnection,
            this.miEditConnections});
            this.miConnections.Name = "miConnections";
            this.miConnections.Size = new System.Drawing.Size(221, 22);
            this.miConnections.Text = "Соединения";
            this.miConnections.Click += new System.EventHandler(this.miConnections_Click);
            // 
            // miNewConnection
            // 
            this.miNewConnection.Name = "miNewConnection";
            this.miNewConnection.Size = new System.Drawing.Size(196, 22);
            this.miNewConnection.Text = "Новое";
            this.miNewConnection.Click += new System.EventHandler(this.miNewConnection_Click);
            // 
            // miEditConnections
            // 
            this.miEditConnections.Name = "miEditConnections";
            this.miEditConnections.Size = new System.Drawing.Size(196, 22);
            this.miEditConnections.Text = "Редактировать список";
            this.miEditConnections.Click += new System.EventHandler(this.miEditConnections_Click);
            // 
            // miMaps
            // 
            this.miMaps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMapAdd,
            this.miMapRemove});
            this.miMaps.Name = "miMaps";
            this.miMaps.Size = new System.Drawing.Size(221, 22);
            this.miMaps.Text = "Карты";
            // 
            // miMapAdd
            // 
            this.miMapAdd.Name = "miMapAdd";
            this.miMapAdd.Size = new System.Drawing.Size(126, 22);
            this.miMapAdd.Text = "Добавить";
            this.miMapAdd.Click += new System.EventHandler(this.miMapAdd_Click);
            // 
            // miMapRemove
            // 
            this.miMapRemove.Name = "miMapRemove";
            this.miMapRemove.Size = new System.Drawing.Size(126, 22);
            this.miMapRemove.Text = "Удалить";
            this.miMapRemove.Click += new System.EventHandler(this.miMapRemove_Click);
            // 
            // miSetNorth
            // 
            this.miSetNorth.Name = "miSetNorth";
            this.miSetNorth.Size = new System.Drawing.Size(221, 22);
            this.miSetNorth.Text = "Настройки антенны";
            this.miSetNorth.Visible = false;
            this.miSetNorth.Click += new System.EventHandler(this.miSetNorth_Click);
            // 
            // miCalibrate
            // 
            this.miCalibrate.Name = "miCalibrate";
            this.miCalibrate.Size = new System.Drawing.Size(221, 22);
            this.miCalibrate.Text = "Калибровать";
            this.miCalibrate.Visible = false;
            this.miCalibrate.Click += new System.EventHandler(this.miCalibrate_Click);
            // 
            // miModuleSettings
            // 
            this.miModuleSettings.Name = "miModuleSettings";
            this.miModuleSettings.Size = new System.Drawing.Size(221, 22);
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
            this.pMap.Location = new System.Drawing.Point(0, 59);
            this.pMap.Name = "pMap";
            this.pMap.Size = new System.Drawing.Size(526, 394);
            this.pMap.TabIndex = 16;
            this.pMap.TabStop = false;
            this.pMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pMap_Paint);
            this.pMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pMap_MouseClick);
            this.pMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pMap_MouseMove);
            this.pMap.Resize += new System.EventHandler(this.pMap_Resize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSizeM,
            this.bSizeP,
            this.toolStripSeparator1,
            this.slMvt,
            this.lAngle,
            this.toolStripSeparator2,
            this.bStop,
            this.ddSettings,
            this.toolStripSeparator3,
            this.slCalibration});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 26);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bSizeM
            // 
            this.bSizeM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.bSizeP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bSizeP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSizeP.Image = ((System.Drawing.Image)(resources.GetObject("bSizeP.Image")));
            this.bSizeP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bSizeP.Name = "bSizeP";
            this.bSizeP.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.bSizeP.Size = new System.Drawing.Size(23, 23);
            this.bSizeP.Text = "+";
            this.bSizeP.Click += new System.EventHandler(this.lSizeP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // slMvt
            // 
            this.slMvt.AutoSize = false;
            this.slMvt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.slMvt.Image = ((System.Drawing.Image)(resources.GetObject("slMvt.Image")));
            this.slMvt.ImageTransparentColor = System.Drawing.Color.White;
            this.slMvt.IsLink = true;
            this.slMvt.Name = "slMvt";
            this.slMvt.Size = new System.Drawing.Size(16, 23);
            // 
            // lAngle
            // 
            this.lAngle.AutoSize = false;
            this.lAngle.Name = "lAngle";
            this.lAngle.Size = new System.Drawing.Size(90, 23);
            this.lAngle.Text = "/";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // bStop
            // 
            this.bStop.BackColor = System.Drawing.Color.Red;
            this.bStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bStop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bStop.ForeColor = System.Drawing.Color.White;
            this.bStop.Image = ((System.Drawing.Image)(resources.GetObject("bStop.Image")));
            this.bStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(57, 23);
            this.bStop.Text = " Stop ";
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // ddSettings
            // 
            this.ddSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ddSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConnections,
            this.miConnectionGroups,
            this.miMaps,
            this.miSetNorth,
            this.miCalibrate,
            this.miRelays,
            this.miModuleSettings,
            this.miIngnoreEngineOffMovement,
            this.miExpertSync,
            this.miAbout});
            this.ddSettings.ForeColor = System.Drawing.Color.Transparent;
            this.ddSettings.Image = ((System.Drawing.Image)(resources.GetObject("ddSettings.Image")));
            this.ddSettings.ImageTransparentColor = System.Drawing.Color.Black;
            this.ddSettings.Name = "ddSettings";
            this.ddSettings.Size = new System.Drawing.Size(29, 23);
            this.ddSettings.Text = "Настройки";
            // 
            // miConnectionGroups
            // 
            this.miConnectionGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConnectionGroupsList});
            this.miConnectionGroups.Name = "miConnectionGroups";
            this.miConnectionGroups.Size = new System.Drawing.Size(221, 22);
            this.miConnectionGroups.Text = "Группы соединений";
            // 
            // miConnectionGroupsList
            // 
            this.miConnectionGroupsList.Name = "miConnectionGroupsList";
            this.miConnectionGroupsList.Size = new System.Drawing.Size(196, 22);
            this.miConnectionGroupsList.Text = "Редактировать список";
            this.miConnectionGroupsList.Click += new System.EventHandler(this.miConnectionGroupsList_Click);
            // 
            // miRelays
            // 
            this.miRelays.CheckOnClick = true;
            this.miRelays.Name = "miRelays";
            this.miRelays.Size = new System.Drawing.Size(221, 22);
            this.miRelays.Text = "Управление реле";
            this.miRelays.Visible = false;
            this.miRelays.CheckStateChanged += new System.EventHandler(this.miRelays_CheckStateChanged);
            // 
            // miIngnoreEngineOffMovement
            // 
            this.miIngnoreEngineOffMovement.CheckOnClick = true;
            this.miIngnoreEngineOffMovement.Name = "miIngnoreEngineOffMovement";
            this.miIngnoreEngineOffMovement.Size = new System.Drawing.Size(221, 22);
            this.miIngnoreEngineOffMovement.Text = "Игнорировать движение";
            this.miIngnoreEngineOffMovement.Visible = false;
            this.miIngnoreEngineOffMovement.CheckStateChanged += new System.EventHandler(this.miIngnoreEngineOffMovement_CheckStateChanged);
            // 
            // miExpertSync
            // 
            this.miExpertSync.CheckOnClick = true;
            this.miExpertSync.Name = "miExpertSync";
            this.miExpertSync.Size = new System.Drawing.Size(221, 22);
            this.miExpertSync.Text = "Подключение к ExpertSync";
            this.miExpertSync.Click += new System.EventHandler(this.miExpertSync_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(221, 22);
            this.miAbout.Text = "О программе";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // slCalibration
            // 
            this.slCalibration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slCalibration.ForeColor = System.Drawing.Color.Red;
            this.slCalibration.Name = "slCalibration";
            this.slCalibration.Size = new System.Drawing.Size(105, 23);
            this.slCalibration.Text = "Калибровка";
            this.slCalibration.Visible = false;
            // 
            // lCaption
            // 
            this.lCaption.AutoSize = true;
            this.lCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCaption.ForeColor = System.Drawing.Color.Red;
            this.lCaption.Location = new System.Drawing.Point(4, 27);
            this.lCaption.Name = "lCaption";
            this.lCaption.Size = new System.Drawing.Size(204, 29);
            this.lCaption.TabIndex = 18;
            this.lCaption.Text = "Нет соединения";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 453);
            this.Controls.Add(this.lCaption);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "Нет соединения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.ResizeEnd += new System.EventHandler(this.fMain_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.fMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.fMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pMap)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdMap;
        private System.Windows.Forms.ToolStripMenuItem miModuleSettings;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem miConnections;
        private System.Windows.Forms.ToolStripMenuItem miEditConnections;
        private System.Windows.Forms.ToolStripMenuItem miSetNorth;
        private System.Windows.Forms.ToolStripMenuItem miNewConnection;
        private System.Windows.Forms.ToolStripMenuItem miCalibrate;
        private System.Windows.Forms.PictureBox pMap;
        private System.Windows.Forms.ToolStripMenuItem miMaps;
        private System.Windows.Forms.ToolStripMenuItem miMapAdd;
        private System.Windows.Forms.ToolStripMenuItem miMapRemove;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bSizeM;
        private System.Windows.Forms.ToolStripButton bSizeP;
        private System.Windows.Forms.ToolStripButton bStop;
        private System.Windows.Forms.ToolStripDropDownButton ddSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel slMvt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lAngle;
        private System.Windows.Forms.ToolStripLabel slCalibration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miRelays;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miIngnoreEngineOffMovement;
        private System.Windows.Forms.ToolStripMenuItem miConnectionGroups;
        private System.Windows.Forms.ToolStripMenuItem miConnectionGroupsList;
        private System.Windows.Forms.ToolStripMenuItem miExpertSync;
        private System.Windows.Forms.Label lCaption;
    }
}

