using Cinema.Dados;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        static async Task Main(string[] args)
        {
#warning ESTA VERSÃO ESTÁ DESATUALIZADA. SIGA AS INSTRUÇÕES E ATUALIZE PARA A VERSÃO 2.0.

//            try
//            {
//#line 1 "um erro comum"
//                //throw new Exception("Erro comum");
//#line 2 "um erro de aplicação"
//                throw new ApplicationException("Erro de aplicação");
//#line default
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.StackTrace);
//            }

            //string assemblyName = typeof(Cinema.Program).Assembly.FullName;
            //Console.WriteLine(assemblyName);
            //Console.ReadKey();

            var cinemaDB = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();

            IList<Filme> filmes = await cinemaDB.GetFilmes();

            foreach (var filme in filmes)
            {
                Console.WriteLine("Diretor: {0} Titulo: {1}", filme.Diretor, filme.Titulo);
            }

            Console.ReadKey();
        }

    }
}
