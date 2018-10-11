Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Public Class ResultsInterpreter
   '-----------------------------------------------------------------------------------------------
   ' Return payload as an XML String
   '-----------------------------------------------------------------------------------------------
   Public Function SerialisePayload(ByVal searchPayload As WebReference.Payload) As String
      Try
         Dim XmlStream As MemoryStream = New MemoryStream
         Dim XmlReader As StreamReader = New StreamReader(XmlStream)
         Dim Serializer As XmlSerializer = New XmlSerializer(GetType(WebReference.Payload))
         Serializer.Serialize(XmlStream, searchPayload)
         XmlStream.Seek(0, IO.SeekOrigin.Begin)
         Return XmlReader.ReadToEnd()
      Catch exp As Exception
         Throw
      End Try

   End Function
   '-----------------------------------------------------------------------------------------------
   ' Return payload as an XML String
   '-----------------------------------------------------------------------------------------------
   Public Function SerialisePayload(ByVal searchPayload As WebReferenceRPC.Payload) As String
      Try
         Dim XmlStream As MemoryStream = New MemoryStream
         Dim XmlReader As StreamReader = New StreamReader(XmlStream)
         Dim Serializer As XmlSerializer = New XmlSerializer(GetType(WebReferenceRPC.Payload))
         Serializer.Serialize(XmlStream, searchPayload)
         XmlStream.Seek(0, IO.SeekOrigin.Begin)
         Return XmlReader.ReadToEnd()
      Catch exp As Exception
         Throw
      End Try
   End Function
   '-----------------------------------------------------------------------------------------------
   ' The SearchPayload response will contain either Buisness Entity, a Search Results List 
   'or an Exception. 
   '-----------------------------------------------------------------------------------------------
   Public Function DisplayEntityDetailsUingProxyClasses(ByVal searchPayload As WebReferenceRPC.Payload) As String
      Try
         If TypeOf searchPayload.Response.ResponseBody Is WebReferenceRPC.ResponseBusinessEntity Then
            Return DisplayBusinessEntityDetails(searchPayload)
         ElseIf TypeOf searchPayload.Response.ResponseBody Is WebReferenceRPC.ResponseSearchResultsList Then
            Return DisplayList(searchPayload)
         ElseIf TypeOf searchPayload.Response.ResponseBody Is WebReferenceRPC.ResponseException Then
            Return DisplayException(searchPayload)
         Else
            Return "Type returned from DisplayEntityDetailsUingProxyClasses in ResultsInterpreter class is not known"
         End If
      Catch exp As Exception
         Throw
      End Try
   End Function
   '-----------------------------------------------------------------------------------------------
   ' Display when SearchPayload is a Buisness Entity
   '-----------------------------------------------------------------------------------------------
   Public Function DisplayBusinessEntityDetails(ByVal searchPayload As WebReferenceRPC.Payload) As String
      Dim BusinessEntity As New WebReferenceRPC.ResponseBusinessEntity
      Dim Individual As New WebReferenceRPC.Individual
      Dim IndividualSimpleName As New WebReferenceRPC.IndividualSimpleName
      Dim NonIndividual As New WebReferenceRPC.OrganisationName
      Dim Details As New StringBuilder

      Try
         ' A buisness entity is either a Individual or a non-Individual
         BusinessEntity = CType(searchPayload.Response.ResponseBody, WebReferenceRPC.ResponseBusinessEntity)
         If BusinessEntity.Name(0).GetType Is NonIndividual.GetType Then
            NonIndividual = CType(BusinessEntity.Name(0), WebReferenceRPC.OrganisationName)
            Details.Append("Organisation Name: " & vbNewLine & NonIndividual.OrganisationName)
            Details.Append(vbNewLine)
            Details.Append("Effective from " & NonIndividual.EffectiveFrom)
         Else ' an individual
            Individual = CType(BusinessEntity.Name(0), WebReferenceRPC.Individual)
            Details.Append("Individual Name: ")
            Details.Append(vbNewLine)
            Details.Append(Individual.FamilyName & ", " & Individual.GivenName & " " & Individual.OtherGivenName)
         End If
         Return Details.ToString
      Catch exp As Exception
         Throw
      End Try
   End Function
   '-----------------------------------------------------------------------------------------------
   ' Display when SearchPayload is a Search Results List 
   '-----------------------------------------------------------------------------------------------
   Public Function DisplayList(ByVal searchPayload As WebReferenceRPC.Payload) As String
      Dim IndividualSimpleName As New WebReferenceRPC.IndividualSimpleName
      Dim NonIndividualSimpleName As New WebReferenceRPC.OrganisationSimpleName
      Dim List As New WebReferenceRPC.ResponseSearchResultsList
      Dim Names As New StringBuilder
      Try
         List = CType(searchPayload.Response.ResponseBody, WebReferenceRPC.ResponseSearchResultsList)
         For Each Record As WebReferenceRPC.SearchResultsRecord In List.SearchResultsRecord
            Names.Append(Record.ABN(0).IdentifierValue)
            Names.Append(" ")
            If Record.Name(0).GetType Is NonIndividualSimpleName.GetType Then
               NonIndividualSimpleName = CType(Record.Name(0), WebReferenceRPC.OrganisationSimpleName)
               Names.Append(NonIndividualSimpleName.OrganisationName & vbNewLine)
            Else
               IndividualSimpleName = CType(Record.Name(0), WebReferenceRPC.IndividualSimpleName)
               Names.Append(IndividualSimpleName.FullName & vbNewLine)
            End If
         Next
      Catch exp As Exception
         Throw
      End Try
      Return Names.ToString
   End Function
   '-----------------------------------------------------------------------------------------------
   ' Display when SearchPayload is an Exception. 
   '-----------------------------------------------------------------------------------------------
   Public Function DisplayException(ByVal searchPayload As WebReferenceRPC.Payload) As String
      Dim Exception As New WebReferenceRPC.ResponseException
      Dim Details As New StringBuilder

      Try
         Exception = CType(searchPayload.Response.ResponseBody, WebReferenceRPC.ResponseException)
         Details.Append("Exception returned from web service")
         Details.Append(vbNewLine)
         Details.Append(Exception.ExceptionDescription)
         Return Details.ToString
      Catch exp As Exception
         Throw
      End Try
   End Function
End Class
