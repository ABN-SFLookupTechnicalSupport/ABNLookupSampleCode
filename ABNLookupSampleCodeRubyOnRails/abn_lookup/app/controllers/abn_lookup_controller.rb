class AbnLookupController < ApplicationController
  require "soap/wsdlDriver"
  
  def lookup
    # Define the WSDL path
    wsdl = "https://www.abn.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx?WSDL"
    
    # All the methods avaliable are parsed and define based on the WSDL path
    soap_client = SOAP::WSDLDriverFactory.new(wsdl).create_rpc_driver
    
    #Define the required options of the method
    options = {:searchString => "#{params[:lookup][:abn]}", :includeHistoricalDetails => "n", :authenticationGuid => "#{params[:lookup][:guid]}"}
    
    #Result for use in view
    @result = soap_client.ABRSearchByABN(options)
  end
  def index
    
  end
end
