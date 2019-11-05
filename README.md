# ChatDemo
Simple Chat Messenger – A Demo of a WCF Self-Hosted Service & Client "Tester" Windows Form Application Exchanging Messages


Project Article:

https://portfolio.katiegirl.net/2019/11/05/simple-chat-messenger-a-demo-of-a-wcf-self-hosted-service-client-tester-windows-form-application-exchanging-messages/


About


This project presents a simple Chat Message Service and Client Application demonstration. The Chat Service is a self-hosted (service host) WCF application launched and managed with a simple console interface. The service prints to the console window the user activities (log on, log off) and what messages are sent to users. The client “tester” has a simplified GUI user interface to quickly demo and test the service (Windows Form Application). The GUI has features to log on, log off, send a message, and receive messages from other users on the chat service.



Architecture 

 
The demo project consists of these component topics:


Shared Class Library Project “SharedLibrary”
* IChatService (Interface for Service)
* IChatServiceCallback (Interface for Service Callback)
* DuplicateUserFault (Class describing a WCF Exception as a Fault)
* ChatMessage (Class Describing a Chat Message Object)


Service Class Library Project “ChatServiceLibrary”
* ChatService (Code that Implements the Service Interface)
* config (Configuration Reference for Service Host)
* Reference to the Shared Class Library


WCF Service (Host) Application Project “ChatServiceHost”
* Program (Starts, Manages, Stops the Service)
* config (Configuration for Service Host)
* Reference to the ChatServiceLibrary


Client “Tester to Service” Windows Form Application Project “Client”
* Reference to the Shared Class Library
* Main Form GUI User Interface
* Form Code – Processes GUI User Interface


The service interface is defined not in the service application but in a Shared Library. This library defines the interface contracts for the chat message services (ex: Send Message) and is referenced by both the client and service host projects.  The SharedLibrary also has a class definition that defines a chat message object with a name, timestamp, and message properties. Furthermore, a callback contract is defined for the client to implement so they can receive chat messages while connected to the service.  Lastly, since exceptions (errors) are really faults in WCF services, a custom error (fault) class is defined in the shared library so that the client can understand and process the duplicate user faults (errors). 


The ChatServiceLibrary implements the Chat Message service and contracts as defined in the SharedLibrary. The ChatServiceHost is a simple console application that is responsible for starting the Chat service, hosting, and managing the service (self-hosted). 


The service behaviors were designed to allow all the clients to connect to a single instance of the service that sends messages to all connected clients. Further improvements and features such as thread locks should have been implemented to safeguard the shared resources, however that was not the purpose of this short demo application as I budgeted limited time for this project. 


A client “tester” windows form application tests the service and provides output to the user in a simple GUI.   


