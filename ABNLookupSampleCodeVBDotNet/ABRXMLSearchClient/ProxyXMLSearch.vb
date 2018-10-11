Imports ABRXMLSearchClient.WebReference
'Imports ABRXMLSearchClient.au.gov.business.abr

' Strongly Typed Search - Uses the web service proxy classes to search ABRpublic. 
Public Class ProxyXMLSearch
   '-----------------------------------------------------------------------------------------------
   ' Search by ABN
   '-----------------------------------------------------------------------------------------------
    Public Function ABNSearch(ByVal searchString As String, _
                              ByVal history As String, _
                              ByVal guid As String) As WebReference.Payload

        Dim ABRSearch As WebReference.ABRXMLSearch = New WebReference.ABRXMLSearch
        Return ABRSearch.ABRSearchByABN(searchString, history, guid)
    End Function
    '-----------------------------------------------------------------------------------------------
    ' Search by ASIC
    '-----------------------------------------------------------------------------------------------
    Public Function ASICSearch(ByVal searchString As String, _
                              ByVal history As String, _
                              ByVal guid As String) As WebReference.Payload

        Dim ABRSearch As WebReference.ABRXMLSearch = New WebReference.ABRXMLSearch
        Return ABRSearch.ABRSearchByASIC(searchString, history, guid)

    End Function
    '-----------------------------------------------------------------------------------------------
    ' Search by Name
    '-----------------------------------------------------------------------------------------------
    Public Function NameSearch(ByVal guid As String, _
                               ByVal criteria As ExternalRequestNameSearch) As WebReference.Payload

        Dim ABRSearch As WebReference.ABRXMLSearch = New WebReference.ABRXMLSearch
        Return ABRSearch.ABRSearchByName(criteria, guid)
    End Function

End Class
