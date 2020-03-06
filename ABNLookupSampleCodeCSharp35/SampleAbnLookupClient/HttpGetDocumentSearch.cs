using System;
using System.Text;

namespace AbnLookup.SearchClientCSharpe {
   /// <summary>
   /// Callweb services using HttpGet 
   /// Handles four types of search (Name, Asic, Abn and postcode)   /// </summary>
   class HttpGetDocumentSearch : HttpGetSearch {
      // -----------------------------------------------------------------------------------------------
      //  Return query string for a search by ABN 
      // -----------------------------------------------------------------------------------------------
      protected override string BuildAbnQueryString(string searchText, string history, string guid) {
         StringBuilder QueryString = new StringBuilder("https://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx/ABRSearchByABN?");
         QueryString.Append("searchString=" + searchText);
         QueryString.Append("&includeHistoricalDetails=" + history);
         QueryString.Append("&authenticationGuid=" + guid);
         return QueryString.ToString();
      }
      // -----------------------------------------------------------------------------------------------
      //  Return query string for a search by Acn 
      // -----------------------------------------------------------------------------------------------
      protected override string BuildAsicQueryString(string searchText, string history, string guid) {
         StringBuilder QueryString = new StringBuilder("https://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx/ABRSearchByASIC?");
         QueryString.Append("searchString=" + searchText);
         QueryString.Append("&includeHistoricalDetails=" + history);
         QueryString.Append("&authenticationGuid=" + guid);
         return QueryString.ToString();
      }

      // -----------------------------------------------------------------------------------------------
      //  Return query string for a search by Name
      // -----------------------------------------------------------------------------------------------
      protected override string BuildNameQueryString(string searchText, string act, string nsw, string nt, string qld, string tas, string vic, string wa, string sa, string postcode, string legalName, string tradingName, string guid) {
         StringBuilder QueryString = new StringBuilder("https://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx/ABRSearchByNameSimpleProtocol?");
         QueryString.Append("authenticationGuid=" + System.Web.HttpUtility.UrlEncode(guid));
         QueryString.Append("&Name=" + System.Web.HttpUtility.UrlEncode(searchText));
         QueryString.Append("&ACT=" + act);
         QueryString.Append("&NSW=" + nsw);
         QueryString.Append("&NT=" + nt);
         QueryString.Append("&QLD=" + qld);
         QueryString.Append("&TAS=" + tas);
         QueryString.Append("&VIC=" + vic);
         QueryString.Append("&WA=" + wa);
         QueryString.Append("&SA=" + sa);
         QueryString.Append("&postcode=" + postcode);
         QueryString.Append("&legalName=" + legalName);
         QueryString.Append("&tradingName=" + tradingName);
         return QueryString.ToString();
      }
      // -----------------------------------------------------------------------------------------------
      //  Return query string for a search by Acn 
      // -----------------------------------------------------------------------------------------------
      protected override string BuildPostcodeQueryString(string postcode, string guid) {
         StringBuilder QueryString = new StringBuilder("https://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx/SearchByPostcode?");
         QueryString.Append("postcode=" + postcode);
         QueryString.Append("&authenticationGuid=" + guid);
         return QueryString.ToString();
      }
   }
}
