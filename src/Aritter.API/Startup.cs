﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Aritter.API.Startup))]

namespace Aritter.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}