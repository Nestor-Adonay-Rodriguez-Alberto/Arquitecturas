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

         

        public async Task<(List<Empleado>,int TotalItems)> Listar(int pageNumber, int pageSize)
        {
            IQueryable<Empleado> Query = _MyDBcontext.Empleados.AsQueryable();

            // Nose como enviarlo
            int TotalItems = await _MyDBcontext.Empleados.CountAsync();

            // Elementos a Omitir:
            int skip = (pageNumber - 1) * pageSize;

            // Obtenemos de DB paginados:
            List<Empleado> Empleados = await Query
                .OrderByDescending(x => x.Id)  
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return (Empleados,TotalItems);
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
