using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Projetos;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;


namespace DesafioTestesApi.Tests.Projetos
{
    [TestFixture]
    public class DeletarUmProjetoTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> idProjesto = SolicitacaoDBSteps.RetornaIdNomeAleatorioProjetoDB();
            string project_id = idProjesto[0];
            #endregion


            #region Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            DeletarUmProjetoRequest deletarUmProjetoRequest = new DeletarUmProjetoRequest(project_id);
            IRestResponse<dynamic> response = deletarUmProjetoRequest.ExecuteRequest();

            
             Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidos()
        {
            #region Parameters
            string issue_id = "A90000";
            #endregion
           
            #region Resultado esperado
            string statusCodeEsperado = "BadRequest";
            #endregion

            DeletarUmProjetoRequest deletarUmProjetoRequest = new DeletarUmProjetoRequest(issue_id);

            IRestResponse<dynamic> response = deletarUmProjetoRequest.ExecuteRequest();

    
           Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
       
        }

    }
}
