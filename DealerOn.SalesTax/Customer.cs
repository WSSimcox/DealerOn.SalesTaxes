namespace DealerOn.SalesTaxes.Models
{
    public class Customer
    {
        /// <summary>
        /// Unique identification number for a user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A string that represents and contains the user's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// A string that represents and contains the user's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A string that represents and contains the user's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// A string that represents and contains the user's last name
        /// </summary>
        public string LastName { get; set; }
    }
}
