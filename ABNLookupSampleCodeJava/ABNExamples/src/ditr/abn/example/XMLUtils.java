package ditr.abn.example;

import java.io.IOException;
import java.io.InputStream;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.FactoryConfigurationError;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

// Deal with the differences in the XML classes between Java 1.4 and Java 1.5 (and 1.6)
public class XMLUtils
{
	public static Document DOMParseXML(InputStream is) throws SAXException, IOException, ParserConfigurationException, FactoryConfigurationError
	{
		return DOMParseXML(is, false);
	}

	public static Document DOMParseXML(InputStream is, boolean namespaceAware) throws SAXException, IOException, ParserConfigurationException,
			FactoryConfigurationError
	{
		Document doc = null;

		doc = getDocumentBuilder(namespaceAware).parse(is);

		return doc;
	}

	private static DocumentBuilder getDocumentBuilder(boolean namespaceAware) throws ParserConfigurationException
	{
		DocumentBuilder d = null;

		DocumentBuilderFactory f;

		f = DocumentBuilderFactory.newInstance();
		f.setNamespaceAware(namespaceAware);

		d = f.newDocumentBuilder();

		return d;
	}

	public static String getNodeText(Node root, String path)
	{
		String s = "";

		Node n = getNode(root, path);

		if (n != null)
			s = getTextContent(n);

		return s;
	}

	public static String getTextContent(Node node)
	{
		String s = null;

		if (node.getNodeType() == Node.TEXT_NODE)
			s += node.getNodeValue();

		NodeList list = node.getChildNodes();

		for (int i = 0; i < list.getLength(); i++)
		{
			Node n = list.item(i);

			if (n.getNodeType() == Node.TEXT_NODE)
			{
				if (s == null || s.length() == 0)
					s = n.getNodeValue();
				else
					s += " " + n.getNodeValue();
			}
		}

		return s;
	}

	public static Node getNode(Node root, String path)
	{
		if (path.startsWith("/"))
			path = path.substring(1);

		String[] nodeNames = path.split("/");

		Node start = root;
		Node node = null;

		for (int i = 0; i < nodeNames.length; i++)
		{
			node = findNode(start, nodeNames[i]);

			if (node == null)
				return null;

			start = node;
		}

		return node;
	}

	private static Node findNode(Node root, String name)
	{
		if (name.equals(root.getNodeName()))
			return root;

		NodeList list = root.getChildNodes();

		for (int i = 0; i < list.getLength(); i++)
		{
			Node n = list.item(i);

			if (name.equals(n.getNodeName()))
				return n;
		}

		return null;
	}
}
