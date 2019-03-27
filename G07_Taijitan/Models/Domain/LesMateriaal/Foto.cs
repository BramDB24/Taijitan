using System.IO;


namespace G07_Taijitan.Models.Domain.LesMateriaal {
    public class Foto : Lesmateriaal{
        private byte[] _image;
        public byte[] Image { get; set;}

        public Foto(){

        }
    }
}
