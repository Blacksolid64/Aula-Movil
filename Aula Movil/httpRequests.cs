using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Usuario.cs;


namespace Aula_Movil
{
    class Program
    {    
        //static async Task Main(string[] args)
        //{
          //  Program program = new Program();
            //await program.getUsuarios("http://nodejsclusters-55543-0.cloudclusters.net/usuarios");
            //Console.WriteLine("\nhola hola\n");
       // }

        private async Task getUsuarios(string url)
        {
            HttpClient client = new HttpClient();
            string respuesta = await client.GetStringAsync(url);
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(respuesta);
            foreach (var item in usuarios)
            {
                Console.WriteLine(item.nombre);
            }
        }

    }
}