using System;
using System.Collections.Generic;

namespace FleetManagerApp
{
    // ---------- Interfaces ----------
    interface IMaintainable
    {
        void ScheduleMaintenance();
    }

    interface ITrackable
    {
        string GetLocation();
    }

    // ---------- Abstract Class ----------
    abstract class Vehicle
    {
        private static int idCounter = 1;
        public int Id { get; }

        public string Make { get; set; }
        public string Model { get; set; }

        private double fuelLevel;

        public double FuelLevel
        {
            get => fuelLevel;
            protected set
            {
                fuelLevel = value < 0 ? 0 : value;
            }
        }

        protected Vehicle(string make, string model, double fuel)
        {
            Id = idCounter++;
            Make = make;
            Model = model;
            FuelLevel = fuel;
        }

        public virtual void Start()
        {
            Console.WriteLine($"Vehicle {Id} started.");
        }

        public void Stop()
        {
            Console.WriteLine($"Vehicle {Id} stopped.");
        }
    }

    // ---------- Car ----------
    class Car : Vehicle, IMaintainable, ITrackable
    {
        public Car(string make, string model, double fuel)
            : base(make, model, fuel) { }

        public override void Start()
        {
            Console.WriteLine($"Car {Id} is starting smoothly.");
        }

        public void ScheduleMaintenance()
        {
            Console.WriteLine($"Car {Id} maintenance scheduled.");
        }

        public string GetLocation()
        {
            return "Car is in Parking Area.";
        }
    }

    // ---------- Truck ----------
    class Truck : Vehicle, IMaintainable, ITrackable
    {
        public Truck(string make, string model, double fuel)
            : base(make, model, fuel) { }

        public override void Start()
        {
            Console.WriteLine($"Truck {Id} started with heavy engine.");
        }

        public void ScheduleMaintenance()
        {
            Console.WriteLine($"Truck {Id} maintenance scheduled.");
        }

        public string GetLocation()
        {
            return "Truck is on Highway.";
        }
    }

    // ---------- Main Program ----------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Day-4 Fleet Manager Assignment ===\n");

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car("Maruti", "Swift", 50),
                new Truck("Tata", "Ultra", 80),
                new Car("Hyundai", "i20", 40)
            };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Vehicle ID: {vehicle.Id}");
                Console.WriteLine($"Make: {vehicle.Make}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Fuel Level: {vehicle.FuelLevel}");

                vehicle.Start();
                vehicle.Stop();

                if (vehicle is IMaintainable maintainable)
                    maintainable.ScheduleMaintenance();

                if (vehicle is ITrackable trackable)
                    Console.WriteLine(trackable.GetLocation());

                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine("Assignment Completed Successfully.");
        }
    }
}
