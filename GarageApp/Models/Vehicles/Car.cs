using GarageApp.Models;
using GarageApp.Models.Vehicles;

namespace GarageApp;

public class Car(string regNumber, Color color, byte amountOfWheels, bool isConvertible) : Vehicle(regNumber, color, amountOfWheels)
{
    private bool IsConvertible { get; } = isConvertible;
}