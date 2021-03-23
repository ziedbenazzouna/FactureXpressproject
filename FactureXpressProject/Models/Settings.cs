using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FactureXpressProject.Models
{
    public class Settings
    {
        public int SettingsId { get; set; }

        [DisplayName("Timbre")]
        public int? Stamp { get; set; }

        [DisplayName("Matricule fiscale")]
        public string TaxRegistration  { get; set; }

        [DisplayName("TVA")]
        public int? Tva { get; set; }
    }
}
