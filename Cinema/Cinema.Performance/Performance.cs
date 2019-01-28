using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cinema.Performance
{
    public class Performance
    {
        private const string NomeCategoriaContadores = "_Cinema";
        private const string NomeContadorAverageTimer32 = "AverageTimer32Sample";
        private const string NomeContadorAverageTimer32Base = "AverageTimer32SampleBase";
        public static PerformanceCounter contadorAverageTimer32;
        public static PerformanceCounter contadorAverageTimer32Base;

        /// <summary>
        //Se a categoria não existir, crie a categoria e saia.
        //Os contadores de desempenho não devem ser criados e usados imediatamente.
        //Há um tempo de latência para ativar os contadores, eles devem ser criados
        //antes de executar o aplicativo que usa os contadores.
        //Execute esta amostra uma segunda vez para usar a categoria.
        /// </summary>
        /// <returns></returns>
        public static bool ConfigurarCategoria()
        {
            if (!PerformanceCounterCategory.Exists(NomeCategoriaContadores))
            {
                CounterCreationDataCollection counterDataCollection = new CounterCreationDataCollection();

                // Adiciona o contador.
                CounterCreationData dadosContador = new CounterCreationData();
                dadosContador.CounterType = PerformanceCounterType.AverageTimer32;
                dadosContador.CounterName = NomeContadorAverageTimer32;
                counterDataCollection.Add(dadosContador);

                // Adiciona o contador base.
                CounterCreationData dadosContadorBase = new CounterCreationData();
                dadosContadorBase.CounterType = PerformanceCounterType.AverageBase;
                dadosContadorBase.CounterName = NomeContadorAverageTimer32Base;
                counterDataCollection.Add(dadosContadorBase);

                // Cria a categoria.
                PerformanceCounterCategory.Create(NomeCategoriaContadores,
                    "Demonstra o uso do contador de performance de tipo AverageTimer32.",
                    PerformanceCounterCategoryType.SingleInstance, counterDataCollection);

                return (true);
            }
            else
            {
                Console.WriteLine("Categoria já existes - " + NomeCategoriaContadores);
                return (false);
            }
        }

        public static void CriarContadores()
        {
            // Cria os contadores.
            contadorAverageTimer32 = new PerformanceCounter(NomeCategoriaContadores,
                NomeContadorAverageTimer32,
                false);

            contadorAverageTimer32Base = new PerformanceCounter(NomeCategoriaContadores,
                NomeContadorAverageTimer32Base,
                false);

            contadorAverageTimer32.RawValue = 0;
            contadorAverageTimer32Base.RawValue = 0;
        }

        public static async Task ColetarAmostrasAsync(List<CounterSample> amostras)
        {
            Random r = new Random(DateTime.Now.Millisecond);

            Stopwatch stopwatch = new Stopwatch();

            for (int j = 0; j < 100; j++)
            {
                stopwatch.Start();

                await Task.Delay(r.Next(500, 1000));
                stopwatch.Stop();

                var performanceCounterTicks = stopwatch.Elapsed.Ticks * Stopwatch.Frequency / TimeSpan.TicksPerSecond;
                contadorAverageTimer32.IncrementBy(performanceCounterTicks);
                contadorAverageTimer32Base.Increment();

                stopwatch.Reset();
            }

        }
    }

}
