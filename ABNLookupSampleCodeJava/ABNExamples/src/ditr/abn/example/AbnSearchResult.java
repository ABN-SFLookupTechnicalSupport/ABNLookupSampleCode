package ditr.abn.example;

import java.lang.reflect.InvocationTargetException;

import org.w3c.dom.Node;

public class AbnSearchResult
{
	private Node	searchResultsPayload;

	public AbnSearchResult(Node searchResultsPayload)
	{
		this.searchResultsPayload = searchResultsPayload;
	}

	public boolean isException()
	{
		return XMLUtils.getNode(searchResultsPayload, "/ABRPayloadSearchResults/response/exception") != null;
	}

	public String getOrganisationName() throws SecurityException, IllegalArgumentException, ClassNotFoundException, NoSuchMethodException,
			IllegalAccessException, InvocationTargetException
	{
		return XMLUtils.getNodeText(searchResultsPayload, "/ABRPayloadSearchResults/response/businessEntity/mainName/organisationName");
	}

	public String getExceptionDescription() throws SecurityException, IllegalArgumentException, ClassNotFoundException, NoSuchMethodException,
			IllegalAccessException, InvocationTargetException
	{
		return XMLUtils.getNodeText(searchResultsPayload, "/ABRPayloadSearchResults/response/exception/exceptionDescription");
	}
}
