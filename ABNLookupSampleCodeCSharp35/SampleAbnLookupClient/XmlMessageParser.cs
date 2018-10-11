using System;
using System.Xml;
using System.IO;
using System.Data;
using System.Globalization;

namespace AbnLookup.SearchClientCSharpe {
   /// <summary>
   /// Process XML message using DOM.
   /// </summary>
   class XmlMessageParser {
      // ---------------------------------------------------------------------------------------
      // private constructor
      // ---------------------------------------------------------------------------------------
      private XmlMessageParser() { }
      // ---------------------------------------------------------------------------------------
      //  Get the name details from the dom
      // ---------------------------------------------------------------------------------------
      public static DataTable GetNames(string xml) {
         DataTable MatchingNames = CreateNewNamesDataTable();
         XmlDocument XmlDoc = LoadXml(xml);
         XmlNamespaceManager NamespaceManager = initialiseNamespace(XmlDoc);
         try {
            if (!IsException(XmlDoc, NamespaceManager)) {
               XmlNodeList Names = XmlDoc.SelectNodes(AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.CommonRoot), NamespaceManager);
               foreach (System.Xml.XmlNode Name in Names) {
                  DataRow MatchingName = MatchingNames.NewRow();
                  MatchingName["ABN"] = getNodeValue(Name, AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.AbnValue), NamespaceManager);
                  MatchingName["Entity Name"] = getNodeValue(Name, AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.Name), NamespaceManager);
                  MatchingName["State"] = getNodeValue(Name, AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.State), NamespaceManager);
                  MatchingName["Postcode"] = getNodeValue(Name, AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.Postcode), NamespaceManager);
                  MatchingName["Score"] = getNodeValue(Name, AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.Score), NamespaceManager);
                  MatchingNames.Rows.Add(MatchingName);
               }
            }
            else {
               throw new System.Exception("Exception from Soap Search");
            }
         }
         catch {
            throw;
         }
         return MatchingNames;
      }
      // ---------------------------------------------------------------------------------------
      // load xml into the dom
      // ---------------------------------------------------------------------------------------
      private static XmlDocument LoadXml(string xml) {
         XmlDocument XmlDoc = new XmlDocument();
         try {
            XmlDoc.LoadXml(xml);
         }
         catch {
            throw;
         }
         return XmlDoc;
      }
      // ---------------------------------------------------------------------------------------
      //  return true if there was an exception returned by the Soap call
      // ---------------------------------------------------------------------------------------
      private static bool IsException(XmlDocument xmlDoc, XmlNamespaceManager namespaceManager) {
         XmlNode SoapException;
         SoapException = xmlDoc.SelectSingleNode(AbnLookupXpath.LocationSoap(AbnLookupXpath.Path.Exception), namespaceManager);
         return !(SoapException == null);
      }
      // ---------------------------------------------------------------------------------------
      //  Create  data table for the names collection 
      // ---------------------------------------------------------------------------------------
      private static DataTable CreateNewNamesDataTable() {
         DataTable MatchingNames = new DataTable();
         MatchingNames.Locale = CultureInfo.CurrentCulture;
         MatchingNames.Columns.Add("ABN");
         MatchingNames.Columns.Add("Entity Name");
         MatchingNames.Columns.Add("State");
         MatchingNames.Columns.Add("Postcode");
         MatchingNames.Columns.Add("Score");
         return MatchingNames;
      }
      // ---------------------------------------------------------------------------------------
      //  Add namespace to the namespace manager
      // ---------------------------------------------------------------------------------------
      private static XmlNamespaceManager initialiseNamespace(XmlDocument xmlDoc) {
         const string NAMEPACE_ALIAS = "abn";
         const string NAMEPACE = "http://abr.business.gov.au/ABRXMLSearch/";
         XmlNamespaceManager NamespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
         NamespaceManager.AddNamespace(NAMEPACE_ALIAS, NAMEPACE);
         return NamespaceManager;
      }
      // ---------------------------------------------------------------------------------------
      //  Add namespace to the namespace manager
      // ---------------------------------------------------------------------------------------
      private static string getNodeValue(XmlNode node, string xPath, XmlNamespaceManager namespaceManager) {
         XmlNode Element;
         Element = node.SelectSingleNode(xPath, namespaceManager);
         if (!(Element == null)) {
            return Element.InnerText;
         }
         else {
            return "";
         }
      }
   }
}
