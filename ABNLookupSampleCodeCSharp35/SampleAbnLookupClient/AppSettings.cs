using System;
using System.Collections.Generic;

namespace AbnLookup.SearchClientCSharpe {
   public sealed class AppSettings {
      public enum EncodingStyle {
         None = 0,
         Rpc = 1,
         Document = 2,
      }
      // Private Constructor:
      private AppSettings() { }
      //--------------------------------------------------------------------------
      // Guid to access the web services
      //--------------------------------------------------------------------------
      public static string Proxy {
         get {
            return Settings.GetApplicationSetting("Proxy");
         }
      }
      //--------------------------------------------------------------------------
      // Guid to access the web services
      //--------------------------------------------------------------------------
      public static string Guid {
         get {
            return Settings.GetApplicationSetting("Guid");
         }
      }
      //--------------------------------------------------------------------------
      // Web request timeout
      //--------------------------------------------------------------------------
      public static string RequestTimeoutInMilliseconds {
         get {
            return Settings.GetApplicationSetting("RequestTimeoutInMilliseconds");
         }
      }
      //--------------------------------------------------------------------------
      // Url for rpc web services
      //--------------------------------------------------------------------------
      private static string RpcSearchUrl {
         get {
            return Settings.GetApplicationSetting("Rpc.SearchUrl");
         }
      }
      //--------------------------------------------------------------------------
      // Url for document web services
      //--------------------------------------------------------------------------
      private static string DocumentSearchUrl {
         get {
            return Settings.GetApplicationSetting("Document.SearchUrl");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for abn search
      //--------------------------------------------------------------------------
      private static string RpcSoapActionAbnSearch {
         get {
            return Settings.GetApplicationSetting("Rpc.SoapAction.AbnSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for acn search
      //--------------------------------------------------------------------------
      private static string RpcSoapActionAsicSearch {
         get {
            return Settings.GetApplicationSetting("Rpc.SoapAction.AsicSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for name search
      //--------------------------------------------------------------------------
      private static string RpcSoapActionNameSearch {
         get {
            return Settings.GetApplicationSetting("Rpc.SoapAction.NameSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for postcode search
      //--------------------------------------------------------------------------
      private static string RpcSoapActionPostcodeSearch {
         get {
            return Settings.GetApplicationSetting("Rpc.SoapAction.PostcodeSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for abn search
      //--------------------------------------------------------------------------
      private static string DocumentSoapActionAbnSearch {
         get {
            return Settings.GetApplicationSetting("Document.SoapAction.AbnSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for acn search
      //--------------------------------------------------------------------------
      private static string DocumentSoapActionAsicSearch {
         get {
            return Settings.GetApplicationSetting("Document.SoapAction.AsicSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for name search
      //--------------------------------------------------------------------------
      private static string DocumentSoapActionNameSearch {
         get {
            return Settings.GetApplicationSetting("Document.SoapAction.NameSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Soap action for postcode search
      //--------------------------------------------------------------------------
      private static string DocumentSoapActionPostcodeSearch {
         get {
            return Settings.GetApplicationSetting("Document.SoapAction.PostcodeSearch");
         }
      }
      //--------------------------------------------------------------------------
      // Return url depending of style
      //--------------------------------------------------------------------------
      public static Uri SearchUrl(EncodingStyle style) {
         if (style == EncodingStyle.Rpc) {
            return new Uri(RpcSearchUrl);
         }
         else {
            return new Uri(DocumentSearchUrl);
         }
      }
      //--------------------------------------------------------------------------
      // Return action depending of style
      //--------------------------------------------------------------------------
      public static string SoapActionAbnSearch(EncodingStyle style) {
         if (style == EncodingStyle.Rpc) {
            return RpcSoapActionAbnSearch;
         }
         else {
            return DocumentSoapActionAbnSearch;
         }
      }
      //--------------------------------------------------------------------------
      // Return action depending of style
      //--------------------------------------------------------------------------
      public static string SoapActionAsicSearch(EncodingStyle style) {
         if (style == EncodingStyle.Rpc) {
            return RpcSoapActionAsicSearch;
         }
         else {
            return DocumentSoapActionAsicSearch;
         }
      }
      //--------------------------------------------------------------------------
      // Return action depending of style
      //--------------------------------------------------------------------------
      public static string SoapActionNameSearch(EncodingStyle style) {
         if (style == EncodingStyle.Rpc) {
            return RpcSoapActionNameSearch;
         }
         else {
            return DocumentSoapActionNameSearch;
         }
      }
      //--------------------------------------------------------------------------
      // Return action depending of style
      //--------------------------------------------------------------------------
      public static string SoapActionPostcodeSearch(EncodingStyle style) {
         if (style == EncodingStyle.Rpc) {
            return RpcSoapActionPostcodeSearch;
         }
         else {
            return DocumentSoapActionPostcodeSearch;
         }
      }

   }
}
