using System.Text;

namespace GarageApp;

public static class GarageViewer
{
    public static void ListVehicles(Garage garage)
    {
        var sb = new StringBuilder();
        
        foreach (var v in garage.GetVehicles())
        {
            if (v != null)
                sb.AppendLine(v.ToString());
            
        }
        Console.WriteLine(sb.ToString());
    }
}