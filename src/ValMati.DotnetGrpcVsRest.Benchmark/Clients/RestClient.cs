namespace ValMati.DotnetGrpcVsRest.Benchmark.Clients
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Mime;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using ValMati.DotnetGrpcVsRest.REST.Shared.Requests;

    public class RestClient : IClient, IDisposable
    {
        private readonly HttpClient client;

        private bool _disposed = false;

        public RestClient()
        {
            client = new HttpClient();
        }

        public async Task CallEchoAsync(int size)
        {
            var request = new RestEchoRequest
            {
                Size = size
            };

            var jsonRequest = GetJsonRequest(request);

            var response = await client.PostAsync(Urls.RESTURL, jsonRequest);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Invalid status code {response.StatusCode}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                client.Dispose();
            }

            _disposed = true;
        }

        private StringContent GetJsonRequest<T>(T value)
        {
            return new StringContent(
                JsonSerializer.Serialize(value),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
        }
    }
}