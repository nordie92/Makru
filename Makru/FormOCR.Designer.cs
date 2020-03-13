namespace Makru
{
    partial class FormOCR
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
            this.nudImageX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudImageY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudImageWidth = new System.Windows.Forms.NumericUpDown();
            this.nudImageHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudImageEditContrast = new System.Windows.Forms.NumericUpDown();
            this.cbImageEditGray = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudImageEditSizeFactor = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.llOCRHelper = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudLetterBorderY = new System.Windows.Forms.NumericUpDown();
            this.nudLetterBorderX = new System.Windows.Forms.NumericUpDown();
            this.nudLetterWidth = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.nudLetterHeight = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbLetterSpacingActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditSizeFactor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // nudImageX
            // 
            this.nudImageX.Location = new System.Drawing.Point(12, 30);
            this.nudImageX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudImageX.Name = "nudImageX";
            this.nudImageX.Size = new System.Drawing.Size(60, 20);
            this.nudImageX.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X:";
            // 
            // nudImageY
            // 
            this.nudImageY.Location = new System.Drawing.Point(78, 30);
            this.nudImageY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudImageY.Name = "nudImageY";
            this.nudImageY.Size = new System.Drawing.Size(60, 20);
            this.nudImageY.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y:";
            // 
            // nudImageWidth
            // 
            this.nudImageWidth.Location = new System.Drawing.Point(12, 69);
            this.nudImageWidth.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudImageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageWidth.Name = "nudImageWidth";
            this.nudImageWidth.Size = new System.Drawing.Size(60, 20);
            this.nudImageWidth.TabIndex = 0;
            this.nudImageWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudImageHeight
            // 
            this.nudImageHeight.Location = new System.Drawing.Point(78, 69);
            this.nudImageHeight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudImageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageHeight.Name = "nudImageHeight";
            this.nudImageHeight.Size = new System.Drawing.Size(60, 20);
            this.nudImageHeight.TabIndex = 0;
            this.nudImageHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Breite:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Höhe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Kontrast:";
            // 
            // nudImageEditContrast
            // 
            this.nudImageEditContrast.Location = new System.Drawing.Point(12, 53);
            this.nudImageEditContrast.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudImageEditContrast.Name = "nudImageEditContrast";
            this.nudImageEditContrast.Size = new System.Drawing.Size(126, 20);
            this.nudImageEditContrast.TabIndex = 4;
            // 
            // cbImageEditGray
            // 
            this.cbImageEditGray.AutoSize = true;
            this.cbImageEditGray.Location = new System.Drawing.Point(12, 19);
            this.cbImageEditGray.Name = "cbImageEditGray";
            this.cbImageEditGray.Size = new System.Drawing.Size(78, 17);
            this.cbImageEditGray.TabIndex = 6;
            this.cbImageEditGray.Text = "Graustufen";
            this.cbImageEditGray.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Vergrößerungsfaktor:";
            // 
            // nudImageEditSizeFactor
            // 
            this.nudImageEditSizeFactor.Location = new System.Drawing.Point(12, 90);
            this.nudImageEditSizeFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageEditSizeFactor.Name = "nudImageEditSizeFactor";
            this.nudImageEditSizeFactor.Size = new System.Drawing.Size(126, 20);
            this.nudImageEditSizeFactor.TabIndex = 4;
            this.nudImageEditSizeFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudImageX);
            this.groupBox1.Controls.Add(this.nudImageY);
            this.groupBox1.Controls.Add(this.nudImageWidth);
            this.groupBox1.Controls.Add(this.nudImageHeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Textpassage ausschneiden";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbImageEditGray);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudImageEditContrast);
            this.groupBox2.Controls.Add(this.nudImageEditSizeFactor);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(169, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 149);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bild bearbeiten";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // llOCRHelper
            // 
            this.llOCRHelper.AutoSize = true;
            this.llOCRHelper.Location = new System.Drawing.Point(12, 204);
            this.llOCRHelper.Name = "llOCRHelper";
            this.llOCRHelper.Size = new System.Drawing.Size(189, 13);
            this.llOCRHelper.TabIndex = 15;
            this.llOCRHelper.TabStop = true;
            this.llOCRHelper.Text = "Werte mithilfe von Beispielbild ermitteln";
            this.llOCRHelper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOCRHelper_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "Dieser Befehl kreiert ein Screenshoot und versucht den Text aus diesem Screenshoo" +
    "t auszulesen";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbLetterSpacingActive);
            this.groupBox3.Controls.Add(this.nudLetterBorderY);
            this.groupBox3.Controls.Add(this.nudLetterBorderX);
            this.groupBox3.Controls.Add(this.nudLetterWidth);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.nudLetterHeight);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(326, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(151, 149);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buchstaben separieren";
            // 
            // nudLetterBorderY
            // 
            this.nudLetterBorderY.Location = new System.Drawing.Point(78, 112);
            this.nudLetterBorderY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLetterBorderY.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudLetterBorderY.Name = "nudLetterBorderY";
            this.nudLetterBorderY.Size = new System.Drawing.Size(60, 20);
            this.nudLetterBorderY.TabIndex = 0;
            // 
            // nudLetterBorderX
            // 
            this.nudLetterBorderX.Location = new System.Drawing.Point(12, 112);
            this.nudLetterBorderX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLetterBorderX.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudLetterBorderX.Name = "nudLetterBorderX";
            this.nudLetterBorderX.Size = new System.Drawing.Size(60, 20);
            this.nudLetterBorderX.TabIndex = 0;
            // 
            // nudLetterWidth
            // 
            this.nudLetterWidth.Location = new System.Drawing.Point(12, 75);
            this.nudLetterWidth.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLetterWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLetterWidth.Name = "nudLetterWidth";
            this.nudLetterWidth.Size = new System.Drawing.Size(60, 20);
            this.nudLetterWidth.TabIndex = 0;
            this.nudLetterWidth.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Höhe:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(78, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Rand Y:";
            // 
            // nudLetterHeight
            // 
            this.nudLetterHeight.Location = new System.Drawing.Point(78, 75);
            this.nudLetterHeight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLetterHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLetterHeight.Name = "nudLetterHeight";
            this.nudLetterHeight.Size = new System.Drawing.Size(60, 20);
            this.nudLetterHeight.TabIndex = 0;
            this.nudLetterHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 98);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Rand X:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Breite:";
            // 
            // cbLetterSpacingActive
            // 
            this.cbLetterSpacingActive.AutoSize = true;
            this.cbLetterSpacingActive.Location = new System.Drawing.Point(12, 19);
            this.cbLetterSpacingActive.Name = "cbLetterSpacingActive";
            this.cbLetterSpacingActive.Size = new System.Drawing.Size(73, 17);
            this.cbLetterSpacingActive.TabIndex = 6;
            this.cbLetterSpacingActive.Text = "Aktivieren";
            this.cbLetterSpacingActive.UseVisualStyleBackColor = true;
            // 
            // FormOCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 252);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llOCRHelper);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOCR";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bild zu Text";
            ((System.ComponentModel.ISupportInitialize)(this.nudImageX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditSizeFactor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudImageX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudImageY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudImageWidth;
        private System.Windows.Forms.NumericUpDown nudImageHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudImageEditContrast;
        private System.Windows.Forms.CheckBox cbImageEditGray;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudImageEditSizeFactor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llOCRHelper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudLetterBorderY;
        private System.Windows.Forms.NumericUpDown nudLetterBorderX;
        private System.Windows.Forms.NumericUpDown nudLetterWidth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nudLetterHeight;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbLetterSpacingActive;
    }
}