using System;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Globalization;
using AbnLookup.SearchClientCSharpe.ServiceReferenceAbnLookupRpc;
using AbnLookup.SearchClientCSharpe.ServiceReferenceAbnLookup;

namespace AbnLookup.SearchClientCSharpe {
   class ResultsInterpreter {
      //  Private constructor
      private ResultsInterpreter() { }
      // -----------------------------------------------------------------------------------------------
      //  Return payload as an XML String
      // -----------------------------------------------------------------------------------------------
      public static string SerialisePayload(ServiceReferenceAbnLookup.Payload searchPayload) {
         try {
            MemoryStream XmlStream = new MemoryStream();
            StreamReader XmlReader = new StreamReader(XmlStream);
            XmlSerializer Serializer = new XmlSerializer(typeof(ServiceReferenceAbnLookup.Payload));
            Serializer.Serialize(XmlStream, searchPayload);
            XmlStream.Seek(0, System.IO.SeekOrigin.Begin);
            return XmlReader.ReadToEnd();
         }
         catch {
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Return payload as an XML String
      // -----------------------------------------------------------------------------------------------
      public static string SerialisePayload(ServiceReferenceAbnLookupRpc.Payload searchPayload) {
         try {
            MemoryStream XmlStream = new MemoryStream();
            StreamReader XmlReader = new StreamReader(XmlStream);
            XmlSerializer Serializer = new XmlSerializer(typeof(ServiceReferenceAbnLookupRpc.Payload), ExtraTypes());
            Serializer.Serialize(XmlStream, searchPayload);
            XmlStream.Seek(0, System.IO.SeekOrigin.Begin);
            return XmlReader.ReadToEnd();
         }
         catch {
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      // add extra types only known at run time for rpc calls
      // -----------------------------------------------------------------------------------------------
      private static Type[] ExtraTypes() {
         Type[] extraTypes = new Type[8];
         extraTypes[0] = typeof(ServiceReferenceAbnLookupRpc.IndividualName);
         extraTypes[1] = typeof(ServiceReferenceAbnLookupRpc.OrganisationName);
         extraTypes[2] = typeof(ServiceReferenceAbnLookupRpc.OrganisationSimpleName);
         extraTypes[3] = typeof(ServiceReferenceAbnLookupRpc.ExternalRequestIdentifierSearch);
         extraTypes[4] = typeof(ServiceReferenceAbnLookupRpc.ResponseABNList);
         extraTypes[5] = typeof(ServiceReferenceAbnLookupRpc.ResponseException);
         extraTypes[6] = typeof(ServiceReferenceAbnLookupRpc.ResponseSearchResultsList);
         extraTypes[7] = typeof(ServiceReferenceAbnLookupRpc.ResponseBusinessEntity);
         return extraTypes;
      }
      // -----------------------------------------------------------------------------------------------
      //  Extract names from the xml string
      // -----------------------------------------------------------------------------------------------
      public static DataTable DisplayNamesInGrid(ServiceReferenceAbnLookupRpc.Payload payload) {
         DataRow MatchingName;
         DataTable MatchingNames = CreateNewNamesDataTable();
         int NameIndex = 0;
         ServiceReferenceAbnLookupRpc.ResponseSearchResultsList Names = (ServiceReferenceAbnLookupRpc.ResponseSearchResultsList)payload.Response.ResponseBody;
         try {
            while (NameIndex < Names.NumberOfRecords) {
               ServiceReferenceAbnLookupRpc.SearchResultsRecord Name = Names.SearchResultsRecord[NameIndex];
               MatchingName = MatchingNames.NewRow();
               MatchingName["ABN"] = Name.ABN[0].IdentifierValue;
               ServiceReferenceAbnLookupRpc.OrganisationSimpleName SimpleName = (ServiceReferenceAbnLookupRpc.OrganisationSimpleName)Name.Name[0];
               MatchingName["Entity Name"] = SimpleName.OrganisationName;
               MatchingName["Score"] = SimpleName.Score;
               MatchingName["State"] = Name.MainBusinessPhysicalAddress[0].StateCode;
               MatchingName["Postcode"] = Name.MainBusinessPhysicalAddress[0].Postcode;
               MatchingNames.Rows.Add(MatchingName);
               NameIndex++;
            }
            return MatchingNames;
         }
         catch {
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Extract names from the xml string
      // -----------------------------------------------------------------------------------------------
      public static DataTable DisplayNamesInGrid(ServiceReferenceAbnLookup.Payload payload) {
         DataRow MatchingName;
         DataTable MatchingNames = CreateNewNamesDataTable();
         int NameIndex = 0;
         ServiceReferenceAbnLookup.ResponseBody ReponseBody = (ServiceReferenceAbnLookup.ResponseBody)payload.response.Item;
         ServiceReferenceAbnLookup.ResponseSearchResultsList Names = (ServiceReferenceAbnLookup.ResponseSearchResultsList)ReponseBody;
         try {
            while (NameIndex < Names.numberOfRecords) {
               ServiceReferenceAbnLookup.SearchResultsRecord Name = Names.searchResultsRecord[NameIndex];
               MatchingName = MatchingNames.NewRow();
               MatchingName["ABN"] = Name.ABN[0].identifierValue;
               ServiceReferenceAbnLookup.OrganisationSimpleName SimpleName = (ServiceReferenceAbnLookup.OrganisationSimpleName)Name.Items[0];
               MatchingName["Entity Name"] = SimpleName.organisationName;
               MatchingName["Score"] = SimpleName.score;
               MatchingName["State"] = Name.mainBusinessPhysicalAddress[0].stateCode;
               MatchingName["Postcode"] = Name.mainBusinessPhysicalAddress[0].postcode;
               MatchingNames.Rows.Add(MatchingName);
               NameIndex++;
            }
            return MatchingNames;
         }
         catch {
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Extract names from the xml string
      // -----------------------------------------------------------------------------------------------
      public static DataTable DisplayNamesInGrid(string payload) {
         try {
            return XmlMessageParser.GetNames(payload);
         }
         catch {
            throw;
         }
      }
      // ---------------------------------------------------------------------------------------
      //  Create  data table for the names collection 
      // ---------------------------------------------------------------------------------------
      private static DataTable CreateNewNamesDataTable() {
         DataTable MatchingNames = new DataTable();
         MatchingNames.Locale = CultureInfo.CurrentCulture;
         MatchingNames.Columns.Add("ABN");
         MatchingNames.Columns.Add("Entity Name");
         MatchingNames.Columns.Add("Score");
         MatchingNames.Columns.Add("State");
         MatchingNames.Columns.Add("Postcode");
         return MatchingNames;
      }
   }
}
