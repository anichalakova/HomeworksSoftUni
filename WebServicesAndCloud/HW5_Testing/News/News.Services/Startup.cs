﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(News.Services.Startup))]

namespace News.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
