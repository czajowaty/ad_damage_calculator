namespace AzureDreamsDamageCalculator
{
    partial class AddSpellDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spellComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minChargesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.maxChargesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minChargesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // spellComboBox
            // 
            this.spellComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spellComboBox.FormattingEnabled = true;
            this.spellComboBox.Location = new System.Drawing.Point(51, 12);
            this.spellComboBox.Name = "spellComboBox";
            this.spellComboBox.Size = new System.Drawing.Size(114, 21);
            this.spellComboBox.TabIndex = 0;
            this.spellComboBox.SelectedIndexChanged += new System.EventHandler(this.spellComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spell:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min. charges:";
            // 
            // minChargesNumericUpDown
            // 
            this.minChargesNumericUpDown.Location = new System.Drawing.Point(89, 39);
            this.minChargesNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.minChargesNumericUpDown.Name = "minChargesNumericUpDown";
            this.minChargesNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.minChargesNumericUpDown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max. charges:";
            // 
            // maxChargesNumericUpDown
            // 
            this.maxChargesNumericUpDown.Location = new System.Drawing.Point(89, 65);
            this.maxChargesNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.maxChargesNumericUpDown.Name = "maxChargesNumericUpDown";
            this.maxChargesNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.maxChargesNumericUpDown.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 100);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(58, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(90, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddSpellDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(177, 134);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.maxChargesNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minChargesNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spellComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSpellDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add spell";
            ((System.ComponentModel.ISupportInitialize)(this.minChargesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox spellComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minChargesNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxChargesNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}