using GarageApp.Models;

namespace GarageApp.Ui;

public static class GarageSetup
{
    public static Garage CreateGarageFromInput()
    {
        return new Garage(50, true);
    }
}