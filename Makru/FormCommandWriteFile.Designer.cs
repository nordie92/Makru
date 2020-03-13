namespace Makru
{
    partial class FormCommandWriteFile
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
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.rbOverrideFile = new System.Windows.Forms.RadioButton();
            this.rbAppendFile = new System.Windows.Forms.RadioButton();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVariable = new System.Windows.Forms.ComboBox();
            this.btnInsertVariable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datei";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(12, 25);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(226, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(236, 24);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(24, 22);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // rbOverrideFile
            // 
            this.rbOverrideFile.AutoSize = true;
            this.rbOverrideFile.Location = new System.Drawing.Point(12, 57);
            this.rbOverrideFile.Name = "rbOverrideFile";
            this.rbOverrideFile.Size = new System.Drawing.Size(120, 17);
            this.rbOverrideFile.TabIndex = 3;
            this.rbOverrideFile.Text = "Datei überschreiben";
            this.rbOverrideFile.UseVisualStyleBackColor = true;
            // 
            // rbAppendFile
            // 
            this.rbAppendFile.AutoSize = true;
            this.rbAppendFile.Checked = true;
            this.rbAppendFile.Location = new System.Drawing.Point(138, 57);
            this.rbAppendFile.Name = "rbAppendFile";
            this.rbAppendFile.Size = new System.Drawing.Size(125, 17);
            this.rbAppendFile.TabIndex = 4;
            this.rbAppendFile.TabStop = true;
            this.rbAppendFile.Text = "Der Datei hinzufügen";
            this.rbAppendFile.UseVisualStyleBackColor = true;
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(12, 101);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(318, 154);
            this.rtbText.TabIndex = 5;
            this.rtbText.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text";
            // 
            // cbVariable
            // 
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Location = new System.Drawing.Point(12, 281);
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.Size = new System.Drawing.Size(121, 21);
            this.cbVariable.TabIndex = 7;
            // 
            // btnInsertVariable
            // 
            this.btnInsertVariable.Location = new System.Drawing.Point(139, 280);
            this.btnInsertVariable.Name = "btnInsertVariable";
            this.btnInsertVariable.Size = new System.Drawing.Size(75, 23);
            this.btnInsertVariable.TabIndex = 8;
            this.btnInsertVariable.Text = "Einfügen";
            this.btnInsertVariable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Variable in Text einfügen";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Übernehmen";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(96, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormCommandWriteFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 353);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnInsertVariable);
            this.Controls.Add(this.cbVariable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.rbAppendFile);
            this.Controls.Add(this.rbOverrideFile);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCommandWriteFile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Schreibe in Datei";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.RadioButton rbOverrideFile;
        private System.Windows.Forms.RadioButton rbAppendFile;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVariable;
        private System.Windows.Forms.Button btnInsertVariable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}