using GarageApp.Models;
using GarageApp.Models.Vehicles;

namespace GarageApp;

public class Airplane(string regNumber, Color color, byte amountOfWheels, bool canLandVertically) : Vehicle(regNumber, color, amountOfWheels)
{
    public bool CanLandVertically { get; } = canLandVertically;
}