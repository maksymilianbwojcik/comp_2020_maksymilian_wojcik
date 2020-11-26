using System.Net.Http;
using Grpc.Net.Client;
using Proto;
using Xunit;


namespace Test
{
    public class GreeterServiceTest
    {
        [Fact]
        public void SayHelloTest()
        {
            var httpHandler = new HttpClientHandler();

            httpHandler.ServerCertificateCustomValidationCallback = 
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);
            var response = client.SayHello(new HelloRequest {Name = "smth"});

            Assert.Contains("smth", response.Message);
        }
    }
}