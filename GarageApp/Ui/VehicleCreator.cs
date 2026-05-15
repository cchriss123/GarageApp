using System.Diagnostics;
using GarageApp.Models;
using GarageApp.Models.Vehicles;

namespace GarageApp.Ui;

internal enum VehicleType
{
    Car,
    Motorcycle,
    Bus,
    Boat,
    Airplane
    
}

public static class VehicleCreator
{
    
    public static Vehicle? CreateVehicleFromInput(Garage garage)
    {
        var vehicleType = GetVehicleType();
        if (vehicleType is null) return null;

        var regNumber = GetRegNumber(garage);
        byte amountOfWheels = GetAmountOfWheels();
        var color = GetColor();

        var vehicleMessage = GetVehicleMessage(vehicleType);
        var vehicleSpecificInfo = GetVehicleSpecificInfo(vehicleMessage);

        return vehicleType switch
        {
            VehicleType.Car =>
                new Car(regNumber, color, amountOfWheels, vehicleSpecificInfo),

            VehicleType.Motorcycle =>
                new Motorcycle(regNumber, color, amountOfWheels, vehicleSpecificInfo),

            VehicleType.Bus =>
                new Bus(regNumber, color, amountOfWheels, vehicleSpecificInfo),

            VehicleType.Boat =>
                new Boat(regNumber, color, amountOfWheels, vehicleSpecificInfo),

            VehicleType.Airplane =>
                new Airplane(regNumber, color, amountOfWheels, vehicleSpecificInfo),

            _ => throw new UnreachableException()
        };
    }
    

    private static VehicleType? GetVehicleType()
    {
        const string menuText = """
                                Select type of vehicle here.
                                1. Car
                                2. Motorcycle
                                3. Bus
                                4. Boat
                                5. Airplane
                                E. Cancel
                                """;

        while (true)
        {
            Console.WriteLine(menuText);

            var input = Console.ReadLine();
            var isValidInput = input is "1" or "2" or "3" or "4" or "5" or "E";

            if (isValidInput)
                return input switch
                {
                    "1" => VehicleType.Car,
                    "2" => VehicleType.Motorcycle,
                    "3" => VehicleType.Bus,
                    "4" => VehicleType.Boat,
                    "5" => VehicleType.Airplane,
                    _ => null
                };
            Console.WriteLine("Invalid input");
        }
    }
    
    private static string GetRegNumber(Garage garage)
    {
        const string menuText = "Please enter a registration number\nFormat: ABC123 (3 letters followed by 3 digits)";
        
        while (true)
        {
            Console.WriteLine(menuText);
            var input = Console.ReadLine() ?? "";
            var isValidRegNumber = ValidateRegNumberFormat(input);
            var garageContainsRegNumber = garage.ContainsRegNumber(input);
            
            if (isValidRegNumber && !garageContainsRegNumber) 
                return input;

            if (!isValidRegNumber)
            {
                Console.WriteLine("Invalid input format");
                
            }

            if (garageContainsRegNumber)
            {
                Console.WriteLine("Garage already contains reg number");
            }
            
        }
    }

    private static bool ValidateRegNumberFormat(string input)
    {
        var trimmedInput = input.Trim();
        var trimmedInputLength = trimmedInput.Length;   
        
        if (trimmedInputLength != 6) return false;

        for (var i = 0; i < trimmedInputLength; i++)
        {
            if (i is 0 or 1 or 2)
            {
                if(!char.IsLetter(trimmedInput[i])) return false;
            }
            else
            {
                if (!char.IsDigit(trimmedInput[i])) return false;
            }
        }
        return true;
    }
    
    private static byte GetAmountOfWheels()
    {
        while (true)
        {
            Console.WriteLine("Please enter the number of wheels (0-255): ");

            var input = Console.ReadLine();

            if (byte.TryParse(input, out var amountOfWheels))
            {
                return amountOfWheels;
            }
            Console.WriteLine("Invalid input.");
        }
    }
    
    private static Color GetColor()
    {
        const string menuText = """
                                Select vehicle color.
                                1. Red
                                2. Green
                                3. Blue
                                4. Yellow
                                5. Black
                                6. White
                                7. Grey
                                """;

        while (true)
        {
            Console.WriteLine(menuText);

            var input = Console.ReadLine();
            var isValidInput = input is "1" or "2" or "3" or "4" or "5" or "6" or "7";

            if (isValidInput)
                return input switch
                {
                    "1" => Color.Red,
                    "2" => Color.Green,
                    "3" => Color.Blue,
                    "4" => Color.Yellow,
                    "5" => Color.Black,
                    "6" => Color.White,
                    "7" => Color.Grey,
                    _ => throw new UnreachableException()
                };

            Console.WriteLine("Invalid input");
        }
    }
    
    private static string GetVehicleMessage(VehicleType? vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.Car =>
                "Is the car convertible?",
            VehicleType.Motorcycle =>
                "Does the motorcycle have a sidecar?",
            VehicleType.Bus =>
                "Is the bus double decker?",
            VehicleType.Boat =>
                "Does the boat have a trailer?\nWarning: Boats without trailers cannot be parked in the garage.",
            VehicleType.Airplane =>
                "Can the airplane land vertically?\nWarning: Airplanes that cannot land vertically cannot be parked in the garage.",
            _ => throw new UnreachableException()
        };
    }

    private static bool GetVehicleSpecificInfo(string vehicleMessage)
    {
        while (true)
        {
            Console.WriteLine(vehicleMessage);
            Console.WriteLine("1. Yes\n2. No");
            var input = Console.ReadLine() ?? "";

            if (input is "1" or "2")
            {
                return input == "1";

            }
            Console.WriteLine("Invalid input");

        }
    }

}
                               