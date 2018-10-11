<?php
include(dirname(__FILE__)."/config.inc.php"); // $abn_guid is set here.

/**
 * @author Justin Swan - 16 August 2012
 * extends php soap client to utilize the Australian Government ABN Lookup web service 
 * requires php 5 or greater and lib-xml enabled/compiled with apache
 * @link	http://www.php.net/manual/en/book.soap.php
 * @link	http://abr.business.gov.au/Webservices.aspx
 * 
 * @param string $guid - get a guid id by registering @ http://abr.business.gov.au/Webservices.aspx
 * 
 */


class abnlookup extends SoapClient{

    private $guid = ""; 
	
	public function __construct($guid)
    {
		$this->guid = $guid;
		$params = array(
			'soap_version' => SOAP_1_1,
			'exceptions' => true,
			'trace' => 1,
			'cache_wsdl' => WSDL_CACHE_NONE
		); 

		parent::__construct('http://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx?WSDL', $params);
    }
	
	public function searchByAbn($abn, $historical = 'N'){
		$params = new stdClass();
		$params->searchString				= $abn;
		$params->includeHistoricalDetails	= $historical;
		$params->authenticationGuid			= $this->guid;
		return $this->ABRSearchByABN($params);
	}
}

$abn_search_string = "11111111111"; // you can assign your post/get var or abn string here

try{
	$abnlookup = new abnlookup($abn_guid);
	try{
		$result = $abnlookup->searchByAbn($abn_search_string); 
		
		// display all results
		echo "<pre>";
		print_r($result);
		echo "</pre>";
		
		// also display by variables using object notation.
		echo "<pre>";
		$result->ABRPayloadSearchResults->response;
		echo "</pre>";
		
	} catch	(Exception $e){
		throw $e;
	}
	
} catch(Exception $e){
	echo $e->getMessage();
}