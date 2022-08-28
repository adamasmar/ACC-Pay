namespace ACC_Pay.Shared.Models
{
    public class EmployeeW4Configuration
    {
        public Guid EmployeeW4ConfigurationId { get; set; }
        public virtual EmployeeContactInformation EmployeeContactInformation { get; set; }
        public bool Value2c { get; set; }
        public decimal Value3 { get; set; }
        public decimal Value4a { get; set; }
        public decimal Value4b { get; set; }
        public decimal Value4c { get; set; }
        public DateTime DateSigned { get; set; }
        public virtual W4Years W4year { get; set; }
    }
}
