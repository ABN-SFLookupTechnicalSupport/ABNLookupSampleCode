Imports ABRXMLSearchClient.WebReferenceRPC
'Imports ABRXMLSearchClient.au.gov.business.abr

' Strongly Typed Search - Uses the web service proxy classes to search ABRpublic. 
Public Class ProxyXMLRPCSearch
   '-----------------------------------------------------------------------------------------------
   ' Search by ABN
   '-----------------------------------------------------------------------------------------------
    Public Function ABNSearch(ByVal searchString As String, _
                              ByVal history As String, _
                              ByVal guid As String) As WebReferenceRPC.Payload

        Dim ABRSearch As WebReferenceRPC.ABRXMLSearchRPC = New WebReferenceRPC.ABRXMLSearchRPC
      Return ABRSearch.ABRSearchByABN(searchString, history, guid)
    End Function
   '-----------------------------------------------------------------------------------------------
   ' Search by ASIC
   '-----------------------------------------------------------------------------------------------
    Public Function ASICSearch(ByVal searchString As String, _
                              ByVal history As String, _
                              ByVal guid As String) As WebReferenceRPC.Payload

        Dim ABRSearch As WebReferenceRPC.ABRXMLSearchRPC = New WebReferenceRPC.ABRXMLSearchRPC
        Return ABRSearch.ABRSearchByASIC(searchString, history, guid)

    End Function
   '-----------------------------------------------------------------------------------------------
   ' Search by Name
   '-----------------------------------------------------------------------------------------------
    Public Function NameSearch(ByVal guid As String, _
                               ByVal criteria As WebReferenceRPC.ExternalRequestNameSearch) As WebReferenceRPC.Payload

        Dim ABRSearch As WebReferenceRPC.ABRXMLSearchRPC = New WebReferenceRPC.ABRXMLSearchRPC
        Return ABRSearch.ABRSearchByName(criteria, guid)
    End Function

End Class
