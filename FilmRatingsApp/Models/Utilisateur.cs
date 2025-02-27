using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace FilmRatingsApp.Models
{
    [Table("t_e_utilisateur_utl")]
    [Index(nameof(Mail), IsUnique = true, Name = "uq_utl_mail")]
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le mobile doit contenir 10 chiffres.")]
        public string? Mobile { get; set; }

        [Column("utl_mail")]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string Mail { get; set; }

        [Column("utl_pwd")]
        [StringLength(64)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,20}$", ErrorMessage = "Le mot de passe doit contenir entre 12 et 20 caractères avec au moins 1 lettre majuscule, 1 chiffre et 1 caractère spécial.")]
        public string Pwd { get; set; }

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres.")]
        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public string? Ville { get; set; }

        [Column("utl_pays")]
        [StringLength(50)]
        public string? Pays { get; set; }

        [Column("utl_latitude", TypeName = "real")]
        public float? Latitude { get; set; }

        [Column("utl_longitude", TypeName = "real")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation", TypeName = "date")]
        public DateTime DateCreation { get; set; }

        [InverseProperty(nameof(Notation.UtilisateurNotant))]
        public ICollection<Notation> NotesUtilisateur { get; set; } = new List<Notation>();

        public override bool Equals(object obj)
        {
            return obj is Utilisateur utilisateur &&
                   this.UtilisateurId == utilisateur.UtilisateurId &&
                   this.Nom == utilisateur.Nom &&
                   this.Prenom == utilisateur.Prenom &&
                   this.Mobile == utilisateur.Mobile &&
                   this.Mail == utilisateur.Mail &&
                   this.Pwd == utilisateur.Pwd &&
                   this.Rue == utilisateur.Rue &&
                   this.CodePostal == utilisateur.CodePostal &&
                   this.Ville == utilisateur.Ville &&
                   this.Pays == utilisateur.Pays &&
                   this.Latitude == utilisateur.Latitude &&
                   this.Longitude == utilisateur.Longitude &&
                   EqualityComparer<ICollection<Notation>>.Default.Equals(this.NotesUtilisateur, utilisateur.NotesUtilisateur);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.UtilisateurId);
            hash.Add(this.Nom);
            hash.Add(this.Prenom);
            hash.Add(this.Mobile);
            hash.Add(this.Mail);
            hash.Add(this.Pwd);
            hash.Add(this.Rue);
            hash.Add(this.CodePostal);
            hash.Add(this.Ville);
            hash.Add(this.Pays);
            hash.Add(this.Latitude);
            hash.Add(this.Longitude);
            hash.Add(this.NotesUtilisateur);
            return hash.ToHashCode();
        }
    }
}
