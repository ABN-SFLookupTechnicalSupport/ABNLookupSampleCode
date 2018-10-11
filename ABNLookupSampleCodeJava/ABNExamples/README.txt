
This sample code demonstrates calling the ABN Lookup Web Services from Java code.

The AbnSearchWSHttpGet class demonstrates using a simple HTTP GET request.

The AbnSearchWSSOAP class demonstrates using SOAP.

To use these sample applications, you should:
  - extract the source code
  - register for access to the ABN Lookup Web Service to obtain a GUID
  - replace the "<insert your GUID here>" text in the main method of the AbnSearchWSHttpGet and AbnSearchWSSOAP classes with your GUID
  - compile the code using your favourite Java development environment (e.g. eclipse)
  - run sample to retrieve the business name of an organisation given its ABN (the main method of the AbnSearchWSHttpGet and AbnSearchWSSOAP classes)
  
The sample code has been tested under the following Java environments:
  - Java 1.4.2 (JRE 1.4.2_15) with apache axis 1.4 for SOAP functionality
  - Java 1.5 aka Java 5 (JRE 1.5.0_12) with apache axis 1.4 for SOAP functionality
  - Java 1.6 aka Java 6 (JRE 1.6.0_02)

