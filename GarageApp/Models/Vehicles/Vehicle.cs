using System.Drawing;

namespace GarageApp;

public abstract class Vehicle(string regNumber, Color color,  byte amountOfWheels )
{
    public string RegistrationNumber { get; set; } = regNumber;
    public Color Color { get; set; } = color;
    public byte AmountOfWheels { get; set; } = amountOfWheels;
}