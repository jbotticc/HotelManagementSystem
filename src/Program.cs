using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Contracts;
using HotelManagementSystem.Domain.Enums;
using HotelManagementSystem.Domain.Models;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.Services;
using HotelManagementSystem.Services.Factories;
using HotelManagementSystem.Services.Strategy;
using HotelManagementSystem.Domain.Factory;

namespace HotelManagementSystem;

public class Program
{
    private static IUserRepository _userRepository = UserRepository.GetInstance();
    private static IRoomRepository _roomRepository = RoomRepository.GetInstance();
    private static IMaintenanceTaskRepository _taskRepository = MaintenanceTaskRepository.GetInstance();
    
    private static ILoginService _loginService = new LoginService(_userRepository);
    private static IPricingService _pricingService = new PricingService(new RegularPricing(), _roomRepository);
    private static IManagerService _managerService = new ManagerService(_roomRepository, _userRepository, _pricingService);
    private static IFrontDeskService _frontDeskService = new FrontDeskService(GuestRepository.GetInstance(), _roomRepository);
    private static IHouseKeepingService _houseKeepingService = new HouseKeepingService(_taskRepository, _roomRepository);

    public static void Main(string[] args)
    {
        CreateInitialUser();

        while (true)
        {
            if (!_loginService.IsLoggedIn())
            {
                ShowLoginScreen();
            }
            else
            {
                ShowMainMenu();
            }   
        }
    }



