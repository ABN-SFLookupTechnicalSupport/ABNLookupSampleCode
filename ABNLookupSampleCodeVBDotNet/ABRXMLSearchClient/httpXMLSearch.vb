Imports System.Net
Imports System.IO
Imports System.Configuration
'---------------------------------------------------------------------------------------------
' Non-Strongly Typed Search - Builds the SOAP message as a string. 
'---------------------------------------------------------------------------------------------
Public MustInherit Class httpXMLSearch
   Public Enum StyleEnum
      RPC = 1
      Document = 2
   End Enum
   '-----------------------------------------------------------------------------------------------
   ' RPC or Document style of SOAP message
   '-----------------------------------------------------------------------------------------------
   Private _rpcStyle As Boolean
   Protected Property RPCStyle() As Boolean
      Get
         Return _rpcStyle
      End Get
      Set(ByVal Value As Boolean)
         _rpcStyle = Value
      End Set
   End Property
   '---------------------------------------------------------------------------------------------
   ' Indicates whether RPC or document style
   '---------------------------------------------------------------------------------------------
   Protected MustOverride ReadOnly Property StylePrefix() As String

   '---------------------------------------------------------------------------------------------
   ' SOAP string depends on whether using RPC or document style
   '---------------------------------------------------------------------------------------------
   Protected MustOverride Function BuildABNSOAPMessage(ByVal searchString As String, _
                                          ByVal history As String, _
                                          ByVal guid As String) As String

   '---------------------------------------------------------------------------------------------
   ' SOAP string depends on whether using RPC or document style
   '---------------------------------------------------------------------------------------------
   Protected MustOverride Function BuildASICSOAPMessage(ByVal searchString As String, _
                                          ByVal history As String, _
                                          ByVal guid As String) As String

   '---------------------------------------------------------------------------------------------
   ' SOAP string depends on whether using RPC or document style
   '---------------------------------------------------------------------------------------------
   Protected MustOverride Function BuildNameSOAPMessage(ByVal searchString As String, _
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
   '---------------------------------------------------------------------------------------------
   ' Search by an ABN
   '---------------------------------------------------------------------------------------------
   Public Function ABNSearch(ByVal searchString As String, _
                             ByVal history As String, _
                             ByVal guid As String) As String

      Dim SoapMessage As String = BuildABNSOAPMessage(searchString, history, guid)
      Dim SoapAction As String = ConfigurationSettings.AppSettings(StylePrefix & ".SoapAction.ABNSearch")
      Dim WebRequest As HttpWebRequest
      Try
         WebRequest = SetRequestHeader(SoapMessage, SoapAction)
         Send(WebRequest, SoapMessage)
         Return ReadResponse(WebRequest)
      Catch exp As Exception
         Throw
      Finally
         WebRequest.Abort()
      End Try

   End Function
   '---------------------------------------------------------------------------------------------
   ' Search by an ASIC number
   '---------------------------------------------------------------------------------------------
   Public Function ASICSearch(ByVal searchString As String, _
                              ByVal history As String, _
                              ByVal guid As String) As String

      Dim SoapMessage As String = BuildASICSOAPMessage(searchString, history, guid)
      Dim SoapAction As String = ConfigurationSettings.AppSettings(StylePrefix & ".SoapAction.ASICSearch")
      Dim WebRequest As HttpWebRequest
      Try
         WebRequest = SetRequestHeader(SoapMessage, SoapAction)
         Send(WebRequest, SoapMessage)
         Return ReadResponse(WebRequest)

      Catch exp As Exception
         Throw
      End Try

   End Function
   '---------------------------------------------------------------------------------------------
   ' Search by a Name
   '---------------------------------------------------------------------------------------------
   Public Function NameSearch(ByVal searchString As String, _
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

      Dim SoapMessage As String = BuildNameSOAPMessage(searchString, ACT, NSW, NT, QLD, TAS, VIC, WA, SA, _
                                                       postcode, legalName, tradingName, guid)
      Dim SoapAction As String = ConfigurationSettings.AppSettings(StylePrefix & ".SoapAction.NameSearch")
      Dim WebRequest As HttpWebRequest
      Try
         WebRequest = SetRequestHeader(SoapMessage, SoapAction)
         Send(WebRequest, SoapMessage)
         Return ReadResponse(WebRequest)
      Catch exp As Exception
         Throw
      End Try

   End Function
   '---------------------------------------------------------------------------------------------
   ' Set the request header details
   '---------------------------------------------------------------------------------------------
   Private Function SetRequestHeader(ByVal soapMessage As String, _
                                     ByVal soapAction As String) As HttpWebRequest

      Dim WebRequest As HttpWebRequest
      WebRequest = CType(WebRequest.Create(ConfigurationSettings.AppSettings(StylePrefix & ".ABRXMLSearchURL")), HttpWebRequest)
      Try
         WebRequest.Timeout = Integer.Parse(ConfigurationSettings.AppSettings("SoapRequestTimeoutInMilliseconds"))
      Catch
         WebRequest.Timeout = 100000
      End Try
      WebRequest.Headers.Add("SOAPAction", soapAction)
      WebRequest.ContentType = "text/xml; charset=utf-8"
      WebRequest.ContentLength = soapMessage.Length
      WebRequest.Method = "POST"
      Return WebRequest

   End Function

   '---------------------------------------------------------------------------------------------
   ' issue the request to the web service
   '---------------------------------------------------------------------------------------------
   Private Sub Send(ByVal webRequest As HttpWebRequest, ByVal soapMessage As String)
      Dim ResponseContents As String
      Dim StreamReader As StreamReader
      Dim StreamWriter As StreamWriter

      StreamWriter = New StreamWriter(webRequest.GetRequestStream())
      StreamWriter.Write(soapMessage)
      StreamWriter.Flush()
      StreamWriter.Close()
   End Sub
   '---------------------------------------------------------------------------------------------
   ' Return the response from the request as a string 
   '---------------------------------------------------------------------------------------------
   Private Function ReadResponse(ByVal webRequest As HttpWebRequest) As String
      Dim WebResponse As HttpWebResponse
      Dim StreamReader As StreamReader
      Dim ResponseContents As String
      Try
         WebResponse = CType(webRequest.GetResponse(), HttpWebResponse)
         StreamReader = New StreamReader(WebResponse.GetResponseStream())
         ResponseContents = StreamReader.ReadToEnd
         Return ResponseContents
      Catch exp As Exception
         Throw
      Finally
         StreamReader.Close()
         WebResponse.Close()
      End Try

   End Function
End Class
