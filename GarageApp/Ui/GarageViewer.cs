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
}