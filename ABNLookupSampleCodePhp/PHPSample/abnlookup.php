<?php
/*
 *	ABN Lookup sample in PHP.
 *
 *  Written by Ben Hitchcock 9th Oct 2007.
 *  Distributed under the terms of the LGPL.
 *
 *	Based on wsdlclient1.php by snichol, and clientSideValidation.htm by the Australian Government.
 *
 *  Uses the NuSoap library located here: http://sourceforge.net/projects/nusoap/, distributed under the LGPL.
 *
 *	Service: ABN Lookup
 *	Payload: document/literal
 *	Transport: http
 *	Authentication: none
 */
 
if(isset($_POST['ButtonABNLookup']))
{
	require_once('lib/nusoap.php');
	$proxyhost = '';
	$proxyport = '';
	$proxyusername = '';
	$proxypassword = '';
	
	$client = new soapclient('http://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx?WSDL', true,
							$proxyhost, $proxyport, $proxyusername, $proxypassword);
	$err = $client->getError();
	if ($err) 
	{
		echo '<h2>Constructor error</h2><pre>' . $err . '</pre>';
	}
	// Doc/lit parameters get wrapped
	
	
	
	$param = array('searchString' => $_POST['TextBoxABN'],
					'includeHistoricalDetails' => 'N',
					'authenticationGuid' => $_POST['TextBoxGUID']);
	$result = $client->call('ABRSearchByABN', array('parameters' => $param), '', '', false, true);

	// Check for a fault
	if ($client->fault) 
	{
		echo '<h2>Fault</h2><pre>';
		print_r($result);
		echo '</pre>';
	} else 
	{
		// Check for errors
		$err = $client->getError();
		if ($err) 
		{
			// Display the error
			echo '<h2>Error</h2><pre>' . $err . '</pre>';
		} else 
		{
		
			$OutputGUID = $result['ABRPayloadSearchResults']['request']['identifierSearchRequest']['authenticationGUID'];
			
			$OutputABN = $result['ABRPayloadSearchResults']['response']['businessEntity']['ABN']['identifierValue'];
			$OutputABNStatus = $result['ABRPayloadSearchResults']['response']['businessEntity']['entityStatus']['entityStatusCode'];
			$OutputASICNumber = $result['ABRPayloadSearchResults']['response']['businessEntity']['ASICNumber'];
			$OutputEntityName = $result['ABRPayloadSearchResults']['response']['businessEntity']['mainName']['organisationName'];
			$OutputTradingName = $result['ABRPayloadSearchResults']['response']['businessEntity']['mainTradingName']['organisationName'];
			$OutputLegalName = 	$result['ABRPayloadSearchResults']['response']['businessEntity']['legalName']['givenName'] . " " . 
								$result['ABRPayloadSearchResults']['response']['businessEntity']['legalName']['otherGivenName'] . " " . 
								$result['ABRPayloadSearchResults']['response']['businessEntity']['legalName']['familyName'];
			$OutputOrganisationType = $result['ABRPayloadSearchResults']['response']['businessEntity']['entityType']['entityDescription'];
			$OutputState = $result['ABRPayloadSearchResults']['response']['businessEntity']['mainBusinessPhysicalAddress']['stateCode'];
			$OutputPostcode = $result['ABRPayloadSearchResults']['response']['businessEntity']['mainBusinessPhysicalAddress']['postcode'];
						
		}
	}

}
?>

<html>
	<head>
		<title>Using ABN Lookup web services</title>
		<link rel="stylesheet" type="text/css" href="style.css" />
		<script src="abnlookup.js"></script>
		<!-- script src="abnlookup.vbs" language="vbscript"></script -->
	</head>
	<body>
		<center>
			<form action="" method="POST">
				<table class="pageFrame" cellpadding="3" cellspacing="3">
					<tr>
						<td class="pageFrameBody" style="WIDTH:100%">
							<table class="bodyContainer">
								<tr>
									<td>
										<table class="helpMessage">
											<tr>
												<td class="pageTitle">Using ABN Lookup web services</td>
											</tr>
											<tr>
												<td>GUID: <input name="TextBoxGUID" type="text" id="TextBoxGUID" style="WIDTH:300px" value="<?php echo $OutputGUID ?>" /></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table class="dataEdit"  cellpadding="3" cellspacing="3">
											<caption>
												<div>Client Details</div>
											</caption>
											<tr>
												<td>ABN</td>
												<td style="WIDTH:2%">&nbsp;</td>
												<td>
													<input name="TextBoxABN" type="text" id="TextBoxABN" style="WIDTH:93px" value="<?php echo $OutputABN ?>" />
													<input type="submit" name="ButtonABNLookup" value="Lookup ABN" id="ButtonABNLookup" />
												</td>
											</tr>
											<tr>
												<td>ABN Status</td>
												<td style="WIDTH:2%" />
												<td>
													<?php echo $OutputABNStatus ?>
												</td>
											</tr>
											<tr>
												<td>ASIC Number</td>
												<td style="WIDTH:2%">&nbsp;</td>
												<td>
													<?php echo $OutputASICNumber ?>
												</td>
											</tr>
											<tr>
												<td>Entity name</td>
												<td style="WIDTH:2%" />
												<td>
													<?php echo $OutputEntityName ?>
												</td>
											</tr>
											<tr>
												<td>Trading&nbsp;name</td>
												<td style="WIDTH:2%">&nbsp;</td>
												<td>
													<?php echo $OutputTradingName ?>
												</td>
											</tr>
											<tr>
												<td>Legal Name</td>
												<td style="WIDTH:2%">&nbsp;</td>
												<td>
													<?php echo $OutputLegalName ?>
												</td>
											</tr>
											
											<tr>
												<td>Organisation&nbsp;type</td>
												<td style="WIDTH:2%" />
												<td>
													<?php echo $OutputOrganisationType ?>
												</td>
											</tr>
											<tr>
												<td>State</td>
												<td style="WIDTH:2%" />
												<td>
													<?php echo $OutputState ?>"
												</td>
											</tr>											
											<tr>
												<td>Postcode</td>
												<td style="WIDTH:2%" />
												<td>
													<?php echo $OutputPostcode ?>
												</td>
											</tr>											
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
		</center>
		</form>
	</body>
</html>
<?php
	// Display the result
	echo '<h2>Result</h2><pre>';
	print_r($result);
	echo '</pre>';

	//echo '<h2>Request</h2><pre>' . htmlspecialchars($client->request, ENT_QUOTES) . '</pre>';
	//echo '<h2>Response</h2><pre>' . htmlspecialchars($client->response, ENT_QUOTES) . '</pre>';
	//echo '<h2>Debug</h2><pre>' . htmlspecialchars($client->debug_str, ENT_QUOTES) . '</pre>';
?>
