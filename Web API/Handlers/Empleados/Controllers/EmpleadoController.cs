using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_API.Handlers.Empleados.DTOs;
using Web_API.Handlers.Empleados.Interfaces;
using Web_API.Handlers.Empleados.Services;


namespace Web_API.Handlers.Empleados.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public IEmpleado _empleadoRepository;
         
        public EmpleadoController(IEmpleado empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Listar(int? pageNumber, int? pageSize)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int number = pageNumber ?? 1;
            int size = pageSize ?? 2;

            AllEmpleadosDTO allEmpleados = await _service.Listar(number, size);

            return Ok(allEmpleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener_PoId(int id)
        {
            EmpleadoService _service = new(_empleadoRepository);

            EmpleadoDTO? empleado = await _service.Obtener_PoId(id);

            if (empleado == null)
            {
                return NotFound("Registro No Existente.");
            }

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearEmpleadoDTO crearEmpleadoDTO)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int Respuesta = await _service.Crear(crearEmpleadoDTO);

            if (Respuesta > 0)
            {
                return Ok("Nuevo Empleado Guardado Correctamente");
            }
            else
            {
                return NotFound("Error Al Guardar el Nuevo Empleado.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EmpleadoDTO empleadoDTO)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int Respuesta = await _service.Editar(empleadoDTO);

            if (Respuesta > 0)
            {
                return Ok("Empleado Editado Correctamente");
            }
            else
            {
                return NotFound("Error Al Editar el Empleado.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            EmpleadoService _service = new(_empleadoRepository);

            int Respuesta = await _service.Eliminar(id);

            if (Respuesta > 0)
            {
                return Ok("Empleado Eliminado Correctamente");
            }
            else
            {
                return NotFound("Error El Registro No Existe.");
            }
        }

    }
}
