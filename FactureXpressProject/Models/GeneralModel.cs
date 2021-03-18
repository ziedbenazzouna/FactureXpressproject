using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactureXpressProject.Models
{
    public class GeneralModel
    {
        [DisplayName("Nom Complet")]
        public int ClientId { get; set; }

        [DisplayName("Nom Complet")]
        [Required(ErrorMessage = "Le champ Nom Complet est obligatoire ")]
        public string FullName { get; set; }
        [DisplayName("Matricule fiscale")]
        public string Matricule { get; set; }

        public string Email { get; set; }

        [DisplayName("Numéro téléphone")]
        public string PhoneNumber { get; set; }

        public int CommandeId { get; set; }

        public int ProduitId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int? Qantity { get; set; }

        public int? Price { get; set; }

        public List<Produit> Produits { get; set; } = new List<Produit>();
    }
}
