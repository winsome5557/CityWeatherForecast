using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AppInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;



namespace TestProject
{ 
    [TestClass]
    public class TestTTokenService
    {


        [TestMethod]
        public void ShouldReturn_InValidAuthException_IfServerIsNotAuthenticated()
        {

            // Arrange

            Mock<HttpMessageHandler> httpHandlerMoq = new Mock<HttpMessageHandler>();

            httpHandlerMoq.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Content = new StringContent("Success")
                }));

            // Act
            TokenService service = new TokenService(new HttpClient(httpHandlerMoq.Object), "http://httpbin.org/get");
            // Assert
            Assert.ThrowsExceptionAsync<UnauthorizedAccessException>(()=> service.GetToken());


        }


    }
}
