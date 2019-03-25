using G07_Taijitan.Models.Domain.LesMateriaal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain {
    public class Oefening
    {
        private readonly ICollection<Commentaar> _comments = new List<Commentaar>();
        public int OefeningId { get; set; }

        public string Naam { get; set; }

        public Graad Graad { get; set; }
        public OefeningType OefeningType { get; set; }
        public IEnumerable<Lesmateriaal> Lesmateriaal { get; set; }
        public IEnumerable<Commentaar> Comments => _comments.AsEnumerable();
        public Oefening() { }

        public void addCommentaar(Gebruiker.Gebruiker gebruiker, string tekst) {
            _comments.Add(new Commentaar(gebruiker, this, tekst));
        }
    }
}
