using ArabaKiralamaWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArabaKiralamaWebApp.ViewModels.RequestModels
{
    public class MusteriHareketEkleRequestModel
    {
        public int AracId { get; set; }
        public int MusteriId { get; set; }
        public DateTime KiraBasla { get; set; }
        public DateTime KiraBitir{ get; set; } 

        public List<SelectListItem> Araclar { get; set; } = null!;
        public List<SelectListItem> Musteriler { get; set; } = null!;
        public List<MusteriHareket>? Data { get; set; }
        
    }
}





