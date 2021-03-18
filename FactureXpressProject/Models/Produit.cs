using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactureXpressProject.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public int CommandeId { get; set; }
        public string Description { get; set; }
        public int? Qantity { get; set; }
        public int? Price { get; set; }
        public Commande Commande { get; set; }
    }
}
