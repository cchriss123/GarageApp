using GarageApp.Models;
using GarageApp.Models.Vehicles;

namespace GarageApp;

public class Boat(string regNumber, Color color, byte amountOfWheels, bool hasTrailer) : Vehicle(regNumber, color, amountOfWheels)
{
    public bool HasTrailer { get; } = hasTrailer;
    
}