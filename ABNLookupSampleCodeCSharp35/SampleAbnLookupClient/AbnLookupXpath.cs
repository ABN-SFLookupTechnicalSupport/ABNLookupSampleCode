using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbnLookup.SearchClientCSharpe {
   class AbnLookupXpath {
      public enum Path {
         CommonRoot,
         Name,
         AbnValue,
         State,
         Score,
         Postcode,
         Exception
      }
      // Private constructor 
      private AbnLookupXpath() { }
      //  Paths for SOAP messages
      public static string LocationSoap(Path path) {
         string CommonRoot = "//abn:ABRSearchByNameResponse/abn:ABRPayloadSearchResults/abn:response/abn:searchResultsList/abn:searchResultsRecord";
         switch (path) {
            case Path.CommonRoot:
               return CommonRoot;
            case Path.Name:
               return "./abn:legalName/abn:fullName|./abn:mainTradingName/abn:organisationName|./abn:mainName/abn:organisationName|./abn:otherTradingName/abn:organisationName";
            case Path.AbnValue:
               return "./abn:ABN/abn:identifierValue";
            case Path.State:
               return "./abn:mainBusinessPhysicalAddress/abn:stateCode";
            case Path.Score:
               return "./abn:legalName/abn:score|./abn:mainTradingName/abn:score|./abn:mainName/abn:score|./abn:otherTradingName/abn:score";
            case Path.Postcode:
               return "./abn:mainBusinessPhysicalAddress/abn:postcode";
            case Path.Exception:
               return "abn:exception/abn:exceptionDescription";
            default:
               return "";
         }
      }
   }
}
