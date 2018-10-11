using System;

namespace AbnLookup.SearchClientCSharpe {
   class SoapRpcSearch : SoapSearch {
      // -----------------------------------------------------------------------------------------------
      //  Prefix in config file
      // -----------------------------------------------------------------------------------------------
      protected override AppSettings.EncodingStyle Style {
         get {
            return AppSettings.EncodingStyle.Rpc;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Return the SOAP message for a search by ABN 
      // -----------------------------------------------------------------------------------------------
      protected override string BuildAbnSoapMessage(string searchText, string history, string guid) {

         return
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<soap:Envelope " +
               "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
               "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
               "xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" " +
               "xmlns:tns=\"http://abr.business.gov.au/ABRXMLSearchRPC/\" " +
               "xmlns:types=\"http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes\" " +
               "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
               "<soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
               "<tns:ABRSearchByABN> " +
               "<searchString xsi:type=\"xsd:string\">" + searchText + "</searchString>" +
               "<includeHistoricalDetails xsi:type=\"xsd:string\">" + history + "</includeHistoricalDetails>" +
               "<authenticationGuid xsi:type=\"xsd:string\">" + guid + "</authenticationGuid>" +
               "</tns:ABRSearchByABN>" +
               "</soap:Body>" +
               "</soap:Envelope>";
      }

      // -----------------------------------------------------------------------------------------------
      //  Return the SOAP message for a search by ASIC
      // -----------------------------------------------------------------------------------------------
      protected override string BuildAsicSoapMessage(string searchText, string history, string guid) {
         return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<soap:Envelope " +
                 "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                 "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
                 "xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" " +
                 "xmlns:tns=\"http://abr.business.gov.au/ABRXMLSearchRPC/\" " +
                 "xmlns:types=\"http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes\" " +
                 "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                 "<soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                 "<tns:ABRSearchByASIC> " +
                 "<searchString xsi:type=\"xsd:string\">" + searchText + "</searchString>" +
                 "<includeHistoricalDetails xsi:type=\"xsd:string\">" + history + "</includeHistoricalDetails>" +
                 "<authenticationGuid xsi:type=\"xsd:string\">" + guid + "</authenticationGuid>" +
                 "</tns:ABRSearchByASIC>" +
                 "</soap:Body>" +
                 "</soap:Envelope>";
      }
      // -----------------------------------------------------------------------------------------------
      //  Return the SOAP message for a search by Name
      // -----------------------------------------------------------------------------------------------
      protected override string BuildNameSoapMessage(string searchText, string act, string nsw, string nt, string qld, string tas, string vic, string wa, string sa, string postcode, string legalName, string tradingName, string guid) {
         return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<soap:Envelope " +
                 "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                 "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
                 "xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" " +
                 "xmlns:tns=\"http://abr.business.gov.au/ABRXMLSearchRPC/\" " +
                 "xmlns:types=\"http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes\" " +
                 "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                 "<soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                 "<tns:ABRSearchByName>" +
                 "<externalNameSearch href=\"#id1\"/>" +
                 "<authenticationGuid xsi:type=\"xsd:string\">" + guid + "</authenticationGuid>" +
                 "</tns:ABRSearchByName>" +
                 "<tns:ExternalRequestNameSearch id=\"id1\" xsi:type=\"tns:ExternalRequestNameSearch\">" +
                 "<AuthenticationGUID xsi:type=\"xsd:string\">" + guid + "</AuthenticationGUID>" +
                 "<Name xsi:type=\"xsd:string\">" + searchText + "</Name>" +
                 "<Filters href=\"#id2\"/>" + "</tns:ExternalRequestNameSearch>" +
                 "<tns:ExternalRequestFilters id=\"id2\" xsi:type=\"tns:ExternalRequestFilters\" > " +
                 "<NameType href=\"#id3\"/>" +
                 "<Postcode xsi:type=\"xsd:string\">" + postcode.Trim() + "</Postcode>" +
                 "<StateCode href=\"#id4\"/>" +
                 "</tns:ExternalRequestFilters>" +
                 "<tns:ExternalRequestFilterNameType id=\"id3\" xsi:type=\"tns:ExternalRequestFilterNameType\">" +
                 "<TradingName xsi:type=\"xsd:string\">" + tradingName + "</TradingName>" +
                 "<LegalName xsi:type=\"xsd:string\">" + legalName + "</LegalName>" +
                 "</tns:ExternalRequestFilterNameType>" +
                 "<tns:ExternalRequestFilterStateCode id=\"id4\" xsi:type=\"tns:ExternalRequestFilterStateCode\">" +
                 "<QLD xsi:type=\"xsd:string\">" + qld + "</QLD>" +
                 "<NT xsi:type=\"xsd:string\">" + nt + "</NT>" +
                 "<SA xsi:type=\"xsd:string\">" + sa + "</SA>" +
                 "<WA xsi:type=\"xsd:string\">" + wa + "</WA>" +
                 "<VIC xsi:type=\"xsd:string\">" + vic + "</VIC>" +
                 "<ACT xsi:type=\"xsd:string\">" + act + "</ACT>" +
                 "<TAS xsi:type=\"xsd:string\">" + tas + "</TAS>" +
                 "<NSW xsi:type=\"xsd:string\">" + nsw + "</NSW>" +
                 "</tns:ExternalRequestFilterStateCode>" +
                 "</soap:Body>" +
                 "</soap:Envelope>";
      }

      // -----------------------------------------------------------------------------------------------
      //  Return the SOAP message for a search by Postcode
      // -----------------------------------------------------------------------------------------------
      protected override string BuildPostcodeSoapMessage(string postcode, string guid) {
         return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + "<soap:Envelope " +
                  "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                  "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
                  "xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" " +
                  "xmlns:tns=\"http://abr.business.gov.au/ABRXMLSearchRPC/\" " +
                  "xmlns:types=\"http://abr.business.gov.au/ABRXMLSearchRPC/encodedTypes\" " +
                  "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                  "<soap:Body soap:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">" +
                  "<tns:SearchByPostcode> " +
                  "<postcode xsi:type=\"xsd:string\">" + postcode + "</postcode >" +
                  "<authenticationGuid xsi:type=\"xsd:string\">" + guid + "</authenticationGuid>" +
                  "</tns:SearchByPostcode>" +
                  "</soap:Body>" +
                  "</soap:Envelope>";
      }

   }
}
