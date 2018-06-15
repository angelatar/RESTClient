using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ProductToConsole
{
    /// <summary>
    /// Http requests
    /// </summary>
    public static class HTTPWebRequests
    {
        /// <summary>
        /// Http request which return all products
        /// </summary>
        public static void Get()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["Url"];

            string productJson = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                productJson = reader.ReadToEnd();
            }

            var temp = //Mapper.JsonToProduct(productJson); 
                JsonConvert.DeserializeObject<List<Product>>(productJson);

            foreach (var item in temp)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Http request which return product with given ID
        /// </summary>
        /// <param name="id"></param>
        public static void Get(string id)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["Url"];

            string productJson = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(@"{0}/{1}/{2}", url, "/", id));
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                productJson = reader.ReadToEnd();
            }
            var temp = //Mapper.JsonToProduct(productJson); 
                JsonConvert.DeserializeObject<Product>(productJson);

            Console.WriteLine(temp.ToString());
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        public static void Post(string data, string contentType)
        {

            var url = System.Configuration.ConfigurationManager.AppSettings["Url"];

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = "POST";

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

        }

        /// <summary>
        /// Change product
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        public static void Put(string data, string contentType)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["Url"];

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = "PUT";

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        public static void Delete(string data, string contentType)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["Url"];

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = "DELETE";

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }
        }
    }
}
