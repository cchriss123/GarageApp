namespace GarageApp;

public class Motorcycle(string regNumber, Color color, byte amountOfWheels, bool hasSideCar) : Vehicle(regNumber, color, amountOfWheels)
{
    public bool HasSideCar { get;  } = hasSideCar;
}