using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Web_API.Handlers.Empleados.DTOs
{
    // CLASE #1:
    public class EmpleadoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese Un Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Inhrese la Edad del Empleado:")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese El Puesto de Trabajo:")]
        public string Puesto { get; set; }

        [Required(ErrorMessage = "Ingrese El Salario:")]
        public decimal Salario { get; set; }
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
        [Required(ErrorMessage ="Ingrese Un Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Inhrese la Edad del Empleado:")]
        public int Edad { get; set; }

        [Required(ErrorMessage ="Ingrese El Puesto de Trabajo:")]
        public string Puesto { get; set; }

        [Required(ErrorMessage ="Ingrese El Salario:")]
        public decimal Salario { get; set; }
    }

  
}
