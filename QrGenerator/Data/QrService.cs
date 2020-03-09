using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DeepLink.QrGenerator.Data
{
    public class QrService
    {
        public Task<string> GenereteQR()
        {
            try
            {
                var url = string.Format("http://chart.apis.google.com/chart?cht=qr&chs={1}x{2}&chl={0}", "https://www.deeplink.gr", 150, 150);
                var response = default(WebResponse);
                var remoteStream = default(Stream);
                var request = WebRequest.Create(url);
                response = request.GetResponse();
                remoteStream = response.GetResponseStream();
                
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    remoteStream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }

                var base64 = Convert.ToBase64String(bytes);
                
                return Task.FromResult(base64);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
