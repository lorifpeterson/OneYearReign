using OneYearReign.Core.Interfaces;
using OneYearReign.Infrastructure;
using StructureMap;
namespace OneYearReign.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.Assembly("OneYearReign.Core");
                                        scan.Assembly("OneYearReign.Infrastructure");
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
            //                x.For<IExample>().Use<Example>();
                            x.For<IProfileRepository>().Use<ProfileStaticTextRepository>();
                            //x.For<INewsService>().Use<NewsStaticTextService>();
                            x.For<INewsService>().Use<FacebookNewsServiceAdapter>()
                                .Ctor<string>("accessToken").Is("229476660510789|twqbYmKET7G3dD3W3VkNiEb-KLs")
                                .Ctor<string>("account").Is("oneyearreign");
                            x.For<IMemberRepository>().Use<MemberStaticTextRepository>();
                        });

            return ObjectFactory.Container;
        }
    }
}