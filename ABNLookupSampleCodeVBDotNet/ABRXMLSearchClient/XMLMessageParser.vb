Imports System.Xml
Imports System.IO

Public Class XMLMessageParser
   ' Log for the message parser
   Private _xmlDoc As XmlDocument
   Public Property XmlDoc() As XmlDocument
      Get
         If _xmlDoc Is Nothing Then
            _xmlDoc = New XmlDocument
         End If
         Return _xmlDoc
      End Get
      Set(ByVal value As XmlDocument)
         _xmlDoc = value
      End Set
   End Property
   Private _namespaceManager As XmlNamespaceManager
   Public Property NamespaceManager() As XmlNamespaceManager
      Get
         If _namespaceManager Is Nothing Then
            initialiseNamespace()
         End If
         Return _namespaceManager
      End Get
      Set(ByVal value As XmlNamespaceManager)
         _namespaceManager = value
      End Set
   End Property
   Public Sub New(ByVal xml As String)
      LoadXML(xml)
   End Sub
   Public Sub LoadXML(ByVal xml As String)
      Try
         XmlDoc.LoadXml(xml)
      Catch exp As Exception
         Throw
      End Try
   End Sub
   '---------------------------------------------------------------------------------------
   ' Get the name details from the dom
   '---------------------------------------------------------------------------------------
   Public Function GetNames() As DataTable
      Dim MatchingName As DataRow
      Dim MatchingNames As DataTable = CreateNewNamesDataTable()
      Dim Names As XmlNodeList
      Dim SoapException As XmlNode
      Try
         SoapException = XmlDoc.SelectSingleNode(XPath.LocationSOAP(XPath.Path.Exception), NamespaceManager)
         If SoapException Is Nothing Then
            Names = XmlDoc.SelectNodes(XPath.LocationSOAP(XPath.Path.commonRoot), NamespaceManager)
            For Each Name As XmlNode In Names
               MatchingName = MatchingNames.NewRow
               MatchingName("ABN") = getNodeValue(Name, XPath.LocationSOAP(XPath.Path.abnValue))
               MatchingName("Entity Name") = getNodeValue(Name, XPath.LocationSOAP(XPath.Path.name))
               MatchingName("State") = getNodeValue(Name, XPath.LocationSOAP(XPath.Path.postcode))
               MatchingName("Postcode") = getNodeValue(Name, XPath.LocationSOAP(XPath.Path.state))
               MatchingName("Score") = getNodeValue(Name, XPath.LocationSOAP(XPath.Path.score))
               MatchingNames.Rows.Add(MatchingName)
            Next
         Else
            Throw New System.Exception("Exception from Soap Search")
         End If
      Catch exp As Exception
         Throw exp
      End Try
      Return MatchingNames
   End Function
   '---------------------------------------------------------------------------------------
   ' Create  data table for the names collection 
   '---------------------------------------------------------------------------------------
   Private Function CreateNewNamesDataTable() As DataTable
      Dim MatchingNames As New DataTable
      MatchingNames = New DataTable
      MatchingNames.Columns.Add("ABN")
      MatchingNames.Columns.Add("Entity Name")
      MatchingNames.Columns.Add("State")
      MatchingNames.Columns.Add("Postcode")
      MatchingNames.Columns.Add("Score")
      Return MatchingNames
   End Function
   '---------------------------------------------------------------------------------------
   ' Add namespace to the namespace manager
   '---------------------------------------------------------------------------------------
   Private Sub initialiseNamespace()
      Const _soap As String = "SOAP"
      Const _namepaceAlias As String = "abn"
      Const _namepace As String = "http://abr.business.gov.au/ABRXMLSearch/"
      Me.NamespaceManager = New XmlNamespaceManager(Me.XmlDoc.NameTable)
      Me.NamespaceManager.AddNamespace(_namepaceAlias, _namepace)
   End Sub
   '---------------------------------------------------------------------------------------
   ' Add namespace to the namespace manager
   '---------------------------------------------------------------------------------------
   Private Function getNodeValue(ByVal node As XmlNode, ByVal xPath As String) As String
      Dim Element As XmlNode
      Element = node.SelectSingleNode(xPath, NamespaceManager)
      If Not Element Is Nothing Then
         Return Element.InnerText
      Else
         Return ""
      End If
   End Function

End Class
