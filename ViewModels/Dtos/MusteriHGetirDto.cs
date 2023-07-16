using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArabaKiralamaWebApp.ViewModels.Dtos
{
    public class MusteriHGetirDto
    {
        public int Id { get; set; }

        [Display(Name = "Musteri")]
        public int Musteri_Id { get; set; }

        [Display(Name = "Araba")]
        public int Araba_Id { get; set; }
        public DateTime? KiraBaslangic { get; set; }
        public DateTime? KiraBitis { get; set; }
        public List<SelectListItem> Arabas { get; set; }
        public List<SelectListItem> Musteris { get; set; }
    }
}








