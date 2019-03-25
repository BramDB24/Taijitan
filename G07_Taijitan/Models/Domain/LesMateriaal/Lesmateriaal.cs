using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Models.Domain.LesMateriaal
{
    public abstract class Lesmateriaal
    {
        public int LesmateriaalId { get; set; }
        public string Naam { get; set; }
        public int OefeningId { get; set; }
        public ICollection<Commentaar> Comment { get; set; }
        public Lesmateriaal()
        {
        }

        public void addCommentaar(Commentaar comment)
        {
            Comment.Add(comment);
        }

    }
}
