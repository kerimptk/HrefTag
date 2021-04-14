using Autofac;
using Blog.Application.Services;
using Blog.Domain.Interfaces;
using Blog.Domain.Security.Hashing;
using Blog.Domain.Security.JWT;
using Blog.Infrastructure.Repository.EntityFrameworkCore;

namespace Blog.Application.DependencyResolvers
{
    public class BlogAutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCoreEtiketRepository>().As<IEtiketRepository>();
            builder.RegisterType<EtiketService>().As<IEtiketService>();

            builder.RegisterType<EfCoreEtiketYaziRepository>().As<IEtiketYaziRepository>();
            builder.RegisterType<EtiketYaziService>().As<IEtiketYaziService>();

            builder.RegisterType<EfCoreKategoriRepository>().As<IKategoriRepository>();
            builder.RegisterType<KategoriService>().As<IKategoriService>();

            builder.RegisterType<EfCoreKategoriYaziRepository>().As<IKategoriYaziRepository>();
            builder.RegisterType<KategoriYaziService>().As<IKategoriYaziService>();

            builder.RegisterType<EfCoreYaziRepository>().As<IYaziRepository>();
            builder.RegisterType<YaziService>().As<IYaziService>();

            builder.RegisterType<EfCoreYorumRepository>().As<IYorumRepository>();
            builder.RegisterType<YorumService>().As<IYorumService>();

            builder.RegisterType<EfCoreSayfaRepository>().As<ISayfaRepository>();
            builder.RegisterType<SayfaService>().As<ISayfaService>();
            
            builder.RegisterType<EfCoreSosyalMedyaRepository>().As<ISosyalMedyaRepository>();
            builder.RegisterType<SosyalMedyaService>().As<ISosyalMedyaService>();

            builder.RegisterType<EfCoreReklamAlanlariRepository>().As<IReklamAlanlariRepository>();
            builder.RegisterType<ReklamAlanlariService>().As<IReklamAlanlariService>();

            builder.RegisterType<EfCorePostaKutusuRepository>().As<IPostaKutusuRepository>();
            builder.RegisterType<PostaKutusuService>().As<IPostaKutusuService>();

            builder.RegisterType<EfCoreIletisimBilgileriRepository>().As<IIletisimBilgileriRepository>();
            builder.RegisterType<IletisimBilgileriService>().As<IIletisimBilgileriService>();

            builder.RegisterType<EfCoreGenelAyarlarRepository>().As<IGenelAyarlarRepository>();
            builder.RegisterType<GenelAyarlarService>().As<IGenelAyarlarService>();

            builder.RegisterType<EfCoreSeoAyarlariRepository>().As<ISeoAyarlariRepository>();
            builder.RegisterType<SeoAyarlariService>().As<ISeoAyarlariService>();

            builder.RegisterType<EfCoreToDoListRepository>().As<IToDoListRepository>();
            builder.RegisterType<ToDoListService>().As<IToDoListService>();

            builder.RegisterType<EfCoreCekilisSonuclariRepository>().As<ICekilisSonuclariRepository>();
            builder.RegisterType<CekilisSonuclariService>().As<ICekilisSonuclariService>();

            builder.RegisterType<EfCoreUserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfCoreUserRoleRepository>().As<IUserRoleRepository>();
            builder.RegisterType<UserRoleService>().As<IUserRoleService>();
            builder.RegisterType<EfCoreRoleRepository>().As<IRoleRepository>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();


        }
    }
}
