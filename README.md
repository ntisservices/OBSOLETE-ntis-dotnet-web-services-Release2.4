ntis-dotnet-web-services-Release2.4
===================================

Note : You may also wish to refer to the Java implementation of the service at:
https://github.com/ntisservices/ntis-java-web-services-Release2.4


NTIS Subscriber Service - README
================================

This project is an example implementation of the NTIS Subscriber Service.

It has been created in, and tested with, Visual Studio 2012 and the .NET framework version 4

Building and testing the website 
----------------------------------------------------------------

### Testing

Visual studio features 

For initial testing, you may wish to use the development server that visual studio is equipped with:
	Open '\SubscriberService\SubscriberWebService.sln' in visual studio
	Open the 'DEBUG' dropdown menu, and click 'Start Debugging'
Visual studio will 
Visual studio should now launch an instance of the Visual Studio Development Server [1]

Note: Visual Studio will fail to launch the Development Server if IIS is installed and running with the same port number configured.

### Deploying locally using IIS 8.

To deploy the example implementation on a dedicated IIS install. 
	Select Publish from the 'BUILD' menu
	Create a new profile.
	Select a publish method of 'File System' and navigate to the folder which will contain the service (e.g 'C:\inetpub\wwwroot')
	Click Publish
You should now be able to navigate to the location in your browser (e.g 'http://localhost/WebServiceSubscriber.svc')

Note: You may need to register .NET 4 with IIS, this can be done using the ASP.NET IIS Registration Tool ('Aspnet_regiis.exe')
	To register .NET 4 with IIS, run "Aspnet_regiis.exe -i" from the Visual Studio Developer Console.
Note: If you receive a server error related to 'targetFramework' check that the correct .NET version is set in your application pool.
	Application pools can be viewed in the IIS Manager, which can be found in control panel, under administrative tools.
This example implementation should be compatible with any .NET 4 version (e.g 4.0 or 4.5)


### Example Requests

Featured in '\exampleRequests' are some example requests which can be used to test your implementation. All the included requests conform to the 2.4 standard.

### Testing Using SoapUI

SoapUI is an open source cross-platform tool which can be used for testing SOAP requests and responses.
The version used for testing this example was V4.5.2 Because of its simple interface, it was used as a client for testing this Subscriber web service.

	Make sure that the Subscriber web service is running (either through IIS or the Development Server)
	Start soapUI.
	From the main menu select File -> New soapUI Project.
	Enter a Project Name, browse to the WSDL or manually enter the location. (e.g. 'http://localhost/WebServiceSubscriber.svc?wsdl')
	Click "OK".
	The service and its operations will then be exposed.
	Modify any of the requests and enter suitable values, or copy any of the example messages provided in the "exampleRequests" folder, which match the message to be tested, and paste over the contents of the "Request 1" sample generated.
	Click the green play arrow at the top of the request and check that a success response is sent.
	The message requests and responses will be logged in 'C:\temp\logs\SOAP'.