using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.Gebruiker;
using G07_Taijitan.Models.Domain.LesMateriaal;

namespace G07_Taijitan.Data
{
    public class GebruikerDataInitializer
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GebruikerDataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                if (!_context.Gebruikers.Any())
                {
                    ////Gebruikers
                    Gebruiker Jonah = new Lid()
                    {
                        Naam = "De Smet",
                        Voornaam = "Jonah",
                        Adres = "EenAdres",
                        Email = "jonah.desmet@hotmail.com",
                        Geboortedatum = new DateTime(1998, 03, 13),
                        Gebruikersnaam = "jonah.desmet",
                        Telefoonnummer = "054000000",
                        Wachtwoord = "P@ssword1",
                        Graad = Graad.Dan3,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat",
                        Huisnummer = "1",
                        Postcode = "9506",
                        Stad = "stad",
                        Land = "België",
                        Rijksregisternummer = "19980313000000",
                        Gsm = "0476000000",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };
                    Gebruiker Bram = new Lid()
                    {
                        Naam = "De Bleecker",
                        Voornaam = "Bram",
                        Adres = "EenAdres1",
                        Email = "bram.debleccker@hotmail.com",
                        Geboortedatum = new DateTime(1999, 02, 12),
                        Gebruikersnaam = "bram.debleecker",
                        Telefoonnummer = "054111111",
                        Wachtwoord = "P@ssword2",
                        Graad = Graad.Kyu4,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat2",
                        Huisnummer = "2",
                        Postcode = "9500",
                        Stad = "stad1",
                        Land = "België",
                        Rijksregisternummer = "19990212000000",
                        Gsm = "0476000001",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };
                    Gebruiker Johanna = new Lid()
                    {
                        Naam = "De Bruycker",
                        Voornaam = "Johanna",
                        Adres = "EenAdres",
                        Email = "johanna.debruycker@hotmail.com",
                        Geboortedatum = new DateTime(1997, 01, 11),
                        Gebruikersnaam = "johanna.debruycker",
                        Telefoonnummer = "054000001",
                        Wachtwoord = "P@ssword3",
                        Graad = Graad.Dan8,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat",
                        Huisnummer = "1",
                        Postcode = "9500",
                        Stad = "stad",
                        Land = "België",
                        Rijksregisternummer = "19970111000000",
                        Gsm = "0476000002",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };
                    Gebruiker Lowie = new Lid()
                    {
                        Naam = "Scheirlinckx",
                        Voornaam = "Lowie",
                        Adres = "EenAdres2",
                        Email = "lowie.scheirlinckx@hotmail.com",
                        Geboortedatum = new DateTime(1998, 12, 10),
                        Gebruikersnaam = "lowie.scheirlinckx",
                        Telefoonnummer = "054000002",
                        Wachtwoord = "P@ssword4",
                        Graad = Graad.Dan6,
                        InschrijvingsDatum = DateTime.Today,
                        Straatnaam = "straat",
                        Huisnummer = "1",
                        Postcode = "9506",
                        Stad = "stad",
                        Land = "België",
                        Rijksregisternummer = "19981210000000",
                        Gsm = "0476000002",
                        EmailOuders = "ouders@hotmail.com",
                        Geboorteplek = "Aalst"
                    };

                    ////LesMateriaal
                    #region WurgGrepenVideo
                    //Wurggrepen Kyu1 - Dan3
                    Lesmateriaal WurgGreep1 = new Video()
                    {
                        Naam = "WurgGreepKyu1",
                        Url = "https://www.youtube.com/embed/2s53EtXPJd8"
                    };
                    Lesmateriaal WurgGreep2 = new Video()
                    {
                        Naam = "WurgGreep1Kyu1",
                        Url = "https://www.youtube.com/embed/Gf4H1EBFE7o"
                    };

                    Lesmateriaal WurgGreep3 = new Video()
                    {
                        Naam = "WurgGreepDan3",
                        Url = "https://www.youtube.com/embed/GaD5s0_H0T4"
                    };

                    Lesmateriaal WurgGreep4 = new Video()
                    {
                        Naam = "WurgGreep1Dan3",
                        Url = "https://www.youtube.com/embed/LppnEfRoFIM"
                    };

                    Lesmateriaal bevrapp = new Foto() {
                        Naam = "Test",
                        Image = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAMMAAADPCAYAAAE/ulVHAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAA96SURBVHhe7Z2/iiXHFcbnEfQI+wj7BDPshAsLEyhQpgkUObExAoMSGYPAONrAmYMFJYsULWLTxRPZRokXtGBwsJZBIKTEEiiecZ17q/aeW/er6qrqqu6qnu/Aj7nT9VVVnzp9bv+r233m293l+c3d5cXdHGxTp4bEc7FN7w0JamG7aNvJ7eX5i3gMfvkhH9BO3ItApSB9daKF+vM//nr4/OtfHT5r2Mm7z/enk0AHAjs5fHYs0okQ6GjLnWgClYJsv5Pby4vfoIJ3SMUUdMw8mu/jdx2I3T06/wkJamC72Nvdo4vfI9EcbNOnhsQ5SIxtU8eGxLMww2+bbhhwM/RNtyYh3AHa9lPw2ol3gJbH6KMDJ9LilM/ofwM7OHxG/xvqdaA/KwbpQC/zqOfB82eHzwrG4PD5s0/v7p48PvxvqdcB+t9w2oEDiCfpqwMZ05xOAtpwBw6pmAKqa5juYCZNjyp2jTtDgjnYZrHdXp5/iyr1gF3FsKFKPWNXe289j/wU1oWCCKCUbgXq36NsE8rooBg64eMaQyB9LTL6SHdiaplbji5syPLM63jBPgB04miZW04nLF99uS/74H1c7tGfE+6YVv76ZQH6ckJGXpa9enm8fIK+nAi1O0F/m1Oo7Qj9OeE2qU8+Pi0L0J8TbnmoDNCnE0KoD0C6Ewik7dIJREYHxQzvxF/+nNV+mROCc6QVqM8AZaennbFzQgwVjoBd/YMhUa/YVY6bzPBCldfErlqeTd6LX4TzG7s6eYYbWx+5yGdXMWwt5w3UxK7uqSFxz9jVPliLCRVLYFd/b0gwAu9ypMev0hx2TqCCSdCxTgtQ3x6bcGK3H8EFE0gHX3yOy2rww38ynDDRQAsnkQ6e/gmX1YBOpCIdoHPmWlR3QhpDDBUJt9L+Mt8JpCtZLsgVk1AZgE6cLEMd5y4X6AQCdSb/04nIcmETTnzzdbgM0KcTsTJAf06467AZRwT9ORFaHqEvJ2T0ZVlgRm2IvpwIaSfoxwmZqCv/v31zrEuAkThZhlYgZ3lIO0FfTriJKXpZAn05EVsegU6cLEOd5y6Xbye0PEJ/TrgyOQhEZYB+nQiVAejEyTLUce5yofqMAteZT0sn3IEgKgNMO4GQDlpeAdyEE4tMUGnthLS/iBOZ0z6zWMyJjE6ycG3LJoXKAWVOCK6zVqA+A5Q7IbhD55okzg937J4TgApGYnf3VAwVjoJ1YVwn7OofDIm6Rj/KQhsUd4pdZWyoQlfIcz5SDTawIjKRxq7afBt9Vs4SVB1wZ6NOSuuKnDT2DTZIZmOHd9pGmRg7NKFDDWewEmmGHfZjQ0LSHjv8e0OC6sh1i62B/CxgF4TFfqaCLmmMDvKzgGUv1WgHWk7Nbomb4upAmkLWCYR/X2YUGIhOYCA6oetA6BVLhYE4oc9AaK3MskYajdan3MjVelQews34Lqk7Qf1AII2gNQzECQwEKg/BQACNRusZiImV0xoG4gQGApWHYCCARqP1DMTEymnNqIHQ9XLrTsBAoHKErpNTLxEGApX7aH1qnUwYCFSu0doUfSEMBCp3aN2UdiYMBCoXfmx3gQ/BQKByQWtk5jvSVISBQOWCTA5I0VWCgUDlDq2b0s6EgUDlGq3NeE9BLgwEKtfIj+1y9IUwEKjcR+vlaAppZsJAoHKfjz48riP/I90MGAhUjmh8XsFAoPIQul7lH2ozEKg8hP+TZqQppH4gUhg1ENJ2ad0J+gxEr3QdiFS0AylbbY+4F9A5kKYQBiIH91hUB9IUsk4gMl7f1hXah4q/GBLWCYSAND3TeP2XC4TgOzMqyLeZmECc36CCpvhnqaOAfKmCfdUVLiRLsQuCGB90sh4nD1AxC75FQtIOGXM7/MfGJ9EsSMoTa2BFUg07zOnGJ9VUZOqJNKnGfUg+wX1Abds/x2OF85DuOL/ZPU9jDbu7uHh4++ji6X3PFPFfxkHGww5NWzOdXvkrQSBXdsjqmWn02uuEpHFth3CegYZJJnYo802+41CDpJDcfYapxK+fNqR9PYnQq0jqEg+ESZkHoBKpjRlnO+SnBiuQJtghPzae/S6NveOmDQtJS+zQ740X6dbh6EIfEpBlcAFof0gq0w71Y5m3QOZLpiJcL3MTR2Zmo2kmI1Nr+qfc+IEFtfnu39iRkak4K32ZIPz8PXZkZIYPAtKMgPaBQVgJ7cNwQWj4+OVF0T4wCCuhfWAQVkL7wCCshPaBQVgJ7cNwQfDPmJFmBLQPXQVBr1gqqJ0R0D4wCCuhfdh0EHJ/cZ/7Vae1KXqNrlfx99t1g4DKhZwdM4NQgF4xVC4wCFEYBKQJoesxCAoGwaBXDJULDEIUBgFpQuh6DIKCQTDoFUPlAoMQhUFAmhC6HoOgYBAMesVQucAgRGEQkCaErscgKBgEg14xVC5sIQh+P/XmojIIUIMorZcAg4A0Pv5ztit+FQkMAtL4lNTJgEFAGo38FkHrG7yzh0FAGk2uvgAGAWkc/oPNJSuQbiYMAtI4crQzYBCQRpDzAK1r+IpJBgFphFRdBRgEpHny+FgjfSBdJRgEpBn6lcOoXBgtCA3fMoJgEJDG3yk3flMKg4A0gta8fYM1lWAQkEaQgU/RVYBBQBrBX4+K9w98GASkcWid7KyRpgIMAtI4crQzYBCQxuFfwJOTOKSbCYOANBqtbXT9iEFAGk2uvgAGAWk08gPBHH0BDALS+Gj982dYMwMGAWl8SupkwCAgjU/DV8sLDALSIHSdij8kFxgEpEGU1kuAQUAaxKuXZfUSYBCQBuHfY5D1RLoCGASkCaHrVZyDxCAgTQhdr9sgpILacYwSBOkXaQpgEJAmhK636SD0jPahqyCkkLu19or2gUFYCe0Dg7AS2oeujo5S2GIQujpZS2ELQcg9asuAQUil4fzUZYLg//gOaXpHr7/M2kaaQpYJgj/fX65IIl2v+Dd1Kk8QXiYIgnZCaHCvtgn+3CMB6WawXBD8HduoNJgmv1wQBD+tR6PR1+iyQRBkS0IO9k6j3zALywfBIcHwD117Q46CKt/URyzz2kcSxr72ke/kX5f9O/tBAVmIXQDE+FLsdTh6KbYYEpG22KE/mLy4HwlJK85v7NAfGxaTFtghP7W7i4sHqAKpjBlnO+TYjIiHrG3ZH5JOmQi9iqQOaQFwZlLmIWiElGLG0w5tvsEGSRZ2KOeZaYhfT2Xkff2kmGn0yuuEYK7skLU1+Y67fXTx9L5f8hD/ZRxmfecvYWYF3zMrfG1W+AUvnZMkzHay215kV2i2H7spjWfiwH3/piJtsNtV/WOeWia7Jl6LJetgtru1D43MCjwwWfoaryAhy7PbHqcuVdc00ykvZ5ARaHcoJY17nREyAvWSYn8+ADshZBzmnlfwnIBsCdme7aadbtwbkE2TupcwYp4bkPtA/FxCBF4FQrYMTghTwElH5D5yPInMHEPJ3CEkJGT76LlP5ixbJkRh4Uj0/iABsqfiE+5qINv/LhE2deWIyTAGv/stjt+ayBWm3RxwVDgiP3+PB5/0xQKP2clF8mBbz8GIJcM//7Z/0BRZhv99h+Mg9JgMJg/kKhIsHJJYMnzxOa5D2uC/cEbTYTIITAbSBibDygwYgM3CZFgZJkM/MBlWhsnQD0yGlWEy9AOTYWVe/x0PvtDjjZ4tw2QoAA1WC7hnWBYmQwFosFrAZFgWJkMBaLBaMCcAsZedyXwoVCeH2JyqGpPaULsOpK/Bf/+F+xP++AdcZ2WYDCkwGfJp7VMD+k4GpI/RatfMZMiHyVAAGiwH0sdgMmBQuw6krwGToQA0WA6kj8FkwKB2HUhfAyZDAWiwHEgfg8mAQe06kL4GTIYC0GA5kD4GkwGD2nUgfQ2YDAWgwXIgfQwmAwa160D6GjAZCkCD5UD6GEwGDGrXgfQ1YDIUgAbLgfQxmAwY1K4D6WvAZCgADZYD6WMwGTCoXQfS14DJUAAaLAfSx2AyYFC7DqSvAZOhADRYDqSPwWTAoHYdSF8DJkMBaLAcSB+DyYBB7TqQvgZMhgLQYDmQPgaTAYPadSD9XGLjJTAZAqDBciB9DCYDBrXrQPo5fPQh7sfx1Ze4XgcwGVJgMqTxwfu4D8erl7heJzAZUmAyTPPkMW7fUWOcGsNkSIHJEEcS4cfI2L99g+t1BpMhBSZDHNnYUdvCIIkgMBlSYDKEiSWC7C1kr4HqdQiTIQUmAya23oMlgsBkSIHJcEpsnQW5soTqdQyTIQUmwzFyrwC15RgwEQQmQwpMhgNTiVBjfVeCyZACk2GPvJ4KteH45GNcbxCYDCkwGaZvqs0Z305gMqTAZNgjY4jaEOTqEaozEEyGFJgMB775GrcjPH+G6wwCkyEFJsOBqVmpUo7qDQCTIQUmwzGyB0BtCQNNv/BhMqTAZDglNjFvzlivCJMhBSbDKXIZFbXn4B3oAtBAOpA+BpMBg9p1IH0q8mMd1KbQ+Q95EEyGFJgMmKl7D599iut1CpMhBSZDGBlX1K4w2L0HJkMKTIY4sXsPHT8AwIfJkAKTIc5G7j0wGVJgMkyzgXsPTIYUmAxpDH7vgcmQApMhjcHvPTAZUmAypBP78Q8fIjYBGjQH0sdgMmBQuw6kn8PA9x6YDCkwGfKQDR715UB1OoDJkAKTIZ/YvYcaPjWAyZACkyGf2O+lpQzVWZm+k6EmTAYM0tcgdqhUY8wawGRIgcmQT+sxawCTIQW5QiLBRdSYaiBtoLaFGo9oRO06kL4G0jaKg8BkCIAGqwVzkoHkw2RYmdaHGyQdJsPKMBn6gVeTVobJ0A+xWHR6yMpkIG1AMXB0OmGPyUDqEztEkhihOh2wrWQY8Dh1c8i3Php/R8dP6t5WMmzwWT5DIfdEYj/w4RTuhYkdKgmDPb5kGKZmqg7w08/tJYMQmzHpkODIVY2BH5S7KrIXkD3x1JePIGNd4056Y7aZDELs/IEsx0CPqT+7vTz/FhVshthTG0g7BnpekiB5cHb76OIpKtwcspuWvUXsBI/MQ06QB71IIXlwdndx8RAVEnKvMHlwJmZ2ES+ggJB7gGz/u0QQM1nxHhIRci8w279Nhb2ZhVcnIkK2z5VNgWMzBdeekJAtc203fWwi8CoQskXiieCMV5jIpnFXjnLMnGW/ho0RMiCyPdtNu8y4lyCboGRvEDLTIM8lyIiknRuUmDTudUZIj7RLAt/MbucBzylIT+y2R7Nd2k10HdufV5zfoBUkpC1mu6t5PlDbzEpemyzd9tRwsgp2u1ruEKi2mcyVuU+SIC/uHp3/pJ0jBGK2k932Iueo/tyhJnZ29n9UowHc6cUXzQAAAABJRU5ErkJggg==")
                    };

                    Lesmateriaal tekst = new Tekst() {
                        Naam = "Pdf voorbeeld",
                        
                    };
                    #endregion

                    #region BeenWorpenVideo
                    Lesmateriaal lesmateriaal1 = new Video()
                    {
                        Naam = "BeenworpKyu1",
                        Url = "https://www.youtube.com/embed/JdGWiOcijdQ"
                    };
                    Lesmateriaal lesmateriaal2 = new Video()
                    {
                        Naam = "BeenworpKyu1",
                        Url = "https://www.youtube.com/embed/71XFjhqKBIY"
                    };
                    Lesmateriaal lesmateriaal3 = new Video()
                    {
                        Naam = "BeenworpDan3",
                        Url = "https://www.youtube.com/embed/CrwGeAMbAUQ"
                    };
                    Lesmateriaal lesmateriaal4 = new Video()
                    {
                        Naam = "BeenworpDan4",
                        Url = "https://www.youtube.com/embed/RN6jkQ4dAbo"
                    };
                    #endregion

                    #region ArmStotenVideo
                    Lesmateriaal Armstoot = new Video()
                    {
                        Naam = "ArmstootKyu1",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    Lesmateriaal Armstoot1 = new Video()
                    {
                        Naam = "Armstoot1Kyu1",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    Lesmateriaal Armstoot2 = new Video()
                    {
                        Naam = "ArmstootDan3",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    Lesmateriaal Armstoot3 = new Video()
                    {
                        Naam = "Armstoot1Dan3",
                        Url = "https://www.youtube.com/embed/udo0RzY-9Cg"
                    };
                    #endregion

                    #region KopStotenVideo
                    Lesmateriaal Kopstoot = new Video()
                    {
                        Naam = "KopstootKyu1",
                        Url = "https://www.youtube.com/embed/-qjnHJHy8Og"
                    };
                    Lesmateriaal Kopstoot1 = new Video()
                    {
                        Naam = "Kopstoot1Kyu1",
                        Url = "https://www.youtube.com/embed/rHBpNOpzths"
                    };
                    Lesmateriaal Kopstoot2 = new Video()
                    {
                        Naam = "KopstootDan3",
                        Url = "https://www.youtube.com/embed/3Qma7Sxe6VE"
                    };
                    Lesmateriaal Kopstoot3 = new Video()
                    {
                        Naam = "Kopstoot1Dan3",
                        Url = "https://www.youtube.com/embed/t7HYNINWJe0"
                    };
                    #endregion
                    
                    ////Oefeningen
                    #region Beenworpen

                    //Beenworpen - Kyu1
                    Oefening oefening1 = new Oefening()
                    {
                        Naam = "Makkelijke Beenworp",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal1, bevrapp, tekst }
                    };

                    Oefening oefening6 = new Oefening()
                    {
                        Naam = "Middelmatige beenworp",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal2}
                    };

                    //Beenworpen - Dan3
                    Oefening oefening7 = new Oefening()
                    {
                        Naam = "Moeilijke beenworp",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal3}
                    };

                    Oefening oefening8 = new Oefening()
                    {
                        Naam = "Zeer moeilijke beenworp",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Beenworpen,
                        Lesmateriaal = new List<Lesmateriaal> { lesmateriaal4}
                    };
                    #endregion

                    #region Armstoten
                    //Armstoten - Kyu1
                    Oefening oefening2 = new Oefening()
                    {
                        Naam = "Makkelijke armstoot",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot }
                    };

