using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Tache
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Categorie { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateFinPrevu { get; set; }
        public DateTime? DateFinReel { get; set; }
        public int PersonneAssignee { get; set; }
    }
}
