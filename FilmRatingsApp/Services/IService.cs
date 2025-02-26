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
    }
}
