namespace Makru
{
    partial class FormCommandInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbSelectMousebutton = new System.Windows.Forms.RadioButton();
            this.rbSelectKeyboardKey = new System.Windows.Forms.RadioButton();
            this.gbMouseButton = new System.Windows.Forms.GroupBox();
            this.cbMouseMode = new System.Windows.Forms.ComboBox();
            this.cbMouseButton = new System.Windows.Forms.ComboBox();
            this.nudMouseY = new System.Windows.Forms.NumericUpDown();
            this.nudMouseX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSelectMouseWheel = new System.Windows.Forms.RadioButton();
            this.gbKeyboardKey = new System.Windows.Forms.GroupBox();
            this.btnSelectKeyboardKey = new System.Windows.Forms.Button();
            this.lbKeyboardKey = new System.Windows.Forms.Label();
            this.cbKeyboardMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbMouseWheel = new System.Windows.Forms.GroupBox();
            this.cbMouseWheelDirection = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCalcel = new System.Windows.Forms.Button();
            this.gbMouseButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbKeyboardKey.SuspendLayout();
            this.gbMouseWheel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // rbSelectMousebutton
            // 
            this.rbSelectMousebutton.AutoSize = true;
            this.rbSelectMousebutton.Checked = true;
            this.rbSelectMousebutton.Location = new System.Drawing.Point(6, 19);
            this.rbSelectMousebutton.Name = "rbSelectMousebutton";
            this.rbSelectMousebutton.Size = new System.Drawing.Size(74, 17);
            this.rbSelectMousebutton.TabIndex = 1;
            this.rbSelectMousebutton.TabStop = true;
            this.rbSelectMousebutton.Text = "Maustaste";
            this.rbSelectMousebutton.UseVisualStyleBackColor = true;
            this.rbSelectMousebutton.CheckedChanged += new System.EventHandler(this.commandKind_CheckedChanged);
            // 
            // rbSelectKeyboardKey
            // 
            this.rbSelectKeyboardKey.AutoSize = true;
            this.rbSelectKeyboardKey.Location = new System.Drawing.Point(158, 19);
            this.rbSelectKeyboardKey.Name = "rbSelectKeyboardKey";
            this.rbSelectKeyboardKey.Size = new System.Drawing.Size(67, 17);
            this.rbSelectKeyboardKey.TabIndex = 2;
            this.rbSelectKeyboardKey.Text = "Tastertur";
            this.rbSelectKeyboardKey.UseVisualStyleBackColor = true;
            this.rbSelectKeyboardKey.CheckedChanged += new System.EventHandler(this.commandKind_CheckedChanged);
            // 
            // gbMouseButton
            // 
            this.gbMouseButton.Controls.Add(this.cbMouseMode);
            this.gbMouseButton.Controls.Add(this.cbMouseButton);
            this.gbMouseButton.Controls.Add(this.nudMouseY);
            this.gbMouseButton.Controls.Add(this.nudMouseX);
            this.gbMouseButton.Controls.Add(this.label2);
            this.gbMouseButton.Controls.Add(this.label4);
            this.gbMouseButton.Controls.Add(this.label3);
            this.gbMouseButton.Controls.Add(this.label1);
            this.gbMouseButton.Location = new System.Drawing.Point(12, 69);
            this.gbMouseButton.Name = "gbMouseButton";
            this.gbMouseButton.Size = new System.Drawing.Size(126, 158);
            this.gbMouseButton.TabIndex = 3;
            this.gbMouseButton.TabStop = false;
            this.gbMouseButton.Text = "Maustaste";
            // 
            // cbMouseMode
            // 
            this.cbMouseMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseMode.FormattingEnabled = true;
            this.cbMouseMode.Items.AddRange(new object[] {
            "Maus drücken",
            "Maus loslassen"});
            this.cbMouseMode.Location = new System.Drawing.Point(6, 72);
            this.cbMouseMode.Name = "cbMouseMode";
            this.cbMouseMode.Size = new System.Drawing.Size(108, 21);
            this.cbMouseMode.TabIndex = 5;
            // 
            // cbMouseButton
            // 
            this.cbMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseButton.FormattingEnabled = true;
            this.cbMouseButton.Items.AddRange(new object[] {
            "Rechtsklick",
            "Linksklick"});
            this.cbMouseButton.Location = new System.Drawing.Point(6, 32);
            this.cbMouseButton.Name = "cbMouseButton";
            this.cbMouseButton.Size = new System.Drawing.Size(108, 21);
            this.cbMouseButton.TabIndex = 5;
            // 
            // nudMouseY
            // 
            this.nudMouseY.Location = new System.Drawing.Point(63, 112);
            this.nudMouseY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMouseY.Name = "nudMouseY";
            this.nudMouseY.Size = new System.Drawing.Size(51, 20);
            this.nudMouseY.TabIndex = 2;
            // 
            // nudMouseX
            // 
            this.nudMouseX.Location = new System.Drawing.Point(6, 112);
            this.nudMouseX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMouseX.Name = "nudMouseX";
            this.nudMouseX.Size = new System.Drawing.Size(51, 20);
            this.nudMouseX.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Art";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Taste";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSelectMouseWheel);
            this.groupBox2.Controls.Add(this.rbSelectMousebutton);
            this.groupBox2.Controls.Add(this.rbSelectKeyboardKey);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 51);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gerät";
            // 
            // rbSelectMouseWheel
            // 
            this.rbSelectMouseWheel.AutoSize = true;
            this.rbSelectMouseWheel.Location = new System.Drawing.Point(86, 19);
            this.rbSelectMouseWheel.Name = "rbSelectMouseWheel";
            this.rbSelectMouseWheel.Size = new System.Drawing.Size(66, 17);
            this.rbSelectMouseWheel.TabIndex = 1;
            this.rbSelectMouseWheel.Text = "Mausrad";
            this.rbSelectMouseWheel.UseVisualStyleBackColor = true;
            this.rbSelectMouseWheel.CheckedChanged += new System.EventHandler(this.commandKind_CheckedChanged);
            // 
            // gbKeyboardKey
            // 
            this.gbKeyboardKey.Controls.Add(this.btnSelectKeyboardKey);
            this.gbKeyboardKey.Controls.Add(this.lbKeyboardKey);
            this.gbKeyboardKey.Controls.Add(this.cbKeyboardMode);
            this.gbKeyboardKey.Controls.Add(this.label6);
            this.gbKeyboardKey.Enabled = false;
            this.gbKeyboardKey.Location = new System.Drawing.Point(276, 69);
            this.gbKeyboardKey.Name = "gbKeyboardKey";
            this.gbKeyboardKey.Size = new System.Drawing.Size(126, 158);
            this.gbKeyboardKey.TabIndex = 3;
            this.gbKeyboardKey.TabStop = false;
            this.gbKeyboardKey.Text = "Tastertur";
            // 
            // btnSelectKeyboardKey
            // 
            this.btnSelectKeyboardKey.Location = new System.Drawing.Point(6, 56);
            this.btnSelectKeyboardKey.Name = "btnSelectKeyboardKey";
            this.btnSelectKeyboardKey.Size = new System.Drawing.Size(108, 37);
            this.btnSelectKeyboardKey.TabIndex = 7;
            this.btnSelectKeyboardKey.Text = "Wähle Taste";
            this.btnSelectKeyboardKey.UseVisualStyleBackColor = true;
            this.btnSelectKeyboardKey.Click += new System.EventHandler(this.btnSelectKeyboardKey_Click);
            // 
            // lbKeyboardKey
            // 
            this.lbKeyboardKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeyboardKey.Location = new System.Drawing.Point(6, 16);
            this.lbKeyboardKey.Name = "lbKeyboardKey";
            this.lbKeyboardKey.Size = new System.Drawing.Size(108, 37);
            this.lbKeyboardKey.TabIndex = 6;
            this.lbKeyboardKey.Text = "Keine Taste";
            this.lbKeyboardKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbKeyboardMode
            // 
            this.cbKeyboardMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeyboardMode.FormattingEnabled = true;
            this.cbKeyboardMode.Items.AddRange(new object[] {
            "Taste drücken",
            "Taste loslassen"});
            this.cbKeyboardMode.Location = new System.Drawing.Point(6, 117);
            this.cbKeyboardMode.Name = "cbKeyboardMode";
            this.cbKeyboardMode.Size = new System.Drawing.Size(108, 21);
            this.cbKeyboardMode.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Art";
            // 
            // gbMouseWheel
            // 
            this.gbMouseWheel.Controls.Add(this.cbMouseWheelDirection);
            this.gbMouseWheel.Controls.Add(this.label8);
            this.gbMouseWheel.Enabled = false;
            this.gbMouseWheel.Location = new System.Drawing.Point(144, 69);
            this.gbMouseWheel.Name = "gbMouseWheel";
            this.gbMouseWheel.Size = new System.Drawing.Size(126, 158);
            this.gbMouseWheel.TabIndex = 3;
            this.gbMouseWheel.TabStop = false;
            this.gbMouseWheel.Text = "Mausrad";
            // 
            // cbMouseWheelDirection
            // 
            this.cbMouseWheelDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseWheelDirection.FormattingEnabled = true;
            this.cbMouseWheelDirection.Items.AddRange(new object[] {
            "Aufwärts",
            "Abwärts"});
            this.cbMouseWheelDirection.Location = new System.Drawing.Point(6, 32);
            this.cbMouseWheelDirection.Name = "cbMouseWheelDirection";
            this.cbMouseWheelDirection.Size = new System.Drawing.Size(108, 21);
            this.cbMouseWheelDirection.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Richtung";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCalcel
            // 
            this.btnCalcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCalcel.Location = new System.Drawing.Point(93, 233);
            this.btnCalcel.Name = "btnCalcel";
            this.btnCalcel.Size = new System.Drawing.Size(75, 23);
            this.btnCalcel.TabIndex = 5;
            this.btnCalcel.Text = "Abbrechen";
            this.btnCalcel.UseVisualStyleBackColor = true;
            // 
            // FormCommandInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 266);
            this.Controls.Add(this.btnCalcel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbKeyboardKey);
            this.Controls.Add(this.gbMouseWheel);
            this.Controls.Add(this.gbMouseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCommandInput";
            this.ShowIcon = false;
            this.Text = "Eingabe";
            this.gbMouseButton.ResumeLayout(false);
            this.gbMouseButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMouseX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbKeyboardKey.ResumeLayout(false);
            this.gbKeyboardKey.PerformLayout();
            this.gbMouseWheel.ResumeLayout(false);
            this.gbMouseWheel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSelectMousebutton;
        private System.Windows.Forms.RadioButton rbSelectKeyboardKey;
        private System.Windows.Forms.GroupBox gbMouseButton;
        private System.Windows.Forms.ComboBox cbMouseMode;
        private System.Windows.Forms.ComboBox cbMouseButton;
        private System.Windows.Forms.NumericUpDown nudMouseY;
        private System.Windows.Forms.NumericUpDown nudMouseX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbKeyboardKey;
        private System.Windows.Forms.ComboBox cbKeyboardMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbKeyboardKey;
        private System.Windows.Forms.Button btnSelectKeyboardKey;
        private System.Windows.Forms.RadioButton rbSelectMouseWheel;
        private System.Windows.Forms.GroupBox gbMouseWheel;
        private System.Windows.Forms.ComboBox cbMouseWheelDirection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCalcel;
    }
}