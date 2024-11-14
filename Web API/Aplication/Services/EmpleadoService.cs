using Web_API.Domain.DTOs;
using Web_API.Domain.Repositories;
using Web_API.Domain.Entities;


namespace Web_API.Aplication.Services
{
    public class EmpleadoService
    {
        public IEmpleado _EmpleadoRepository;
         
        public EmpleadoService(IEmpleado empleado)
        {
            _EmpleadoRepository = empleado;
        }


        // METODO #1:
        public async Task<AllEmpleadosDTO> Listar()
        {
            List<Empleado> empleados = await _EmpleadoRepository.Listar();

            // DTO a retornar:
            AllEmpleadosDTO allEmpleados = new();

            foreach (Empleado empleado in empleados)
            {
                allEmpleados.List_Empleados.Add(new EmpleadoDTO
                {
                    Id = empleado.Id,
                    FirstName = empleado.FirstName,
                    LastName = empleado.LastName,
                    Email = empleado.Email,
                    ContactNumber = empleado.ContactNumber,
                    Age = empleado.Age,
                    dob = empleado.dob,
                    Salary = empleado.Salary,
                    Address = empleado.Address
                });
            }

            return allEmpleados;
        }



        // NO USAR:
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
                FirstName = empleado.FirstName,
                LastName = empleado.LastName,
                Email = empleado.Email,
                ContactNumber = empleado.ContactNumber,
                Age = empleado.Age,
                dob = empleado.dob,
                Salary = empleado.Salary,
                Address = empleado.Address
            };

            return empleadoDTO;
        }

        public async Task<int> Crear(CrearEmpleadoDTO crearEmpleadoDTO)
        {
            Empleado empleado = new Empleado
            {
            };

            return await _EmpleadoRepository.Crear(empleado);
        }

        public async Task<int> Editar(EmpleadoDTO empleadoDTO)
        {
            Empleado? encontrado = await _EmpleadoRepository.Obtener_PoId((int)empleadoDTO.Id);

            if (encontrado == null)
            {
                return 0;
            }


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
