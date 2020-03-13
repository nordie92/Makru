namespace Makru
{
    partial class FormOCRHelper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOCRHelper));
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudImageEditContrast = new System.Windows.Forms.NumericUpDown();
            this.nudImageEditSizeFactor = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudImageX = new System.Windows.Forms.NumericUpDown();
            this.nudImageY = new System.Windows.Forms.NumericUpDown();
            this.nudImageWidth = new System.Windows.Forms.NumericUpDown();
            this.nudImageHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbText = new System.Windows.Forms.PictureBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbLettersActive = new System.Windows.Forms.RadioButton();
            this.rbLettersDeavtive = new System.Windows.Forms.RadioButton();
            this.rbLettersShowLines = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.nudLetterBorderY = new System.Windows.Forms.NumericUpDown();
            this.nudLetterBorderX = new System.Windows.Forms.NumericUpDown();
            this.nudLetterWidth = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.nudLetterHeight = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbDetectedText = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerRenderTextImage = new System.Windows.Forms.Timer(this.components);
            this.timerShowLetters = new System.Windows.Forms.Timer(this.components);
            this.cbImageEditGray2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditSizeFactor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbText)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterHeight)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbOriginal
            // 
            this.pbOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOriginal.Location = new System.Drawing.Point(0, 0);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(597, 425);
            this.pbOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOriginal.TabIndex = 0;
            this.pbOriginal.TabStop = false;
            this.pbOriginal.Paint += new System.Windows.Forms.PaintEventHandler(this.pbOriginal_Paint);
            this.pbOriginal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbOriginal_MouseDown);
            this.pbOriginal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbOriginal_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbImageEditGray2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudImageEditContrast);
            this.groupBox2.Controls.Add(this.nudImageEditSizeFactor);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 120);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bild bearbeiten";
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
            this.nudImageEditContrast.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudImageEditContrast.ValueChanged += new System.EventHandler(this.pbEditedChanged);
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
            10,
            0,
            0,
            0});
            this.nudImageEditSizeFactor.ValueChanged += new System.EventHandler(this.pbEditedChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 96);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Textpassage ausschneiden";
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
            this.nudImageX.ValueChanged += new System.EventHandler(this.PrintImage);
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
            this.nudImageY.ValueChanged += new System.EventHandler(this.PrintImage);
            // 
            // nudImageWidth
            // 
            this.nudImageWidth.Location = new System.Drawing.Point(12, 67);
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
            21,
            0,
            0,
            0});
            this.nudImageWidth.ValueChanged += new System.EventHandler(this.PrintImage);
            // 
            // nudImageHeight
            // 
            this.nudImageHeight.Location = new System.Drawing.Point(78, 67);
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
            8,
            0,
            0,
            0});
            this.nudImageHeight.ValueChanged += new System.EventHandler(this.PrintImage);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Breite:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Höhe:";
            // 
            // pbText
            // 
            this.pbText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbText.Location = new System.Drawing.Point(793, 78);
            this.pbText.Name = "pbText";
            this.pbText.Size = new System.Drawing.Size(231, 236);
            this.pbText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbText.TabIndex = 0;
            this.pbText.TabStop = false;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(189, 55);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenImage.TabIndex = 11;
            this.btnOpenImage.Text = "Öffne Bild";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1012, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(790, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Bildausschnitt";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbLettersActive);
            this.groupBox3.Controls.Add(this.rbLettersDeavtive);
            this.groupBox3.Controls.Add(this.rbLettersShowLines);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.nudLetterBorderY);
            this.groupBox3.Controls.Add(this.nudLetterBorderX);
            this.groupBox3.Controls.Add(this.nudLetterWidth);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.nudLetterHeight);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 221);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buchstaben separieren";
            // 
            // rbLettersActive
            // 
            this.rbLettersActive.AutoSize = true;
            this.rbLettersActive.Location = new System.Drawing.Point(12, 114);
            this.rbLettersActive.Name = "rbLettersActive";
            this.rbLettersActive.Size = new System.Drawing.Size(72, 17);
            this.rbLettersActive.TabIndex = 8;
            this.rbLettersActive.Text = "Aktivieren";
            this.rbLettersActive.UseVisualStyleBackColor = true;
            this.rbLettersActive.CheckedChanged += new System.EventHandler(this.cbImageEditGray);
            // 
            // rbLettersDeavtive
            // 
            this.rbLettersDeavtive.AutoSize = true;
            this.rbLettersDeavtive.Checked = true;
            this.rbLettersDeavtive.Location = new System.Drawing.Point(12, 78);
            this.rbLettersDeavtive.Name = "rbLettersDeavtive";
            this.rbLettersDeavtive.Size = new System.Drawing.Size(85, 17);
            this.rbLettersDeavtive.TabIndex = 8;
            this.rbLettersDeavtive.TabStop = true;
            this.rbLettersDeavtive.Text = "Deaktivieren";
            this.rbLettersDeavtive.UseVisualStyleBackColor = true;
            this.rbLettersDeavtive.CheckedChanged += new System.EventHandler(this.cbImageEditGray);
            // 
            // rbLettersShowLines
            // 
            this.rbLettersShowLines.AutoSize = true;
            this.rbLettersShowLines.Location = new System.Drawing.Point(12, 96);
            this.rbLettersShowLines.Name = "rbLettersShowLines";
            this.rbLettersShowLines.Size = new System.Drawing.Size(99, 17);
            this.rbLettersShowLines.TabIndex = 8;
            this.rbLettersShowLines.Text = "Zeige Hilfslinien";
            this.rbLettersShowLines.UseVisualStyleBackColor = true;
            this.rbLettersShowLines.CheckedChanged += new System.EventHandler(this.cbImageEditGray);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(9, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 53);
            this.label9.TabIndex = 7;
            this.label9.Text = "Manche Schriftarten erfordern eine Separierung der einzelnen Buchstaben. (Nur bei" +
    " Monospace-Schriftart möglich)";
            // 
            // nudLetterBorderY
            // 
            this.nudLetterBorderY.Location = new System.Drawing.Point(78, 188);
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
            this.nudLetterBorderY.ValueChanged += new System.EventHandler(this.pbEditedChanged);
            // 
            // nudLetterBorderX
            // 
            this.nudLetterBorderX.Location = new System.Drawing.Point(12, 188);
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
            this.nudLetterBorderX.ValueChanged += new System.EventHandler(this.pbEditedChanged);
            // 
            // nudLetterWidth
            // 
            this.nudLetterWidth.Location = new System.Drawing.Point(12, 151);
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
            this.nudLetterWidth.ValueChanged += new System.EventHandler(this.pbEditedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Höhe:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(78, 174);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Rand Y:";
            // 
            // nudLetterHeight
            // 
            this.nudLetterHeight.Location = new System.Drawing.Point(78, 151);
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
            this.nudLetterHeight.ValueChanged += new System.EventHandler(this.pbEditedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 174);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Rand X:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Breite:";
            // 
            // lbDetectedText
            // 
            this.lbDetectedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDetectedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetectedText.Location = new System.Drawing.Point(793, 338);
            this.lbDetectedText.Name = "lbDetectedText";
            this.lbDetectedText.Size = new System.Drawing.Size(231, 165);
            this.lbDetectedText.TabIndex = 14;
            this.lbDetectedText.Text = "Kein Text erkannt";
            this.lbDetectedText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(790, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Erkannter Text";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Übernehmen";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 513);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbOriginal);
            this.panel1.Location = new System.Drawing.Point(190, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 425);
            this.panel1.TabIndex = 16;
            // 
            // timerRenderTextImage
            // 
            this.timerRenderTextImage.Enabled = true;
            this.timerRenderTextImage.Interval = 1000;
            this.timerRenderTextImage.Tick += new System.EventHandler(this.timerRenderTextImage_Tick);
            // 
            // timerShowLetters
            // 
            this.timerShowLetters.Enabled = true;
            this.timerShowLetters.Interval = 500;
            // 
            // cbImageEditGray2
            // 
            this.cbImageEditGray2.AutoSize = true;
            this.cbImageEditGray2.Checked = true;
            this.cbImageEditGray2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbImageEditGray2.Location = new System.Drawing.Point(12, 19);
            this.cbImageEditGray2.Name = "cbImageEditGray2";
            this.cbImageEditGray2.Size = new System.Drawing.Size(78, 17);
            this.cbImageEditGray2.TabIndex = 5;
            this.cbImageEditGray2.Text = "Graustufen";
            this.cbImageEditGray2.UseVisualStyleBackColor = true;
            this.cbImageEditGray2.CheckedChanged += new System.EventHandler(this.cbImageEditGray2_CheckedChanged);
            // 
            // FormOCRHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbDetectedText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbText);
            this.Name = "FormOCRHelper";
            this.ShowIcon = false;
            this.Text = "Bilderkennung - Einrichtunggsassistent";
            this.Load += new System.EventHandler(this.FormOCRHelper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageEditSizeFactor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbText)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterBorderX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLetterHeight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudImageEditContrast;
        private System.Windows.Forms.NumericUpDown nudImageEditSizeFactor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudImageX;
        private System.Windows.Forms.NumericUpDown nudImageY;
        private System.Windows.Forms.NumericUpDown nudImageWidth;
        private System.Windows.Forms.NumericUpDown nudImageHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbText;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudLetterWidth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudLetterHeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbDetectedText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudLetterBorderX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudLetterBorderY;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerRenderTextImage;
        private System.Windows.Forms.Timer timerShowLetters;
        private System.Windows.Forms.RadioButton rbLettersActive;
        private System.Windows.Forms.RadioButton rbLettersDeavtive;
        private System.Windows.Forms.RadioButton rbLettersShowLines;
        private System.Windows.Forms.CheckBox cbImageEditGray2;
    }
}