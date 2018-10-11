Imports System.Configuration.ConfigurationSettings
'Imports ABRXMLSearchClient.au.gov.business.abr
Imports ABRXMLSearchClient.WebReference
Imports ABRXMLSearchClient.WebReferenceRPC
'-----------------------------------------------------------------------------------------------
' Simple example of using the ABRpublic Web Service from a Windows Application
'-----------------------------------------------------------------------------------------------
Public Class FormSearch : Inherits System.Windows.Forms.Form
   Private YES As String = "Y"
   Private NO As String = "N"
   Private initialControlValue As New Collection
#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents TextBoxCriteria As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents GroupStates As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents CheckBoxNSW As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxVIC As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxQLD As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxSA As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxWA As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxTAS As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxTrading As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxLegal As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxACT As System.Windows.Forms.CheckBox
   Friend WithEvents CheckBoxNT As System.Windows.Forms.CheckBox
   Friend WithEvents TextBoxPostcode As System.Windows.Forms.TextBox
   Friend WithEvents ButtonSearch As System.Windows.Forms.Button
   Friend WithEvents RadioButtonABN As System.Windows.Forms.RadioButton
   Friend WithEvents RadioButtonASIC As System.Windows.Forms.RadioButton
   Friend WithEvents RadioButtonName As System.Windows.Forms.RadioButton
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents TextBoxGUID As System.Windows.Forms.TextBox
   Friend WithEvents CheckBoxHistory As System.Windows.Forms.CheckBox
   Friend WithEvents RichTextBoxResults As System.Windows.Forms.RichTextBox
   Friend WithEvents ButtonExit As System.Windows.Forms.Button
   Friend WithEvents CheckBoxProxy As System.Windows.Forms.CheckBox
   Friend WithEvents TabControlWebServices As System.Windows.Forms.TabControl
   Friend WithEvents TabPageXMLSearch As System.Windows.Forms.TabPage
   Friend WithEvents RadioButtonDocument As System.Windows.Forms.RadioButton
   Friend WithEvents GroupBoxStyle As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBoxMethod As System.Windows.Forms.GroupBox
   Friend WithEvents RadioButtonRPC As System.Windows.Forms.RadioButton
   Friend WithEvents ButtonReset As System.Windows.Forms.Button
   Friend WithEvents DataGridNames As System.Windows.Forms.DataGrid
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.TextBoxCriteria = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.GroupStates = New System.Windows.Forms.GroupBox
      Me.CheckBoxNT = New System.Windows.Forms.CheckBox
      Me.CheckBoxACT = New System.Windows.Forms.CheckBox
      Me.CheckBoxTAS = New System.Windows.Forms.CheckBox
      Me.CheckBoxWA = New System.Windows.Forms.CheckBox
      Me.CheckBoxSA = New System.Windows.Forms.CheckBox
      Me.CheckBoxQLD = New System.Windows.Forms.CheckBox
      Me.CheckBoxVIC = New System.Windows.Forms.CheckBox
      Me.CheckBoxNSW = New System.Windows.Forms.CheckBox
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.CheckBoxTrading = New System.Windows.Forms.CheckBox
      Me.CheckBoxLegal = New System.Windows.Forms.CheckBox
      Me.TextBoxPostcode = New System.Windows.Forms.TextBox
      Me.ButtonSearch = New System.Windows.Forms.Button
      Me.RadioButtonABN = New System.Windows.Forms.RadioButton
      Me.RadioButtonASIC = New System.Windows.Forms.RadioButton
      Me.RadioButtonName = New System.Windows.Forms.RadioButton
      Me.Label3 = New System.Windows.Forms.Label
      Me.TextBoxGUID = New System.Windows.Forms.TextBox
      Me.CheckBoxHistory = New System.Windows.Forms.CheckBox
      Me.RichTextBoxResults = New System.Windows.Forms.RichTextBox
      Me.ButtonExit = New System.Windows.Forms.Button
      Me.CheckBoxProxy = New System.Windows.Forms.CheckBox
      Me.TabControlWebServices = New System.Windows.Forms.TabControl
      Me.TabPageXMLSearch = New System.Windows.Forms.TabPage
      Me.DataGridNames = New System.Windows.Forms.DataGrid
      Me.ButtonReset = New System.Windows.Forms.Button
      Me.GroupBoxMethod = New System.Windows.Forms.GroupBox
      Me.GroupBoxStyle = New System.Windows.Forms.GroupBox
      Me.RadioButtonDocument = New System.Windows.Forms.RadioButton
      Me.RadioButtonRPC = New System.Windows.Forms.RadioButton
      Me.GroupStates.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.TabControlWebServices.SuspendLayout()
      Me.TabPageXMLSearch.SuspendLayout()
      CType(Me.DataGridNames, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBoxStyle.SuspendLayout()
      Me.SuspendLayout()
      '
      'TextBoxCriteria
      '
      Me.TextBoxCriteria.Location = New System.Drawing.Point(64, 94)
      Me.TextBoxCriteria.Name = "TextBoxCriteria"
      Me.TextBoxCriteria.Size = New System.Drawing.Size(264, 20)
      Me.TextBoxCriteria.TabIndex = 1
      Me.TextBoxCriteria.Text = "51835430479"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label1.Location = New System.Drawing.Point(8, 91)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(48, 23)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Criteria:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label2.Location = New System.Drawing.Point(9, 214)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(64, 23)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Postcode:"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'GroupStates
      '
      Me.GroupStates.Controls.Add(Me.CheckBoxNT)
      Me.GroupStates.Controls.Add(Me.CheckBoxACT)
      Me.GroupStates.Controls.Add(Me.CheckBoxTAS)
      Me.GroupStates.Controls.Add(Me.CheckBoxWA)
      Me.GroupStates.Controls.Add(Me.CheckBoxSA)
      Me.GroupStates.Controls.Add(Me.CheckBoxQLD)
      Me.GroupStates.Controls.Add(Me.CheckBoxVIC)
      Me.GroupStates.Controls.Add(Me.CheckBoxNSW)
      Me.GroupStates.Location = New System.Drawing.Point(16, 121)
      Me.GroupStates.Name = "GroupStates"
      Me.GroupStates.Size = New System.Drawing.Size(232, 88)
      Me.GroupStates.TabIndex = 3
      Me.GroupStates.TabStop = False
      Me.GroupStates.Text = "States"
      '
      'CheckBoxNT
      '
      Me.CheckBoxNT.Checked = True
      Me.CheckBoxNT.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxNT.Location = New System.Drawing.Point(177, 50)
      Me.CheckBoxNT.Name = "CheckBoxNT"
      Me.CheckBoxNT.Size = New System.Drawing.Size(39, 24)
      Me.CheckBoxNT.TabIndex = 7
      Me.CheckBoxNT.Text = "NT"
      '
      'CheckBoxACT
      '
      Me.CheckBoxACT.Checked = True
      Me.CheckBoxACT.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxACT.Location = New System.Drawing.Point(177, 24)
      Me.CheckBoxACT.Name = "CheckBoxACT"
      Me.CheckBoxACT.Size = New System.Drawing.Size(47, 24)
      Me.CheckBoxACT.TabIndex = 6
      Me.CheckBoxACT.Text = "ACT"
      '
      'CheckBoxTAS
      '
      Me.CheckBoxTAS.Checked = True
      Me.CheckBoxTAS.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxTAS.Location = New System.Drawing.Point(121, 50)
      Me.CheckBoxTAS.Name = "CheckBoxTAS"
      Me.CheckBoxTAS.Size = New System.Drawing.Size(56, 24)
      Me.CheckBoxTAS.TabIndex = 5
      Me.CheckBoxTAS.Text = "Tas"
      '
      'CheckBoxWA
      '
      Me.CheckBoxWA.Checked = True
      Me.CheckBoxWA.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxWA.Location = New System.Drawing.Point(122, 24)
      Me.CheckBoxWA.Name = "CheckBoxWA"
      Me.CheckBoxWA.Size = New System.Drawing.Size(56, 24)
      Me.CheckBoxWA.TabIndex = 4
      Me.CheckBoxWA.Text = "WA"
      '
      'CheckBoxSA
      '
      Me.CheckBoxSA.Checked = True
      Me.CheckBoxSA.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxSA.Location = New System.Drawing.Point(66, 50)
      Me.CheckBoxSA.Name = "CheckBoxSA"
      Me.CheckBoxSA.Size = New System.Drawing.Size(56, 24)
      Me.CheckBoxSA.TabIndex = 3
      Me.CheckBoxSA.Text = "SA"
      '
      'CheckBoxQLD
      '
      Me.CheckBoxQLD.Checked = True
      Me.CheckBoxQLD.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxQLD.Location = New System.Drawing.Point(66, 24)
      Me.CheckBoxQLD.Name = "CheckBoxQLD"
      Me.CheckBoxQLD.Size = New System.Drawing.Size(54, 24)
      Me.CheckBoxQLD.TabIndex = 2
      Me.CheckBoxQLD.Text = "Qld"
      '
      'CheckBoxVIC
      '
      Me.CheckBoxVIC.Checked = True
      Me.CheckBoxVIC.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxVIC.Location = New System.Drawing.Point(8, 50)
      Me.CheckBoxVIC.Name = "CheckBoxVIC"
      Me.CheckBoxVIC.Size = New System.Drawing.Size(56, 24)
      Me.CheckBoxVIC.TabIndex = 1
      Me.CheckBoxVIC.Text = "Vic"
      '
      'CheckBoxNSW
      '
      Me.CheckBoxNSW.Checked = True
      Me.CheckBoxNSW.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxNSW.Location = New System.Drawing.Point(8, 24)
      Me.CheckBoxNSW.Name = "CheckBoxNSW"
      Me.CheckBoxNSW.Size = New System.Drawing.Size(56, 24)
      Me.CheckBoxNSW.TabIndex = 0
      Me.CheckBoxNSW.Text = "NSW"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.CheckBoxTrading)
      Me.GroupBox1.Controls.Add(Me.CheckBoxLegal)
      Me.GroupBox1.Location = New System.Drawing.Point(264, 121)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(112, 88)
      Me.GroupBox1.TabIndex = 4
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Name Types"
      '
      'CheckBoxTrading
      '
      Me.CheckBoxTrading.Checked = True
      Me.CheckBoxTrading.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxTrading.Location = New System.Drawing.Point(5, 50)
      Me.CheckBoxTrading.Name = "CheckBoxTrading"
      Me.CheckBoxTrading.Size = New System.Drawing.Size(100, 24)
      Me.CheckBoxTrading.TabIndex = 1
      Me.CheckBoxTrading.Text = "Trading Name"
      '
      'CheckBoxLegal
      '
      Me.CheckBoxLegal.Checked = True
      Me.CheckBoxLegal.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBoxLegal.Location = New System.Drawing.Point(5, 24)
      Me.CheckBoxLegal.Name = "CheckBoxLegal"
      Me.CheckBoxLegal.Size = New System.Drawing.Size(89, 24)
      Me.CheckBoxLegal.TabIndex = 0
      Me.CheckBoxLegal.Text = "Legal Name"
      '
      'TextBoxPostcode
      '
      Me.TextBoxPostcode.Location = New System.Drawing.Point(83, 217)
      Me.TextBoxPostcode.Name = "TextBoxPostcode"
      Me.TextBoxPostcode.Size = New System.Drawing.Size(56, 20)
      Me.TextBoxPostcode.TabIndex = 5
      Me.TextBoxPostcode.Text = "ALL"
      '
      'ButtonSearch
      '
      Me.ButtonSearch.Location = New System.Drawing.Point(400, 256)
      Me.ButtonSearch.Name = "ButtonSearch"
      Me.ButtonSearch.TabIndex = 6
      Me.ButtonSearch.Text = "Search"
      '
      'RadioButtonABN
      '
      Me.RadioButtonABN.Checked = True
      Me.RadioButtonABN.Location = New System.Drawing.Point(66, 28)
      Me.RadioButtonABN.Name = "RadioButtonABN"
      Me.RadioButtonABN.Size = New System.Drawing.Size(104, 20)
      Me.RadioButtonABN.TabIndex = 7
      Me.RadioButtonABN.TabStop = True
      Me.RadioButtonABN.Text = "ABN Search"
      '
      'RadioButtonASIC
      '
      Me.RadioButtonASIC.Location = New System.Drawing.Point(181, 28)
      Me.RadioButtonASIC.Name = "RadioButtonASIC"
      Me.RadioButtonASIC.Size = New System.Drawing.Size(104, 20)
      Me.RadioButtonASIC.TabIndex = 8
      Me.RadioButtonASIC.Text = "ASIC Search"
      '
      'RadioButtonName
      '
      Me.RadioButtonName.Location = New System.Drawing.Point(296, 28)
      Me.RadioButtonName.Name = "RadioButtonName"
      Me.RadioButtonName.Size = New System.Drawing.Size(104, 20)
      Me.RadioButtonName.TabIndex = 9
      Me.RadioButtonName.Text = "Name Search"
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label3.Location = New System.Drawing.Point(16, 65)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(40, 23)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "GUID:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'TextBoxGUID
      '
      Me.TextBoxGUID.Location = New System.Drawing.Point(64, 64)
      Me.TextBoxGUID.Name = "TextBoxGUID"
      Me.TextBoxGUID.Size = New System.Drawing.Size(264, 20)
      Me.TextBoxGUID.TabIndex = 0
      Me.TextBoxGUID.Text = ""
      '
      'CheckBoxHistory
      '
      Me.CheckBoxHistory.Location = New System.Drawing.Point(148, 216)
      Me.CheckBoxHistory.Name = "CheckBoxHistory"
      Me.CheckBoxHistory.TabIndex = 12
      Me.CheckBoxHistory.Text = "Include History"
      '
      'RichTextBoxResults
      '
      Me.RichTextBoxResults.Location = New System.Drawing.Point(8, 288)
      Me.RichTextBoxResults.Name = "RichTextBoxResults"
      Me.RichTextBoxResults.Size = New System.Drawing.Size(472, 264)
      Me.RichTextBoxResults.TabIndex = 13
      Me.RichTextBoxResults.Text = ""
      '
      'ButtonExit
      '
      Me.ButtonExit.Location = New System.Drawing.Point(455, 624)
      Me.ButtonExit.Name = "ButtonExit"
      Me.ButtonExit.TabIndex = 14
      Me.ButtonExit.Text = "Exit"
      '
      'CheckBoxProxy
      '
      Me.CheckBoxProxy.Location = New System.Drawing.Point(254, 217)
      Me.CheckBoxProxy.Name = "CheckBoxProxy"
      Me.CheckBoxProxy.Size = New System.Drawing.Size(165, 24)
      Me.CheckBoxProxy.TabIndex = 15
      Me.CheckBoxProxy.Text = "Use Strongly Typed Search"
      '
      'TabControlWebServices
      '
      Me.TabControlWebServices.Controls.Add(Me.TabPageXMLSearch)
      Me.TabControlWebServices.Location = New System.Drawing.Point(16, 8)
      Me.TabControlWebServices.Name = "TabControlWebServices"
      Me.TabControlWebServices.SelectedIndex = 0
      Me.TabControlWebServices.Size = New System.Drawing.Size(520, 608)
      Me.TabControlWebServices.TabIndex = 16
      '
      'TabPageXMLSearch
      '
      Me.TabPageXMLSearch.Controls.Add(Me.DataGridNames)
      Me.TabPageXMLSearch.Controls.Add(Me.ButtonReset)
      Me.TabPageXMLSearch.Controls.Add(Me.RadioButtonASIC)
      Me.TabPageXMLSearch.Controls.Add(Me.RadioButtonName)
      Me.TabPageXMLSearch.Controls.Add(Me.RadioButtonABN)
      Me.TabPageXMLSearch.Controls.Add(Me.Label3)
      Me.TabPageXMLSearch.Controls.Add(Me.Label1)
      Me.TabPageXMLSearch.Controls.Add(Me.TextBoxCriteria)
      Me.TabPageXMLSearch.Controls.Add(Me.TextBoxGUID)
      Me.TabPageXMLSearch.Controls.Add(Me.GroupStates)
      Me.TabPageXMLSearch.Controls.Add(Me.GroupBox1)
      Me.TabPageXMLSearch.Controls.Add(Me.TextBoxPostcode)
      Me.TabPageXMLSearch.Controls.Add(Me.CheckBoxHistory)
      Me.TabPageXMLSearch.Controls.Add(Me.Label2)
      Me.TabPageXMLSearch.Controls.Add(Me.CheckBoxProxy)
      Me.TabPageXMLSearch.Controls.Add(Me.ButtonSearch)
      Me.TabPageXMLSearch.Controls.Add(Me.RichTextBoxResults)
      Me.TabPageXMLSearch.Controls.Add(Me.GroupBoxMethod)
      Me.TabPageXMLSearch.Controls.Add(Me.GroupBoxStyle)
      Me.TabPageXMLSearch.Location = New System.Drawing.Point(4, 22)
      Me.TabPageXMLSearch.Name = "TabPageXMLSearch"
      Me.TabPageXMLSearch.Size = New System.Drawing.Size(512, 582)
      Me.TabPageXMLSearch.TabIndex = 0
      Me.TabPageXMLSearch.Text = "XML Search"
      '
      'DataGridNames
      '
      Me.DataGridNames.DataMember = ""
      Me.DataGridNames.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGridNames.Location = New System.Drawing.Point(24, 288)
      Me.DataGridNames.Name = "DataGridNames"
      Me.DataGridNames.Size = New System.Drawing.Size(448, 264)
      Me.DataGridNames.TabIndex = 21
      '
      'ButtonReset
      '
      Me.ButtonReset.Location = New System.Drawing.Point(320, 256)
      Me.ButtonReset.Name = "ButtonReset"
      Me.ButtonReset.TabIndex = 20
      Me.ButtonReset.Text = "Reset"
      '
      'GroupBoxMethod
      '
      Me.GroupBoxMethod.Location = New System.Drawing.Point(16, 11)
      Me.GroupBoxMethod.Name = "GroupBoxMethod"
      Me.GroupBoxMethod.Size = New System.Drawing.Size(488, 48)
      Me.GroupBoxMethod.TabIndex = 19
      Me.GroupBoxMethod.TabStop = False
      Me.GroupBoxMethod.Text = "Search Method"
      '
      'GroupBoxStyle
      '
      Me.GroupBoxStyle.Controls.Add(Me.RadioButtonDocument)
      Me.GroupBoxStyle.Controls.Add(Me.RadioButtonRPC)
      Me.GroupBoxStyle.Location = New System.Drawing.Point(384, 121)
      Me.GroupBoxStyle.Name = "GroupBoxStyle"
      Me.GroupBoxStyle.Size = New System.Drawing.Size(120, 88)
      Me.GroupBoxStyle.TabIndex = 18
      Me.GroupBoxStyle.TabStop = False
      Me.GroupBoxStyle.Text = "SOAP Style"
      '
      'RadioButtonDocument
      '
      Me.RadioButtonDocument.Checked = True
      Me.RadioButtonDocument.Location = New System.Drawing.Point(7, 31)
      Me.RadioButtonDocument.Name = "RadioButtonDocument"
      Me.RadioButtonDocument.Size = New System.Drawing.Size(104, 16)
      Me.RadioButtonDocument.TabIndex = 17
      Me.RadioButtonDocument.TabStop = True
      Me.RadioButtonDocument.Text = "Document Style"
      '
      'RadioButtonRPC
      '
      Me.RadioButtonRPC.Location = New System.Drawing.Point(7, 55)
      Me.RadioButtonRPC.Name = "RadioButtonRPC"
      Me.RadioButtonRPC.Size = New System.Drawing.Size(88, 16)
      Me.RadioButtonRPC.TabIndex = 16
      Me.RadioButtonRPC.Text = "RPC Style"
      '
      'FormSearch
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(544, 653)
      Me.Controls.Add(Me.TabControlWebServices)
      Me.Controls.Add(Me.ButtonExit)
      Me.Name = "FormSearch"
      Me.Text = "ABR AML Search"
      Me.GroupStates.ResumeLayout(False)
      Me.GroupBox1.ResumeLayout(False)
      Me.TabControlWebServices.ResumeLayout(False)
      Me.TabPageXMLSearch.ResumeLayout(False)
      CType(Me.DataGridNames, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBoxStyle.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region
#Region " Window Events Handler"
   '-----------------------------------------------------------------------------------------------
   ' Default is Search by ABN so disable name search selection criteria when the form loads
   '-----------------------------------------------------------------------------------------------
   Private Sub FormSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      disableControls()
      For Each FormControl As Control In Me.TabPageXMLSearch.Controls
         If TypeOf (FormControl) Is System.Windows.Forms.TextBox Then
            initialControlValue.Add(FormControl.Text)
         End If
      Next
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' If Search by ABN, disable name search controls
   '-----------------------------------------------------------------------------------------------
   Private Sub RadioButtonABN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonABN.CheckedChanged
      disableControls()
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' If Search by ASIC Number, disable name search controls
   '-----------------------------------------------------------------------------------------------
   Private Sub RadioButtonASIC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonASIC.CheckedChanged
      disableControls()
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' If Search by Names, enable name search controls
   '-----------------------------------------------------------------------------------------------
   Private Sub RadioButtonName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonName.CheckedChanged
      enableControls()
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Initiate the search
   '-----------------------------------------------------------------------------------------------
   Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click

      Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
      Me.RichTextBoxResults.Visible = True
      Me.DataGridNames.Visible = False
      Try
         If Me.CheckBoxProxy.Checked Then
            UseStronglyTypedSearch()
         Else
            UseHttpSearch(Me.RadioButtonRPC.Checked)
         End If
      Catch exp As Exception
         MsgBox(exp.Message)
      End Try
      Me.Cursor = System.Windows.Forms.Cursors.Default
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Exit the program
   '-----------------------------------------------------------------------------------------------
   Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
      Me.Close()
   End Sub
#End Region
   '-----------------------------------------------------------------------------------------------
   ' Search ABRpublic using the web service proxies. See Web References for the project
   '-----------------------------------------------------------------------------------------------
   Private Sub UseStronglyTypedSearch()
      If Me.RadioButtonRPC.Checked Then
         UseStronglyTypedRPCSearch()
      Else
         UseStronglyTypedDocumentSearch()
      End If
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Search ABRpublic using the web service proxies use Document style SOAP (.NET default)
   '-----------------------------------------------------------------------------------------------
   Private Sub UseStronglyTypedDocumentSearch()
      Dim Search As ProxyXMLSearch = New ProxyXMLSearch
      Dim SearchPayload As WebReference.Payload
      Dim Display As New ResultsInterpreter
      Try
         If Me.RadioButtonABN.Checked Then
            ' SearchPayload response will contain a Buisness Entity when searching By ABN
            SearchPayload = Search.ABNSearch(Me.TextBoxCriteria.Text, SetFlag(Me.CheckBoxHistory.Checked), Me.TextBoxGUID.Text)
         ElseIf Me.RadioButtonASIC.Checked Then
            ' SearchPayload response will contain a Buisness Entity when searching by ASIC
            SearchPayload = Search.ASICSearch(Me.TextBoxCriteria.Text, SetFlag(Me.CheckBoxHistory.Checked), Me.TextBoxGUID.Text)
         ElseIf Me.RadioButtonName.Checked Then
            ' SearchPayload response will contain a Search Results List when searching By name
            SearchPayload = Search.NameSearch(Me.TextBoxGUID.Text, InitialiseNameSearchCriteria())
         End If
         Me.RichTextBoxResults.Text = Display.SerialisePayload(SearchPayload)
      Catch exp As Exception
         MsgBox("Error: " & vbNewLine & exp.Message)
      End Try
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Search ABRpublic using the web service proxies use RPC style SOAP (java, php)
   ' Serialising the Payload does not work for RPC without modifing the information generated from 
   ' the web reference file. Therefore just pull out some of the information for display.
   '-----------------------------------------------------------------------------------------------
   Private Sub UseStronglyTypedRPCSearch()
      Dim Search As ProxyXMLRPCSearch = New ProxyXMLRPCSearch
      Dim SearchPayload As WebReferenceRPC.Payload
      Dim Display As New ResultsInterpreter
      Try
         ' SearchPayload response will contain a Buisness Entity when searching by ABN
         If Me.RadioButtonABN.Checked Then
            SearchPayload = Search.ABNSearch(Me.TextBoxCriteria.Text, SetFlag(Me.CheckBoxHistory.Checked), Me.TextBoxGUID.Text)
            Me.RichTextBoxResults.Text = Display.DisplayEntityDetailsUingProxyClasses(SearchPayload)
         ElseIf Me.RadioButtonASIC.Checked Then
            ' SearchPayload response will contain a Buisness Entity when searching by ACN
            SearchPayload = Search.ASICSearch(Me.TextBoxCriteria.Text, SetFlag(Me.CheckBoxHistory.Checked), Me.TextBoxGUID.Text)
            Me.RichTextBoxResults.Text = Display.DisplayEntityDetailsUingProxyClasses(SearchPayload)
         ElseIf Me.RadioButtonName.Checked Then
            ' SearchPayload response will contain a Search Results List when searching By name
            SearchPayload = Search.NameSearch(Me.TextBoxGUID.Text, InitialiseRPCNameSearchCriteria())
            Me.RichTextBoxResults.Text = Display.DisplayEntityDetailsUingProxyClasses(SearchPayload)
         End If
         'Me.RichTextBoxResults.Text = Display.SerialisePayload(SearchPayload)
      Catch exp As Exception
         MsgBox("Error: " & vbNewLine & exp.Message)
      End Try
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Search ABRpublic without using the web service proxies. 
   '-----------------------------------------------------------------------------------------------
   Private Sub UseHttpSearch(ByVal rpc As Boolean)
      Dim SearchPayload As String
      Dim Search As httpXMLSearch
      If rpc Then
         Search = New httpXMLRPCSearch
      Else
         Search = New httpXMLDocumentSearch
      End If
      Try
         If Me.RadioButtonABN.Checked Then
            SearchPayload = Search.ABNSearch(Me.TextBoxCriteria.Text, SetFlag(Me.CheckBoxHistory.Checked), Me.TextBoxGUID.Text)
            Me.RichTextBoxResults.Text = SearchPayload
         ElseIf Me.RadioButtonASIC.Checked Then
            SearchPayload = Search.ASICSearch(Me.TextBoxCriteria.Text, SetFlag(Me.CheckBoxHistory.Checked), Me.TextBoxGUID.Text)
            Me.RichTextBoxResults.Text = SearchPayload
         Else
            SearchPayload = Search.NameSearch(Me.TextBoxCriteria.Text, _
                                              SetFlag(Me.CheckBoxACT.Checked), _
                                              SetFlag(Me.CheckBoxNSW.Checked), _
                                              SetFlag(Me.CheckBoxNT.Checked), _
                                              SetFlag(Me.CheckBoxQLD.Checked), _
                                              SetFlag(Me.CheckBoxTAS.Checked), _
                                              SetFlag(Me.CheckBoxVIC.Checked), _
                                              SetFlag(Me.CheckBoxWA.Checked), _
                                              SetFlag(Me.CheckBoxSA.Checked), _
                                              Me.TextBoxPostcode.Text, _
                                              SetFlag(Me.CheckBoxLegal.Checked), _
                                              SetFlag(Me.CheckBoxTrading.Checked), _
                                              Me.TextBoxGUID.Text)
            If rpc Then
               Me.RichTextBoxResults.Text = SearchPayload
            Else
               displayNamesInGrid(SearchPayload)
            End If

         End If
      Catch exp As Exception
         Throw
      End Try
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Extract names from the xml string
   '-----------------------------------------------------------------------------------------------
   Private Sub displayNamesInGrid(ByVal payload As String)
      Dim NamesDataTable As DataTable
      Dim parser As New XMLMessageParser(payload)
      Me.RichTextBoxResults.Visible = False
      Me.DataGridNames.Visible = True
      Try
         NamesDataTable = parser.GetNames()
         Me.DataGridNames.DataSource = NamesDataTable
         Me.DataGridNames.Refresh()
      Catch exp As Exception
         Throw
      End Try
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Initialise the name search criteria object with the selection criteria entered on the screen
   '-----------------------------------------------------------------------------------------------
   Private Function InitialiseNameSearchCriteria() As WebReference.ExternalRequestNameSearch
      Dim Criteria As WebReference.ExternalRequestNameSearch = New WebReference.ExternalRequestNameSearch
      Dim Filters As New WebReference.ExternalRequestFilters
      Criteria.name = Me.TextBoxCriteria.Text
      Filters.nameType = New WebReference.ExternalRequestFilterNameType
      Filters.stateCode = New WebReference.ExternalRequestFilterStateCode
      Filters.postcode = Me.TextBoxPostcode.Text
      Filters.nameType.legalName = SetFlag(Me.CheckBoxLegal.Checked)
      Filters.nameType.tradingName = SetFlag(Me.CheckBoxTrading.Checked)
      Filters.stateCode.ACT = SetFlag(Me.CheckBoxACT.Checked)
      Filters.stateCode.NSW = SetFlag(Me.CheckBoxNSW.Checked)
      Filters.stateCode.NT = SetFlag(Me.CheckBoxNT.Checked)
      Filters.stateCode.QLD = SetFlag(Me.CheckBoxQLD.Checked)
      Filters.stateCode.SA = SetFlag(Me.CheckBoxSA.Checked)
      Filters.stateCode.TAS = SetFlag(Me.CheckBoxTAS.Checked)
      Filters.stateCode.VIC = SetFlag(Me.CheckBoxVIC.Checked)
      Filters.stateCode.WA = SetFlag(Me.CheckBoxWA.Checked)
      Criteria.filters = Filters
      Return Criteria

   End Function
   '-----------------------------------------------------------------------------------------------
   ' Initialise the name search criteria object with the selection criteria entered on the screen
   '-----------------------------------------------------------------------------------------------
   Private Function InitialiseRPCNameSearchCriteria() As WebReferenceRPC.ExternalRequestNameSearch
      Dim Criteria As WebReferenceRPC.ExternalRequestNameSearch = New WebReferenceRPC.ExternalRequestNameSearch
      Dim Filters As New WebReferenceRPC.ExternalRequestFilters
      Criteria.Name = Me.TextBoxCriteria.Text
      Filters.NameType = New WebReferenceRPC.ExternalRequestFilterNameType
      Filters.StateCode = New WebReferenceRPC.ExternalRequestFilterStateCode
      Filters.Postcode = Me.TextBoxPostcode.Text
      Filters.NameType.LegalName = SetFlag(Me.CheckBoxLegal.Checked)
      Filters.NameType.TradingName = SetFlag(Me.CheckBoxTrading.Checked)
      Filters.StateCode.ACT = SetFlag(Me.CheckBoxACT.Checked)
      Filters.StateCode.NSW = SetFlag(Me.CheckBoxNSW.Checked)
      Filters.StateCode.NT = SetFlag(Me.CheckBoxNT.Checked)
      Filters.StateCode.QLD = SetFlag(Me.CheckBoxQLD.Checked)
      Filters.StateCode.SA = SetFlag(Me.CheckBoxSA.Checked)
      Filters.StateCode.TAS = SetFlag(Me.CheckBoxTAS.Checked)
      Filters.StateCode.VIC = SetFlag(Me.CheckBoxVIC.Checked)
      Filters.StateCode.WA = SetFlag(Me.CheckBoxWA.Checked)
      Criteria.Filters = Filters
      Return Criteria

   End Function
   '-----------------------------------------------------------------------------------------------
   ' Convert boolean values to Y or N as this is what the web service expects
   '-----------------------------------------------------------------------------------------------
   Private Function SetFlag(ByVal checked As Boolean) As String
      If checked Then
         Return YES
      Else
         Return NO
      End If
   End Function
   '-----------------------------------------------------------------------------------------------
   ' Disable name search controls if search by name not selected
   '-----------------------------------------------------------------------------------------------
   Private Sub disableControls()
      Me.CheckBoxACT.Enabled = False
      Me.CheckBoxLegal.Enabled = False
      Me.CheckBoxNSW.Enabled = False
      Me.CheckBoxNT.Enabled = False
      Me.CheckBoxQLD.Enabled = False
      Me.CheckBoxSA.Enabled = False
      Me.CheckBoxTAS.Enabled = False
      Me.CheckBoxTrading.Enabled = False
      Me.CheckBoxVIC.Enabled = False
      Me.CheckBoxWA.Enabled = False
      Me.TextBoxPostcode.Enabled = False
      Me.CheckBoxHistory.Enabled = True
      Me.RichTextBoxResults.Visible = True
      Me.DataGridNames.Visible = False
      SetTextBoxDefaultValues()
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Enable name search controls if search by name selected
   '-----------------------------------------------------------------------------------------------
   Private Sub enableControls()
      Me.CheckBoxACT.Enabled = True
      Me.CheckBoxLegal.Enabled = True
      Me.CheckBoxNSW.Enabled = True
      Me.CheckBoxNT.Enabled = True
      Me.CheckBoxQLD.Enabled = True
      Me.CheckBoxSA.Enabled = True
      Me.CheckBoxTAS.Enabled = True
      Me.CheckBoxTrading.Enabled = True
      Me.CheckBoxVIC.Enabled = True
      Me.CheckBoxWA.Enabled = True
      Me.TextBoxPostcode.Enabled = True
      Me.CheckBoxHistory.Enabled = False
      Me.RichTextBoxResults.Visible = False
      Me.DataGridNames.Visible = True
      SetTextBoxDefaultValues()
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Initialises the tex box with default values
   '-----------------------------------------------------------------------------------------------
   Private Sub SetTextBoxDefaultValues()
      If Me.RadioButtonName.Checked Then
         Me.TextBoxCriteria.Text = "industry, tourism and resources"
      ElseIf Me.RadioButtonASIC.Checked Then
         Me.TextBoxCriteria.Text = "080036693"
      Else
         Me.TextBoxCriteria.Text = "51835430479"
      End If
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Enable name search controls if search by name selected
   '-----------------------------------------------------------------------------------------------
   Private Sub initialiseControls()
      Me.CheckBoxACT.Checked = True
      Me.CheckBoxLegal.Checked = True
      Me.CheckBoxNSW.Checked = True
      Me.CheckBoxNT.Checked = True
      Me.CheckBoxQLD.Checked = True
      Me.CheckBoxSA.Checked = True
      Me.CheckBoxTAS.Checked = True
      Me.CheckBoxTrading.Checked = True
      Me.CheckBoxVIC.Checked = True
      Me.CheckBoxWA.Checked = True
      Me.CheckBoxHistory.Checked = False
      Me.RichTextBoxResults.Visible = False
      Me.DataGridNames.Visible = True
   End Sub
   '-----------------------------------------------------------------------------------------------
   ' Initialise the form as a start up
   '-----------------------------------------------------------------------------------------------
   Private Sub ButtonReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReset.Click
      Dim Index As Integer = 1
      For Each FormControl As Control In Me.TabPageXMLSearch.Controls
         If TypeOf (FormControl) Is System.Windows.Forms.TextBox Then
            FormControl.Text = CType(initialControlValue(Index), String)
            Index = Index + 1
         End If
      Next
      initialiseControls()
   End Sub

End Class
