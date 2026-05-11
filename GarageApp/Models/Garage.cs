using GarageApp.Models.Vehicles;

namespace GarageApp.Models;

public class Garage
{
   private readonly Vehicle?[] _vehicles; 
   
   public Garage(byte amountOfSlots, bool isPrePopulated)
   {
      _vehicles = new Vehicle[amountOfSlots];

      if (!isPrePopulated || amountOfSlots < 12) return; 
      _vehicles[0] = new Car("ABC123", Color.Red, 4, true);
      _vehicles[1] = new Car("CAR456", Color.Blue, 4, false);
      // 2 empty
      _vehicles[3] = new Car("RED111", Color.Red, 4, false);
      _vehicles[4] = new Car("BLK222", Color.Grey, 4, true);

      _vehicles[5] = new Motorcycle("MCR123", Color.Black, 2, true);
      _vehicles[6] = new Motorcycle("BIK456", Color.Red, 2, false);
      _vehicles[7] = new Motorcycle("SPD789", Color.Blue, 3, true);

      _vehicles[8] = new Bus("BUS123", Color.Yellow, 6, true);

      _vehicles[9] = new Boat("SEA123", Color.White, 0, true);

      _vehicles[10] = new Airplane("FLY123", Color.Grey, 8, true);

      _vehicles[11] = new Car("XYZ789", Color.Black, 4, true);
   }
   
   
   public void AddVehicle(Vehicle vehicle)
   {
      switch (vehicle)
      {
         case Airplane { CanLandVertically: false }:
            Console.WriteLine("Cannot park airplane in the garage because the garage has no runway.");
            return;
         case Boat { HasTrailer: false }:
            Console.WriteLine("Cannot park boat in the garage because it does not have a trailer.");
            return;
      }

      for (var i = 0; i < _vehicles.Length; i++)
      {
         if (_vehicles[i] != null) continue;
         _vehicles[i] = vehicle;
         Console.WriteLine($"Your {vehicle.GetType().Name} has parked at slot {i}.");
         return;
      }

      Console.WriteLine("Cannot park since the garage is full.");
   }
   
   public Vehicle?[] GetVehiclesClone()
   {
      return _vehicles.ToArray(); // Returns a copy to prevent external modification of the internal array
   }


   public void RemoveVehicle(int slot)
   {
      if (slot < 0 || slot >= _vehicles.Length)
      {
         Console.WriteLine("Please enter a valid number");
         return;
      }
      if (_vehicles[slot] == null)
      {
         Console.WriteLine("There is no vehicle with slot number " + slot);
         return;
      }
      _vehicles[slot] = null;
      Console.WriteLine($"Vehicle removed from slot {slot}.");
   }
}