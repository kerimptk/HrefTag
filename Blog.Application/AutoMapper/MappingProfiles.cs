using AutoMapper;
using Blog.Domain.Entities;
using System.Linq;
using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;
using System;

namespace Blog.Application.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Etiket, EtiketDto>();

            CreateMap<EtiketYazi, EtiketYaziDto>();

            CreateMap<Yazi, BlogYaziListDto>()
                .ForMember(d => d.KategoriUrlAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().UrlAd)))
                .ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname)))
                .ForMember(d => d.KategoriAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().Ad)));

            CreateMap<Yazi, PopulerIceriklerDto>()
                .ForMember(d => d.KategoriUrlAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().UrlAd)))
                .ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname)))
                .ForMember(d => d.KategoriAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().Ad)));

            CreateMap<Yazi, EditorunSectikleriDto>()
                .ForMember(d => d.KategoriUrlAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().UrlAd)))
                .ForMember(d => d.KategoriAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().Ad)))
                .ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname)));
            
            CreateMap<Yazi, DuyurularDto>()
                .ForMember(d => d.KategoriUrlAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().UrlAd)))
                .ForMember(d => d.KategoriAd, o => o.MapFrom(s => (s.KategoriYazilar.Select(i => i.Kategori).FirstOrDefault().Ad)))
                .ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname)));

            CreateMap<KategoriYazi, KategoriYaziListDto>()
                .ForMember(d => d.KategoriUrlAd, o => o.MapFrom(s => (s.Kategori.UrlAd)))
                .ForMember(d => d.UrlBaslik, o => o.MapFrom(s => (s.Yazi.UrlBaslik)))
                .ForMember(d => d.KategoriAd, o => o.MapFrom(s => (s.Kategori.Ad)))
                .ForMember(d => d.OneCikanGorsel, o => o.MapFrom(s => s.Yazi.OneCikanGorsel))
                .ForMember(d => d.OkunmaSayisi, o => o.MapFrom(s => s.Yazi.OkunmaSayisi))
                .ForMember(d => d.Baslik, o => o.MapFrom(s => s.Yazi.Baslik))
                .ForMember(d => d.Ozet, o => o.MapFrom(s => s.Yazi.Ozet))
                /*.ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname))*/;

            CreateMap<Yazi, YaziDto>()
                .ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname)))
                .ForMember(d => d.CreateUserAvatar, o => o.MapFrom(s => (s.User.ImagePath)));

            CreateMap<Kategori, KategoriDto>();

            CreateMap<Yazi, YaziInsertDto>();

            CreateMap<YaziInsertDto, Yazi>()
                .ForMember(i => i.KategoriYazilar, c => c.MapFrom(f => new List<KategoriYazi>()))
                .ForMember(i => i.InsertDate, c => c.MapFrom(f => DateTime.Now));

            CreateMap<YaziUpdateDto, Yazi>()
                .ForMember(i => i.KategoriYazilar, c => c.MapFrom(f => new List<KategoriYazi>()))
                .ForMember(i => i.UpdateDate, c => c.MapFrom(f => DateTime.Now));

            CreateMap<Yazi, YaziUpdateDto>()
                .ForMember(i => i.SelectedCategoryIds, o => o.MapFrom(c => c.KategoriYazilar.Select(i => i.KategoriId).ToList()));

            CreateMap<SayfaInsertDto, Sayfa>()
                .ForMember(i => i.InsertDate, c => c.MapFrom(f => DateTime.Now))
                .ForMember(i => i.UrlBaslik, c => c.MapFrom(f => BaseCore.Utilities.Helpers.UrlHelper.ToUrlSlug(f.Baslik) + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year));

            CreateMap<Sayfa, SayfaUpdateDto>();

            CreateMap<SayfaUpdateDto, Sayfa>()
                .ForMember(i => i.UpdateDate, c => c.MapFrom(f => DateTime.Now))
                .ForMember(i => i.UrlBaslik, c => c.MapFrom(f => BaseCore.Utilities.Helpers.UrlHelper.ToUrlSlug(f.Baslik) + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year));

            CreateMap<Sayfa, SayfaDto>();

            CreateMap<Yorum, YorumDto>()
                .ForMember(d => d.YaziBaslik, c => c.MapFrom(f => (f.Yazi.Baslik)))
                .ForMember(d => d.YaziUrlBaslik, c => c.MapFrom(f => (f.Yazi.UrlBaslik)));

            CreateMap<SosyalMedya, SosyalMedyaDto>();

            CreateMap<ReklamAlanlari, ReklamAlanlariDto>();

            CreateMap<PostaKutusu, PostaKutusuDto>();

            CreateMap<IletisimBilgileri, IletisimBilgileriDto>();

            CreateMap<KategoriYazi, KategoriYaziDto>();

            CreateMap<GenelAyarlar, GenelAyarlarDto>();

            CreateMap<SeoAyarlari, SeoAyarlariDto>();

            CreateMap<Yazi, SearchResponseDto>();

            CreateMap<ToDoList, ToDoListDto>()
                .ForMember(d => d.CreateUserFullName, o => o.MapFrom(s => (s.User.Name + " " + s.User.Surname)));

            CreateMap<ToDoListDto, ToDoList>();

            CreateMap<CekilisSonuclari, CekilisSonuclariDto>();

            CreateMap<CekilisSonuclariDto, CekilisSonuclari>();
        }
    }
}