    private static void CreateInitialUser()
    {
        if (!_userRepository.GetAll().Any())
        {
            Console.WriteLine("No users found in the system.");
            User manager = _managerService.AddUser(Role.Manager);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Initial Manager Account Created!");
            Console.WriteLine($"Login Code (Employee ID): {manager.EmployeeId}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Press any key to continue to login...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void ShowLoginScreen()
    {
        Console.WriteLine("=== Hotel Management System Login ===");
        Console.Write("Enter Employee ID: ");
        string? idString = Console.ReadLine();

        if (int.TryParse(idString, out int id))
        {
            try
            {
                _loginService.Login(id);
                Console.WriteLine("Login successful!");
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login failed: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    private static void ShowMainMenu()
    {
        Role role = _loginService.GetCurrentUserRole();
        Console.WriteLine($"=== Main Menu ({role}) ===");

        switch (role)
        {
            case Role.Manager:
                ShowManagerMenu();
                break;
            case Role.FrontDesk:
                ShowFrontDeskMenu();
                break;
            case Role.Housekeeping:
                ShowHousekeepingMenu();
                break;
        }
    }

    private static void ShowManagerMenu()
    {
        Console.WriteLine("1. View Occupancy");
        Console.WriteLine("2. Create Room");
        Console.WriteLine("3. Add User");
        Console.WriteLine("4. Set Pricing Strategy");
        Console.WriteLine("5. Logout");
        Console.Write("Select an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine($"Current Occupancy: {_managerService.ViewOccupancy()} rooms");
                break;
            case "2":
                CreateRoomPrompt();
                break;
            case "3":
                CreateUserPrompt();
                break;
            case "4":
                SetPricingStrategyPrompt();
                break;
            case "5":
                _loginService.Logout();
                Console.Clear();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private static void CreateRoomPrompt()
    {
        try
        {
            int num;
            while (true)
            {
                Console.Write("Enter Room Number: ");
                if (int.TryParse(Console.ReadLine(), out num)) break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            
            RoomFactory factory;
            while (true)
            {
                Console.WriteLine("Select Room Type: \n1. Standard \n2. Suite");
                string? type = Console.ReadLine();
                if (type == "1") { factory = new StandardRoomFactory(); break; }
                if (type == "2") { factory = new SuiteRoomFactory(); break; }
                Console.WriteLine("Invalid room type.");
            }
                
            int beds;
            while (true)
            {
                Console.Write("Enter Bed Count: ");
                if (int.TryParse(Console.ReadLine(), out beds)) break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            _managerService.CreateRoom(factory, num, beds);
            Console.WriteLine("Room created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CreateUserPrompt()
    {
        try
        {
            Role role;
            while (true)
            {
                Console.WriteLine("Select Role:\n1. Manager\n2. FrontDesk\n3. Housekeeping");
                string? roleString = Console.ReadLine();
                if (roleString == "1") { role = Role.Manager; break; }
                if (roleString == "2") { role = Role.FrontDesk; break; }
                if (roleString == "3") { role = Role.Housekeeping; break; }
                Console.WriteLine("Invalid role.");
            }

            User newUser = _managerService.AddUser(role);
            Console.WriteLine($"User created successfully. Generated Employee ID: {newUser.EmployeeId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void SetPricingStrategyPrompt()
    {
        try
        {
            IPricingStrategy strategy;
            while (true)
            {
                Console.WriteLine("Select Pricing Strategy:\n1. Regular\n2. Holiday");
                string? choice = Console.ReadLine();
                if (choice == "1") { strategy = new RegularPricing(); break; }
                if (choice == "2") { strategy = new HolidayPricing(); break; }
                Console.WriteLine("Invalid choice.");
            }

            _managerService.SetPricingStrategy(strategy);
            Console.WriteLine("Pricing strategy updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ShowFrontDeskMenu()
    {
        Console.WriteLine("1. Check In Guest");
        Console.WriteLine("2. Check Out Guest");
        Console.WriteLine("3. View Available Rooms");
        Console.WriteLine("4. Logout");
        Console.Write("Select an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                CheckInPrompt();
                break;
            case "2":
                CheckOutPrompt();
                break;
            case "3":
                ViewAvailableRoomsPrompt();
                break;
            case "4":
                _loginService.Logout();
                Console.Clear();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private static void ViewAvailableRoomsPrompt()
    {
        var availableRooms = _frontDeskService.GetAvailableRooms();
        if (availableRooms.Count == 0)
        {
            Console.WriteLine("No rooms are currently available.");
            return;
        }

        Console.WriteLine("=== Available Rooms ===");
        foreach (var room in availableRooms)
        {
            Console.WriteLine(room.ToString());
        }
    }

    private static void CheckInPrompt()
    {
        try
        {
            int room;
            while (true)
            {
                Console.Write("Room Number: ");
                if (int.TryParse(Console.ReadLine(), out room)) break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            int stay;
            while (true)
            {
                Console.Write("Length of Stay (days): ");
                if (int.TryParse(Console.ReadLine(), out stay)) break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            float price = _pricingService.CalculatePrice(room, stay);
            Console.WriteLine($"Price for {stay} nights: ${price:F2}");
            Console.Write("Confirm booking? (Y/N): ");
            string confirm = Console.ReadLine()?.ToUpper() ?? "N";
            while (confirm != "Y" && confirm != "N")
            {
                Console.Write("Invalid input. Please enter Y or N: ");
                confirm = Console.ReadLine()?.ToUpper() ?? "N";
            }

            if (confirm == "N") return;

            string? name;
            while (true)
            {
                Console.Write("Guest Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) break;
                Console.WriteLine("Input cannot be empty.");
            }

            string? phone;
            while (true)
            {
                Console.Write("Phone Number: ");
                phone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(phone)) break;
                Console.WriteLine("Input cannot be empty.");
            }

            _frontDeskService.CheckIn(room, name!, phone!, stay);

            Console.WriteLine("Check-in successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void CheckOutPrompt()
    {
        try
        {
            int room;
            while (true)
            {
                Console.Write("Room Number: ");
                if (int.TryParse(Console.ReadLine(), out room)) break;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            _frontDeskService.CheckOut(room);
            Console.WriteLine("Check-out successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void ShowHousekeepingMenu()
    {
        Console.WriteLine("1. View Rooms with Tasks");
        Console.WriteLine("2. View Tasks for Room");
        Console.WriteLine("3. Mark Task as Done");
        Console.WriteLine("4. Create Cleaning Task");
        Console.WriteLine("5. Create Repair Task");
        Console.WriteLine("6. Remove Task");
        Console.WriteLine("7. Logout");
        Console.Write("Select an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                var rooms = _houseKeepingService.GetRoomsWithTasks();
                if (rooms.Count == 0)
                {
                    Console.WriteLine("No rooms currently have tasks.");
                    break;
                }
                Console.WriteLine("Rooms with tasks: " + string.Join(", ", rooms));
                break;
            case "2":
                try
                {
                    int taskRoom;
                    while (true)
                    {
                        Console.Write("Room Number: ");
                        if (int.TryParse(Console.ReadLine(), out taskRoom)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    var tasks = _houseKeepingService.GetTasksForRoom(taskRoom);
                    for (int i = 1; i <= tasks.Count; i++)
                    {
                        Console.WriteLine($"[{i}] {tasks[i-1].ToString()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
            case "3":
                try
                {
                    int completedTaskRoom;
                    while (true)
                    {
                        Console.Write("Room Number: ");
                        if (int.TryParse(Console.ReadLine(), out completedTaskRoom)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    int taskNumber;
                    while (true)
                    {
                        Console.Write("Task Number: ");
                        if (int.TryParse(Console.ReadLine(), out taskNumber)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    _houseKeepingService.MarkDone(completedTaskRoom, taskNumber - 1);
                    Console.WriteLine("Task marked as done.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
            case "4":
                try
                {
                    int taskRoomCleaning;
                    while (true)
                    {
                        Console.Write("Room Number: ");
                        if (int.TryParse(Console.ReadLine(), out taskRoomCleaning)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    bool deep;
                    while (true)
                    {
                        Console.Write("Deep Clean? (y/n): ");
                        string deepString = Console.ReadLine()?.ToLower() ?? "n";
                        if (deepString == "y") { deep = true; break; }
                        if (deepString == "n") { deep = false; break; }
                        Console.WriteLine("Invalid input.");
                    }
                    _houseKeepingService.CreateCleaningTask(taskRoomCleaning, deep);
                    Console.WriteLine("Cleaning task created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
            case "5":
                try
                {
                    int taskRoomRepair;
                    while (true)
                    {
                        Console.Write("Room Number: ");
                        if (int.TryParse(Console.ReadLine(), out taskRoomRepair)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    string[] items;
                    while (true)
                    {
                        Console.Write("Damaged Items (comma separated): ");
                        string? input = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            items = input.Split(',').Select(s => s.Trim()).ToArray();
                            break;
                        }
                        Console.WriteLine("Input cannot be empty.");
                    }
                    _houseKeepingService.CreateRepairTask(taskRoomRepair, items);
                    Console.WriteLine("Repair task created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
            case "6":
                try
                {
                    int taskRoomRemove;
                    while (true)
                    {
                        Console.Write("Room Number: ");
                        if (int.TryParse(Console.ReadLine(), out taskRoomRemove)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    int taskNumberRemove;
                    while (true)
                    {
                        Console.Write("Task Number: ");
                        if (int.TryParse(Console.ReadLine(), out taskNumberRemove)) break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    _houseKeepingService.RemoveTask(taskRoomRemove, taskNumberRemove - 1);
                    Console.WriteLine("Task removed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;
            case "7":
                _loginService.Logout();
                Console.Clear();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}