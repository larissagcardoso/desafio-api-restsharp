using NUnit.Framework;
using RestSharp;
using DesafioTestesApi.Bases;
using DesafioTestesApi.Requests.Usuarios;
using DesafioTestesApi.DBSteps;
using DesafioTestesApi.Helpers;
using System.Collections.Generic;

namespace DesafioTestesApi.Tests.Usuarios
{
    [TestFixture]
    public class CriarUmUsuarioTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void DadosValidos()
        {
            #region Parameters
            string username = "larissa teste "+GeneralHelpers.GeraStringAutomatica(4);
            string password = "123456";
            string real_name = "larissa" +GeneralHelpers.GeraStringAutomatica(5);
            string email = "larissa@teste"+GeneralHelpers.GeraNumeroAutomatico(2)+".com";
            string nameLevel = "updater";
            string enabled = "true";
            string protectedLevel = "false";
            #endregion

            CriarUmUsuarioRequest criarUmUsuarioRequest = new CriarUmUsuarioRequest();
            criarUmUsuarioRequest.SetJsonBody(username, password, real_name, email, nameLevel, enabled, protectedLevel);

            IRestResponse<dynamic> response = criarUmUsuarioRequest.ExecuteRequest();

            

            List<string> dadosCriacao = SolicitacaoDBSteps.RetornaCriacaoUsuarioDB();
            #region ParametersResponse

            //Resultado esperado
            string statusCodeEsperado = "Created";
            string idUser = dadosCriacao[0];
            string nameUser = dadosCriacao[1];
            string real_nameUser = dadosCriacao[2];
            string emailCriacao = dadosCriacao[3];
            string idAccess_level = dadosCriacao[4];
            #endregion

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());

                Assert.AreEqual(idUser, response.Data["user"]["id"].ToString());
                Assert.AreEqual(nameUser, response.Data["user"]["name"].ToString());
                Assert.AreEqual(real_nameUser, response.Data["user"]["real_name"].ToString());
                Assert.AreEqual(emailCriacao, response.Data["user"]["email"].ToString());
                Assert.AreEqual(idAccess_level, response.Data["user"]["access_level"]["id"].ToString());

            });

        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosUsuario()
        {
            #region Parameters
            string username = "Administrator";
            string password = "123456";
            string real_name = "Administrador";
            string email = "root@localhost";
            string nameLevel = "updater";
            string enabled = "true";
            string protectedLevel = "false";

            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "Username 'Administrator' already used.";
            string code = "800";
            string localized = "That username is already being used. Please go back and select another one.";

            #endregion

            CriarUmUsuarioRequest criarUmUsuarioRequest = new CriarUmUsuarioRequest();
            criarUmUsuarioRequest.SetJsonBody(username, password, real_name, email, nameLevel, enabled, protectedLevel);

            IRestResponse<dynamic> response = criarUmUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(message, response.Data["message"].ToString());
                Assert.AreEqual(code, response.Data["code"].ToString());
                Assert.AreEqual(localized, response.Data["localized"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DadosInvalidosEmail()
        {
            #region Parameters
            string username = GeneralHelpers.GeraStringAutomatica(9);
            string password = "123456";
            string real_name = GeneralHelpers.GeraStringAutomatica(9);
            string email = "root@localhost";
            string nameLevel = "updater";
            string enabled = "true";
            string protectedLevel = "false";

            //Resultado esperado
            string statusCodeEsperado = "BadRequest";
            string message = "Email 'root@localhost' already used.";
            string code = "813";
            string localized = "That email is already being used. Please go back and select another one.";

            #endregion

            CriarUmUsuarioRequest criarUmUsuarioRequest = new CriarUmUsuarioRequest();
            criarUmUsuarioRequest.SetJsonBody(username, password, real_name, email, nameLevel, enabled, protectedLevel);

            IRestResponse<dynamic> response = criarUmUsuarioRequest.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(message, response.Data["message"].ToString());
                Assert.AreEqual(code, response.Data["code"].ToString());
                Assert.AreEqual(localized, response.Data["localized"].ToString());
            });
        }


    }

}
