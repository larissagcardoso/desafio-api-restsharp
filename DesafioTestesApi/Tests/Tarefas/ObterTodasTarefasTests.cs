using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;


namespace DesafioTestesApi.Tests.Tarefas
{// Validar query 
    [TestFixture]
    public class ObterTodasTarefasTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string page_size = "20";
            string page = "1";
            //Resultado esperado
            string statusCodeEsperado = "OK";
           // string message = "New Issue";
           #endregion

            ObterTodasTarefasRequest obterTodasTarefasRequest = new ObterTodasTarefasRequest(page_size,page);
            IRestResponse<dynamic> response = obterTodasTarefasRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
          
            });
        }

    }
}
