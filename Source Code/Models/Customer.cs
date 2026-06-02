namespace projjjjj
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Customer() { }

        public Customer(int customerId, string firstName, string lastName,
                        string phoneNumber, string email)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString()
        {
            return $"[{CustomerID}] {FullName} | {PhoneNumber} | {Email}";
        }
    }
}
