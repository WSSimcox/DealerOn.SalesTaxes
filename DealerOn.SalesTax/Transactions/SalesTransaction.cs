namespace DealerOn.SalesTaxes.Models.Transactions
{
    public class SalesTransaction
    {
        /// <summary>
        /// Unique Identification number for a reciept
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DateTime of when reciept was issued
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// List of all products and their quantities that belong to a reciept
        /// </summary>
        public IList<LineItem>? LineItems { get; set; }

        /// <summary>
        /// Create a new instance of an initialized SalesTransaction object
        /// </summary>
        /// <returns> SalesTransaction object </returns>
        public static SalesTransaction CreateSalesTransaction()
        {
            var transaction = new SalesTransaction();
            transaction.Id = Guid.NewGuid();
            transaction.TransactionDate = DateTime.UtcNow;
            transaction.LineItems = new List<LineItem>();

            return transaction;
        }
    }
}
