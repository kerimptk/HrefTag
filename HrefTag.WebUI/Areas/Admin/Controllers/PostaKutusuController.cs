using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostaKutusuController : Controller
    {
        IPostaKutusuService _postaKutusuService;
        IMapper _mapper;
        public PostaKutusuController(
            IPostaKutusuService postaKutusuService,
            IMapper mapper)
        {
            _postaKutusuService = postaKutusuService;
            _mapper = mapper;
        }

        public IActionResult OkunmamisMesajlar()
        {
            var mesajlar = _postaKutusuService.GetOkunmamisList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            var viewModel = new AdminPostaKutusuViewModel() { 
                postaKutusuDtos = mesajlarMap
            };
            return View(viewModel);
        }

        public IActionResult TumMesajlar()
        {
            var mesajlar = _postaKutusuService.GetList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            var viewModel = new AdminPostaKutusuViewModel()
            {
                postaKutusuDtos = mesajlarMap
            };
            return View(viewModel);
        }


        public IActionResult IstekveOneriler()
        {
            var mesajlar = _postaKutusuService.GetOneriIstekList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            var viewModel = new AdminPostaKutusuViewModel()
            {
                postaKutusuDtos = mesajlarMap
            };
            return View(viewModel);
        }

        public IActionResult HataBildirimleri()
        {
            var mesajlar = _postaKutusuService.GetHataBildirimiList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            var viewModel = new AdminPostaKutusuViewModel()
            {
                postaKutusuDtos = mesajlarMap
            };
            return View(viewModel);
        }

        public IActionResult ReklamveIsBirligiTalepleri()
        {
            var mesajlar = _postaKutusuService.GetReklamVeIsBirligiList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            var viewModel = new AdminPostaKutusuViewModel()
            {
                postaKutusuDtos = mesajlarMap
            };
            return View(viewModel);
        }

        public IActionResult DigerMesajlar()
        {
            var mesajlar = _postaKutusuService.GetDigerList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            var viewModel = new AdminPostaKutusuViewModel()
            {
                postaKutusuDtos = mesajlarMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CopeAt(int id)
        {
            var mesaj = _postaKutusuService.GetById(id);
            mesaj.SilId = 1;
            mesaj.OnayDurumuId = 0;
            _postaKutusuService.Update(mesaj);
            return RedirectToAction("OkunmamisMesajlar");
        }

        [HttpPost]
        public async Task<IActionResult> OkunduOlarakIsaretle(int id)
        {
            var mesaj = _postaKutusuService.GetById(id);
            mesaj.OnayDurumuId = 1;
            _postaKutusuService.Update(mesaj);
            return RedirectToAction("OkunmamisMesajlar");
        }

        public async Task<IActionResult> geridonusumkutusu(int id)
        {
            var mesajlar = _postaKutusuService.GetSilinmisList();
            var mesajlarMap = _mapper.Map<List<PostaKutusuDto>>(mesajlar);
            return View(mesajlarMap);
        }


        [HttpPost]
        public async Task<IActionResult> KaliciSil(int id)
        {
            var mesaj = _postaKutusuService.GetById(id);
            _postaKutusuService.Delete(mesaj);
            return RedirectToAction("OkunmamisMesajlar");
        }

        [HttpPost]
        public async Task<IActionResult> GeriYukle(int id)
        {
            var mesaj = _postaKutusuService.GetById(id);
            mesaj.SilId = 0;
            mesaj.OnayDurumuId = 0;
            _postaKutusuService.Update(mesaj);
            return RedirectToAction("OkunmamisMesajlar");
        }
    }
}