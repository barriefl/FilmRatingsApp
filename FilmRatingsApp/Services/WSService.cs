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

        public async Task<Utilisateur> GetUtilisateurByIdAsync(string nomController, int utilisateurId)
        {
            try
            {
                string url = string.Concat(nomController, "/GetById/", utilisateurId);
                return await client.GetFromJsonAsync<Utilisateur>(url);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Utilisateur> GetUtilisateurByEmailAsync(string nomController, string utilisateurEmail)
        {
            try
            {
                string url = string.Concat(nomController, "/GetByEmail/", utilisateurEmail);
                return await client.GetFromJsonAsync<Utilisateur>(url);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PutUtilisateurAsync(string nomController, Utilisateur utilisateur)
        {
            try
            {
                string url = string.Concat(nomController, "/", utilisateur.UtilisateurId);
                var reponse = await client.PutAsJsonAsync(url, utilisateur);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PostUtilisateurAsync(string nomController, Utilisateur utilisateur)
        {
            try
            {
                var reponse = await client.PostAsJsonAsync(nomController, utilisateur);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUtilisateurAsync(string nomController, int utilisateurId)
        {
            try
            {
                var url = string.Concat(nomController + "/", utilisateurId);
                var reponse = await client.DeleteAsync(url);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
