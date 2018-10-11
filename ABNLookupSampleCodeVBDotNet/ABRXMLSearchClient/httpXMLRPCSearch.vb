Imports System.Net
Imports System.IO
'-----------------------------------------------------------------------------------------------
' Non-Strongly Typed Search - Builds the SOAP message as a string. 
'-----------------------------------------------------------------------------------------------
Public Class httpXMLRPCSearch : Inherits httpXMLSearch
    '-----------------------------------------------------------------------------------------------
    ' Prefix in config file
    '-----------------------------------------------------------------------------------------------
    Protected Overrides ReadOnly Property StylePrefix() As String
        Get
            Return StyleEnum.RPC.ToString()
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
              "xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" " & _
              "xmlns:tns=""http://abr.business.gov.au/ABRXMLSearchRPC/"" " & _
              "xmlns:types=""http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes"" " & _
              "xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & _
              "<soap:Body soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" & _
              "<tns:ABRSearchByABN> " & _
              "<searchString xsi:type=""xsd:string"">" & searchString & "</searchString>" & _
              "<includeHistoricalDetails xsi:type=""xsd:string"">" & history & "</includeHistoricalDetails>" & _
              "<authenticationGuid xsi:type=""xsd:string"">" & guid & "</authenticationGuid>" & _
              "</tns:ABRSearchByABN>" & _
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
                 "xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" " & _
                 "xmlns:tns=""http://abr.business.gov.au/ABRXMLSearchRPC/"" " & _
                 "xmlns:types=""http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes"" " & _
                 "xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & _
                "<soap:Body soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" & _
                "<tns:ABRSearchByASIC> " & _
                "<searchString xsi:type=""xsd:string"">" & searchString & "</searchString>" & _
                "<includeHistoricalDetails xsi:type=""xsd:string"">" & history & "</includeHistoricalDetails>" & _
                "<authenticationGuid xsi:type=""xsd:string"">" & guid & "</authenticationGuid>" & _
                "</tns:ABRSearchByASIC>" & _
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
              "xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" " & _
              "xmlns:tns=""http://abr.business.gov.au/ABRXMLSearchRPC/"" " & _
              "xmlns:types=""http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes"" " & _
              "xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" & _
              "<soap:Body soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" & _
              "<tns:ABRSearchByName>" & _
              "<externalNameSearch href=""#id1""/>" & _
              "<authenticationGuid xsi:type=""xsd:string"">" & guid & "</authenticationGuid>" & _
              "</tns:ABRSearchByName>" & _
              "<tns:ExternalRequestNameSearch id=""id1"" xsi:type=""tns:ExternalRequestNameSearch"">" & _
              "<AuthenticationGUID xsi:type=""xsd:string"">" & guid & "</AuthenticationGUID>" & _
              "<Name xsi:type=""xsd:string"">" & EncodeXML(searchString) & "</Name>" & _
              "<Filters href=""#id2""/>" & _
              "</tns:ExternalRequestNameSearch>" & _
              "<tns:ExternalRequestFilters id=""id2"" xsi:type=""tns:ExternalRequestFilters"" > " & _
              "<NameType href=""#id3""/>" & _
              "<Postcode xsi:type=""xsd:string"">" & postcode.Trim & "</Postcode>" & _
              "<StateCode href=""#id4""/>" & _
              "</tns:ExternalRequestFilters>" & _
              "<tns:ExternalRequestFilterNameType id=""id3"" xsi:type=""tns:ExternalRequestFilterNameType"">" & _
              "<TradingName xsi:type=""xsd:string"">" & tradingName & "</TradingName>" & _
              "<LegalName xsi:type=""xsd:string"">" & legalName & "</LegalName>" & _
              "</tns:ExternalRequestFilterNameType>" & _
              "<tns:ExternalRequestFilterStateCode id=""id4"" xsi:type=""tns:ExternalRequestFilterStateCode"">" & _
              "<QLD xsi:type=""xsd:string"">" & QLD & "</QLD>" & _
              "<NT xsi:type=""xsd:string"">" & NT & "</NT>" & _
              "<SA xsi:type=""xsd:string"">" & SA & "</SA>" & _
              "<WA xsi:type=""xsd:string"">" & WA & "</WA>" & _
              "<VIC xsi:type=""xsd:string"">" & VIC & "</VIC>" & _
              "<ACT xsi:type=""xsd:string"">" & ACT & "</ACT>" & _
              "<TAS xsi:type=""xsd:string"">" & TAS & "</TAS>" & _
              "<NSW xsi:type=""xsd:string"">" & NSW & "</NSW>" & _
              "</tns:ExternalRequestFilterStateCode>" & _
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
