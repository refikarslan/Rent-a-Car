using ArabaKiralamaWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArabaKiralamaWebApp.ViewModels.RequestModels
{
    public class MusteriTakipRequestModel
    {
       
            public int AracId { get; set; }
            public int MusteriId { get; set; }
            public DateTime KiraBasla { get; set; }
            public DateTime KiraBitir { get; set; }

            //public virtual Musteri  Musteri { get; set; } = null!;
            //public virtual Araba Araba { get; set; } = null!;

            public List<SelectListItem> Araclar { get; set; } = null!;
            public List<SelectListItem> Musteriler { get; set; } = null!;

            public List<MusteriHareket>? Data { get; set; }
        }

}
