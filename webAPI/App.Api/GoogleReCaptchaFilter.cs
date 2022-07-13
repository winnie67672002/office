using App.Common;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Api
{
    public class GoogleReCaptchaFilter : ActionFilterAttribute
    {

        public GoogleReCaptchaFilter()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {


            string reCAPTCHA = actionContext.HttpContext.Request.Headers["reCAPTCHA"];
            var secret = AppSettingHelper.GetSection("reCAPTCHASecret").Value; //Google reCAPTCHA 
            if (reCAPTCHA != null)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var content = new FormUrlEncodedContent(new[]{
                        new KeyValuePair<string, string>("secret", secret),
                        new KeyValuePair<string, string>("response", reCAPTCHA),
                    });

                        var result = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content).Result;
                        var resultContent = result.Content.ReadAsStringAsync().Result;
                        var data = JsonConvert.DeserializeObject<GoogleReCaptcha>(resultContent);
                        if (!data.success)
                            actionContext.Result = new UnauthorizedResult();
                    }
                }
                catch (Exception ex)
                {
                    actionContext.Result = new UnauthorizedResult();
                }
            }
            else
            {
                actionContext.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(actionContext);
        }
    }
    public class GoogleReCaptcha
    {
        public bool success { get; set; }
        public DateTime? challenge_ts { get; set; }
        public string hostname { get; set; }
    }
}
