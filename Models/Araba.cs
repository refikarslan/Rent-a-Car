using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabaKiralamaWebApp.Models
{
    public class Araba
    {
        [Key]
        public int Araba_Id { get; set; }
        public string? Araba_Model { get; set; }
        public string? Araba_Marka { get; set; }
        public string? Yıl { get; set; }
        public int? Fiyat { get; set; }
        public string? Araba_Plaka { get; set; }
        public string? Araba_Renk { get; set;}

        [MaxLength(100)]
        public string? FileName { get; set; }
        [MaxLength(100)]
        public string? FileType { get; set; }
        [MaxLength]
        public byte[]? DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
        
       

    }
}
