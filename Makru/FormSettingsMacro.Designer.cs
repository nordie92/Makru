namespace Makru
{
    partial class FormSettingsMacro
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nudMouseInterpolationSteps = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbRelativeMouseMove = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbMouseMoveInterpolation = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nudMouseMoveClickDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbWaitCompension = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseInterpolationSteps)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseMoveClickDelay)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Übernehmen";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 201);
            this.panel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.nudMouseInterpolationSteps);
            this.panel5.Location = new System.Drawing.Point(167, 72);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(136, 37);
            this.panel5.TabIndex = 7;
            // 
            // nudMouseInterpolationSteps
            // 
            this.nudMouseInterpolationSteps.Location = new System.Drawing.Point(6, 8);
            this.nudMouseInterpolationSteps.Name = "nudMouseInterpolationSteps";
            this.nudMouseInterpolationSteps.Size = new System.Drawing.Size(120, 20);
            this.nudMouseInterpolationSteps.TabIndex = 1;
            this.nudMouseInterpolationSteps.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbRelativeMouseMove);
            this.panel2.Location = new System.Drawing.Point(167, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(136, 37);
            this.panel2.TabIndex = 7;
            // 
            // cbRelativeMouseMove
            // 
            this.cbRelativeMouseMove.AutoSize = true;
            this.cbRelativeMouseMove.Location = new System.Drawing.Point(6, 11);
            this.cbRelativeMouseMove.Name = "cbRelativeMouseMove";
            this.cbRelativeMouseMove.Size = new System.Drawing.Size(15, 14);
            this.cbRelativeMouseMove.TabIndex = 0;
            this.cbRelativeMouseMove.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cbMouseMoveInterpolation);
            this.panel4.Location = new System.Drawing.Point(167, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(136, 37);
            this.panel4.TabIndex = 7;
            // 
            // cbMouseMoveInterpolation
            // 
            this.cbMouseMoveInterpolation.AutoSize = true;
            this.cbMouseMoveInterpolation.Location = new System.Drawing.Point(6, 11);
            this.cbMouseMoveInterpolation.Name = "cbMouseMoveInterpolation";
            this.cbMouseMoveInterpolation.Size = new System.Drawing.Size(15, 14);
            this.cbMouseMoveInterpolation.TabIndex = 0;
            this.cbMouseMoveInterpolation.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(0, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Schritte zwischen den Mausbewegungen (in ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mauspositionen relativ ausführen (Gamemode)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(0, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mausbewegung zwischen zwei punkten interpolieren";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.nudMouseMoveClickDelay);
            this.panel3.Location = new System.Drawing.Point(167, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 37);
            this.panel3.TabIndex = 5;
            // 
            // nudMouseMoveClickDelay
            // 
            this.nudMouseMoveClickDelay.Location = new System.Drawing.Point(6, 8);
            this.nudMouseMoveClickDelay.Name = "nudMouseMoveClickDelay";
            this.nudMouseMoveClickDelay.Size = new System.Drawing.Size(120, 20);
            this.nudMouseMoveClickDelay.TabIndex = 1;
            this.nudMouseMoveClickDelay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pause zwischen Maus bewegen und Maus drücken/loslassen (ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(0, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 57);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mit \"Warte-Befehl\" die Verzögerungs des verhergehenden Befehls ausgleichen";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cbWaitCompension);
            this.panel6.Location = new System.Drawing.Point(167, 144);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(136, 57);
            this.panel6.TabIndex = 7;
            // 
            // cbWaitCompension
            // 
            this.cbWaitCompension.AutoSize = true;
            this.cbWaitCompension.Location = new System.Drawing.Point(6, 20);
            this.cbWaitCompension.Name = "cbWaitCompension";
            this.cbWaitCompension.Size = new System.Drawing.Size(15, 14);
            this.cbWaitCompension.TabIndex = 0;
            this.cbWaitCompension.UseVisualStyleBackColor = true;
            // 
            // FormSettingsMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 254);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingsMacro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Makro Einstellungen";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseInterpolationSteps)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseMoveClickDelay)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nudMouseInterpolationSteps;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cbMouseMoveInterpolation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nudMouseMoveClickDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbRelativeMouseMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox cbWaitCompension;
        private System.Windows.Forms.Label label5;
    }
}