using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Projetos;
using System.Collections.Generic;
using DesafioTestesApi.DBSteps;


namespace DesafioTestesApi.Tests.Projetos
{
    [TestFixture]
    public class DeletarUmSubProjetoTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            List<string> idProjesto = SolicitacaoDBSteps.RetornaIdSubProjetoDB();
            string project_id = idProjesto[0];
            #endregion


            #region Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            DeletarUmSubProjetoRequest deletarUmSubProjetoRequest = new DeletarUmSubProjetoRequest(project_id);
            IRestResponse<dynamic> response = deletarUmSubProjetoRequest.ExecuteRequest();

            
             Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosIdSubProjeto()
        {
            #region Parameters
            string project_id = "ABC1313";
            #endregion
           
            #region Resultado esperado
            string statusCodeEsperado = "BadRequest";
            #endregion

            DeletarUmSubProjetoRequest deletarUmSubProjetoRequest = new DeletarUmSubProjetoRequest(project_id);

            IRestResponse<dynamic> response = deletarUmSubProjetoRequest.ExecuteRequest();

    
           Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
       
        }


        [Test]
        [Parallelizable]
        public void DadosInvalidosProjetoNaoAutorizado()
        {
            #region Parameters
            string project_id = "9999999a";
            #endregion

            #region Resultado esperado
            string statusCodeEsperado = "Forbidden";
            #endregion

            DeletarUmSubProjetoRequest deletarUmSubProjetoRequest = new DeletarUmSubProjetoRequest(project_id);

            IRestResponse<dynamic> response = deletarUmSubProjetoRequest.ExecuteRequest();


            Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

        }

    }
}
