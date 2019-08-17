using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ITSolution.Framework.Util
{
    public class TaskWatch
    {
        /// <summary>
        /// Conta de tempo de uma rotina
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static TimeSpan StartTaskWatch(Task t)
        {

            // Cria o StopWatch
            Stopwatch sw = new Stopwatch();

            // Começa a contar o tempo
            sw.Start();

            // *** Executa a sua rotina ***
            t.Start();
            
            t.Wait();

            // Para de contar o tempo
            sw.Stop();
            // Obtém o tempo que a rotina demorou a executar
            TimeSpan tempo = sw.Elapsed;

            return tempo;
        }

    }
}
