namespace EncRotator
{
    partial class FSetNorth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSetNorth));
            this.bRotate0 = new System.Windows.Forms.Button();
            this.bRotate1 = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bStop0 = new System.Windows.Forms.Button();
            this.bStop1 = new System.Windows.Forms.Button();
            this.bNorth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bRotate0
            // 
            this.bRotate0.Location = new System.Drawing.Point(9, 14);
            this.bRotate0.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bRotate0.Name = "bRotate0";
            this.bRotate0.Size = new System.Drawing.Size(150, 35);
            this.bRotate0.TabIndex = 0;
            this.bRotate0.Text = "По час.";
            this.bRotate0.UseVisualStyleBackColor = true;
            this.bRotate0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bRotate0_MouseDown);
            this.bRotate0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bRotate_MouseUp);
            // 
            // bRotate1
            // 
            this.bRotate1.Location = new System.Drawing.Point(164, 14);
            this.bRotate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bRotate1.Name = "bRotate1";
            this.bRotate1.Size = new System.Drawing.Size(150, 35);
            this.bRotate1.TabIndex = 1;
            this.bRotate1.Text = "Против час.";
            this.bRotate1.UseVisualStyleBackColor = true;
            this.bRotate1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bRotate1_MouseDown);
            this.bRotate1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bRotate_MouseUp);
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(214, 137);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(82, 32);
            this.bOK.TabIndex = 2;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(301, 137);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(82, 32);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bStop0
            // 
            this.bStop0.Location = new System.Drawing.Point(9, 67);
            this.bStop0.Name = "bStop0";
            this.bStop0.Size = new System.Drawing.Size(120, 55);
            this.bStop0.TabIndex = 4;
            this.bStop0.Text = "Стоп по час.";
            this.bStop0.UseVisualStyleBackColor = true;
            this.bStop0.Click += new System.EventHandler(this.bStop0_Click);
            // 
            // bStop1
            // 
            this.bStop1.Location = new System.Drawing.Point(258, 67);
            this.bStop1.Name = "bStop1";
            this.bStop1.Size = new System.Drawing.Size(120, 55);
            this.bStop1.TabIndex = 5;
            this.bStop1.Text = "Стоп пр. час.";
            this.bStop1.UseVisualStyleBackColor = true;
            this.bStop1.Click += new System.EventHandler(this.bStop1_Click);
            // 
            // bNorth
            // 
            this.bNorth.Location = new System.Drawing.Point(133, 67);
            this.bNorth.Name = "bNorth";
            this.bNorth.Size = new System.Drawing.Size(120, 55);
            this.bNorth.TabIndex = 6;
            this.bNorth.Text = "Север";
            this.bNorth.UseVisualStyleBackColor = true;
            this.bNorth.Click += new System.EventHandler(this.bNorth_Click);
            // 
            // FSetNorth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 172);
            this.Controls.Add(this.bNorth);
            this.Controls.Add(this.bStop1);
            this.Controls.Add(this.bStop0);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bRotate1);
            this.Controls.Add(this.bRotate0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FSetNorth";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Калибровка";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRotate0;
        private System.Windows.Forms.Button bRotate1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bStop0;
        private System.Windows.Forms.Button bStop1;
        private System.Windows.Forms.Button bNorth;
    }
}