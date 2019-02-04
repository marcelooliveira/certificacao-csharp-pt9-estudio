﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    public class Program
//    {
//        private static System.Diagnostics.Stopwatch _execTimer =
//        new System.Diagnostics.Stopwatch();
//        public static void Delay(int delay)
//        {
//            Thread.Sleep(delay);
//        }
//        public static void LogLongExec(string msg)
//        {
//            if (_execTimer.Elapsed.Seconds >= 5)
//                throw new Exception(
//                    string.Format("Execution is too long > {0} > {1}",
//                    msg, _execTimer.Elapsed.TotalMilliseconds));
//        }
//        public static void Main()
//        {
//            _execTimer.Start();
//            try
//            {
//                Delay(10);
//                LogLongExec("Delay(10)");
//                Delay(5000);
//                LogLongExec("Delay(5000)");
//            }
//            catch (Exception ex)
//            {
//                //A.
//                //System.Diagnostics.TraceSource trace = new TraceSource("./Trace.log");
//                //trace.TraceEvent(TraceEventType.Error, ex.HResult, ex.Message);
//                //Incorreto. O arquivo Trace.log não é gravado porque não foi executado
//                //o método `Flush()` no objeto `trace´.

//                //B.
//                //using (System.Diagnostics.XmlWriterTraceListener log1 =
//                //new XmlWriterTraceListener("./Error.log"))
//                //{
//                //    log1.TraceEvent(
//                //    new TraceEventCache(), ex.Message, TraceEventType.Error, ex.HResult);
//                //    log1.Flush();
//                //}
//                ////Correto, esta opção registra o erro no arquivo Error.log:
//                //<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
//                //  <System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
//                //    <EventID>2148734208</EventID>
//                //    <Type>3</Type>
//                //    <SubType Name="Error">0</SubType>
//                //    <Level>2</Level>
//                //    <TimeCreated SystemTime="2019-02-01T15:41:16.4905497Z" />
//                //    <Source Name="Execution is too long &gt; Delay(5000) &gt; 5011,4864" />
//                //    <Correlation ActivityID="{00000000-0000-0000-0000-000000000000}" />
//                //    <Execution ProcessName="ConsoleApp1" ProcessID="11748" ThreadID="1" />
//                //    <Channel/>
//                //    <Computer>DESKTOP-6FPHLJT</Computer>
//                //  </System>
//                //  <ApplicationData></ApplicationData>
//                //</E2ETraceEvent>

//                //C.
//                //System.Diagnostics.EventInstance errorEvent =
//                //new System.Diagnostics.EventInstance(ex.HResult, 1, EventLogEntryType.Error);
//                //System.Diagnostics.EventLog.WriteEvent("MyAppErrors", errorEvent, ex.Message);
//                ////Incorreto: Essa opção lança a exceção
//                ////System.ArgumentOutOfRangeException: 'Argumento especificado estava fora do intervalo de valores válidos. Arg_ParamName_Name'

//                //D.
//                //EventLog logEntry = new EventLog();
//                //logEntry.Source = "Application";
//                //logEntry.WriteEntry(ex.Message, EventLogEntryType.Error);
//                ////Quase. Como o Id evento não é informado, a mensagem abaixo é lançada no log de eventos.
//                ////Não é possível localizar a descrição da Identificação de Evento 0 na origem "Application". 
//            }
//        }
//    }
//}
