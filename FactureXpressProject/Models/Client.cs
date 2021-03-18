using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactureXpressProject.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [DisplayName("Nom Complet")]
        [Required(ErrorMessage = "Le champ Nom Complet est obligatoire ")]
        public string FullName { get; set; }

        [DisplayName("Matricule fiscale")]
        public string Matricule { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Numéro téléphone")]
        public string PhoneNumber { get; set; }
    }
}
