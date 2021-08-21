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
        private const string BASE_URL = @"https://36c0a55c-85ca-46fe-8494-5944d1398573.mock.pstmn.io";
        private FlurlClient _flurClient;

        public RequestSender(string baseUrl = BASE_URL)
        {
            _flurClient = new FlurlClient(baseUrl);
        }

        public async Task<object> SendPost<T>(string path, T data)
            => await _flurClient
                .Request(path)
                .PostJsonAsync(data)
                .ReceiveJson<object>();
    }
}
