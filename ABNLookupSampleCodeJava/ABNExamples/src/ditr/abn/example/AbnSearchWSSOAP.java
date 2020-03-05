package ditr.abn.example;

import java.io.IOException;
import java.lang.reflect.InvocationTargetException;
import java.net.URL;

import javax.xml.soap.MessageFactory;
import javax.xml.soap.MimeHeaders;
import javax.xml.soap.Name;
import javax.xml.soap.SOAPBody;
import javax.xml.soap.SOAPConnection;
import javax.xml.soap.SOAPConnectionFactory;
import javax.xml.soap.SOAPElement;
import javax.xml.soap.SOAPEnvelope;
import javax.xml.soap.SOAPException;
import javax.xml.soap.SOAPHeader;
import javax.xml.soap.SOAPMessage;
import javax.xml.soap.SOAPPart;

public class AbnSearchWSSOAP
{

	public static void main(String[] args)
	{
		try
		{
			String guid = "<insert your GUID here>";
			String abn = "69 410 335 356";

			AbnSearchResult result = searchByABN(guid, abn, false);

			if (!result.isException())
				System.out.println("ABN search for ABN [" + abn + "] returned business name [" + result.getOrganisationName() + "]");
			else
				System.out.println("ABN search for ABN [" + abn + "] returned exception [" + result.getExceptionDescription() + "]");
		}
		catch (Exception e)
		{
			System.err.println("Caught exception : " + e);
			e.printStackTrace(System.err);
		}
	}

	public static AbnSearchResult searchByABN(String guid, String abn, boolean includeHistorical) throws UnsupportedOperationException,
			SOAPException, IOException, SecurityException, IllegalArgumentException, ClassNotFoundException, NoSuchMethodException,
			IllegalAccessException, InvocationTargetException
	{
		AbnSearchResult result = null;

		// All connections are created by using a connection factory
		SOAPConnectionFactory conFactory = SOAPConnectionFactory.newInstance();

		// Now we can create a SOAPConnection object using the connection factory
		SOAPConnection connection = conFactory.createConnection();

		// All SOAP messages are created by using a message factory
		MessageFactory msgFactory = MessageFactory.newInstance();

		// Now we can create the SOAP message object
		SOAPMessage msg = msgFactory.createMessage();

		// Get the SOAP part from the SOAP message object
		SOAPPart soapPart = msg.getSOAPPart();

		// The SOAP part object will automatically contain the SOAP envelope
		SOAPEnvelope envelope = soapPart.getEnvelope();

		// Get the SOAP header from the envelope
		SOAPHeader header = envelope.getHeader();

		// The client does not yet support SOAP headers
		header.detachNode();

		// Get the SOAP body from the envelope and populate it
		SOAPBody body = envelope.getBody();

		// Create the default namespace for the SOAP body
		body.addNamespaceDeclaration("", "https://abr.business.gov.au/ABRXMLSearch/");

		// Add the service information
		Name svcInfo = envelope.createName("ABRSearchByABN", "", "https://abr.business.gov.au/ABRXMLSearch/");
		SOAPElement svcElem = body.addChildElement(svcInfo);

		SOAPElement node;

		node = svcElem.addChildElement("searchString", "", "https://abr.business.gov.au/ABRXMLSearch/");
		node.addTextNode(abn);

		node = svcElem.addChildElement("includeHistoricalDetails", "", "https://abr.business.gov.au/ABRXMLSearch/");
		node.addTextNode(encodeBooleanParam(includeHistorical));

		node = svcElem.addChildElement("authenticationGuid", "", "https://abr.business.gov.au/ABRXMLSearch/");
		node.addTextNode(guid);

		// Add the SOAPAction value as a MIME header
		MimeHeaders mimeHeaders = msg.getMimeHeaders();
		mimeHeaders.setHeader("SOAPAction", "https://abr.business.gov.au/ABRXMLSearch/ABRSearchByABN");

		// Save changes to the message we just populated
		msg.saveChanges();

		// Get ready for the invocation
		URL endpoint = new URL("https://abr.business.gov.au/abrxmlsearch/ABRXMLSearch.asmx");

		// Make the call
		SOAPMessage response = connection.call(msg, endpoint);

		// Close the connection, we are done with it
		connection.close();

		SOAPBody respBody = response.getSOAPBody();

		// result = new AbnSearchResult(respBody.extractContentAsDocument().getDocumentElement().getChildNodes().item(0));
		result = new AbnSearchResult(respBody.getFirstChild());

		return result;
	}

	private static String encodeBooleanParam(boolean value)
	{
		if (value)
			return "Y";
		else
			return "N";
	}
}
