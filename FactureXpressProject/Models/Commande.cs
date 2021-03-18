using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FactureXpressProject.Models
{
    public class Commande
    {
        public int CommandeId { get; set; }

        [DisplayName("Nom Complet")]
        public int ClientId { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        public bool Deleted { get; set; }

        public Client Client { get; set; }

        public List<Produit> Produits { get; set; }

        public int? TotalPrice
        {
            get
            {
                return Produits?.Sum(p => p.Qantity * p.Price);
            }
        }
    }
}
