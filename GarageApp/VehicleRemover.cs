using System.Text;

namespace GarageApp;

public class VehicleRemover
{
    public static void RemoveVehicle(Garage garage)
    {
        var sb = new StringBuilder();
        
        var vehicles = garage.GetVehicles();
        
        sb.Append("There are vehicles parked at slot number ");
        for (var i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] != null)
            {
                sb.Append($"{i},");
            }
        }
        var temp = sb.ToString();
        if (temp[^1] == ',')         // remove trailing if there is one
            sb.Remove(temp.Length - 1, 1);

        sb.AppendLine();
        sb.AppendLine("Select what slot you want to remove");
        
        Console.WriteLine(sb.ToString());
        if (!int.TryParse(Console.ReadLine() , out var slot))
        {
            Console.WriteLine("Please enter a number");
            return;
        }

        garage.RemoveVehicle(slot);
        
    }
}