namespace DealerOn.SalesTaxes.Models.Transactions
{
    public class Receipt : SalesTransaction
    {
        /// <summary>
        /// decimal that represents sales tax cost
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// decimal that represents total cost of a reciept
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}
