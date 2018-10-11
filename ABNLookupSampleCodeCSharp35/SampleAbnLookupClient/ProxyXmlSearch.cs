using System;
using AbnLookup.SearchClientCSharpe.ServiceReferenceAbnLookup;

namespace AbnLookup.SearchClientCSharpe {
   class ProxyXmlSearch {
      //  Private constructor
      private ProxyXmlSearch() { }
      // -----------------------------------------------------------------------------------------------
      //  Search by ABN
      // -----------------------------------------------------------------------------------------------
      public static Payload AbnSearch(string searchText, string history, string guid) {
         ABRXMLSearchSoapClient Search = new ABRXMLSearchSoapClient();
         return Search.ABRSearchByABN(searchText, history, guid);
      }
      // -----------------------------------------------------------------------------------------------
      //  Search by ASIC
      // -----------------------------------------------------------------------------------------------
      public static Payload AsicSearch(string searchText, string history, string guid) {
         ABRXMLSearchSoapClient Search = new ABRXMLSearchSoapClient();
         return Search.ABRSearchByASIC(searchText, history, guid);
      }
      // -----------------------------------------------------------------------------------------------
      //  Search by Name
      // -----------------------------------------------------------------------------------------------
      public static Payload NameSearch(string guid, ExternalRequestNameSearch criteria) {
         ABRXMLSearchSoapClient Search = new ABRXMLSearchSoapClient();
         return Search.ABRSearchByName(criteria, guid);
      }
      // -----------------------------------------------------------------------------------------------
      //  Search by Postcode
      // -----------------------------------------------------------------------------------------------
      public static Payload PostcodeSearch(string guid, string postcode) {
         ABRXMLSearchSoapClient Search = new ABRXMLSearchSoapClient();
         return Search.SearchByPostcode(postcode, guid);
      }
   }
}

