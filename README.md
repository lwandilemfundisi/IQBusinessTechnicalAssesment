# IQBusiness Technical Assesment
IQBusiness Technical Assement

The solution consist of 3 console projects and 2 libraries (Assessment.RabbitMq and Assessment.Domain)

To run the solution, run the three Consoles
  -- SendTerminal is where user input is expected
  -- Interpreter is where messages sent from SendTerminal are processed and then produces a response based on incoming message
  -- RecieveTerminal is where the printed message is displayed as a result
  
The solution is built very simple using my own custom framework (available as nuget packages).

Each service is composed of CastleWindsor, Commands, Rules, DummyPersistenceFactory (Please ignore this one, that's a hack I done to resolve an assumption I made on my framework that all services(each application) will always have a database)

Basic explanation
-- Rules section is composed of my custom rules to validate pocos
-- Commands think of them as instruction to my application (otherwise known as a Service), it could be a query for data or mutating state of the application
-- Castle windsor to resolve CommandHandler dependencies

What's nice about this style is that its configurable, my RabbitMq is setup using .json files


*I INCLUDED THE PACKAGES IN THE SOLUTION IN CASE YOU HAVE TROUBLE RESTORING THEM. IF EVER NEED BE JUST INSTALL THEM YOURSELF*

But should be fairly simple to run.
