using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Web_API.Domain.DTOs
{
    // CLASE #1:
    public class EmpleadoDTO
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

    // CLASE #2:
    public class AllEmpleadosDTO
    {
        public List<EmpleadoDTO> List_Empleados { get; set; }

        public AllEmpleadosDTO()
        {
            List_Empleados = new List<EmpleadoDTO>();
        }
    }

    // CLASE #3:
    public class CrearEmpleadoDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public int? Age { get; set; }
        public DateTime? dob { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
    }


}
