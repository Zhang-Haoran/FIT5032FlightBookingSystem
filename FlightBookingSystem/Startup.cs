/* Copyright 2019, "All Rights Reserved" Haoran Zhang*/using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlightBookingSystem.Startup))]
namespace FlightBookingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
