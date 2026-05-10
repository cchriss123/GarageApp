using System.Text;
using GarageApp.Models;

namespace GarageApp.Ui;

public static class GarageViewer
{
    public static void ListVehicles(Garage garage)
    {
        var sb = new StringBuilder();

        var vehicles = garage.GetVehicles();
        for (var i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] != null)
                sb.AppendLine($"{i}: {vehicles[i]?.ToString()}.");
        }
        Console.WriteLine(sb.ToString());
    }

    public static void SearchMenu(Garage garage)
    {
        const string searchMenuText = """
                                      Search vehicles
                                      1. Search by registration number
                                      2. Filter by vehicle properties

                                      Any other key to go back.
                                      """;
        Console.WriteLine(searchMenuText);
        var input = Console.ReadLine() ?? "";

        if (input == "1")
            SearchByRegNumber(garage);
        else if (input == "2") 
            SearchByVehicleProperties(garage);
    }

    private static void SearchByRegNumber(Garage garage)
    {
        var vehicles = garage.GetVehicles();
        
        Console.Write("Search by register number:\nPlease enter number to search for ");
        
        var input = Console.ReadLine() ?? "";
        
        for (var i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
                continue;

            if (vehicles[i]?.RegistrationNumber == input)
            {
                Console.Write($"Found at {i}: {vehicles[i]}.");
                return;
            }
        }
        Console.WriteLine($"{input} not found.");
    }
    
    private static void SearchByVehicleProperties(Garage garage)
    {
        throw new NotImplementedException();
    }
}