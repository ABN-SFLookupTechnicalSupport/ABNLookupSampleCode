using System;
using System.IO;
using System.Net;
using System.Globalization;

namespace AbnLookup.SearchClientCSharpe {
   /// <summary>
   /// Non-Strongly Typed Search - Builds the Soap message as a string. 
   /// Parent class for 'httpXMLRPCSearch' and 'httpXMLDocumentSearch'
   /// Handles four types of search (Name, Asic, Abn and postcode)
   /// Pending on types of Soap Document (Document Style or RPC Style), handle and process separately in Child class.
   /// </summary>
   public abstract class SoapSearch {
      // ---------------------------------------------------------------------------------------------
      //  Indicates whether RPC or document style
      // ---------------------------------------------------------------------------------------------
      protected abstract AppSettings.EncodingStyle Style { get; }
      // ---------------------------------------------------------------------------------------------
      //  Soap string depends on whether using RPC or document style
      // ---------------------------------------------------------------------------------------------
      protected abstract string BuildAbnSoapMessage(string searchText, string history, string guid);
      // ---------------------------------------------------------------------------------------------
      //  Soap string depends on whether using RPC or document style
      // ---------------------------------------------------------------------------------------------
      protected abstract string BuildAsicSoapMessage(string searchText, string history, string guid);
      // ---------------------------------------------------------------------------------------------
      //  Soap string depends on whether using RPC or document style
      // ---------------------------------------------------------------------------------------------
      protected abstract string BuildNameSoapMessage(string searchText, string act, string nsw, string nt, string qld, string tas, string vic, string wa, string sa, string postcode, string legalName, string tradingName, string guid);
      // ---------------------------------------------------------------------------------------------
      //  Soap string depends on whether using RPC or document style
      // ---------------------------------------------------------------------------------------------
      protected abstract string BuildPostcodeSoapMessage(string postcode, string guid);
      // ---------------------------------------------------------------------------------------------
      //  Search by an Abn
      // ---------------------------------------------------------------------------------------------
      public string AbnSearch(string searchText, string history, string guid) {
         string SoapMessage = BuildAbnSoapMessage(searchText, history, guid);
         string SoapAction = AppSettings.SoapActionAbnSearch(this.Style);
         HttpWebRequest WebRequest = null;
         try {
            WebRequest = BuildRequest(SoapMessage, SoapAction);
            Send(WebRequest, SoapMessage);
            return ReadResponse(WebRequest);
         }
         catch {
            throw;
         }
         finally {
            WebRequest.Abort();
         }
      }
      // ---------------------------------------------------------------------------------------------
      //  Search by an Asic number (ACN)
      // ---------------------------------------------------------------------------------------------
      public string AsicSearch(string searchText, string history, string guid) {
         string SoapMessage = BuildAsicSoapMessage(searchText, history, guid);
         string SoapAction = AppSettings.SoapActionAsicSearch(this.Style);
         HttpWebRequest WebRequest;
         try {
            WebRequest = BuildRequest(SoapMessage, SoapAction);
            Send(WebRequest, SoapMessage);
            return ReadResponse(WebRequest);
         }
         catch {
            throw;
         }
      }
      // ---------------------------------------------------------------------------------------------
      //  Search by Name
      // ---------------------------------------------------------------------------------------------
      public string NameSearch(string searchText, string act, string nsw, string nt, string qld, string tas, string vic, string wa, string sa, string postcode, string legalName, string tradingName, string guid) {
         string SoapMessage = BuildNameSoapMessage(searchText, act, nsw, nt, qld, tas, vic, wa, sa, postcode, legalName, tradingName, guid);
         string SoapAction = AppSettings.SoapActionNameSearch(this.Style);
         HttpWebRequest WebRequest;
         try {
            WebRequest = BuildRequest(SoapMessage, SoapAction);
            Send(WebRequest, SoapMessage);
            return ReadResponse(WebRequest);
         }
         catch {
            throw;
         }
      }
      // ---------------------------------------------------------------------------------------------
      //  Search by a Postcode
      // ---------------------------------------------------------------------------------------------
      public string PostcodeSearch(string postcode, string guid) {
         string SoapMessage = BuildPostcodeSoapMessage(postcode, guid);
         string SoapAction = AppSettings.SoapActionPostcodeSearch(this.Style);
         HttpWebRequest WebRequest;
         try {
            WebRequest = BuildRequest(SoapMessage, SoapAction);
            Send(WebRequest, SoapMessage);
            return ReadResponse(WebRequest);
         }
         catch {
            throw;
         }
      }
      // ---------------------------------------------------------------------------------------------
      //  Set the request header details
      // ---------------------------------------------------------------------------------------------
      private HttpWebRequest BuildRequest(string soapMessage, string soapAction) {
         HttpWebRequest Request;
         Request = (HttpWebRequest)WebRequest.Create(AppSettings.SearchUrl(this.Style));
         try {
            Request.Timeout = int.Parse(AppSettings.RequestTimeoutInMilliseconds, CultureInfo.CurrentCulture);
         }
         catch {
            Request.Timeout = 100000;
         }
         Request.Headers.Add("SoapAction", soapAction);
         Request.ContentType = "text/xml; charset=utf-8";
         Request.ContentLength = soapMessage.Length;
         Request.Proxy = GetWebProxy();
         Request.Method = "POST";
         return (Request);
      }
      // ---------------------------------------------------------------------------------------------
      //  Set proxy depending on settings in the config file
      // ---------------------------------------------------------------------------------------------
      private static IWebProxy GetWebProxy() {
         string ProxySetting = AppSettings.Proxy;
         if (ProxySetting.Length > 0) {
            return new WebProxy(ProxySetting);
         }
         else {
            return WebRequest.GetSystemWebProxy();
         }
      }
      // ---------------------------------------------------------------------------------------------
      //  issue the request to the web service
      // ---------------------------------------------------------------------------------------------
      private static void Send(HttpWebRequest webRequest, string soapMessage) {
         StreamWriter StreamWriter;
         StreamWriter = new StreamWriter(webRequest.GetRequestStream());
         StreamWriter.Write(soapMessage);
         StreamWriter.Flush();
         StreamWriter.Close();
      }
      // ---------------------------------------------------------------------------------------------
      //  Return the response from the request as a string 
      // ---------------------------------------------------------------------------------------------
      private static string ReadResponse(HttpWebRequest webRequest) {
         StreamReader Reader;
         HttpWebResponse Response;
         String ResponseContents = "";
         try {
            Response = ((HttpWebResponse)(webRequest.GetResponse()));
            Reader = new StreamReader(Response.GetResponseStream());
            ResponseContents = Reader.ReadToEnd();
            Reader.Close();
         }
         catch (ObjectDisposedException) {
            throw;
         }
         catch (IOException) {
            throw;
         }
         catch (SystemException) {
            throw;
         }
         return ResponseContents;
      }
   }
}
