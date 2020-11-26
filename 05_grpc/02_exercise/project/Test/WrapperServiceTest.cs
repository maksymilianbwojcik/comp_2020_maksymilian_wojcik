using System.Net.Http;
using Grpc.Net.Client;
using Proto;
using Xunit;

namespace Test
{
    public class WrapperServiceTest
    {
        [Fact]
        public void TextWrapTest()
        {
            var httpHandler = new HttpClientHandler();

            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions {HttpHandler = httpHandler});
            var client = new Wrapper.WrapperClient(channel);
            var response = client.WrapText(new WrapRequest
            {
                Line =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis accumsan dignissim ante vel suscipit. Aenean suscipit ex porttitor, lobortis eros non, cursus nunc. In consectetur, magna nec sodales egestas, nisi felis tincidunt ipsum, et ornare massa magna sit amet eros. Etiam bibendum eros viverra augue ultrices vehicula. Etiam risus lectus, rhoncus vitae odio eget, sagittis malesuada nisl. Phasellus accumsan mi lorem, eget finibus purus pulvinar nec. Aliquam consequat ligula et maximus lobortis. In volutpat libero vitae eros gravida aliquet. Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce ac felis sapien. Nulla at lacus non risus imperdiet bibendum sit amet molestie purus. Nunc quis rutrum est. Sed id nisl non tortor facilisis rhoncus.",
                Columns = 50
            });

            Assert.Contains(@"Lorem ipsum dolor sit amet, consectetur adipiscing
            elit. Duis accumsan dignissim ante vel suscipit.
                Aenean suscipit ex porttitor, lobortis eros non,
                cursus nunc. In consectetur, magna nec sodales
                egestas, nisi felis tincidunt ipsum, et ornare
                massa magna sit amet eros. Etiam bibendum eros
                viverra augue ultrices vehicula. Etiam risus
                lectus, rhoncus vitae odio eget, sagittis
            malesuada nisl. Phasellus accumsan mi lorem, eget
            finibus purus pulvinar nec. Aliquam consequat
            ligula et maximus lobortis. In volutpat libero
                vitae eros gravida aliquet. Interdum et malesuada
                fames ac ante ipsum primis in faucibus. Fusce ac
            felis sapien. Nulla at lacus non risus imperdiet
            bibendum sit amet molestie purus. Nunc quis rutrum
            est. Sed id nisl non tortor facilisis rhoncus.", response.Text);
        }
    }
}