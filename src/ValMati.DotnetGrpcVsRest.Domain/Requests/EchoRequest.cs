namespace ValMati.DotnetGrpcVsRest.Domain.Requests
{
    public class EchoRequest
    {
        public int Delay { get; set; }

        public int Size { get; set; }
    }
}