using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Helpers
{
    public static class ServiceProviderHelper
    {
        private static IServiceProvider mServiceProvider;

        public static void Init(IServiceProvider serviceProvider)
        {
            mServiceProvider = serviceProvider;
        }

        public static IServiceProvider ServiceProvider => mServiceProvider;
    }
}
