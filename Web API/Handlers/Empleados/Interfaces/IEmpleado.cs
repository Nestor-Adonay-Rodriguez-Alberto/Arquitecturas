
using Web_API.Models.Entities;

namespace Web_API.Handlers.Empleados.Interfaces
{
    public interface IEmpleado
    {
        Task<int> Crear(Empleado empleado);
        Task<int> Editar(Empleado empleado);
        Task<int> Eliminar(Empleado empleado);
        Task<Empleado> Obtener_PoId(int Id);
        Task<(List<Empleado>,int TotalItems)> Listar(int pageNumber, int pageSize);

    }
}
