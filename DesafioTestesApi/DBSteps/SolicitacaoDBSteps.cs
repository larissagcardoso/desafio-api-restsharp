using DesafioTestesApi.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTestesApi.DBSteps
{
    public class SolicitacaoDBSteps
    {

        public static void LimpaTodosRegistroBancoDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/deletarTodosRegistrosTabela.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Deleta todos registros para inciar testes");
            DBHelpers.ExecuteQuery(query);
        }

        public static void InsereTodosRegistrosDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/inserirTodosRegistrosTabela.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Insere todos registros para inciar testes ");
            DBHelpers.ExecuteQuery(query);
        }


        public static List<string> RetornaInfoProblemaDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/obterTarefa.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna dados de um problema");
            return DBHelpers.RetornaDadosQuery(query);
    
        }

        public static List<string> RetornaInfoTarefaCriadaDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/obterTarefaCriada.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna dados de uma tarefa criada");
            return DBHelpers.RetornaDadosQuery(query);

        }



        public static List<string> RetornaIdProblemaDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/idUmaTarefa.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna id de um problema");
            return DBHelpers.RetornaDadosQuery(query);

        }

        public static List<string> RetornaIdUsuarioDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/idUmUsuario.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna id de um usuario");
            return DBHelpers.RetornaDadosQuery(query);

        }


        public static List<string> RetornaCriacaoUsuarioDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/criacaoUsuario.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna dados de criacao de usuario");
            return DBHelpers.RetornaDadosQuery(query);
        }

        public static List<string> RetornaIdNomeAleatorioProjetoDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/obterIdNomeProjeto.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna id e nome do projeto");
            return DBHelpers.RetornaDadosQuery(query);
        }

        public static List<string> RetornaNomeAleatorioProjetoDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/nomeProjeto.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna nome projeto");
            return DBHelpers.RetornaDadosQuery(query);
        }

        public static List<string> RetornaIdProjetoIdNoteDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/idProjetoIdNote.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna Id projeto e Id Anotação");
            return DBHelpers.RetornaDadosQuery(query);
        }

        public static List<string> RetornaIdSubProjetoDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/idSubProjeto.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna Id Sub Projeto");
            return DBHelpers.RetornaDadosQuery(query);
        }

        public static void DeletaSubprojetosDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/deletarSubProjetos.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Deleta SubProjetos vinculados a um projeto");
            DBHelpers.ExecuteQuery(query);
        }

        public static List<string> RetornaInfoMeuUsuarioDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/obterInfoMeuUsuario.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna Informações meu usuario adm");
            return DBHelpers.RetornaDadosQuery(query);
        }

        public static List<string> RetornaProjetosDB()
        {
            string query = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Queries/obterProjetos.sql", Encoding.UTF8);
            ExtentReportHelpers.AddTestInfo(2, "Retorna id e name Projetos");
            return DBHelpers.RetornaDadosQuery(query);
        }
    }
}
