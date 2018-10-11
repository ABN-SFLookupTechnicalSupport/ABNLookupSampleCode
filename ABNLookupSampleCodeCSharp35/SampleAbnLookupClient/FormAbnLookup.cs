using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AbnLookup.SearchClientCSharpe;

namespace AbnLookup.SearchClientCSharpe {

   public partial class FormAbnLookup : Form {
      private Collection<string> initialControlValue = new Collection<string>();
      public FormAbnLookup() {
         InitializeComponent();
      }
      // -----------------------------------------------------------------------------------------------
      //  Default is Search by ABN so disable name search selection criteria when the form loads
      // -----------------------------------------------------------------------------------------------
      private void formAbnLookup_Load(object sender, EventArgs e) {
         EnableControls(false);
         InitialiseTextBoxValues();
         foreach (Control control in this.tabPageXmlSearch.Controls) {
            if (control is TextBox) {
               initialControlValue.Add(control.Text);
            }
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  If Search by ABN, disable name search controls
      // -----------------------------------------------------------------------------------------------
      private void radioButtonAbn_CheckedChanged(object sender, EventArgs e) {
         EnableControls(false);
      }
      // -----------------------------------------------------------------------------------------------
      //  If Search by ASIC Number, disable name search controls
      // -----------------------------------------------------------------------------------------------
      private void radioButtonAsic_CheckedChanged(object sender, EventArgs e) {
         EnableControls(false);
      }
      // -----------------------------------------------------------------------------------------------
      //  If Search by Names, enable name search controls
      // -----------------------------------------------------------------------------------------------
      private void radioButtonName_CheckedChanged(object sender, EventArgs e) {
         EnableControls(true);
      }
      // -----------------------------------------------------------------------------------------------
      //  If Search by Postcode, disable name search controls
      // -----------------------------------------------------------------------------------------------
      private void radioButtonPostcode_CheckedChanged(object sender, EventArgs e) {
         EnableControls(false);
      }
      // -----------------------------------------------------------------------------------------------
      //  If Search by Update event, disable name search controls
      // -----------------------------------------------------------------------------------------------
      private void radioButtonUpdateEvent_CheckedChanged(object sender, EventArgs e) {
         EnableControls(false);
      }
      // -----------------------------------------------------------------------------------------------
      //  Exit the program
      // -----------------------------------------------------------------------------------------------
      private void buttonExit_Click(object sender, EventArgs e) {
         this.Close();
      }
      // -----------------------------------------------------------------------------------------------
      //  Reset the form as a start up
      // -----------------------------------------------------------------------------------------------
      private void buttonReset_Click(object sender, EventArgs e) {
         int index = 0;
         try {
            foreach (Control control in tabPageXmlSearch.Controls) {
               if (control is TextBox) {
                  control.Text = (initialControlValue[index].ToString());
                  index++;
               }
            }
         }
         catch (Exception exp) {
            ShowException(exp.ToString());
         }
         InitialiseControls();
      }
      // -----------------------------------------------------------------------------------------------
      //  Initiate the search
      // -----------------------------------------------------------------------------------------------
      private void buttonSearch_Click(object sender, EventArgs e) {
         InitialiseResultControls();
         try {
            if (this.radioButtonProxy.Checked) {
               UseStronglyTypedSearch();
            }
            else if (this.radioButtonSoap.Checked) {
               UseSoapSearch();
            }
            else {
               UseHttpGetSearch();
            }
         }
         catch (Exception exp) {
            ShowException(exp.ToString());
         }
         this.Cursor = System.Windows.Forms.Cursors.Default;
      }
      // -----------------------------------------------------------------------------------------------
      //  Set search result controls to initial state
      // -----------------------------------------------------------------------------------------------
      private void InitialiseResultControls() {
         this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
         this.richTextBoxResults.Clear();
         this.dataGridNames.DataSource = null;
         this.dataGridNames.Refresh();
         this.richTextBoxResults.Visible = true;
         this.dataGridNames.Visible = false;
      }
      // -----------------------------------------------------------------------------------------------
      //  Set name search controls to initial state
      // -----------------------------------------------------------------------------------------------
      private void InitialiseControls() {
         this.checkBoxAct.Checked = true;
         this.checkBoxLegal.Checked = true;
         this.checkBoxNsw.Checked = true;
         this.checkBoxNt.Checked = true;
         this.checkBoxQld.Checked = true;
         this.checkBoxSa.Checked = true;
         this.checkBoxTas.Checked = true;
         this.checkBoxTrading.Checked = true;
         this.checkBoxVic.Checked = true;
         this.checkBoxWa.Checked = true;
         this.checkBoxHistory.Checked = false;
         this.richTextBoxResults.Visible = false;
         this.dataGridNames.Visible = true;
         this.radioButtonAbn.Checked = true;
         this.radioButtonAbn.Focus();
      }
      // -----------------------------------------------------------------------------------------------
      //  Enable name search controls if search by name selected
      // -----------------------------------------------------------------------------------------------
      private void EnableControls(bool nameSearchSelected) {
         this.checkBoxAct.Enabled = nameSearchSelected;
         this.checkBoxLegal.Enabled = nameSearchSelected;
         this.checkBoxNsw.Enabled = nameSearchSelected;
         this.checkBoxNt.Enabled = nameSearchSelected;
         this.checkBoxQld.Enabled = nameSearchSelected;
         this.checkBoxSa.Enabled = nameSearchSelected;
         this.checkBoxTas.Enabled = nameSearchSelected;
         this.checkBoxTrading.Enabled = nameSearchSelected;
         this.checkBoxVic.Enabled = nameSearchSelected;
         this.checkBoxWa.Enabled = nameSearchSelected;
         this.textBoxPostcode.Enabled = nameSearchSelected;
         this.checkBoxHistory.Enabled = !nameSearchSelected;
         this.richTextBoxResults.Visible = !nameSearchSelected;
         this.dataGridNames.Visible = nameSearchSelected;
         InitialiseTextBoxValues();
      }
      // -----------------------------------------------------------------------------------------------
      //  Initialises the tex box with default values
      // -----------------------------------------------------------------------------------------------
      private void InitialiseTextBoxValues() {
         if (this.radioButtonName.Checked) {
            this.textBoxCriteria.Text = "industry tourism";
         }
         else if (this.radioButtonAsic.Checked) {
            this.textBoxCriteria.Text = "080036693";
         }
         else if (this.radioButtonAbn.Checked) {
            this.textBoxCriteria.Text = "51835430479";
         }
         else if (this.radioButtonPostcode.Checked) {
            this.textBoxCriteria.Text = "2601";
         }
         this.textBoxGuid.Text = AppSettings.Guid;
      }
      // -----------------------------------------------------------------------------------------------
      //  Search using the web service proxies. See Web References for the project
      // -----------------------------------------------------------------------------------------------
      private void UseStronglyTypedSearch() {
         if (this.radioButtonDocument.Checked) {
            UseStronglyTypedDocumentSearch();
         }
         else {
            UseStronglyTypedRpcSearch();
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Call web service proxies using document style soap
      // -----------------------------------------------------------------------------------------------
      private void UseStronglyTypedDocumentSearch() {
         ServiceReferenceAbnLookup.Payload SearchPayload = null;
         try {
            if (this.radioButtonAbn.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching By ABN
               SearchPayload = ProxyXmlSearch.AbnSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
               this.richTextBoxResults.Text = ResultsInterpreter.SerialisePayload(SearchPayload);
            }
            else if (this.radioButtonAsic.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching by ASIC
               SearchPayload = ProxyXmlSearch.AsicSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
               this.richTextBoxResults.Text = ResultsInterpreter.SerialisePayload(SearchPayload);
            }
            else if (this.radioButtonName.Checked) {
               //  SearchPayload response will contain a Search Results List when searching By name
               SearchPayload = ProxyXmlSearch.NameSearch(this.textBoxGuid.Text, InitialiseNameSearchCriteria());
               DisplayNamesInGrid(SearchPayload);
            }
            else if (this.radioButtonPostcode.Checked) {
               //  SearchPayload response will contain a ABN List when searching By postcode
               SearchPayload = ProxyXmlSearch.PostcodeSearch(this.textBoxGuid.Text, this.textBoxCriteria.Text);
               this.richTextBoxResults.Text = ResultsInterpreter.SerialisePayload(SearchPayload);
            }
         }
         catch (Exception e) {
            ShowException(e.ToString());
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Call the web service proxies using Rpc style soap.
      //  Serialising the Payload does not work for RPC without modifing the information generated from 
      //  the web reference file. Therefore just pull out some of the information for display.
      // -----------------------------------------------------------------------------------------------
      private void UseStronglyTypedRpcSearch() {
         ServiceReferenceAbnLookupRpc.Payload SearchPayload = null;
         try {
            if (this.radioButtonAbn.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching By ABN
               SearchPayload = ProxyXmlRpcSearch.AbnSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
               this.richTextBoxResults.Text = ResultsInterpreter.SerialisePayload(SearchPayload);
            }
            else if (this.radioButtonAsic.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching by ASIC
               SearchPayload = ProxyXmlRpcSearch.AsicSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
               this.richTextBoxResults.Text = ResultsInterpreter.SerialisePayload(SearchPayload);
            }
            else if (this.radioButtonName.Checked) {
               //  SearchPayload response will contain a Search Results List when searching By name
               SearchPayload = ProxyXmlRpcSearch.NameSearch(this.textBoxGuid.Text, InitialiseRpcNameSearchCriteria());
               DisplayNamesInGrid(SearchPayload);
            }
            else if (this.radioButtonPostcode.Checked) {
               //  SearchPayload response will contain a ABN List when searching By postcode
               SearchPayload = ProxyXmlRpcSearch.PostcodeSearch(this.textBoxGuid.Text, this.textBoxCriteria.Text);
               this.richTextBoxResults.Text = ResultsInterpreter.SerialisePayload(SearchPayload);
            }
         }
         catch (Exception e) {
            ShowException(e.ToString());
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Search ABRpublic without using the web service proxies. 
      // -----------------------------------------------------------------------------------------------
      private void UseSoapSearch() {
         string SearchPayload = "";
         SoapSearch Search;
         if (this.radioButtonDocument.Checked) {
            Search = new SoapDocumentSearch();
         }
         else {
            Search = new SoapRpcSearch();
         }
         try {
            if (this.radioButtonAbn.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching By ABN
               SearchPayload = Search.AbnSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
               this.richTextBoxResults.Text = SearchPayload;
            }
            else if (this.radioButtonAsic.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching By ACN
               SearchPayload = Search.AsicSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
               this.richTextBoxResults.Text = SearchPayload;
            }
            else if (this.radioButtonName.Checked) {
               //  SearchPayload response will contain a Search Results List when searching By name
               SearchPayload = Search.NameSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxAct.Checked), SetFlag(this.checkBoxNsw.Checked), SetFlag(this.checkBoxNt.Checked), SetFlag(this.checkBoxQld.Checked), SetFlag(this.checkBoxTas.Checked), SetFlag(this.checkBoxVic.Checked), SetFlag(this.checkBoxWa.Checked), SetFlag(this.checkBoxSa.Checked), this.textBoxPostcode.Text, SetFlag(this.checkBoxLegal.Checked), SetFlag(this.checkBoxTrading.Checked), this.textBoxGuid.Text);
               if (this.radioButtonDocument.Checked) {
                  DisplayNamesInGrid(SearchPayload);
               }
               else {
                  this.richTextBoxResults.Text = SearchPayload;
               }
            }
            else if (this.radioButtonPostcode.Checked) {
               //  SearchPayload response will contain a ABN List when searching By postcode
               SearchPayload = Search.PostcodeSearch(this.textBoxCriteria.Text, this.textBoxGuid.Text);
               this.richTextBoxResults.Text = SearchPayload;
            }
         }
         catch (Exception e) {
            ShowException(e.ToString());
            throw;
         }

      }
      // -----------------------------------------------------------------------------------------------
      //  Search ABN Lookup using http get
      // -----------------------------------------------------------------------------------------------
      private void UseHttpGetSearch() {
         string SearchPayload = "";
         HttpGetSearch Search;
         if (this.radioButtonDocument.Checked) {
            Search = new HttpGetDocumentSearch();
         }
         else {
            Search = new HttpGetRpcSearch();
         }
         try {
            if (this.radioButtonAbn.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching By ABN
               SearchPayload = Search.AbnSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
            }
            else if (this.radioButtonAsic.Checked) {
               //  SearchPayload response will contain a Buisness Entity when searching By ACN
               SearchPayload = Search.AsicSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxHistory.Checked), this.textBoxGuid.Text);
            }
            else if (this.radioButtonName.Checked) {
               //  SearchPayload response will contain a Search Results List when searching By name
               SearchPayload = Search.NameSearch(this.textBoxCriteria.Text, SetFlag(this.checkBoxAct.Checked), SetFlag(this.checkBoxNsw.Checked), SetFlag(this.checkBoxNt.Checked), SetFlag(this.checkBoxQld.Checked), SetFlag(this.checkBoxTas.Checked), SetFlag(this.checkBoxVic.Checked), SetFlag(this.checkBoxWa.Checked), SetFlag(this.checkBoxSa.Checked), this.textBoxPostcode.Text, SetFlag(this.checkBoxLegal.Checked), SetFlag(this.checkBoxTrading.Checked), this.textBoxGuid.Text);
            }
            else if (this.radioButtonPostcode.Checked) {
               //  SearchPayload response will contain a ABN List when searching By postcode
               SearchPayload = Search.PostcodeSearch(this.textBoxCriteria.Text, this.textBoxGuid.Text);
            }
            this.richTextBoxResults.Text = SearchPayload;
         }
         catch (Exception e) {
            ShowException(e.ToString());
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Initialise the name search criteria object with the selection criteria entered on the screen
      // -----------------------------------------------------------------------------------------------
      private ServiceReferenceAbnLookup.ExternalRequestNameSearch InitialiseNameSearchCriteria() {
         ServiceReferenceAbnLookup.ExternalRequestNameSearch Criteria = new ServiceReferenceAbnLookup.ExternalRequestNameSearch();
         ServiceReferenceAbnLookup.ExternalRequestFilters Filters = new ServiceReferenceAbnLookup.ExternalRequestFilters();
         Criteria.name = this.textBoxCriteria.Text;
         Filters.nameType = new ServiceReferenceAbnLookup.ExternalRequestFilterNameType();
         Filters.stateCode = new ServiceReferenceAbnLookup.ExternalRequestFilterStateCode();
         Filters.postcode = this.textBoxPostcode.Text;
         Filters.nameType.legalName = SetFlag(this.checkBoxLegal.Checked);
         Filters.nameType.tradingName = SetFlag(this.checkBoxTrading.Checked);
         Filters.stateCode.ACT = SetFlag(this.checkBoxAct.Checked);
         Filters.stateCode.NSW = SetFlag(this.checkBoxNsw.Checked);
         Filters.stateCode.NT = SetFlag(this.checkBoxNt.Checked);
         Filters.stateCode.QLD = SetFlag(this.checkBoxQld.Checked);
         Filters.stateCode.SA = SetFlag(this.checkBoxSa.Checked);
         Filters.stateCode.TAS = SetFlag(this.checkBoxTas.Checked);
         Filters.stateCode.VIC = SetFlag(this.checkBoxVic.Checked);
         Filters.stateCode.WA = SetFlag(this.checkBoxWa.Checked);
         Criteria.filters = Filters;
         return Criteria;
      }
      // -----------------------------------------------------------------------------------------------
      //  Initialise the name search criteria object with the selection criteria entered on the screen
      // -----------------------------------------------------------------------------------------------
      private ServiceReferenceAbnLookupRpc.ExternalRequestNameSearch InitialiseRpcNameSearchCriteria() {
         ServiceReferenceAbnLookupRpc.ExternalRequestNameSearch Criteria = new ServiceReferenceAbnLookupRpc.ExternalRequestNameSearch();
         ServiceReferenceAbnLookupRpc.ExternalRequestFilters Filters = new ServiceReferenceAbnLookupRpc.ExternalRequestFilters();
         Criteria.Name = this.textBoxCriteria.Text;
         Filters.NameType = new ServiceReferenceAbnLookupRpc.ExternalRequestFilterNameType();
         Filters.StateCode = new ServiceReferenceAbnLookupRpc.ExternalRequestFilterStateCode();
         Filters.Postcode = this.textBoxPostcode.Text;
         Filters.NameType.LegalName = SetFlag(this.checkBoxLegal.Checked);
         Filters.NameType.TradingName = SetFlag(this.checkBoxTrading.Checked);
         Filters.StateCode.ACT = SetFlag(this.checkBoxAct.Checked);
         Filters.StateCode.NSW = SetFlag(this.checkBoxNsw.Checked);
         Filters.StateCode.NT = SetFlag(this.checkBoxNt.Checked);
         Filters.StateCode.QLD = SetFlag(this.checkBoxQld.Checked);
         Filters.StateCode.SA = SetFlag(this.checkBoxSa.Checked);
         Filters.StateCode.TAS = SetFlag(this.checkBoxTas.Checked);
         Filters.StateCode.VIC = SetFlag(this.checkBoxVic.Checked);
         Filters.StateCode.WA = SetFlag(this.checkBoxWa.Checked);
         Criteria.Filters = Filters;
         return Criteria;
      }

      // -----------------------------------------------------------------------------------------------
      //  Extract names from the xml string
      // -----------------------------------------------------------------------------------------------
      private void DisplayNamesInGrid(ServiceReferenceAbnLookupRpc.Payload payload) {
         this.richTextBoxResults.Visible = false;
         this.dataGridNames.Visible = true;
         try {
            this.dataGridNames.DataSource = ResultsInterpreter.DisplayNamesInGrid(payload);
            this.dataGridNames.Refresh();
         }
         catch (Exception exp) {
            ShowException(exp.ToString());
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Extract names from the xml string
      // -----------------------------------------------------------------------------------------------
      private void DisplayNamesInGrid(ServiceReferenceAbnLookup.Payload payload) {
         this.richTextBoxResults.Visible = false;
         this.dataGridNames.Visible = true;
         try {
            this.dataGridNames.DataSource = ResultsInterpreter.DisplayNamesInGrid(payload);
            this.dataGridNames.Refresh();
         }
         catch (Exception exp) {
            ShowException(exp.ToString());
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Extract names from the xml string
      // -----------------------------------------------------------------------------------------------
      private void DisplayNamesInGrid(string payload) {
         this.richTextBoxResults.Visible = false;
         this.dataGridNames.Visible = true;
         try {
            this.dataGridNames.DataSource = ResultsInterpreter.DisplayNamesInGrid(payload);
            this.dataGridNames.Refresh();
         }
         catch (Exception exp) {
            ShowException(exp.ToString());
            throw;
         }
      }
      // -----------------------------------------------------------------------------------------------
      //  Convert boolean values to Y or N as this is what the web service expects
      // -----------------------------------------------------------------------------------------------
      private static string SetFlag(bool checkedIdent) {
         const string YES = "Y";
         const string NO = "N";
         if (checkedIdent) {
            return YES;
         }
         else {
            return NO;
         }
      }
      //------------------------------------------------------------------------------
      // Display an error message
      //------------------------------------------------------------------------------
      private void ShowException(string message) {
         const string CAPTION = "Extract Error";
         MessageBox.Show(this, message, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
   }
}