                    Oefening oefening3 = new Oefening()
                    {
                        Naam = "Middelmatige armstoot",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot1 }
                    };

                    //Armstoten - Dan3
                    Oefening oefening9 = new Oefening()
                    {
                        Naam = "Moeilijke armstoot",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot2 }
                    };

                    Oefening oefening10 = new Oefening()
                    {
                        Naam = "Zeer moeilijke armstoot",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Armstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Armstoot3 }
                    };
                    #endregion

                    #region WurgGrepen
                    //Wurggrepen - Kyu1
                    Oefening oefening4 = new Oefening()
                    {
                        Naam = "Makkelijke wurggreep",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep1 }
                    };

                    Oefening oefening11 = new Oefening()
                    {
                        Naam = "Middelmatige wurggreep",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep2 }
                    };

                    //Wurggrepen - Dan3
                    Oefening oefening12 = new Oefening()
                    {
                        Naam = "Moeilijke wurggreep",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep3 }
                    };

                    Oefening oefening13 = new Oefening()
                    {
                        Naam = "Zeer moeilijke wurggreep",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Wurggrepen,
                        Lesmateriaal = new List<Lesmateriaal> { WurgGreep4 }
                    };
                    #endregion

                    #region Kopstoten
                    //Kopstoten - Kyu1
                    Oefening oefening14 = new Oefening()
                    {
                        Naam = "Makkelijke kopstoot",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot }
                    };

                    Oefening oefening5 = new Oefening()
                    {
                        Naam = "Vliegende kopstoot",
                        Graad = Graad.Kyu1,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot1 }
                    };

                    //kopstoten - Dan3
                    Oefening oefening15 = new Oefening()
                    {
                        Naam = "Ninja kopstoot",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot2 }
                    };

                    Oefening oefening16 = new Oefening()
                    {
                        Naam = "achterwaardse kopstoot",
                        Graad = Graad.Dan3,
                        OefeningType = OefeningType.Kopstoten,
                        Lesmateriaal = new List<Lesmateriaal> { Kopstoot3 }
                    };
                    #endregion

                    _context.Oefeningen.AddRange(
                        oefening1, oefening2, oefening3, oefening4,
                        oefening5, oefening6, oefening7, oefening8,
                        oefening9, oefening10, oefening11, oefening12,
                        oefening13, oefening14, oefening15
                        );

                    await InitilizeUsers(Jonah.Gebruikersnaam, Jonah.Wachtwoord, Jonah.GetType().Name);
                    await InitilizeUsers(Bram.Gebruikersnaam, Bram.Wachtwoord, Bram.GetType().Name);
                    await InitilizeUsers(Johanna.Gebruikersnaam, Johanna.Wachtwoord, Johanna.GetType().Name);
                    await InitilizeUsers(Lowie.Gebruikersnaam, Lowie.Wachtwoord, Lowie.GetType().Name);


                    _context.Gebruikers.AddRange(Jonah, Bram, Lowie, Johanna);
                    _context.SaveChanges();
                }
            }
        }

        private async Task InitilizeUsers(string username, string password, string role)
        {
            var user = new IdentityUser { UserName = username };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
        }
    }
}
