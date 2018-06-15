namespace ProductToConsole
{
    /// <summary>
    /// Product representation
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product's ID
        /// </summary>
        public int? ID { set; get; }

        /// <summary>
        /// Product's name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Product's price
        /// </summary>
        public double? Price { set; get; }

        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Product(int? id, string name, double? price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Return product in string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ID : " + this.ID + "\nName : " + this.Name + "\nPrice : " + this.Price + "\n";
        }
    }
}
