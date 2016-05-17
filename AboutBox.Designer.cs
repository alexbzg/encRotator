namespace EncRotator
{
    partial class AboutBox
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
            this.ll73 = new System.Windows.Forms.LinkLabel();
            this.lName = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ll73
            // 
            this.ll73.AutoSize = true;
            this.ll73.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ll73.Location = new System.Drawing.Point(12, 59);
            this.ll73.Name = "ll73";
            this.ll73.Size = new System.Drawing.Size(82, 20);
            this.ll73.TabIndex = 0;
            this.ll73.TabStop = true;
            this.ll73.Text = "www.73.ru";
            this.ll73.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll73_LinkClicked);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(12, 9);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(204, 20);
            this.lName.TabIndex = 1;
            this.lName.Text = "R7AB Antenna Net Rotator";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lVersion.Location = new System.Drawing.Point(12, 33);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(111, 20);
            this.lVersion.TabIndex = 2;
            this.lVersion.Text = "version 1.0.0.1";
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOK.Location = new System.Drawing.Point(172, 72);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 32);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 115);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.ll73);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ll73;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Button bOK;
    }
}