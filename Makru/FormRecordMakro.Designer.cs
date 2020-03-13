namespace Makru
{
    partial class FormRecordMakro
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
            this.btnRecord = new System.Windows.Forms.Button();
            this.cbMouseMoveRecord = new System.Windows.Forms.CheckBox();
            this.nudMouseMoveInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseMoveInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(12, 87);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(125, 37);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Aufnahme starten";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // cbMouseMoveRecord
            // 
            this.cbMouseMoveRecord.Location = new System.Drawing.Point(12, 12);
            this.cbMouseMoveRecord.Name = "cbMouseMoveRecord";
            this.cbMouseMoveRecord.Size = new System.Drawing.Size(125, 30);
            this.cbMouseMoveRecord.TabIndex = 2;
            this.cbMouseMoveRecord.Text = "Mausbewegungen aufzeichnen";
            this.cbMouseMoveRecord.UseVisualStyleBackColor = true;
            this.cbMouseMoveRecord.CheckedChanged += new System.EventHandler(this.cbMouseMoveRecord_CheckedChanged);
            // 
            // nud
            // 
            this.nudMouseMoveInterval.Enabled = false;
            this.nudMouseMoveInterval.Location = new System.Drawing.Point(12, 61);
            this.nudMouseMoveInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMouseMoveInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMouseMoveInterval.Name = "nud";
            this.nudMouseMoveInterval.Size = new System.Drawing.Size(125, 20);
            this.nudMouseMoveInterval.TabIndex = 3;
            this.nudMouseMoveInterval.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mausbewegungs interval";
            // 
            // FormRecordMakro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 133);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudMouseMoveInterval);
            this.Controls.Add(this.cbMouseMoveRecord);
            this.Controls.Add(this.btnRecord);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRecordMakro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aufnahme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRecordMakro_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseMoveInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.CheckBox cbMouseMoveRecord;
        private System.Windows.Forms.NumericUpDown nudMouseMoveInterval;
        private System.Windows.Forms.Label label2;
    }
}