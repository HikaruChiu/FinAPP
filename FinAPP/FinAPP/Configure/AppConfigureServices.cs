using FinAPP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinAPP.Configure
{
    public class AppConfigureServices {
        /// <summary>
        /// 配置服務
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Build(IServiceCollection services, IConfiguration configuration)
        {

            //var connectionString = configuration["AppConfiguration:ConnectionString"];
            //var connectionStringRedis = configuration["AppConfiguration:ConnectionStringRedis"];

            #region 取消預設驗證Api 接收參數模型 的 驗證特性

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            #endregion

            #region HttpContext、IMemoryCache

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();

            #endregion

            #region NLog

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<INLogHelper, NLogHelper>();

            #endregion

            #region AutoMapper

            //services.AddAutoMapper(typeof(AutoMapperConfig));

            #endregion

            #region DB Connection

            //var sectionConfig = new SectionConfig();
            //configuration.Bind(sectionConfig);
            //services.AddSingleton(sectionConfig);
            var connectionConfig = new ConnectionConfig();
            configuration.GetSection("ConnectionString").Bind(connectionConfig);
            services.AddSingleton(connectionConfig);

            #endregion

            #region 各項服務的 Service DI

            //services.AddSingleton<ICustomer, CustomerService>();
            //services.AddSingleton<IMember, MemberService>();
            //services.AddSingleton<ILogin, LoginService>();

            //services.AddSingleton<IArticle, ArticleService>();

            #endregion

            

        }
    }

}
