namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (input != "end")
            {
                string[] inputParam = input.Split("/").ToArray();
                string type = inputParam[0];
                string brand = inputParam[1];
                string model = inputParam[2];
                if (type == "Car")
                {
                    int horsePower = int.Parse(inputParam[3]);
                    Car car = new Car() { Brand = brand, Model = model, HorsePower = horsePower };
                    cars.Add(car);
                }
                if (type == "Truck")
                {
                    int weight = int.Parse(inputParam[3]);
                    Truck truck = new Truck() { Brand = brand, Model = model, Weight = weight };
                    trucks.Add(truck);
                }
                input = Console.ReadLine();
            }
            if (cars.Count != 0)
            {
                List<Car> orderedCars = cars.OrderBy(car => car.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (trucks.Count != 0)
            {
                List<Truck> orderedTrucks = trucks.OrderBy(truck => truck.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
}
