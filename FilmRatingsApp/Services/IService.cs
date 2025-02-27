using FilmRatingsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Services
{
    public interface IService
    {
        Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur);

        Task<Utilisateur> GetUtilisateurByIdAsync(string nomController, int utilisateurId);

        Task<Utilisateur> GetUtilisateurByEmailAsync(string nomController, string utilisateurEmail);

        Task<bool> PutUtilisateurAsync(string nomController, Utilisateur utilisateur);

        Task<bool> PostUtilisateurAsync(string nomController, Utilisateur utilisateur);

        Task<bool> DeleteUtilisateurAsync(string nomController, int utilisateurId);
    }
}
