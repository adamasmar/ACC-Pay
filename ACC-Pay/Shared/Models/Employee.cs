namespace ACC_Pay.Shared.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int SocialSecurity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<EmployeeContactInformation>? ContactInformation { get; set; }
    }
}
