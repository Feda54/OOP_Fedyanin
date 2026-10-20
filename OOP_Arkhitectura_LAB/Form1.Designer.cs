namespace OOP_Arkhitectura_LAB
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.numPower = new System.Windows.Forms.NumericUpDown();
            this.chkIsElectric = new System.Windows.Forms.CheckBox();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstFleet = new System.Windows.Forms.ListBox();
            this.btnCalculateTax = new System.Windows.Forms.Button();
            this.btnSaveStorable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(105, 101);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(121, 21);
            this.cmbVehicleType.TabIndex = 0;
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(289, 83);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(100, 20);
            this.txtMode.TabIndex = 1;
            // 
            // numPower
            // 
            this.numPower.Location = new System.Drawing.Point(413, 82);
            this.numPower.Name = "numPower";
            this.numPower.Size = new System.Drawing.Size(120, 20);
            this.numPower.TabIndex = 2;
            // 
            // chkIsElectric
            // 
            this.chkIsElectric.AutoSize = true;
            this.chkIsElectric.Location = new System.Drawing.Point(587, 85);
            this.chkIsElectric.Name = "chkIsElectric";
            this.chkIsElectric.Size = new System.Drawing.Size(80, 17);
            this.chkIsElectric.TabIndex = 3;
            this.chkIsElectric.Text = "checkBox1";
            this.chkIsElectric.UseVisualStyleBackColor = true;
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(546, 187);
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(120, 20);
            this.numCapacity.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(627, 252);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lstFleet
            // 
            this.lstFleet.FormattingEnabled = true;
            this.lstFleet.Location = new System.Drawing.Point(546, 313);
            this.lstFleet.Name = "lstFleet";
            this.lstFleet.Size = new System.Drawing.Size(120, 95);
            this.lstFleet.TabIndex = 6;
            // 
            // btnCalculateTax
            // 
            this.btnCalculateTax.Location = new System.Drawing.Point(389, 361);
            this.btnCalculateTax.Name = "btnCalculateTax";
            this.btnCalculateTax.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateTax.TabIndex = 7;
            this.btnCalculateTax.Text = "button1";
            this.btnCalculateTax.UseVisualStyleBackColor = true;
            // 
            // btnSaveStorable
            // 
            this.btnSaveStorable.Location = new System.Drawing.Point(242, 345);
            this.btnSaveStorable.Name = "btnSaveStorable";
            this.btnSaveStorable.Size = new System.Drawing.Size(75, 23);
            this.btnSaveStorable.TabIndex = 8;
            this.btnSaveStorable.Text = "button1";
            this.btnSaveStorable.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveStorable);
            this.Controls.Add(this.btnCalculateTax);
            this.Controls.Add(this.lstFleet);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.chkIsElectric);
            this.Controls.Add(this.numPower);
            this.Controls.Add(this.txtMode);
            this.Controls.Add(this.cmbVehicleType);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.NumericUpDown numPower;
        private System.Windows.Forms.CheckBox chkIsElectric;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstFleet;
        private System.Windows.Forms.Button btnCalculateTax;
        private System.Windows.Forms.Button btnSaveStorable;
    }
}

