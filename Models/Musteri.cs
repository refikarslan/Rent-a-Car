using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabaKiralamaWebApp.Models
{
    public class Musteri
    {
        [Key]
          
        public int Musteri_Id { get; set; }
        public string? Musteri_AdSoyad { get; set; }
        public string? Musteri_EMail { get; set;}
        public string? Musteri_TelNo { get; set;}
        public string? Musteri_Kimlik { get; set; }

        //[DataType(DataType.Date)]
        public DateTime? Musteri_DogmTarihi { get; set; }
        public string? Musteri_HesapNo { get; set; }

        [MaxLength(100)]
        public string? FileName { get; set; }
        [MaxLength(100)]
        public string? FileType { get; set; }
        [MaxLength]
        public byte[]? DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
