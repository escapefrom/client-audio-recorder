using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioDialogRecorder.Core.Sender
{
    public class RequestSender
    {
        private const string BASE_URL = @"http://localhost:5000/session";
        private FlurlClient _flurClient;

        public RequestSender(GlobalSettings globalSettings)
        {
            _flurClient = new FlurlClient(globalSettings?.UrlConfig.ServerUrl ?? BASE_URL);
        }

        public async Task<object> SendPost<T>(string path, T data)
        {
            try
            {
                return await _flurClient
                    .Request(path)
                    .PostJsonAsync(data)
                    .ReceiveJson<object>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}
