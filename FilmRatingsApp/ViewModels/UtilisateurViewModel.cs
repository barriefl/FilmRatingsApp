using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.ViewModels
{
    public class UtilisateurViewModel : ObservableObject
    {
        public IRelayCommand BtnSearchUtilisateurCommand { get; }
        public IRelayCommand BtnModifyUtilisateurCommand { get; }
        public IRelayCommand BtnClearUtilisateurCommand { get; }
        public IRelayCommand BtnAddUtilisateurCommand { get; }
        private Utilisateur utilisateurSearch;
        private string searchMail;
        private WSService service;

        public Utilisateur UtilisateurSearch
        {
            get
            {
                return this.utilisateurSearch;
            }

            set
            {
                this.utilisateurSearch = value;
                OnPropertyChanged();
            }
        }

        public string SearchMail
        {
            get
            {
                return this.searchMail;
            }

            set
            {
                this.searchMail = value;
                OnPropertyChanged();
            }
        }

        public UtilisateurViewModel() 
        {
            GetDataOnLoadAsync();
            BtnSearchUtilisateurCommand = new RelayCommand(ActionSearchUtilisateur);
            BtnModifyUtilisateurCommand = new RelayCommand(ActionModifyUtilisateur);
            BtnClearUtilisateurCommand = new RelayCommand(ActionClearUtilisateur);
            BtnAddUtilisateurCommand = new RelayCommand(ActionAddUtilisateur);
            UtilisateurSearch = new Utilisateur();
        }

        public async void GetDataOnLoadAsync()
        {
            service = new WSService("https://localhost:7290/api/");
            List<Utilisateur> result = await service.GetUtilisateursAsync("utilisateurs");
            if (result == null)
            {
                MessageAsync("API non disponible !", "Erreur");
            }
        }

        public async void ActionSearchUtilisateur()
        {
            var resultat = await service.GetUtilisateurByEmailAsync("utilisateurs", this.SearchMail);

            if (resultat == null)
            {
                MessageAsync("L'utilisateur n'existe pas.", "Erreur");
            }
            else
            {
                this.UtilisateurSearch = resultat;
                MessageAsync("Utilisateur trouvée !", "Notification");
            }
        }

        public async void ActionModifyUtilisateur()
        {
            if (string.IsNullOrEmpty(this.UtilisateurSearch.Nom) || string.IsNullOrEmpty(this.UtilisateurSearch.Prenom) || string.IsNullOrEmpty(this.UtilisateurSearch.Mobile) || string.IsNullOrEmpty(this.UtilisateurSearch.Mail) || string.IsNullOrEmpty(this.UtilisateurSearch.Pwd) || string.IsNullOrEmpty(this.UtilisateurSearch.Rue) || string.IsNullOrEmpty(this.UtilisateurSearch.CodePostal) || string.IsNullOrEmpty(this.UtilisateurSearch.CodePostal) || string.IsNullOrEmpty(this.UtilisateurSearch.Ville) || string.IsNullOrEmpty(this.UtilisateurSearch.Pays))
            {
                MessageAsync("Un ou plusieurs champs sont manquants.", "Erreur");
            }
            else
            {
                bool updated = await service.PutUtilisateurAsync("utilisateurs", this.UtilisateurSearch);

                if (updated)
                {
                    var result = await service.GetUtilisateurByEmailAsync("utilisateurs", this.UtilisateurSearch.Mail);

                    if (result != null)
                    {
                        this.UtilisateurSearch = result;

                        MessageAsync("Utilisateur modifié avec succès !", "Notification");
                    }
                    else
                    {
                        MessageAsync("Erreur lors de la récupération de l'utilisateur.", "Erreur");
                    }
                }
                else
                {
                    MessageAsync("Erreur lors de la mise à jour de l'utilisateur.", "Erreur");
                }
            }
        }

        public void ActionClearUtilisateur()
        {
            this.UtilisateurSearch = null;
            this.SearchMail = null;
        }

        public async void ActionAddUtilisateur()
        {
            if (string.IsNullOrEmpty(this.UtilisateurSearch.Nom) || string.IsNullOrEmpty(this.UtilisateurSearch.Prenom) || string.IsNullOrEmpty(this.UtilisateurSearch.Mobile) || string.IsNullOrEmpty(this.UtilisateurSearch.Mail) || string.IsNullOrEmpty(this.UtilisateurSearch.Pwd) || string.IsNullOrEmpty(this.UtilisateurSearch.Rue) || string.IsNullOrEmpty(this.UtilisateurSearch.CodePostal) || string.IsNullOrEmpty(this.UtilisateurSearch.CodePostal) || string.IsNullOrEmpty(this.UtilisateurSearch.Ville) || string.IsNullOrEmpty(this.UtilisateurSearch.Pays))
            {
                MessageAsync("Un ou plusieurs champs sont manquants.", "Erreur");
            }
            else
            {
                bool added = await service.PostUtilisateurAsync("utilisateurs", this.UtilisateurSearch);

                if (added)
                {
                    var result = await service.GetUtilisateurByEmailAsync("utilisateurs", this.UtilisateurSearch.Mail);

                    if (result != null)
                    {
                        this.UtilisateurSearch = result;

                        MessageAsync("Utilisateur ajouté avec succès !", "Notification");
                    }
                    else
                    {
                        MessageAsync("Erreur lors de la récupération de l'utilisateur.", "Erreur");
                    }
                }
                else
                {
                    MessageAsync("Erreur lors de l'ajout de l'utilisateur.", "Erreur");
                }
            }
        }

        private async void MessageAsync(string content, string title)
        {
            ContentDialog errorMessage = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };

            errorMessage.XamlRoot = App.MainRoot.XamlRoot;
            await errorMessage.ShowAsync();
        }
    }
}
