namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            List<Box> boxes = new List<Box>();

            while (input!="end")
            {
                string[] items = input.Split().ToArray();
                string serialNumber= items[0];
                string itemName = items[1];
                int itemQuantity = int.Parse(items[2]);
                double itemPrice = double.Parse(items[3]); 

                Item item= new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    ItemObject = item,
                    ItemQuantity = itemQuantity,
                    BoxPrice = itemQuantity * itemPrice
                };
                boxes.Add(box);
                input = Console.ReadLine();
            }
            List<Box>orderedBoxes = boxes
                .OrderByDescending(b=> b.BoxPrice)
                .ToList();

            foreach(var box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.ItemObject.Name} - ${box.ItemObject.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Box
    {
        public string SerialNumber { get; set; }
        public Item ItemObject{ get; set; }
        public int ItemQuantity { get; set; }
        public double BoxPrice { get; set; }
    }
}