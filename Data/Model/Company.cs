namespace Data.Model
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManagerUserID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IBAN { get; set; }
        public string MapCode { get; set; }
        public string BankAccountName { get; set; }
        public bool IsActive { get; set; }
    }

}
