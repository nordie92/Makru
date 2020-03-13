namespace Makru
{
    partial class FormMacro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMacro));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadJSON = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLog = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMakros = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewMacro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewActivator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewActivatorShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewActivatorTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewWait = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewInput = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewComandCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewCommandReplayMacro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewSetVariable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewWriteFIle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiReplayMacro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStopReplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecordMacro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tvMakros = new Makru.Macros();
            this.msMain.SuspendLayout();
            this.cmsMakros.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.tsmiLog,
            this.einstellungenToolStripMenuItem,
            this.testToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(421, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSave,
            this.tsmiLoadJSON});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(126, 22);
            this.tsmiSave.Text = "Speichern";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiLoadJSON
            // 
            this.tsmiLoadJSON.Name = "tsmiLoadJSON";
            this.tsmiLoadJSON.Size = new System.Drawing.Size(126, 22);
            this.tsmiLoadJSON.Text = "Öffnen";
            this.tsmiLoadJSON.Click += new System.EventHandler(this.tsmiLoadJSON_Click);
            // 
            // tsmiLog
            // 
            this.tsmiLog.Name = "tsmiLog";
            this.tsmiLog.Size = new System.Drawing.Size(39, 20);
            this.tsmiLog.Text = "Log";
            this.tsmiLog.Click += new System.EventHandler(this.tsmiLog_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // cmsMakros
            // 
            this.cmsMakros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiNewActivator,
            this.tsmiNewCondition,
            this.tsmiNewCommand,
            this.toolStripSeparator1,
            this.tsmiRename,
            this.tsmiRemove,
            this.toolStripSeparator2,
            this.tsmiReplayMacro,
            this.tsmiStopReplay,
            this.tsmiRecordMacro,
            this.toolStripSeparator3,
            this.tsmiSettings});
            this.cmsMakros.Name = "cmsMakros";
            this.cmsMakros.Size = new System.Drawing.Size(173, 242);
            // 
            // tsmiNew
            // 
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewMacro,
            this.tsmiNewFolder});
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(172, 22);
            this.tsmiNew.Text = "Neu";
            // 
            // tsmiNewMacro
            // 
            this.tsmiNewMacro.Image = global::Makru.Properties.Resources.icon_makro;
            this.tsmiNewMacro.Name = "tsmiNewMacro";
            this.tsmiNewMacro.Size = new System.Drawing.Size(111, 22);
            this.tsmiNewMacro.Text = "Makro";
            this.tsmiNewMacro.Click += new System.EventHandler(this.tsmiNewMacro_Click);
            // 
            // tsmiNewFolder
            // 
            this.tsmiNewFolder.Image = global::Makru.Properties.Resources.icon_folder;
            this.tsmiNewFolder.Name = "tsmiNewFolder";
            this.tsmiNewFolder.Size = new System.Drawing.Size(111, 22);
            this.tsmiNewFolder.Text = "Ordner";
            this.tsmiNewFolder.Click += new System.EventHandler(this.tsmiNewFolder_Click);
            // 
            // tsmiNewActivator
            // 
            this.tsmiNewActivator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewActivatorShortcut,
            this.tsmiNewActivatorTime});
            this.tsmiNewActivator.Image = global::Makru.Properties.Resources.icon_aktivate;
            this.tsmiNewActivator.Name = "tsmiNewActivator";
            this.tsmiNewActivator.Size = new System.Drawing.Size(172, 22);
            this.tsmiNewActivator.Text = "Neuer Aktivierung";
            // 
            // tsmiNewActivatorShortcut
            // 
            this.tsmiNewActivatorShortcut.Image = global::Makru.Properties.Resources.icon_key;
            this.tsmiNewActivatorShortcut.Name = "tsmiNewActivatorShortcut";
            this.tsmiNewActivatorShortcut.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewActivatorShortcut.Text = "Shortcut";
            this.tsmiNewActivatorShortcut.Click += new System.EventHandler(this.tsmiNewActivatorShortcut_Click_1);
            // 
            // tsmiNewActivatorTime
            // 
            this.tsmiNewActivatorTime.Image = global::Makru.Properties.Resources.icon_clock;
            this.tsmiNewActivatorTime.Name = "tsmiNewActivatorTime";
            this.tsmiNewActivatorTime.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewActivatorTime.Text = "Zeit";
            this.tsmiNewActivatorTime.Click += new System.EventHandler(this.tsmiNewActivatorTime_Click);
            // 
            // tsmiNewCondition
            // 
            this.tsmiNewCondition.Image = global::Makru.Properties.Resources.icon_condition;
            this.tsmiNewCondition.Name = "tsmiNewCondition";
            this.tsmiNewCondition.Size = new System.Drawing.Size(172, 22);
            this.tsmiNewCondition.Text = "Neue Bedingung";
            this.tsmiNewCondition.Click += new System.EventHandler(this.tsmiNewCondition_Click);
            // 
            // tsmiNewCommand
            // 
            this.tsmiNewCommand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewWait,
            this.tsmiNewInput,
            this.tsmiNewComandCondition,
            this.tsmiNewCommandReplayMacro,
            this.tsmiNewSetVariable,
            this.tsmiNewWriteFIle});
            this.tsmiNewCommand.Image = global::Makru.Properties.Resources.icon_command;
            this.tsmiNewCommand.Name = "tsmiNewCommand";
            this.tsmiNewCommand.Size = new System.Drawing.Size(172, 22);
            this.tsmiNewCommand.Text = "Neuer Befehl";
            // 
            // tsmiNewWait
            // 
            this.tsmiNewWait.Image = global::Makru.Properties.Resources.icon_wait;
            this.tsmiNewWait.Name = "tsmiNewWait";
            this.tsmiNewWait.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewWait.Text = "Warte";
            this.tsmiNewWait.Click += new System.EventHandler(this.tsmiNewWait_Click);
            // 
            // tsmiNewInput
            // 
            this.tsmiNewInput.Image = global::Makru.Properties.Resources.icon_key;
            this.tsmiNewInput.Name = "tsmiNewInput";
            this.tsmiNewInput.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewInput.Text = "Eingabe";
            this.tsmiNewInput.Click += new System.EventHandler(this.tsmiNewInput_Click);
            // 
            // tsmiNewComandCondition
            // 
            this.tsmiNewComandCondition.Image = global::Makru.Properties.Resources.icon_command;
            this.tsmiNewComandCondition.Name = "tsmiNewComandCondition";
            this.tsmiNewComandCondition.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewComandCondition.Text = "Wenn...Dann...Sonst";
            this.tsmiNewComandCondition.Click += new System.EventHandler(this.tsmiNewComandCondition_Click);
            // 
            // tsmiNewCommandReplayMacro
            // 
            this.tsmiNewCommandReplayMacro.Image = global::Makru.Properties.Resources.icon_makro;
            this.tsmiNewCommandReplayMacro.Name = "tsmiNewCommandReplayMacro";
            this.tsmiNewCommandReplayMacro.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewCommandReplayMacro.Text = "Makro ausführen";
            this.tsmiNewCommandReplayMacro.Click += new System.EventHandler(this.tsmiNewCommandReplayMacro_Click);
            // 
            // tsmiNewSetVariable
            // 
            this.tsmiNewSetVariable.Image = global::Makru.Properties.Resources.icon_variable;
            this.tsmiNewSetVariable.Name = "tsmiNewSetVariable";
            this.tsmiNewSetVariable.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewSetVariable.Text = "Variable setzen";
            this.tsmiNewSetVariable.Click += new System.EventHandler(this.tsmiNewSetVariable_Click);
            // 
            // tsmiNewWriteFIle
            // 
            this.tsmiNewWriteFIle.Image = global::Makru.Properties.Resources.icon_writeFile;
            this.tsmiNewWriteFIle.Name = "tsmiNewWriteFIle";
            this.tsmiNewWriteFIle.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewWriteFIle.Text = "Schreibe in Datei";
            this.tsmiNewWriteFIle.Click += new System.EventHandler(this.tsmiNewWriteFIle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(172, 22);
            this.tsmiRename.Text = "Umbennen";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Image = global::Makru.Properties.Resources.icon_remove;
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(172, 22);
            this.tsmiRemove.Text = "Löschen";
            this.tsmiRemove.Click += new System.EventHandler(this.tsmiRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiReplayMacro
            // 
            this.tsmiReplayMacro.Image = global::Makru.Properties.Resources.icon_play;
            this.tsmiReplayMacro.Name = "tsmiReplayMacro";
            this.tsmiReplayMacro.Size = new System.Drawing.Size(172, 22);
            this.tsmiReplayMacro.Text = "Makro abspielen";
            this.tsmiReplayMacro.Click += new System.EventHandler(this.tsmiReplayMacro_Click);
            // 
            // tsmiStopReplay
            // 
            this.tsmiStopReplay.Image = global::Makru.Properties.Resources.icon_stop;
            this.tsmiStopReplay.Name = "tsmiStopReplay";
            this.tsmiStopReplay.Size = new System.Drawing.Size(172, 22);
            this.tsmiStopReplay.Text = "Makro stoppen";
            this.tsmiStopReplay.Click += new System.EventHandler(this.tsmiStopReplay_Click);
            // 
            // tsmiRecordMacro
            // 
            this.tsmiRecordMacro.Image = global::Makru.Properties.Resources.icon_record;
            this.tsmiRecordMacro.Name = "tsmiRecordMacro";
            this.tsmiRecordMacro.Size = new System.Drawing.Size(172, 22);
            this.tsmiRecordMacro.Text = "Makro aufnehmen";
            this.tsmiRecordMacro.Click += new System.EventHandler(this.tsmiRecordMacro_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(172, 22);
            this.tsmiSettings.Text = "Einstellungen";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tvMakros
            // 
            this.tvMakros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMakros.Location = new System.Drawing.Point(12, 27);
            this.tvMakros.Name = "tvMakros";
            this.tvMakros.Size = new System.Drawing.Size(397, 328);
            this.tvMakros.TabIndex = 0;
            this.tvMakros.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMakros_NodeMouseClick_1);
            this.tvMakros.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMakros_NodeMouseDoubleClick);
            // 
            // FormMakro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 367);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.tvMakros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormMakro";
            this.Text = "MakroMaster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMakro_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.cmsMakros.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Macros tvMakros;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadJSON;
        private System.Windows.Forms.ToolStripMenuItem tsmiLog;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMakros;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCondition;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCommand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplayMacro;
        private System.Windows.Forms.ToolStripMenuItem tsmiStopReplay;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecordMacro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewMacro;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewActivator;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewWait;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewInput;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewComandCondition;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewActivatorShortcut;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCommandReplayMacro;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewSetVariable;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewWriteFIle;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewActivatorTime;
    }
}