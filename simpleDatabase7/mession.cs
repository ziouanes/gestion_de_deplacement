using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleDatabase7
{
   public  class mession
    {
        public int id { get; set; }
        public string type { get; set; }
        public int Taux { get; set; }
        public int Taux_Fix { get; set; }
        //int some_dues = Taux * Taux_Fix;
        public string Nom { get; set; }
        public string type_mession { get; set; }
        public string DESTINATION { get; set; }
        public DateTime date_depart { get; set; }
        public DateTime date_retour { get; set; }
        public DateTime date_depart_H { get; set; }
        public DateTime date_retour_H { get; set; }
    }
}
