using GarageApp.Models.Vehicles;

namespace GarageApp;

public class Bus(string regNumber, Color color, byte amountOfWheels, bool isDoubleDecker) : Vehicle(regNumber, color, amountOfWheels)
{
    private bool IsDoubleDecker { get; } = isDoubleDecker;
}