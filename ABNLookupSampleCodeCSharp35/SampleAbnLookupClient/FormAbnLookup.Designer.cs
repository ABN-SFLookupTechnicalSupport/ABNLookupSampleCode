namespace AbnLookup.SearchClientCSharpe
{
    partial class FormAbnLookup
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
           this.tabControlWebServices = new System.Windows.Forms.TabControl();
           this.tabPageXmlSearch = new System.Windows.Forms.TabPage();
           this.groupBoxProtocolOptions = new System.Windows.Forms.GroupBox();
           this.radioButtonHttpGet = new System.Windows.Forms.RadioButton();
           this.radioButtonSoap = new System.Windows.Forms.RadioButton();
           this.radioButtonProxy = new System.Windows.Forms.RadioButton();
           this.dataGridNames = new System.Windows.Forms.DataGrid();
           this.buttonReset = new System.Windows.Forms.Button();
           this.radioButtonAsic = new System.Windows.Forms.RadioButton();
           this.radioButtonName = new System.Windows.Forms.RadioButton();
           this.radioButtonAbn = new System.Windows.Forms.RadioButton();
           this.radioButtonPostcode = new System.Windows.Forms.RadioButton();
           this.labelGuid = new System.Windows.Forms.Label();
           this.labelCriteria = new System.Windows.Forms.Label();
           this.textBoxCriteria = new System.Windows.Forms.TextBox();
           this.textBoxGuid = new System.Windows.Forms.TextBox();
           this.groupStates = new System.Windows.Forms.GroupBox();
           this.checkBoxNt = new System.Windows.Forms.CheckBox();
           this.checkBoxAct = new System.Windows.Forms.CheckBox();
           this.checkBoxTas = new System.Windows.Forms.CheckBox();
           this.checkBoxWa = new System.Windows.Forms.CheckBox();
           this.checkBoxSa = new System.Windows.Forms.CheckBox();
           this.checkBoxQld = new System.Windows.Forms.CheckBox();
           this.checkBoxVic = new System.Windows.Forms.CheckBox();
           this.checkBoxNsw = new System.Windows.Forms.CheckBox();
           this.groupBoxNameTypes = new System.Windows.Forms.GroupBox();
           this.checkBoxTrading = new System.Windows.Forms.CheckBox();
           this.checkBoxLegal = new System.Windows.Forms.CheckBox();
           this.textBoxPostcode = new System.Windows.Forms.TextBox();
           this.checkBoxHistory = new System.Windows.Forms.CheckBox();
           this.labelPostcode = new System.Windows.Forms.Label();
           this.buttonSearch = new System.Windows.Forms.Button();
           this.richTextBoxResults = new System.Windows.Forms.RichTextBox();
           this.groupBoxMethod = new System.Windows.Forms.GroupBox();
           this.groupBoxStyle = new System.Windows.Forms.GroupBox();
           this.radioButtonDocument = new System.Windows.Forms.RadioButton();
           this.radioButtonRpc = new System.Windows.Forms.RadioButton();
           this.buttonExit = new System.Windows.Forms.Button();
           this.radioButtonUpdateEvent = new System.Windows.Forms.RadioButton();
           this.tabControlWebServices.SuspendLayout();
           this.tabPageXmlSearch.SuspendLayout();
           this.groupBoxProtocolOptions.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.dataGridNames)).BeginInit();
           this.groupStates.SuspendLayout();
           this.groupBoxNameTypes.SuspendLayout();
           this.groupBoxMethod.SuspendLayout();
           this.groupBoxStyle.SuspendLayout();
           this.SuspendLayout();
           // 
           // tabControlWebServices
           // 
           this.tabControlWebServices.Controls.Add(this.tabPageXmlSearch);
           this.tabControlWebServices.Location = new System.Drawing.Point(20, 12);
           this.tabControlWebServices.Name = "tabControlWebServices";
           this.tabControlWebServices.SelectedIndex = 0;
           this.tabControlWebServices.Size = new System.Drawing.Size(602, 608);
           this.tabControlWebServices.TabIndex = 21;
           // 
           // tabPageXmlSearch
           // 
           this.tabPageXmlSearch.Controls.Add(this.groupBoxProtocolOptions);
           this.tabPageXmlSearch.Controls.Add(this.dataGridNames);
           this.tabPageXmlSearch.Controls.Add(this.buttonReset);
           this.tabPageXmlSearch.Controls.Add(this.labelGuid);
           this.tabPageXmlSearch.Controls.Add(this.labelCriteria);
           this.tabPageXmlSearch.Controls.Add(this.textBoxCriteria);
           this.tabPageXmlSearch.Controls.Add(this.textBoxGuid);
           this.tabPageXmlSearch.Controls.Add(this.groupStates);
           this.tabPageXmlSearch.Controls.Add(this.groupBoxNameTypes);
           this.tabPageXmlSearch.Controls.Add(this.textBoxPostcode);
           this.tabPageXmlSearch.Controls.Add(this.checkBoxHistory);
           this.tabPageXmlSearch.Controls.Add(this.labelPostcode);
           this.tabPageXmlSearch.Controls.Add(this.buttonSearch);
           this.tabPageXmlSearch.Controls.Add(this.richTextBoxResults);
           this.tabPageXmlSearch.Controls.Add(this.groupBoxMethod);
           this.tabPageXmlSearch.Controls.Add(this.groupBoxStyle);
           this.tabPageXmlSearch.Location = new System.Drawing.Point(4, 22);
           this.tabPageXmlSearch.Name = "tabPageXmlSearch";
           this.tabPageXmlSearch.Size = new System.Drawing.Size(594, 582);
           this.tabPageXmlSearch.TabIndex = 0;
           this.tabPageXmlSearch.Text = "Xml Search";
           // 
           // groupBoxProtocolOptions
           // 
           this.groupBoxProtocolOptions.Controls.Add(this.radioButtonHttpGet);
           this.groupBoxProtocolOptions.Controls.Add(this.radioButtonSoap);
           this.groupBoxProtocolOptions.Controls.Add(this.radioButtonProxy);
           this.groupBoxProtocolOptions.Location = new System.Drawing.Point(264, 217);
           this.groupBoxProtocolOptions.Name = "groupBoxProtocolOptions";
           this.groupBoxProtocolOptions.Size = new System.Drawing.Size(245, 41);
           this.groupBoxProtocolOptions.TabIndex = 23;
           this.groupBoxProtocolOptions.TabStop = false;
           this.groupBoxProtocolOptions.Text = "Protocol options";
           // 
           // radioButtonHttpGet
           // 
           this.radioButtonHttpGet.AutoSize = true;
           this.radioButtonHttpGet.Location = new System.Drawing.Point(173, 13);
           this.radioButtonHttpGet.Name = "radioButtonHttpGet";
           this.radioButtonHttpGet.Size = new System.Drawing.Size(62, 17);
           this.radioButtonHttpGet.TabIndex = 2;
           this.radioButtonHttpGet.Text = "HttpGet";
           this.radioButtonHttpGet.UseVisualStyleBackColor = true;
           // 
           // radioButtonSoap
           // 
           this.radioButtonSoap.AutoSize = true;
           this.radioButtonSoap.Checked = true;
           this.radioButtonSoap.Location = new System.Drawing.Point(117, 13);
           this.radioButtonSoap.Name = "radioButtonSoap";
           this.radioButtonSoap.Size = new System.Drawing.Size(50, 17);
           this.radioButtonSoap.TabIndex = 1;
           this.radioButtonSoap.TabStop = true;
           this.radioButtonSoap.Text = "Soap";
           this.radioButtonSoap.UseVisualStyleBackColor = true;
           // 
           // radioButtonProxy
           // 
           this.radioButtonProxy.AutoSize = true;
           this.radioButtonProxy.Location = new System.Drawing.Point(24, 13);
           this.radioButtonProxy.Name = "radioButtonProxy";
           this.radioButtonProxy.Size = new System.Drawing.Size(88, 17);
           this.radioButtonProxy.TabIndex = 0;
           this.radioButtonProxy.Text = "Proxy objects";
           this.radioButtonProxy.UseVisualStyleBackColor = true;
           // 
           // dataGridNames
           // 
           this.dataGridNames.DataMember = "";
           this.dataGridNames.HeaderForeColor = System.Drawing.SystemColors.ControlText;
           this.dataGridNames.Location = new System.Drawing.Point(24, 288);
           this.dataGridNames.Name = "dataGridNames";
           this.dataGridNames.Size = new System.Drawing.Size(448, 264);
           this.dataGridNames.TabIndex = 21;
           // 
           // buttonReset
           // 
           this.buttonReset.Location = new System.Drawing.Point(16, 259);
           this.buttonReset.Name = "buttonReset";
           this.buttonReset.Size = new System.Drawing.Size(75, 23);
           this.buttonReset.TabIndex = 20;
           this.buttonReset.Text = "Reset";
           this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
           // 
           // radioButtonAsic
           // 
           this.radioButtonAsic.Location = new System.Drawing.Point(112, 19);
           this.radioButtonAsic.Name = "radioButtonAsic";
           this.radioButtonAsic.Size = new System.Drawing.Size(96, 20);
           this.radioButtonAsic.TabIndex = 8;
           this.radioButtonAsic.Text = "ASIC Search";
           this.radioButtonAsic.CheckedChanged += new System.EventHandler(this.radioButtonAsic_CheckedChanged);
           // 
           // radioButtonName
           // 
           this.radioButtonName.Location = new System.Drawing.Point(214, 19);
           this.radioButtonName.Name = "radioButtonName";
           this.radioButtonName.Size = new System.Drawing.Size(98, 20);
           this.radioButtonName.TabIndex = 9;
           this.radioButtonName.Text = "Name Search";
           this.radioButtonName.CheckedChanged += new System.EventHandler(this.radioButtonName_CheckedChanged);
           // 
           // radioButtonAbn
           // 
           this.radioButtonAbn.Checked = true;
           this.radioButtonAbn.Location = new System.Drawing.Point(15, 19);
           this.radioButtonAbn.Name = "radioButtonAbn";
           this.radioButtonAbn.Size = new System.Drawing.Size(91, 20);
           this.radioButtonAbn.TabIndex = 7;
           this.radioButtonAbn.TabStop = true;
           this.radioButtonAbn.Text = "ABN Search";
           this.radioButtonAbn.CheckedChanged += new System.EventHandler(this.radioButtonAbn_CheckedChanged);
           // 
           // radioButtonPostcode
           // 
           this.radioButtonPostcode.Location = new System.Drawing.Point(318, 19);
           this.radioButtonPostcode.Name = "radioButtonPostcode";
           this.radioButtonPostcode.Size = new System.Drawing.Size(114, 20);
           this.radioButtonPostcode.TabIndex = 22;
           this.radioButtonPostcode.Text = "Postcode Search";
           this.radioButtonPostcode.CheckedChanged += new System.EventHandler(this.radioButtonPostcode_CheckedChanged);
           // 
           // labelGuid
           // 
           this.labelGuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelGuid.ForeColor = System.Drawing.SystemColors.Desktop;
           this.labelGuid.Location = new System.Drawing.Point(16, 65);
           this.labelGuid.Name = "labelGuid";
           this.labelGuid.Size = new System.Drawing.Size(40, 23);
           this.labelGuid.TabIndex = 10;
           this.labelGuid.Text = "GUID:";
           this.labelGuid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           // 
           // labelCriteria
           // 
           this.labelCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelCriteria.ForeColor = System.Drawing.SystemColors.Desktop;
           this.labelCriteria.Location = new System.Drawing.Point(8, 91);
           this.labelCriteria.Name = "labelCriteria";
           this.labelCriteria.Size = new System.Drawing.Size(48, 23);
           this.labelCriteria.TabIndex = 1;
           this.labelCriteria.Text = "Criteria:";
           this.labelCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           // 
           // textBoxCriteria
           // 
           this.textBoxCriteria.Location = new System.Drawing.Point(64, 94);
           this.textBoxCriteria.Name = "textBoxCriteria";
           this.textBoxCriteria.Size = new System.Drawing.Size(264, 20);
           this.textBoxCriteria.TabIndex = 1;
           this.textBoxCriteria.Text = "51835430479";
           // 
           // textBoxGuid
           // 
           this.textBoxGuid.Location = new System.Drawing.Point(64, 64);
           this.textBoxGuid.Name = "textBoxGuid";
           this.textBoxGuid.Size = new System.Drawing.Size(264, 20);
           this.textBoxGuid.TabIndex = 0;
           // 
           // groupStates
           // 
           this.groupStates.Controls.Add(this.checkBoxNt);
           this.groupStates.Controls.Add(this.checkBoxAct);
           this.groupStates.Controls.Add(this.checkBoxTas);
           this.groupStates.Controls.Add(this.checkBoxWa);
           this.groupStates.Controls.Add(this.checkBoxSa);
           this.groupStates.Controls.Add(this.checkBoxQld);
           this.groupStates.Controls.Add(this.checkBoxVic);
           this.groupStates.Controls.Add(this.checkBoxNsw);
           this.groupStates.Location = new System.Drawing.Point(16, 121);
           this.groupStates.Name = "groupStates";
           this.groupStates.Size = new System.Drawing.Size(232, 88);
           this.groupStates.TabIndex = 3;
           this.groupStates.TabStop = false;
           this.groupStates.Text = "States";
           // 
           // checkBoxNt
           // 
           this.checkBoxNt.Checked = true;
           this.checkBoxNt.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxNt.Location = new System.Drawing.Point(177, 50);
           this.checkBoxNt.Name = "checkBoxNt";
           this.checkBoxNt.Size = new System.Drawing.Size(47, 24);
           this.checkBoxNt.TabIndex = 7;
           this.checkBoxNt.Text = "NT";
           // 
           // checkBoxAct
           // 
           this.checkBoxAct.Checked = true;
           this.checkBoxAct.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxAct.Location = new System.Drawing.Point(177, 24);
           this.checkBoxAct.Name = "checkBoxAct";
           this.checkBoxAct.Size = new System.Drawing.Size(47, 24);
           this.checkBoxAct.TabIndex = 6;
           this.checkBoxAct.Text = "ACT";
           // 
           // checkBoxTas
           // 
           this.checkBoxTas.Checked = true;
           this.checkBoxTas.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxTas.Location = new System.Drawing.Point(121, 50);
           this.checkBoxTas.Name = "checkBoxTas";
           this.checkBoxTas.Size = new System.Drawing.Size(56, 24);
           this.checkBoxTas.TabIndex = 5;
           this.checkBoxTas.Text = "Tas";
           // 
           // checkBoxWa
           // 
           this.checkBoxWa.Checked = true;
           this.checkBoxWa.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxWa.Location = new System.Drawing.Point(122, 24);
           this.checkBoxWa.Name = "checkBoxWa";
           this.checkBoxWa.Size = new System.Drawing.Size(56, 24);
           this.checkBoxWa.TabIndex = 4;
           this.checkBoxWa.Text = "WA";
           // 
           // checkBoxSa
           // 
           this.checkBoxSa.Checked = true;
           this.checkBoxSa.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxSa.Location = new System.Drawing.Point(66, 50);
           this.checkBoxSa.Name = "checkBoxSa";
           this.checkBoxSa.Size = new System.Drawing.Size(56, 24);
           this.checkBoxSa.TabIndex = 3;
           this.checkBoxSa.Text = "SA";
           // 
           // checkBoxQld
           // 
           this.checkBoxQld.Checked = true;
           this.checkBoxQld.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxQld.Location = new System.Drawing.Point(66, 24);
           this.checkBoxQld.Name = "checkBoxQld";
           this.checkBoxQld.Size = new System.Drawing.Size(54, 24);
           this.checkBoxQld.TabIndex = 2;
           this.checkBoxQld.Text = "Qld";
           // 
           // checkBoxVic
           // 
           this.checkBoxVic.Checked = true;
           this.checkBoxVic.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxVic.Location = new System.Drawing.Point(8, 50);
           this.checkBoxVic.Name = "checkBoxVic";
           this.checkBoxVic.Size = new System.Drawing.Size(56, 24);
           this.checkBoxVic.TabIndex = 1;
           this.checkBoxVic.Text = "Vic";
           // 
           // checkBoxNsw
           // 
           this.checkBoxNsw.Checked = true;
           this.checkBoxNsw.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxNsw.Location = new System.Drawing.Point(8, 24);
           this.checkBoxNsw.Name = "checkBoxNsw";
           this.checkBoxNsw.Size = new System.Drawing.Size(56, 24);
           this.checkBoxNsw.TabIndex = 0;
           this.checkBoxNsw.Text = "NSW";
           // 
           // groupBoxNameTypes
           // 
           this.groupBoxNameTypes.Controls.Add(this.checkBoxTrading);
           this.groupBoxNameTypes.Controls.Add(this.checkBoxLegal);
           this.groupBoxNameTypes.Location = new System.Drawing.Point(264, 121);
           this.groupBoxNameTypes.Name = "groupBoxNameTypes";
           this.groupBoxNameTypes.Size = new System.Drawing.Size(112, 88);
           this.groupBoxNameTypes.TabIndex = 4;
           this.groupBoxNameTypes.TabStop = false;
           this.groupBoxNameTypes.Text = "Name Types";
           // 
           // checkBoxTrading
           // 
           this.checkBoxTrading.Checked = true;
           this.checkBoxTrading.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxTrading.Location = new System.Drawing.Point(5, 50);
           this.checkBoxTrading.Name = "checkBoxTrading";
           this.checkBoxTrading.Size = new System.Drawing.Size(100, 24);
           this.checkBoxTrading.TabIndex = 1;
           this.checkBoxTrading.Text = "Trading Name";
           // 
           // checkBoxLegal
           // 
           this.checkBoxLegal.Checked = true;
           this.checkBoxLegal.CheckState = System.Windows.Forms.CheckState.Checked;
           this.checkBoxLegal.Location = new System.Drawing.Point(5, 24);
           this.checkBoxLegal.Name = "checkBoxLegal";
           this.checkBoxLegal.Size = new System.Drawing.Size(89, 24);
           this.checkBoxLegal.TabIndex = 0;
           this.checkBoxLegal.Text = "Legal Name";
           // 
           // textBoxPostcode
           // 
           this.textBoxPostcode.Location = new System.Drawing.Point(76, 217);
           this.textBoxPostcode.Name = "textBoxPostcode";
           this.textBoxPostcode.Size = new System.Drawing.Size(56, 20);
           this.textBoxPostcode.TabIndex = 5;
           this.textBoxPostcode.Text = "ALL";
           // 
           // checkBoxHistory
           // 
           this.checkBoxHistory.Location = new System.Drawing.Point(144, 217);
           this.checkBoxHistory.Name = "checkBoxHistory";
           this.checkBoxHistory.Size = new System.Drawing.Size(104, 24);
           this.checkBoxHistory.TabIndex = 12;
           this.checkBoxHistory.Text = "Include History";
           // 
           // labelPostcode
           // 
           this.labelPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelPostcode.ForeColor = System.Drawing.SystemColors.Desktop;
           this.labelPostcode.Location = new System.Drawing.Point(9, 214);
           this.labelPostcode.Name = "labelPostcode";
           this.labelPostcode.Size = new System.Drawing.Size(64, 23);
           this.labelPostcode.TabIndex = 2;
           this.labelPostcode.Text = "Postcode:";
           this.labelPostcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           // 
           // buttonSearch
           // 
           this.buttonSearch.Location = new System.Drawing.Point(100, 259);
           this.buttonSearch.Name = "buttonSearch";
           this.buttonSearch.Size = new System.Drawing.Size(75, 23);
           this.buttonSearch.TabIndex = 6;
           this.buttonSearch.Text = "Search";
           this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
           // 
           // richTextBoxResults
           // 
           this.richTextBoxResults.Location = new System.Drawing.Point(8, 288);
           this.richTextBoxResults.Name = "richTextBoxResults";
           this.richTextBoxResults.Size = new System.Drawing.Size(472, 264);
           this.richTextBoxResults.TabIndex = 13;
           this.richTextBoxResults.Text = "";
           // 
           // groupBoxMethod
           // 
           this.groupBoxMethod.Controls.Add(this.radioButtonUpdateEvent);
           this.groupBoxMethod.Controls.Add(this.radioButtonPostcode);
           this.groupBoxMethod.Controls.Add(this.radioButtonAbn);
           this.groupBoxMethod.Controls.Add(this.radioButtonName);
           this.groupBoxMethod.Controls.Add(this.radioButtonAsic);
           this.groupBoxMethod.Location = new System.Drawing.Point(17, 10);
           this.groupBoxMethod.Name = "groupBoxMethod";
           this.groupBoxMethod.Size = new System.Drawing.Size(567, 48);
           this.groupBoxMethod.TabIndex = 19;
           this.groupBoxMethod.TabStop = false;
           this.groupBoxMethod.Text = "Search Method";
           // 
           // groupBoxStyle
           // 
           this.groupBoxStyle.Controls.Add(this.radioButtonDocument);
           this.groupBoxStyle.Controls.Add(this.radioButtonRpc);
           this.groupBoxStyle.Location = new System.Drawing.Point(384, 121);
           this.groupBoxStyle.Name = "groupBoxStyle";
           this.groupBoxStyle.Size = new System.Drawing.Size(120, 88);
           this.groupBoxStyle.TabIndex = 18;
           this.groupBoxStyle.TabStop = false;
           this.groupBoxStyle.Text = "Soap Style";
           // 
           // radioButtonDocument
           // 
           this.radioButtonDocument.Checked = true;
           this.radioButtonDocument.Location = new System.Drawing.Point(7, 31);
           this.radioButtonDocument.Name = "radioButtonDocument";
           this.radioButtonDocument.Size = new System.Drawing.Size(104, 16);
           this.radioButtonDocument.TabIndex = 17;
           this.radioButtonDocument.TabStop = true;
           this.radioButtonDocument.Text = "Document Style";
           // 
           // radioButtonRpc
           // 
           this.radioButtonRpc.Location = new System.Drawing.Point(7, 55);
           this.radioButtonRpc.Name = "radioButtonRpc";
           this.radioButtonRpc.Size = new System.Drawing.Size(88, 16);
           this.radioButtonRpc.TabIndex = 16;
           this.radioButtonRpc.Text = "RPC Style";
           // 
           // buttonExit
           // 
           this.buttonExit.Location = new System.Drawing.Point(461, 626);
           this.buttonExit.Name = "buttonExit";
           this.buttonExit.Size = new System.Drawing.Size(75, 23);
           this.buttonExit.TabIndex = 22;
           this.buttonExit.Text = "Exit";
           this.buttonExit.UseVisualStyleBackColor = true;
           this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
           // 
           // radioButtonUpdateEvent
           // 
           this.radioButtonUpdateEvent.AutoSize = true;
           this.radioButtonUpdateEvent.Location = new System.Drawing.Point(438, 21);
           this.radioButtonUpdateEvent.Name = "radioButtonUpdateEvent";
           this.radioButtonUpdateEvent.Size = new System.Drawing.Size(90, 17);
           this.radioButtonUpdateEvent.TabIndex = 24;
           this.radioButtonUpdateEvent.TabStop = true;
           this.radioButtonUpdateEvent.Text = "Update event";
           this.radioButtonUpdateEvent.UseVisualStyleBackColor = true;
           this.radioButtonUpdateEvent.CheckedChanged += new System.EventHandler(this.radioButtonUpdateEvent_CheckedChanged);
           // 
           // FormAbnLookup
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(644, 660);
           this.Controls.Add(this.buttonExit);
           this.Controls.Add(this.tabControlWebServices);
           this.Name = "FormAbnLookup";
           this.Text = "ABN Lookup";
           this.Load += new System.EventHandler(this.formAbnLookup_Load);
           this.tabControlWebServices.ResumeLayout(false);
           this.tabPageXmlSearch.ResumeLayout(false);
           this.tabPageXmlSearch.PerformLayout();
           this.groupBoxProtocolOptions.ResumeLayout(false);
           this.groupBoxProtocolOptions.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.dataGridNames)).EndInit();
           this.groupStates.ResumeLayout(false);
           this.groupBoxNameTypes.ResumeLayout(false);
           this.groupBoxMethod.ResumeLayout(false);
           this.groupBoxMethod.PerformLayout();
           this.groupBoxStyle.ResumeLayout(false);
           this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tabControlWebServices;
        internal System.Windows.Forms.TabPage tabPageXmlSearch;
        internal System.Windows.Forms.DataGrid dataGridNames;
        internal System.Windows.Forms.Button buttonReset;
        internal System.Windows.Forms.RadioButton radioButtonAsic;
        internal System.Windows.Forms.RadioButton radioButtonName;
        internal System.Windows.Forms.RadioButton radioButtonAbn;
        internal System.Windows.Forms.RadioButton radioButtonPostcode;
        internal System.Windows.Forms.Label labelGuid;
        internal System.Windows.Forms.Label labelCriteria;
        internal System.Windows.Forms.TextBox textBoxCriteria;
        internal System.Windows.Forms.TextBox textBoxGuid;
        internal System.Windows.Forms.GroupBox groupStates;
        internal System.Windows.Forms.CheckBox checkBoxNt;
        internal System.Windows.Forms.CheckBox checkBoxAct;
        internal System.Windows.Forms.CheckBox checkBoxTas;
        internal System.Windows.Forms.CheckBox checkBoxWa;
        internal System.Windows.Forms.CheckBox checkBoxSa;
        internal System.Windows.Forms.CheckBox checkBoxQld;
        internal System.Windows.Forms.CheckBox checkBoxVic;
        internal System.Windows.Forms.CheckBox checkBoxNsw;
        internal System.Windows.Forms.GroupBox groupBoxNameTypes;
        internal System.Windows.Forms.CheckBox checkBoxTrading;
        internal System.Windows.Forms.CheckBox checkBoxLegal;
        internal System.Windows.Forms.TextBox textBoxPostcode;
        internal System.Windows.Forms.CheckBox checkBoxHistory;
        internal System.Windows.Forms.Label labelPostcode;
        internal System.Windows.Forms.Button buttonSearch;
        internal System.Windows.Forms.RichTextBox richTextBoxResults;
        internal System.Windows.Forms.GroupBox groupBoxMethod;
        internal System.Windows.Forms.GroupBox groupBoxStyle;
        internal System.Windows.Forms.RadioButton radioButtonDocument;
        internal System.Windows.Forms.RadioButton radioButtonRpc;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBoxProtocolOptions;
        private System.Windows.Forms.RadioButton radioButtonSoap;
        private System.Windows.Forms.RadioButton radioButtonProxy;
        private System.Windows.Forms.RadioButton radioButtonHttpGet;
        internal System.Windows.Forms.RadioButton radioButtonUpdateEvent;

    }
}

