using ArabaKiralamaWebApp.Models;
using ArabaKiralamaWebApp.ViewModels.Dtos;
using ArabaKiralamaWebApp.ViewModels.RequestModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace ArabaKiralamaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context context;
        private readonly IWebHostEnvironment webHostEnvironment;



        public HomeController(ILogger<HomeController> logger, Context context, IWebHostEnvironment hostEnvironment)
        {

            _logger = logger;
            this.context = context;
            webHostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hakkımızda()
        {
            return View();
        }
        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();

        }

        public List<MusteriHareket> GetList()
        {

            var hareket = context.MusteriHareket.ToList();
            return hareket;
        }
        public IActionResult MusteriHareket()
        {
            var Musteriler = context.Musteri.ToList();
            var Arabalar = context.Araba.ToList();

            List<MusteriHareket> hareket = GetList();


            foreach (var item in hareket)
            {
                if (Musteri != null && Araba != null)
                {
                    item.Musteri = Musteriler.First(i => i.Musteri_Id == item.Musteri_Id);
                    item.Araba = Arabalar.First(i => i.Araba_Id == item.Araba_Id);
                }

            }

            return View(hareket);

        }



        public IActionResult Sil(int id)
        {
            var musteri = context.Musteri.Find(id);
            if (musteri != null)
            {
                context.Musteri.Remove(musteri);
                context.SaveChanges();

            }
            return RedirectToAction("Musteri");

        }
        public IActionResult MusteriGetir(int id)
        {
            var musteri = context.Musteri.Find(id);

            return View("MusteriGetir", musteri);
        }

        public IActionResult MusteriGuncelle(Musteri p2, IFormFile FileName)
        {
            var musteri = context.Musteri.Find(p2.Musteri_Id);

            if (musteri != null)
            {
                musteri.Musteri_Id = p2.Musteri_Id;

                musteri.Musteri_AdSoyad = p2.Musteri_AdSoyad;

                musteri.Musteri_EMail = p2.Musteri_EMail;

                musteri.Musteri_TelNo = p2.Musteri_TelNo;

                musteri.Musteri_Kimlik = p2.Musteri_Kimlik;

                musteri.Musteri_DogmTarihi = p2.Musteri_DogmTarihi;

                musteri.Musteri_HesapNo = p2.Musteri_HesapNo;


            }
            if (FileName != null)
            {
                if (FileName.Length > 0)
                {
                    var fileName = Path.GetFileName(FileName.FileName);

                    var fileExtension = Path.GetExtension(fileName);

                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    p2.FileName = newFileName;
                    p2.FileType = fileExtension;
                    p2.CreatedOn = DateTime.Now;

                    string path = Directory.GetCurrentDirectory();
                    using (FileStream uploadStream = System.IO.File.Create($@"{path}\\wwwroot\\img\\" + newFileName))
                    {
                        using (var target = new MemoryStream())
                        {
                            p2.DataFiles = target.ToArray();
                        }
                        FileName.CopyTo(uploadStream);

                        uploadStream.Flush();
                    }
                    musteri.FileName = p2.FileName;

                    musteri.DataFiles = p2.DataFiles;

                    musteri.FileType = p2.FileType;

                    musteri.CreatedOn = p2.CreatedOn;
                }
            }
            context.Musteri.Update(musteri);
            context.SaveChanges();
            return RedirectToAction("Musteri");

        }



        public IActionResult Araba(int id)
        {
            List<Araba> araba = context.Araba.ToList();
            return View(araba);
        }

        public IActionResult ArabaSil(int id)
        {
            var araba = context.Araba.Find(id);
            if (araba != null)
            {
                context.Araba.Remove(araba);
                context.SaveChanges();

            }

            return RedirectToAction("Araba");

        }
        public IActionResult ArabaGetir(int id)
        {
            var araba = context.Araba.Find(id);

            return View("ArabaGetir", araba);
        }

        public IActionResult ArabaGuncelle(Araba p2, IFormFile FileName)
        {

            var araba = context.Araba.Find(p2.Araba_Id);

            if (araba != null)
            {
                araba.Araba_Id = p2.Araba_Id;

                araba.Araba_Marka = p2.Araba_Marka;

                araba.Araba_Model = p2.Araba_Model;

                araba.Yıl = p2.Yıl;

                araba.Fiyat = p2.Fiyat;

                araba.Araba_Plaka = p2.Araba_Plaka;

                araba.Araba_Renk = p2.Araba_Renk;

            }
            if (FileName != null)
            {
                if (FileName.Length > 0)
                {
                    var fileName = Path.GetFileName(FileName.FileName);

                    var fileExtension = Path.GetExtension(fileName);

                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    p2.FileName = newFileName;
                    p2.FileType = fileExtension;
                    p2.CreatedOn = DateTime.Now;

                    string path = Directory.GetCurrentDirectory();
                    using (FileStream uploadStream = System.IO.File.Create($@"{path}\\wwwroot\\img\\" + newFileName))
                    {
                        using (var target = new MemoryStream())
                        {
                            p2.DataFiles = target.ToArray();
                        }
                        FileName.CopyTo(uploadStream);

                        uploadStream.Flush();
                    }
                    araba.FileName = p2.FileName;

                    araba.DataFiles = p2.DataFiles;

                    araba.FileType = p2.FileType;

                    araba.CreatedOn = p2.CreatedOn;
                }
            }
            context.Araba.Update(araba);
            context.SaveChanges();


            return RedirectToAction("Araba");
        }

        public IActionResult MusteriHSil(int id)
        {
            var musteriH = context.MusteriHareket.Find(id);
            if (musteriH != null)
            {
                context.MusteriHareket.Remove(musteriH);
                context.SaveChanges();

            }

            return RedirectToAction("MusteriHareket");

        }


        public async Task<Musteri?> GetMusteri([FromQuery] int id)
        {
            Musteri? musteri = await context.Musteri.FirstOrDefaultAsync(_ => _.Musteri_Id == id);
            return musteri;
        }

        public async Task<Araba?> GetAraba([FromQuery] int id)
        {
            Araba? araba = await context.Araba.FirstOrDefaultAsync(_ => _.Araba_Id == id);
            return araba;
        }

        public async Task<IActionResult> MusteriHGetir(int id)
        {
            //var musteriH = await context.MusteriHareket.FirstOrDefaultAsync(_ => _.Musteri_Id == id);
            var musteriH = await context.MusteriHareket.FirstOrDefaultAsync(_ => _.Id == id);

            if (musteriH != null)
            {
                MusteriHGetirDto dto = new()
                {

                    Araba_Id = musteriH.Araba_Id,
                    Musteri_Id = musteriH.Musteri_Id,
                    Id = musteriH.Id,
                    KiraBaslangic = musteriH.KiraBaslangic,
                    KiraBitis = musteriH.KiraBitis,
                    Arabas = (await context.Araba.ToListAsync()).Select(_ => new SelectListItem() { Text = _.Araba_Marka, Value = _.Araba_Id.ToString() }).ToList(),
                    Musteris = (await context.Musteri.ToListAsync()).Select(_ => new SelectListItem() { Text = _.Musteri_AdSoyad, Value = _.Musteri_Id.ToString() }).ToList(),
                };

                return View("MusteriHGetir", dto);
            }
            return RedirectToAction("MusteriHareket");

        }
        public IActionResult MusteriHGuncelle(MusteriHareket p2)
        {

            var musteriH = context.MusteriHareket.Find(p2.Id);

            if (musteriH != null)
            {
                musteriH.Id = musteriH.Id;

                musteriH.Musteri_Id = p2.Musteri_Id;

                musteriH.Araba_Id = p2.Araba_Id;

                musteriH.KiraBaslangic = p2.KiraBaslangic;

                musteriH.KiraBitis = p2.KiraBitis;

                context.Update(musteriH);

            }
            context.SaveChanges();
            return RedirectToAction("MusteriHareket");
        }

        [HttpGet]
        public IActionResult MusteriHEkle()
        {
            MusteriHareketEkleRequestModel model = new()
            {
                Araclar = (context.Araba.ToList()).Select(_ => new SelectListItem()
                {
                    Text = _.Araba_Marka,
                    Value = _.Araba_Id.ToString(),

                }).ToList(),

                Musteriler = (context.Musteri.ToList()).Select(_ => new SelectListItem()
                {
                    Text = _.Musteri_AdSoyad,
                    Value = _.Musteri_Id.ToString(),

                }).ToList(),

            };


            return View(model);
        }

        [HttpPost]
        public IActionResult MusteriHEkle(MusteriHareketEkleRequestModel model)
        {
            MusteriHareket musteriHareket = new MusteriHareket
            {
                Musteri_Id = model.MusteriId,
                Araba_Id = model.AracId,
                KiraBaslangic = model.KiraBasla,
                KiraBitis = model.KiraBitir,

            };


            context.MusteriHareket.Add(musteriHareket);
            context.SaveChanges();

            model.Data = context.MusteriHareket.Where(_ => _.Araba_Id == model.AracId).ToList();


            model.Araclar = (context.Araba.ToList()).Select(_ => new SelectListItem()
            {
                Text = _.Araba_Marka,
                Value = _.Araba_Id.ToString(),

            }).ToList();

            model.Musteriler = (context.Musteri.ToList()).Select(_ => new SelectListItem()
            {
                Text = _.Musteri_AdSoyad,
                Value = _.Musteri_Id.ToString(),

            }).ToList();


            return RedirectToAction("MusteriHareket");
        }

        public IActionResult Musteri(int id)
        {
            List<Musteri> musteri = context.Musteri.ToList();
            return View(musteri);
        }


        [HttpGet]
        public IActionResult GetMusteriById(int id)
        {
            var musteri = context.Musteri.Find(id);
            return Json(musteri);
        }


        [HttpGet]
        public IActionResult GetArabaById(int id)
        {
            var araba = context.Araba.Find(id);
            return Json(araba);
        }

        [HttpGet]
        public IActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniMusteri(Musteri p1, IFormFile FileName)
        {
            if (FileName != null)
            {
                if (FileName.Length > 0)
                {
                    var fileName = Path.GetFileName(FileName.FileName);

                    var fileExtension = Path.GetExtension(fileName);

                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    p1.FileName = newFileName;
                    p1.FileType = fileExtension;
                    p1.CreatedOn = DateTime.Now;

                    string path = Directory.GetCurrentDirectory();
                    using (FileStream uploadStream = System.IO.File.Create($@"{path}\\wwwroot\\img\\" + newFileName))
                    {
                        using (var target = new MemoryStream())
                        {
                            p1.DataFiles = target.ToArray();
                        }
                        FileName.CopyTo(uploadStream);

                        uploadStream.Flush();
                    }
                }
            }
            context.Musteri.Add(p1);
            context.SaveChanges();
            return RedirectToAction("Musteri");

        }

        [HttpGet]
        public IActionResult YeniAraba()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniAraba(Araba p1, IFormFile FileName)
        {

            if (FileName != null)
            {
                if (FileName.Length > 0)
                {
                    var fileName = Path.GetFileName(FileName.FileName);

                    var fileExtension = Path.GetExtension(fileName);

                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    p1.FileName = newFileName;
                    p1.FileType = fileExtension;
                    p1.CreatedOn = DateTime.Now;

                    string path = Directory.GetCurrentDirectory();
                    using (FileStream uploadStream = System.IO.File.Create($@"{path}\\wwwroot\\img\\" + newFileName))
                    {
                        using (var target = new MemoryStream())
                        {
                            p1.DataFiles = target.ToArray();
                        }
                        FileName.CopyTo(uploadStream);

                        uploadStream.Flush();
                    }
                }
            }
            context.Araba.Add(p1);
            context.SaveChanges();
            return RedirectToAction("Araba");
        }

        //[HttpGet]
        //public IActionResult MusteriTakip(int id)
        //{
        //    var MusteriHareketleri = context.MusteriHareket.Where(s => s.Musteri_Id == id).ToList();
        //    return Json(MusteriHareketleri);
        //}
        //bi de böyle denemiştim ama daha sade
        //bi de şurda da hatam var sanırım


        [HttpGet]
        public IActionResult MusteriTakip()
        {
            MusteriTakipRequestModel model = new()
            {
                Araclar = (context.Araba.ToList()).Select(_ => new SelectListItem()
                {
                    Text = _.Araba_Marka,
                    Value = _.Araba_Id.ToString(),

                }).ToList(),

                Musteriler = (context.Musteri.ToList()).Select(_ => new SelectListItem()
                {
                    Text = _.Musteri_AdSoyad,
                    Value = _.Musteri_Id.ToString(),

                }).ToList(),

            };
            return View(model); 
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult MusteriTakip(int id)
        {
            List<Musteri> Musteri  = context.Musteri.ToList();
            var MusteriHareketleri = context.MusteriHareket.Include(x=>x.Araba).Include(x=>x.Musteri).Where(s => s.Musteri_Id == id).ToList();
            return Json(MusteriHareketleri);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}