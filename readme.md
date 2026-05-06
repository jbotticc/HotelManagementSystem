Project Overview:
The hotel management system provides an easy way to manage hotel rooms through a command line interface. It is designed to be used by hotel 
staff with roles for different staff members. Managers can create rooms, users, and set the current pricing strategy. Front desk staff 
can check guests into and out of rooms. House keeping can view and manage maintenance tasks for rooms. Main constraint is a lack of 
persisting data between sessions.

Build and Run Instructions:
NET 10 is the framework used. Jetbrains Rider was the primary IDE used for development. dotnet command used to build and run the project.
Step 1. Install dotnet 10 sdk
Step 2. Extract zip file
Step 3. Open terminal in /src directory where HotelManagementSystem.csproj is located
Step 4. Run `dotnet run` to start the application.

Required OOP Features:

OOP Feature             File Name                               Line Numbers    Reasoning / Purpose
Inheritance 1           Domain/Models/SuiteRoom.cs              All             SuiteRoom inherits base attributes from Room class but can override 
                                                                                the size and rent attributes.
Inheritance 2           Domain/Models/RepairTask.cs             All             RepairTask inherits status attribute from MaintenanceTask class but 
                                                                                can define its own task data attribute and ToString method.
Interface 1             Contracts/IFrontDeskService.cs          All             Defines a contract for front desk operations for the front desk service 
                                                                                to implement.
Interface 2             Contracts/IGuestRepository.cs           All             Defines a contract for guest data management for the guest repository 
                                                                                service to implement.
Interface 3             Contracts/IHouseKeepingService.cs       All             Defines a contract for house keeping operations for the house keeping 
                                                                                service to implement.
Polymorphism 1          Services/HousekeepingService.cs         23-35           Gets a MaintenanceTask object from repository and calls the base class 
                                                                                SetStatus method to update the status of the task, whether the retrieved task 
                                                                                was of type CleaningTask or RepairTask.
Polymorphism 2          Services/FrontDeskService.cs            25-36           Gets a Room object from repository and calls the MarkOccupied() method, 
                                                                                whether the Room object from the repository was of type StandardRoom or SuiteRoom.
Access Modifiers        Domain/Models/Room.cs                   All             RoomNumber and BedCount are public readonly so that they can be read but 
                                                                                not changed as they should not change once set. IsVacant has a private setter 
                                                                                so that it can only be changed by the MarkOccupied() and MarkVacant() methods, 
                                                                                which are public for updating when rooms are checked in or out. The 
                                                                                constructor is protected just to further reinforce that the constructor should 
                                                                                only be used by the class or a derived class.
Struct                  Domain/Models/Guest.cs                  All             Stores data for a guest and their checkout date.
Enum                    Domain/Models/Role.cs                   All             Defines values for the roles of a user to be used by the User class.
Data Structure          Domain/Repositories/GuestRepository.cs  7               Dictionary is used to map room numbers to Lists of guests for easy referencing and 
                                                                                organizing of guests per room.
I/O                     Program.cs                              75-98           Displays a UI in the console, prompting for employee ID for logging in as 
                                                                                a user and retrying prompt on invalid input.

Pattern Name            Category            File Name                               Line Numbers    Rationale
Strategy                Behavioral          Services/PricingService.cs              All             Context class for strategy pattern. Allows for setting 
                                                                                                    the pricing strategy at runtime with a class implementing 
                                                                                                    IPricingStrategy to change how price is calculated without 
                                                                                                    changing the class itself. Allows managers to set special pricing
                                                                                                    at runtime.
Factory Method          Creational          Domain/Factory/RoomFactory.cs           All             Base factory class used by concrete factory classes. Defines
                                                                                                    the factory method for creating Room objects. Allows for
                                                                                                    selecting the proper room factory dynamically at runtime and
                                                                                                    polymorphism to then create the room object with the overridden
                                                                                                    method. Allows for coding and implementation of new types of rooms 
                                                                                                    without modifying old code.
Singleton               Creational          Repositories/RoomRepository.cs          9-15            Instantiates the first instance with static attribute 
                                                                                                    and returns only that single instance of it for all subsequent 
                                                                                                    calls by checking if the instance already exists and returning it 
                                                                                                    if it does, otherwise creating a new instance. Ensures only one
                                                                                                    instance of the repository exists and is used during runtime.

Design Decisions:
Main functionality was divided by what staff type would need what functionality. This was intuitive from a role-based system perspective
and kept services for each generally focused, ensuring single responsiblity. The services utilize repositories to manage and organize data
based on domain objects. This also helps single responsiblity in that data management and access is handled by a repository layer with
each main domain object has its own repository. The services all come together within Program.cs to perform the actions of each 
role with the designated methods in the corresponding services for a user's role. Oce important choice was the system creating an initial 
manager user upon running so that a user exists to make other users. Data is not saved between application runs necessitating this.
