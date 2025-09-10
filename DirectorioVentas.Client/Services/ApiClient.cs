using DirectorioVentas.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Client.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7126/")
            };
        }

        public async Task<List<Persona>> GetPersonasAsync()
        {
            return await _http.GetFromJsonAsync<List<Persona>>("api/directorio/personas") ?? new();
        }

        public async Task<bool> AddPersonaAsync(Persona persona)
        {
            var response = await _http.PostAsJsonAsync("api/directorio/personas", persona);
            return response.IsSuccessStatusCode;
        }

    }
}
