﻿using PageCheckerAPI.Services.WebsiteService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PageCheckerAPI.Services.WebsiteService
{
    public class WebsiteService : IWebsiteService
    {
        public async Task<string> GetHtml(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    var encoding = response.CharacterSet.ToLower().Contains("utf-8") ? 
                        Encoding.UTF8 : 
                        Encoding.GetEncoding(response.CharacterSet);

                    readStream = new StreamReader(receiveStream, encoding);
                }

                string body = await readStream.ReadToEndAsync();

                response.Close();
                readStream.Close();

                return body;
            }

            return string.Empty;
        }
    }
}
