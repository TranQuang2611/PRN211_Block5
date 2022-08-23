namespace WebPractice_ADO.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int UnitInstock { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        public Product()
        {
        }

        public Product(int id, string productName, int unitPrice, int unitInstock, string image)
        {
            Id = id;
            ProductName = productName;
            UnitPrice = unitPrice;
            UnitInstock = unitInstock;
            Image = image;
        }

        public Product(int id, string productName, int unitPrice, int unitInstock, string image, Category category) : this(id, productName, unitPrice, unitInstock, image)
        {
            Category = category;
        }
    }
}
