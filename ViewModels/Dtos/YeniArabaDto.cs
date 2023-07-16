using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArabaKiralamaWebApp.ViewModels.Dtos
{
    public class YeniArabaDto
    {
        public int Araba_Id { get; set; }
        public string? Araba_Model { get; set; }
        public string? Araba_Marka { get; set; }
        public string? Yıl { get; set; }
        public string? Araba_Renk { get; set; }
        public string? Araba_Plaka { get; set; }
        public List<SelectListItem> Arabas { get; set; }

    }
}
