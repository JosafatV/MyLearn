# Instituto Tecnológico de Costa Rica
# Computer Engineering Academic Area
## Design and Specification Project: MyLearn
## II 2016

Members:
* Joseph Campos Porras, 
* Sebastián González Quesada, 
* Josafat Vargas Gamboa, 
* Giovanni Villalobos Quirós.

### MyLearn 

My Learn is a school management software created for the Design and Specification Course. 

The layered model of this project is composed of four layers: Presentation, Services, business logic and data layer. This design is top down because the lower layers do not know about the upper layers and it is loosely interacting.

Presentation: This layer is responsible for the functionalities related to the user's interaction with the system, composed of components that serve as a bridge for the contents of the business layer (through the services layer) and the views for the user, these components make requests for data and display said data, in addition these components manage (Logical Interface) and display the user interface (Graphical Interface), this layer includes control for user input data and its display on the screen.

Services: The services layer is exposed as a façade from the business layer to the presentation layer. From a high-level point of view, this layer can be seen as a composition of multiple services that send and receive messages, it is only responsible for providing HTTP services. It was decided to place a services layer because the system must provide services to different applications. In this way all systems only see the service layer. The advantage is that this layer provides alternate views that allow different clients to use different channels, in this case one view for the MyLearn system and one for MyEmployee.

Business Logic: Implements the core functionality of the system by encapsulating the relevant business logic. It was considered necessary to implement this layer because the system must meet a considerable number of business requirements and validations. In the diagram you can see two internal packages that handle the logic of company projects and course projects. This to achieve a better logical organization by separating the two main logics of the system. With this, it also complies with the common principle of closure, because changes in the course logic will only affect the courses, it does not affect the business project logic and vice versa.

Data access layer: Through this layer access to the database is given, internally Entity Framework is responsible for creating the necessary objects to obtain the data in a way that is easier to handle by the upper layers. The database uses stored procedures and triggers to handle certain business laws and make access to the database with previously made queries more secure and simpler. If seen from the point of view of responsibilities, this layer is only responsible for writing, modifying and reading data.

The rest of the Design Document is available in Spanish:

https://docs.google.com/document/d/1Itst1xW15HicF0lWfHW2VPgVRKKTleLYC-hG2WwONDc

### Developed in
* C#
* MS SQL
* JavaScript
* HTML
* CSS
