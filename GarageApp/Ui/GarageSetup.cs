using GarageApp.Models;

namespace GarageApp.Ui;

public static class GarageSetup
{
    public static Garage CreateGarageFromInput()
    {
        Console.WriteLine("Enter garage capacity (1-255). Press Enter for default: 20");
        var input = Console.ReadLine();

        byte amountOfSlots = 20;

        if (byte.TryParse(input, out var parsedSlots) && parsedSlots > 0)
        {
            amountOfSlots = parsedSlots;
        }
        else
        {
            Console.WriteLine("Invalid capacity. Using default: 20");
        }

        Console.WriteLine("Do you want to populate the garage with test vehicles? (y/n)");
        var answer = Console.ReadLine()?.Trim().ToLower() ?? "";

        var isPrePopulated = false;
        if (answer is "n" or "no")
        {
            return new Garage(amountOfSlots, isPrePopulated);
        }
        if (amountOfSlots >= 12)
        {
            isPrePopulated = true;
        }
        else
        {
            Console.WriteLine("Garage is too small for default population. Starting empty.");
        }
        return new Garage(amountOfSlots, isPrePopulated);
    }
}