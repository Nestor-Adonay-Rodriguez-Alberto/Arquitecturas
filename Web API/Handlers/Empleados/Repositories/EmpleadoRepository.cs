using Microsoft.EntityFrameworkCore;
using Web_API.Handlers.Empleados.Interfaces;
using Web_API.Models.Database;
using Web_API.Models.Entities;


namespace Web_API.Handlers.Empleados.Repositories
{
    public class EmpleadoRepository: IEmpleado
    {
        public readonly MyDBcontext _MyDBcontext;

        public EmpleadoRepository(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }



        public async Task<List<Empleado>> Listar()
        {
            List<Empleado> list = await _MyDBcontext.Empleados.ToListAsync();

            return list;
        }

        public async Task<Empleado> Obtener_PoId(int Id)
        {
            Empleado? empleado = await _MyDBcontext.Empleados.FirstOrDefaultAsync(x=> x.Id==Id);

            return empleado;
        }

        public async Task<int> Crear(Empleado empleado)
        {
             _MyDBcontext.Add(empleado);

            return await _MyDBcontext.SaveChangesAsync();
        }

        public async Task<int> Editar(Empleado empleado)
        {
            _MyDBcontext.Update(empleado);

            return await _MyDBcontext.SaveChangesAsync();
        }

        public async Task<int> Eliminar(Empleado empleado)
        {
            _MyDBcontext.Remove(empleado);

            return await _MyDBcontext.SaveChangesAsync();
        }

        
    }
}
