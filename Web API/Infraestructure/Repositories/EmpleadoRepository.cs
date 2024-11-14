using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using Web_API.Domain.DTOs;
using Web_API.Domain.Entities;
using Web_API.Domain.Repositories;
using Web_API.Infraestructure.Database;

namespace Web_API.Infraestructure.Repositories
{
    public class EmpleadoRepository : IEmpleado
    {
        public readonly MyDBcontext _MyDBcontext;
        public  HttpClient _HttpClient;

        public EmpleadoRepository(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;

            // Crear un handler para ignorar la validación del certificado SSL
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _HttpClient = new HttpClient(handler);
            _HttpClient.BaseAddress = new Uri("https://hub.dummyapis.com/");
        }

        public async Task<List<Empleado>> Listar()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("employee");

            List<Empleado> allEmpleados = new List<Empleado>();

            if (response.IsSuccessStatusCode)
            {
                allEmpleados = await response.Content.ReadFromJsonAsync<List<Empleado>>();
            }

            return allEmpleados;
        }



        // NO USAR:
        public async Task<Empleado> Obtener_PoId(int Id)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync("employee/"+Id);

            Empleado empleado = new Empleado();

            if (response.IsSuccessStatusCode)
            {
                empleado = await response.Content.ReadFromJsonAsync<Empleado>();
            }

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
