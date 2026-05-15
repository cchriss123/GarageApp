using GarageApp.Ui;

namespace GarageApp;

internal static class Program
{
    private static void Main()
    {
        
        var garage = GarageSetup.CreateGarageFromInput();

        const string menuText = """
                                Welcome to Garage App
                                Please select an option from the menu

                                1. Park.
                                2. Remove.
                                3. List vehicles.
                                4. SearchMenu.
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
                    var vehicle = VehicleCreator.CreateVehicleFromInput(garage);
                    if (vehicle is null) 
                        break;
                    garage.AddVehicle(vehicle);
                    break;
                }
                case "2":
                    VehicleRemover.RemoveVehicle(garage);
                    break;
                case "3":
                    GarageViewer.ShowVehicles(garage);
                    break;
                case "4": GarageViewer.SearchMenu(garage);
                    break;
                case "E" or "e": isRunning = false; 
                    break;
                default: 
                    Console.WriteLine("Invalid option."); 
                    UiHelper.PressEnterToContinue();
                    break;
            }
        }
    }
}

