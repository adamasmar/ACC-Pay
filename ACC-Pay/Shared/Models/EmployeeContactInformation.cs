namespace ACC_Pay.Shared.Models
{
    public class EmployeeContactInformation
    {
        public Guid EmployeeContactInformationId { get; set; }
        public int? PrimaryPhoneNumber { get; set; }
        public int? SecondaryPhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public bool IsCurrent { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
