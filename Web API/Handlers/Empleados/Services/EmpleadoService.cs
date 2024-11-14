using Microsoft.AspNetCore.Authorization;
using Web_API.Handlers.Empleados.DTOs;
using Web_API.Handlers.Empleados.Interfaces;
using Web_API.Models.Entities;


namespace Web_API.Handlers.Empleados.Services
{
    [Authorize]
    public class EmpleadoService
    {
        public IEmpleado _EmpleadoRepository;

        public EmpleadoService(IEmpleado empleado)
        {
            _EmpleadoRepository = empleado; 
        }



        public async Task<AllEmpleadosDTO> Listar(int? pageNumber, int? pageSize)
        {
            List<Empleado> empleados = await _EmpleadoRepository.Listar();
            int number = pageNumber ?? 1;
            int size = pageSize ?? 2;

            // Paginar la lista de empleados dentro de AllEmpleadosDTO
            var empleadosPaginados = empleados.Skip((number - 1) * size).Take(size).ToList();

            // DTO a retornar:
            AllEmpleadosDTO allEmpleados = new();
            empleados = empleadosPaginados;

            foreach (Empleado empleado in empleados)
            {
                allEmpleados.List_Empleados.Add(new EmpleadoDTO
                {
                    Id = empleado.Id,
                    Nombre = empleado.Nombre,
                    Edad = empleado.Edad,
                    Puesto = empleado.Puesto,
                    Salario = empleado.Salario
                });
            }

            return allEmpleados;
        }

        public async Task<EmpleadoDTO> Obtener_PoId(int Id)
        {
            Empleado? empleado = await _EmpleadoRepository.Obtener_PoId(Id);

            if (empleado == null)
            {
                return null;
            }

            EmpleadoDTO empleadoDTO = new EmpleadoDTO
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Edad = empleado.Edad,
                Puesto = empleado.Puesto,
                Salario = empleado.Salario
            };

            return empleadoDTO;
        }

        public async Task<int> Crear(CrearEmpleadoDTO crearEmpleadoDTO)
        {
            Empleado empleado = new Empleado
            {
                Nombre = crearEmpleadoDTO.Nombre,
                Edad = crearEmpleadoDTO.Edad,
                Puesto = crearEmpleadoDTO.Puesto,
                Salario = crearEmpleadoDTO.Salario
            };

            return await _EmpleadoRepository.Crear(empleado);
        }

        public async Task<int> Editar(EmpleadoDTO empleadoDTO)
        {
            Empleado? encontrado = await _EmpleadoRepository.Obtener_PoId(empleadoDTO.Id);

            if (encontrado == null)
            {
                return 0;
            }

            encontrado.Id = empleadoDTO.Id;
            encontrado.Nombre = empleadoDTO.Nombre;
            encontrado.Edad = empleadoDTO.Edad;
            encontrado.Puesto = empleadoDTO.Puesto;
            encontrado.Salario = empleadoDTO.Salario;


            return await _EmpleadoRepository.Editar(encontrado);
        }

        public async Task<int> Eliminar(int Id)
        {
            Empleado? encontrado = await _EmpleadoRepository.Obtener_PoId(Id);

            if (encontrado == null)
            {
                return 0;
            }

            return await _EmpleadoRepository.Eliminar(encontrado);
        }
    }
}
