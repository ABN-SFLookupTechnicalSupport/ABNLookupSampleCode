using System;
using AbnLookup.SearchClientCSharpe.ServiceReferenceAbnLookupRpc;

namespace AbnLookup.SearchClientCSharpe {
   class ProxyXmlRpcSearch {
      // -----------------------------------------------------------------------------------------------
      // Private constructor
      // -----------------------------------------------------------------------------------------------
      private ProxyXmlRpcSearch() { }
      // -----------------------------------------------------------------------------------------------
      //  Search by ABN
      // -----------------------------------------------------------------------------------------------
      public static Payload AbnSearch(string searchText, string history, string guid) {
         ABRXMLSearchRPCSoapClient Search = new ABRXMLSearchRPCSoapClient();
         return Search.ABRSearchByABN(searchText, history, guid);
      }
      // -----------------------------------------------------------------------------------------------
      //  Search by ASIC
      // -----------------------------------------------------------------------------------------------
      public static Payload AsicSearch(string searchText, string history, string guid) {
         ABRXMLSearchRPCSoapClient Search = new ABRXMLSearchRPCSoapClient();
         return Search.ABRSearchByASIC(searchText, history, guid);
      }
      // -----------------------------------------------------------------------------------------------
      //  Search by Name
      // -----------------------------------------------------------------------------------------------
      public static Payload NameSearch(string guid, ExternalRequestNameSearch criteria) {
         ABRXMLSearchRPCSoapClient Search = new ABRXMLSearchRPCSoapClient();
         return Search.ABRSearchByName(criteria, guid);
      }
      // -----------------------------------------------------------------------------------------------
      //  Search by Postcode
      // -----------------------------------------------------------------------------------------------
      public static Payload PostcodeSearch(string guid, string postcode) {
         ABRXMLSearchRPCSoapClient Search = new ABRXMLSearchRPCSoapClient();
         return Search.SearchByPostcode(postcode, guid);
      }
   }
}
