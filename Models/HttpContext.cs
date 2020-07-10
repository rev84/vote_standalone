using System;
using Microsoft.AspNetCore.Http;

namespace System.Web
{

    public static class HttpContext
    {
        private static IHttpContextAccessor m_httpContextAccessor;


        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            m_httpContextAccessor = httpContextAccessor;
        }


        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                return m_httpContextAccessor.HttpContext;
            }
        }


    }
}