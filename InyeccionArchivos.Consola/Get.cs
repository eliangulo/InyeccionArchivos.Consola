using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace InyeccionArchivos.Consola
{
    public static class Get
    {
        public static async Task Ejecutar()
        {
            var http = new HttpClient();
            var res = await http.GetAsync("https://localhost:7188/WeatherForecast");
            var cuerpo = await res.Content.ReadAsStringAsync();

            foreach(var header in res.Headers)
            {
                Console.WriteLine($"La clave: {header.Key} El valor: {string.Join(",", header.Value)}");
            }

            if(res.IsSuccessStatusCode)
            {
                Console.WriteLine($"La respuesta es Exitosa");
                Console.WriteLine($"Estado: {res.StatusCode} - Codido: {(int)res.StatusCode}");
            }
            else
            {
                Console.WriteLine($"La respuesta es sin exito {res.StatusCode}");
            }
        }
    }
}
