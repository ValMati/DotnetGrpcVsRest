namespace ValMati.DotnetGrpcVsRest.Domain
{
    using System.Threading.Tasks;
    using ValMati.DotnetGrpcVsRest.Domain.Abstractions;
    using ValMati.DotnetGrpcVsRest.Domain.Requests;

    public class EchoService : IEchoService
    {
        public Task<byte[]> EchoAsync(EchoRequest echoRequest)
        {
            ValidateRequest(echoRequest);

            return EchoInternalAsync(echoRequest);
        }

        private void ValidateRequest(EchoRequest echoRequest)
        {
            if (echoRequest.Delay < 0)
            {
                throw new System.ArgumentException($"{nameof(EchoRequest.Delay)} should be greater or equal than zero");
            }

            if (echoRequest.Size < 0)
            {
                throw new System.ArgumentException($"{nameof(EchoRequest.Size)} should be greater or equal than zero");
            }
        }

        private async Task<byte[]> EchoInternalAsync(EchoRequest echoRequest)
        {
            await Task.Delay(echoRequest.Delay);

            return new byte[echoRequest.Size];
        }
    }
}