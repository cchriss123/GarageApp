using System.Text;
using GarageApp.Models;
using GarageApp.Models.Vehicles;

namespace GarageApp.Ui;

public static class GarageViewer
{
    
    public static void ShowVehicles(Garage garage)
    {
        var listVehicles = GarageViewer.ListVehicles(garage.GetVehiclesClone());
        var listVehiclesOutput = listVehicles.Length > 0 ? listVehicles : "No vehicles in the garage";
        Console.WriteLine(listVehiclesOutput);
        UiHelper.PressEnterToContinue();
    }
    
    private static string ListVehicles(Vehicle?[] vehicles)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] != null)
                sb.AppendLine($"{i}: {vehicles[i]?.ToString()}.");
        }
        return sb.ToString();
    }

    public static void SearchMenu(Garage garage)
    {
        while (true)
        {
            const string searchMenuText = """
                                          Search vehicles
                                          1. Search by registration number
                                          2. Filter by vehicle properties

                                          Any other key to go back.
                                          """;
            
            Console.WriteLine(searchMenuText);
            var input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    SearchByRegNumber(garage);
                    break;
                case "2":
                    SearchByVehicleProperties(garage);
                    break;
                default:
                    return;
            }
        }
    }

    private static void SearchByRegNumber(Garage garage)
    {
        var vehicles = garage.GetVehiclesClone();
        
        Console.WriteLine("Please enter registration number to search for:");
        
        var input = Console.ReadLine() ?? "";
        
        for (var i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
                continue;

            if (vehicles[i]?.RegistrationNumber.ToLower() == input.ToLower())
            {
                Console.WriteLine($"Found at slot {i}: {vehicles[i]}");
                UiHelper.PressEnterToContinue();
                return;
            }
        }
        Console.WriteLine("Vehicle not found.");
        UiHelper.PressEnterToContinue();
    }
    
    private static void SearchByVehicleProperties(Garage garage)
    {
        var vehicles = garage.GetVehiclesClone();

        const string vehiclesSelection = """
                                         Please enter the type of vehicle to search for:
                                         1. Car
                                         2. Motorcycle
                                         3. Bus
                                         4. Boat
                                         5. Airplane

                                         Press Enter for any vehicle type.
                                         """;
        Console.WriteLine(vehiclesSelection);
        var vehicleInput = Console.ReadLine() ?? "";

        if (vehicleInput is "1" or "2" or "3" or "4" or "5")
        {
            for (var i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    if (vehicleInput == "1" && vehicles[i] is Car) continue;
                    if (vehicleInput == "2" && vehicles[i] is Motorcycle) continue;
                    if (vehicleInput == "3" && vehicles[i] is Bus) continue;
                    if (vehicleInput == "4" && vehicles[i] is Boat) continue;
                    if (vehicleInput == "5" && vehicles[i] is Airplane) continue;
                }
                vehicles[i] = null;

            }
        }
        
        const string colorSelection = """
                                      Please enter the color to search for:
                                      1. Red
                                      2. Green
                                      3. Blue
                                      4. Yellow
                                      5. Black
                                      6. White
                                      7. Grey

                                      Press Enter for any color.
                                      """;

        Console.WriteLine(colorSelection);
        var colorInput = Console.ReadLine() ?? "";
        
        if (colorInput is "1" or "2" or "3" or "4" or "5"  or "6" or "7")
        {
            for (var i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    if (colorInput == "1" && vehicles[i]?.Color == Color.Red) continue;
                    if (colorInput == "2" && vehicles[i]?.Color == Color.Green) continue;
                    if (colorInput == "3" && vehicles[i]?.Color == Color.Blue) continue;
                    if (colorInput == "4" && vehicles[i]?.Color == Color.Yellow) continue;
                    if (colorInput == "5" && vehicles[i]?.Color == Color.Black) continue;
                    if (colorInput == "6" && vehicles[i]?.Color == Color.White) continue;
                    if (colorInput == "7" && vehicles[i]?.Color == Color.Grey) continue;
                }
                vehicles[i] = null;

            }
        }
        
        Console.WriteLine("Please enter the number of wheels (0-255)\nPress Enter for any amount");

        var amountOfWheelsInput = Console.ReadLine();

        if (byte.TryParse(amountOfWheelsInput, out var amountOfWheels))
        {
            for (var i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null && vehicles[i]?.AmountOfWheels == amountOfWheels) continue;
                vehicles[i] = null;
            }
        }
        
        var hasHits = vehicles.Any(v => v != null);
        
        var output = hasHits 
            ? $"Following vehicles found:\n{ListVehicles(vehicles)}" 
            : "No vehicles found.";
        
        Console.WriteLine(output);
        UiHelper.PressEnterToContinue();
        
    }
}