using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabaKiralamaWebApp.Models
{
    public class MusteriHareket
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Musteri")]
        public int Musteri_Id { get; set; }
        
        [Display(Name = "Araba")]
        public int Araba_Id { get; set; }
        public DateTime KiraBaslangic { get; set; }
        public DateTime KiraBitis { get; set; }


        [ForeignKey("Musteri_Id")]
        public virtual Musteri Musteri { get; set; }

        [ForeignKey("Araba_Id")]
        public virtual Araba Araba { get; set; } 



    }
}
