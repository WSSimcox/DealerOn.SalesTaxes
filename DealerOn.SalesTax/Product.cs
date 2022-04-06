namespace DealerOn.SalesTaxes.Models
{
    public class Product
    {
        /// <summary>
        /// Guid that represents an Product's id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// string that represents Product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ItemType enum that represents an Product's Type
        /// </summary>
        public ProductType Type { get; set; }

        /// <summary>
        /// string that represents Product's description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// double that represents Product's price
        /// </summary>
        public decimal Price { get; set; }

        ///// <summary>
        ///// double that represents the Product's price with tax included
        ///// </summary>
        //public double? PriceAfterTaxes { get; set; }

        /// <summary>
        /// bool that represents if Product is imported
        /// </summary>
        public bool IsImported { get; set; }
    }

    /// <summary>
    /// Enumerator used for classifying a type of Item for tax purposes
    /// </summary>
    public enum ProductType
    {
        Other = 1,
        Book = 2,
        Food = 3,
        Medical = 4,
    }
}
