using InyeccionArchivos.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace InyeccionArchivos.Consola
{
    public static class Post
    {
        public static async Task Ejecutar()
        {
            var http = new HttpClient();
            var url = "https://localhost:7188/WeatherForecast";

            var DTO = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 45,
                Summary = "Mucho Calor"
            };
            var res = await http.PostAsJsonAsync(url, DTO);
            var body = await res.Content.ReadAsStringAsync();

            if(res.IsSuccessStatusCode)
            {
                Console.WriteLine($"La respuesta es Exitosa");
                Console.WriteLine($"{(int)res.StatusCode}{res.StatusCode}");
            }
            else
            {
                Console.WriteLine($"La respuesta es sin exito {res.StatusCode}"); 
            }
        }
    }
}
