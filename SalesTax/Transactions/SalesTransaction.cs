namespace SalesTaxes.Models.Transactions
{
    public class SalesTransaction
    {
        /// <summary>
        /// Unique Identification number for a transaction
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DateTime of when reciept was issued
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// List of all products and their quantities that belong to a transaction
        /// </summary>
        public IList<LineItem>? LineItems { get; set; }

        /// <summary>
        /// Receipt that belongs to a transaction
        /// </summary>
        public Receipt? Receipt { get; set; }

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
            transaction.Receipt = new Receipt();

            return transaction;
        }
    }
}
