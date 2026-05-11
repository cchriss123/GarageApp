namespace GarageApp.Models.Vehicles;

public abstract class Vehicle(string regNumber, Color color,  byte amountOfWheels )
{
    public string RegistrationNumber { get; } = regNumber;
    public Color Color { get; } = color;
    public byte AmountOfWheels { get; set; } = amountOfWheels;
    
    
    
    
    public  override string ToString()
    {
        return $"{GetType().Name}, Registration Number: {RegistrationNumber}, Color: {Color},  AmountOfWheels: {AmountOfWheels}";
    }
}