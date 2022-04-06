namespace DealerOn.SalesTaxes.Models.Transactions
{
    public class CalculatedValue
    {
        /// <summary>
        /// Cost of individual
        /// </summary>
        public decimal CostPerItem { get; set; }

        /// <summary>
        /// Total tax of an item
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total cost of item with tax
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Name of Calculated Value
        /// </summary>
        public string Name { get; set; }
    }
}
