using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Web_API.Domain.Entities
{
    public class Empleado
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public int? Age { get; set; }
        public string? dob { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
    }
}
