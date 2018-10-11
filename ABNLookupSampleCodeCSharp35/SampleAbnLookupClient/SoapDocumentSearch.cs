using System;

namespace AbnLookup.SearchClientCSharpe {
   /// <summary>
   /// Non-Strongly Typed Search - Builds the SOAP message as a string. 
   /// Child of httpXMLSearch class.
   /// Further define abstract methods from parent class. Mainly responsible for Document style SOAP communication
   /// </summary>
   class SoapDocumentSearch : SoapSearch {
      // -----------------------------------------------------------------------------------------------
      //  Prefix in config file
      // -----------------------------------------------------------------------------------------------
      protected override AppSettings.EncodingStyle Style {
         get {
            return AppSettings.EncodingStyle.Document;
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
             "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
             "<soap:Body> " +
             "<ABRSearchByABN xmlns=\"http://abr.business.gov.au/ABRXMLSearch/\"> " +
             "<searchString>" + searchText + "</searchString>" +
             "<includeHistoricalDetails>" + history + "</includeHistoricalDetails>" +
             "<authenticationGuid>" + guid + "</authenticationGuid>" +
             "</ABRSearchByABN>" +
             "</soap:Body>" +
             "</soap:Envelope>";
      }
      // -----------------------------------------------------------------------------------------------
      //  Return the SOAP message for a search by ASIC
      // -----------------------------------------------------------------------------------------------
      protected override string BuildAsicSoapMessage(string searchText, string history, string guid) {
         return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
         "<soap:Envelope " +
         "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
         "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
         "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
         "<soap:Body> " +
         "<ABRSearchByASIC xmlns=\"http://abr.business.gov.au/ABRXMLSearch/\"> " +
         "<searchString>" + searchText + "</searchString>" +
         "<includeHistoricalDetails>" + history + "</includeHistoricalDetails>" +
         "<authenticationGuid>" + guid + "</authenticationGuid>" +
         "</ABRSearchByASIC>" +
         "</soap:Body>" +
         "</soap:Envelope>";
      }
      // -----------------------------------------------------------------------------------------------
      //  Return the SOAP message for a search by Name
      // -----------------------------------------------------------------------------------------------
      protected override string BuildNameSoapMessage(string searchText, string act, string nsw, string nt, string qld, string tas, string vic, string wa, string sa, string postcode, string legalName, string tradingName, string guid) {
         return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
         "<soap:Envelope " +
         "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
         "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" " +
         "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
         "<soap:Body> " +
         "<ABRSearchByName xmlns=\"http://abr.business.gov.au/ABRXMLSearch/\"> " +
         "<externalNameSearch>" +
         "<name>" + searchText + "</name>" +
         "<filters>" +
         "<stateCode>" +
         "<ACT>" + act + "</ACT>" +
         "<NSW>" + nsw + "</NSW>" +
         "<NT>" + nt + "</NT>" +
         "<QLD>" + qld + "</QLD>" +
         "<TAS>" + tas + "</TAS>" +
         "<VIC>" + vic + "</VIC>" +
         "<WA>" + wa + "</WA>" +
         "<SA>" + sa + "</SA>" +
         "</stateCode>" +
         "<postcode>" + postcode + "</postcode>" +
         "<nameType>" +
         "<legalName>" + legalName + "</legalName>" +
         "<tradingName>" + tradingName + "</tradingName>" +
         "</nameType>" +
         "</filters>" +
         "</externalNameSearch>" +
         "<authenticationGuid>" + guid + "</authenticationGuid>" +
         "</ABRSearchByName>" +
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
            "xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
            "<soap:Body> " +
            "<SearchByPostcode xmlns=\"http://abr.business.gov.au/ABRXMLSearch/\"> " +
            "<postcode>" + postcode + "</postcode>" +
            "<authenticationGuid>" + guid + "</authenticationGuid>" +
            "</SearchByPostcode>" +
            "</soap:Body>" +
            "</soap:Envelope>";
      }
   }
}
