using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;


namespace App.Common
{
    public class IpHelper
    {

        public static string GetIp()
        {
            return "";
        }

        /// <summary>
        /// 是否為IP格式
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static bool IPCheck(string IP)
        {
            return Regex.IsMatch(IP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static string GetClinetIPAddress(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers;
            if (headers.ContainsKey("X-Forwarded-For"))
            {
                return httpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',', (char)StringSplitOptions.RemoveEmptyEntries)[0];
            }
            else
            {
                return httpContext.Connection?.RemoteIpAddress?.ToString();
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
