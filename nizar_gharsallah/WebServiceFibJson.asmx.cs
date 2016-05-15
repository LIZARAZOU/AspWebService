using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Util;
using System.Xml;

namespace nizar_gharsallah
{

    public class CustomRequestValidator : RequestValidator
    {
        protected override bool IsValidRequestString(HttpContext context, string value, RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
        {
            // Set a default value for the out parameter.
            validationFailureIndex = -1;            return true;
           
        }
    }





    /// <summary>
    /// Summary description for WebServiceFibJson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceFibJson : System.Web.Services.WebService
    {
        public class CFibonacci
        {
            public long ResulatFibonacci;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public string  Fibonacci(int n)
        {
            CFibonacci fib = new CFibonacci();
            if ((n <= 100) && (n >= 1))
            {
                long a = 0;
                long b = 1;
                for (int i = 0; i < n; i++)
                {
                    long c = a;
                    a = b;
                    b = c + b;
                }
                
                fib.ResulatFibonacci = a;
            }
            else
            {
                fib.ResulatFibonacci = -1;
            }
            return new JavaScriptSerializer().Serialize(fib); 
              
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, XmlSerializeString = true)]
        public string XmlToJson(string xmlString)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlString);
                return JsonConvert.SerializeXmlNode(xmlDocument);
            }
            catch (Exception e1)
            {
                return "Bad Format";
            }

        }


    }
}
