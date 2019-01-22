using Cinema.Dados;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //TraceListener traceListener = new ConsoleTraceListener();
            //TraceListener traceListener = new TextWriterTraceListener("log.txt");

            //Trace.Listeners.Add(traceListener);
            Trace.AutoFlush = true;

            var cinemaDB = new CinemaDB(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();

            IList<Filme> filmes = await cinemaDB.GetFilmes();

            Console.WriteLine("RELATÓRIO DE FILMES");
            Console.WriteLine(new string('=', 50));
            foreach (var filme in filmes)
            {
                Console.WriteLine("Diretor: {0}\n Titulo: {1}", filme.Diretor, filme.Titulo);
                Console.WriteLine(new string('-', 50));
            }
            //traceListener.Flush();
            Console.ReadLine();
        }

    }
}
