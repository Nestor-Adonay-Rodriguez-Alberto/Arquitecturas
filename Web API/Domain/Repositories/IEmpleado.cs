using Web_API.Domain.Entities;

namespace Web_API.Domain.Repositories
{
    public interface IEmpleado
    {
        Task<int> Crear(Empleado empleado);
        Task<int> Editar(Empleado empleado);
        Task<int> Eliminar(Empleado empleado);
        Task<Empleado> Obtener_PoId(int Id);
        Task<List<Empleado>> Listar();

    }
}
