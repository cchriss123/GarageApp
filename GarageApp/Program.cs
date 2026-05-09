namespace GarageApp;

class Program
{
    static void Main(string[] args)
    {
        Garage garage = new Garage();

        string menuText =
            """
            Welcome to Garage App
            Please select an option from the menu
            1. Park.
            E. Exit app.
            """;
        
        var isRunning = true;
        while (isRunning)
        {
            Console.WriteLine(menuText);
            
            var input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                {
                    var vehicle = AddMenu.CreateVehicleFromInput();
                    if (vehicle is null) 
                        break;
                    garage.AddVehicle(vehicle);
                    break;
                }
                case "E" or "e": isRunning = false; break;
                default: Console.WriteLine("Felaktigt alternativ"); break;
                
            }
            
        }
        
        
        
        
        
        
        
        
        
        
        
        



        
     
    }
}