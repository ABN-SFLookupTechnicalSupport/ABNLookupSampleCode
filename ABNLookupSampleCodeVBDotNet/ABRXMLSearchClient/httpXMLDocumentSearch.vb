Imports System.Net
Imports System.IO
'-----------------------------------------------------------------------------------------------
' Non-Strongly Typed Search - Builds the SOAP message as a string. 
'-----------------------------------------------------------------------------------------------
Public Class httpXMLDocumentSearch : Inherits httpXMLSearch
    '-----------------------------------------------------------------------------------------------
    ' Prefix in config file
    '-----------------------------------------------------------------------------------------------
    Protected Overrides ReadOnly Property StylePrefix() As String
        Get
            Return StyleEnum.Document.ToString()
        End Get
    End Property
    '-----------------------------------------------------------------------------------------------
    ' Return the SOAP message for a search by ABN using RPC style
    '-----------------------------------------------------------------------------------------------
    Protected Overrides Function BuildABNSOAPMessage(ByVal searchString As String, _
                                           ByVal history As String, _
                                           ByVal guid As String) As String


      Return "<?xml version=""1.0"" encoding=""utf-8""?>" & _
               "<soap:Envelope " & _
              "xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" " & _
              "xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" " & _
              "xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & _
              "<soap:Body> " & _
              "<ABRSearchByABN xmlns=""http://abr.business.gov.au/ABRXMLSearch/""> " & _
              "<searchString>" & searchString & "</searchString>" & _
              "<includeHistoricalDetails>" & history & "</includeHistoricalDetails>" & _
              "<authenticationGuid>" & guid & "</authenticationGuid>" & _
              "</ABRSearchByABN>" & _
              "</soap:Body>" & _
              "</soap:Envelope>"

   End Function
   '-----------------------------------------------------------------------------------------------
   ' Return the SOAP message for a search by ASIC
   '-----------------------------------------------------------------------------------------------
   Protected Overrides Function BuildASICSOAPMessage(ByVal searchString As String, _
                                        ByVal history As String, _
                                        ByVal guid As String) As String

      Return "<?xml version=""1.0"" encoding=""utf-8""?>" & _
              "<soap:Envelope " & _
              "xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" " & _
              "xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" " & _
              "xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & _
              "<soap:Body> " & _
              "<ABRSearchByASIC xmlns=""http://abr.business.gov.au/ABRXMLSearch/""> " & _
              "<searchString>" & searchString & "</searchString>" & _
              "<includeHistoricalDetails>" & history & "</includeHistoricalDetails>" & _
              "<authenticationGuid>" & guid & "</authenticationGuid>" & _
              "</ABRSearchByASIC>" & _
              "</soap:Body>" & _
              "</soap:Envelope>"
   End Function
   '-----------------------------------------------------------------------------------------------
   ' Return the SOAP message for a search by Name
   '-----------------------------------------------------------------------------------------------
   Protected Overrides Function BuildNameSOAPMessage(ByVal searchString As String, _
                                        ByVal ACT As String, _
                                        ByVal NSW As String, _
                                        ByVal NT As String, _
                                        ByVal QLD As String, _
                                        ByVal TAS As String, _
                                        ByVal VIC As String, _
                                        ByVal WA As String, _
                                        ByVal SA As String, _
                                        ByVal postcode As String, _
                                        ByVal legalName As String, _
                                        ByVal tradingName As String, _
                                        ByVal guid As String) As String

        Return "<?xml version=""1.0"" encoding=""utf-8""?>" & _
                "<soap:Envelope " & _
                "xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" " & _
                "xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" " & _
                "xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & _
                "<soap:Body> " & _
                "<ABRSearchByName xmlns=""http://abr.business.gov.au/ABRXMLSearch/""> " & _
                "<externalNameSearch>" & _
                "<name>" & EncodeXML(searchString) & "</name>" & _
                "<filters>" & _
                "<stateCode>" & _
                "<ACT>" & ACT & "</ACT>" & _
                "<NSW>" & NSW & "</NSW>" & _
                "<NT>" & NT & "</NT>" & _
                "<QLD>" & QLD & "</QLD>" & _
                "<TAS>" & TAS & "</TAS>" & _
                "<VIC>" & VIC & "</VIC>" & _
                "<WA>" & WA & "</WA>" & _
                "<SA>" & SA & "</SA>" & _
                "</stateCode>" & _
                "<postcode>" & postcode & "</postcode>" & _
                "<nameType>" & _
                "<legalName>" & legalName & "</legalName>" & _
                "<tradingName>" & tradingName & "</tradingName>" & _
                "</nameType>" & _
                "</filters>" & _
                "</externalNameSearch>" & _
                "<authenticationGuid>" & guid & "</authenticationGuid>" & _
                "</ABRSearchByName>" & _
                "</soap:Body>" & _
                "</soap:Envelope>"
    End Function
    '-----------------------------------------------------------------------------------------------
    ' Encodes a string as XML
    '-----------------------------------------------------------------------------------------------
    Private Function EncodeXML(ByVal searchString As String) As String
        Dim EncodedXML As String
        Dim Writer As New StringWriter
        Dim XMLWriter As New Xml.XmlTextWriter(Writer)
        XMLWriter.WriteString(searchString)
        Dim Reader As New StringReader(Writer.ToString)
        EncodedXML = Reader.ReadToEnd
        XMLWriter.Close()
        Writer.Close()
        Return EncodedXML
    End Function
End Class
