namespace Data.Model
{
    public class PaymentDetail
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public double CompanyEarning { get; set; }
        public double CompanyPayment { get; set; }
        public double CompanyRemainingAmount { get; set; }
        public DateTime CompanyPaymentDate { get; set; }
        public string CustomerNameSurname { get; set; }
        public double CustomerEarning { get; set; }
        public double CustomerPayment { get; set; }
        public double CustomerRemainingAmount { get; set; }
        public DateTime CustomerPaymentDate { get; set; }
    }

}
