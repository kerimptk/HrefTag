using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HrefTag.WebUI.Controllers
{
    public class AraclarController : Controller
    {
        IReklamAlanlariService _reklamAlanlariService;
        ICekilisSonuclariService _cekilisSonuclariService;
        IMapper _mapper;
        public AraclarController(
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper,
            ICekilisSonuclariService cekilisSonuclariService
        )
        {
            _cekilisSonuclariService = cekilisSonuclariService;
            _reklamAlanlariService = reklamAlanlariService;
            _mapper = mapper;
        }

        [Route("Araclar")]
        public IActionResult Index()
        {
            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new AraclarViewModel()
            {
                reklamAlanlariDtos = reklamlarMap,
            };
            return View(viewModel);
        }

        public IActionResult CekilisAraci()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KazananlariBelirle(CekilisSonuclariDto cekilisSonuclariDto)
        {
            var AsilSayisi = cekilisSonuclariDto.AsilSayisi;
            var YedekSayisi = cekilisSonuclariDto.YedekSayisi;
            int CekilisSayisi = Convert.ToInt32(AsilSayisi) + Convert.ToInt32(YedekSayisi);

            string[] Katilimcilar = cekilisSonuclariDto.CekilisListesi.Split(',');

            List<String> AsilKazananlar = new List<String>();
            List<String> YedekKazananlar = new List<String>();
            Random random = new Random();

            for (int i = 0; i < CekilisSayisi; i++)
            {
                int secici = random.Next(Katilimcilar.Count());
                string talihli = Katilimcilar[secici];
                if (AsilKazananlar.Contains(talihli) || YedekKazananlar.Contains(talihli))
                {
                    CekilisSayisi++;
                }
                else
                {
                    if (AsilKazananlar.Count() < AsilSayisi)
                    {
                        AsilKazananlar.Add(talihli);
                    }
                    else
                    {
                        YedekKazananlar.Add(talihli);
                    }
                }
            }

            var AsilKazananlarString = string.Join(',', AsilKazananlar);
            var YedekKazananlarString = string.Join(',', YedekKazananlar);
            var KatilimcilarString = string.Join(',', Katilimcilar);

            cekilisSonuclariDto.AsilKazananlar = AsilKazananlarString;
            cekilisSonuclariDto.YedekKazananlar = YedekKazananlarString;
            cekilisSonuclariDto.CekilisAdi = cekilisSonuclariDto.CekilisAdi;
            cekilisSonuclariDto.CekilisiYapan = cekilisSonuclariDto.CekilisiYapan;
            cekilisSonuclariDto.CekilisListesi = KatilimcilarString;
            cekilisSonuclariDto.CekilisTarihi = DateTime.Now;
            cekilisSonuclariDto.AsilSayisi = cekilisSonuclariDto.AsilSayisi;
            cekilisSonuclariDto.YedekSayisi = cekilisSonuclariDto.YedekSayisi;

            var cekilisSonuclariMap = _mapper.Map<CekilisSonuclari>(cekilisSonuclariDto);

            var CekilisDonen = _cekilisSonuclariService.Add(cekilisSonuclariMap);

            return RedirectToAction("CekilisSonucu", new { id = CekilisDonen.Data.Id });
        }

        public IActionResult CekilisSonucu(int id)
        {
            var cekilissonucu = _cekilisSonuclariService.GetById(id);
            var cekilissonucuMap = _mapper.Map<CekilisSonuclariDto>(cekilissonucu);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new CekilisAraciViewModel()
            {
                reklamAlanlariDtos = reklamlarMap,
                cekilisSonuclariDto = cekilissonucuMap
            };

            return View(viewModel);
        }

        [Route("Araclar")]
        public IActionResult HarfKelimeSayaci()
        {
            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new AraclarViewModel()
            {
                reklamAlanlariDtos = reklamlarMap,
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult HarfKelimeSayaci(HarfKelimeSayaciDto harfKelimeSayaciDto)
        //{
        //    var reklamlar = _reklamAlanlariService.GetList();
        //    var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

        //    string[] liste = harfKelimeSayaciDto.Metin.Split(' ');
        //    harfKelimeSayaciDto.HarfSayisi = liste.Count();
        //    harfKelimeSayaciDto.KelimeSayisi = harfKelimeSayaciDto.Metin.Length;

        //    var viewModel = new AraclarViewModel()
        //    {
        //        reklamAlanlariDtos = reklamlarMap,
        //    };
        //    return View(viewModel);
        //}
    }
}

