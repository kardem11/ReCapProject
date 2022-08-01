﻿using Core.Utilities.Security.JWT;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
        }
    }
}
