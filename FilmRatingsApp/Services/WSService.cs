using FilmRatingsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace FilmRatingsApp.Services
{
    public class WSService : IService
    {
        private HttpClient client = new HttpClient();

        public WSService(string url)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
