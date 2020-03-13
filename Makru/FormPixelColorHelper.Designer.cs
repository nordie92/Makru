namespace Makru
{
    partial class FormPixelColorHelper
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.nudPixelX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPixelY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.plColor = new System.Windows.Forms.Panel();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMaxDIfference = new System.Windows.Forms.NumericUpDown();
            this.pbColorDif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDIfference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorDif)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(154, 41);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(387, 279);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.pbImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDown);
            // 
            // nudPixelX
            // 
            this.nudPixelX.Location = new System.Drawing.Point(12, 25);
            this.nudPixelX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPixelX.Name = "nudPixelX";
            this.nudPixelX.Size = new System.Drawing.Size(136, 20);
            this.nudPixelX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pixel X";
            // 
            // nudPixelY
            // 
            this.nudPixelY.Location = new System.Drawing.Point(12, 64);
            this.nudPixelY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPixelY.Name = "nudPixelY";
            this.nudPixelY.Size = new System.Drawing.Size(136, 20);
            this.nudPixelY.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pixel Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Color";
            // 
            // plColor
            // 
            this.plColor.BackColor = System.Drawing.Color.White;
            this.plColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plColor.Location = new System.Drawing.Point(12, 103);
            this.plColor.Name = "plColor";
            this.plColor.Size = new System.Drawing.Size(23, 23);
            this.plColor.TabIndex = 4;
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(41, 103);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(107, 23);
            this.btnPickColor.TabIndex = 5;
            this.btnPickColor.Text = "Farbe wählen";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(12, 189);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(136, 131);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(154, 12);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenImage.TabIndex = 6;
            this.btnOpenImage.Text = "Öffne Bild";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Übernehmen";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(94, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maximale Differenz";
            // 
            // nudMaxDIfference
            // 
            this.nudMaxDIfference.Location = new System.Drawing.Point(12, 145);
            this.nudMaxDIfference.Name = "nudMaxDIfference";
            this.nudMaxDIfference.Size = new System.Drawing.Size(136, 20);
            this.nudMaxDIfference.TabIndex = 9;
            this.nudMaxDIfference.ValueChanged += new System.EventHandler(this.nudMaxDIfference_ValueChanged);
            // 
            // pbColorDif
            // 
            this.pbColorDif.Location = new System.Drawing.Point(12, 164);
            this.pbColorDif.Name = "pbColorDif";
            this.pbColorDif.Size = new System.Drawing.Size(136, 12);
            this.pbColorDif.TabIndex = 10;
            this.pbColorDif.TabStop = false;
            // 
            // FormPixelColorHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 359);
            this.Controls.Add(this.pbColorDif);
            this.Controls.Add(this.nudMaxDIfference);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.btnPickColor);
            this.Controls.Add(this.plColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudPixelY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudPixelX);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.pbImage);
            this.Name = "FormPixelColorHelper";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FormPixelColorHelper";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDIfference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorDif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.NumericUpDown nudPixelX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPixelY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plColor;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMaxDIfference;
        private System.Windows.Forms.PictureBox pbColorDif;
    }
}