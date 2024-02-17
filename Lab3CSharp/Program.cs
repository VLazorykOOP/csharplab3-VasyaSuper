using Lab3CSharp;

namespace Lab3CSharp
{
    public class Point
    {
        private int x;
        private int y;
        private int c;

        public Point()
        {
            x = 0;
            y = 0;
            c = 0;
        }
        public Point(int x, int y) 
        {
            this.x = x;
            this.y = y;
            c = 0;
        }
        public void displayCoordinate() 
        {
            Console.WriteLine($"Coordinates of the point: ({x}, {y})");
        }
        public double calculationDistance () 
        {
            return Math.Sqrt( x * x + y * y );
        }
        public void moveToPoint (int x1, int y1)
        {
            x += x1;
            y += y1;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int C
        {
            get { return c; }
        }
    }
    class TransportVehicle
    {
        public string model { get; set; }
        public double speed { get; set; }
        public double price { get; set; }
        public virtual void Show()
        {
            Console.WriteLine($"Model: {model}, Speed: {speed}, Price: {price}");
        }
    }
    class Car: TransportVehicle
    {
        public int numberOfDoors { get; set; }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Number of doors: {numberOfDoors} ");
        }
    }
    class Train: TransportVehicle
    {
        public int numberOfWagons { get; set; }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Number of waagons: {numberOfWagons}");
        }
    }
    class Express: Train
    {
        public bool passengerWagons { get; set; }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Passenger wagons: {passengerWagons}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Lab 3 \n");

            Point point3 = new Point();
            point3.displayCoordinate();

            Point point1 = new Point(3, 4);
            point1.displayCoordinate();

            double distanse = point1.calculationDistance();
            Console.WriteLine($"Distanse to the center: {distanse} ");

            point1.moveToPoint(8, 9);
            point1.displayCoordinate();

            Point point2 = new Point(6, 7);
            point2.X = 3;
            point2.Y = 4;
            point2.displayCoordinate();
            Console.WriteLine($"X point coordinate: {point2.X}\n");
            

            Point[] points = new Point[]
            {
            new Point(1, 2),
            new Point(3, 4),
            new Point(5, 6),
            new Point(7, 8),
            new Point(9, 10)
            };

            double totalDistance = 0;
            foreach (Point point in points)
            {
                double distance = point.calculationDistance();
                Console.WriteLine($"Distance ({point.X}, {point.Y}), distance to the center: {distance}");
                totalDistance += distance;
            }

            double averageDistance = totalDistance / points.Length;
            Console.WriteLine($"\nAverage distance: {averageDistance}\n");

            foreach (Point point in points)
            {
                if (point.calculationDistance() > averageDistance)
                {
                    Console.WriteLine($"Point ({point.X}, {point.Y}) moved to vector (20, 20)\n");
                    point.moveToPoint(20, 20);
                }
            }
            // Створення масиву базового класу
            TransportVehicle[] vehicles = new TransportVehicle[3];

            // Наповнення масиву об'єктами різних похідних класів
            vehicles[0] = new Car { model = "Toyota", speed = 180, price = 25000, numberOfDoors = 4 };
            vehicles[1] = new Train { model = "Intercity", speed = 120, price = 100000, numberOfWagons = 10 };
            vehicles[2] = new Express { model = "HighSpeedExpress", speed = 250, price = 500000, numberOfWagons = 6, passengerWagons = true };

            // Виведення масиву впорядкованого за швидкістю
            Array.Sort(vehicles, (x, y) => x.speed.CompareTo(y.speed));

            Console.WriteLine("Vehicles sorted by speed:");
            foreach (var vehicle in vehicles)
            {
                vehicle.Show();
            }
        }
    }
}
