using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Tarefas;


namespace DesafioTestesApi.Tests.Tarefas
{
    [TestFixture]
    public class ObterTarefasNaoAtribuidasTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string filter_id = "unassigned";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            ObterTarefasNaoAtribuidasRequest obterTarefasNaoAtribuidasRequest = new ObterTarefasNaoAtribuidasRequest(filter_id);
            IRestResponse<dynamic> response = obterTarefasNaoAtribuidasRequest.ExecuteRequest();

            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

         
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosFiltroAtribuicao()
        {
            #region Parameters
            string filter_id = "testes1";

            //Resultado esperado
            string statusCodeEsperado = "OK";
            string status_code = "404";
            string fault_string = "Unknown filter 'testes1'";
            #endregion

            ObterTarefasNaoAtribuidasRequest obterTarefasNaoAtribuidasRequest = new ObterTarefasNaoAtribuidasRequest(filter_id);
            IRestResponse<dynamic> response = obterTarefasNaoAtribuidasRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(status_code, response.Data["issues"]["status_code"].ToString());
                Assert.AreEqual(fault_string, response.Data["issues"]["fault_string"].ToString());

            });
        }
    }
}
