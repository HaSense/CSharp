using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsingThreadState
{
    class Program
    {
        private static void PrintThreadState(ThreadState state)
        {
            Console.WriteLine("{0,-16} : {1}", state, (int)state);
        }
        static void Main(string[] args)
        {
            PrintThreadState(ThreadState.Running);
            PrintThreadState(ThreadState.SuspendRequested);
            PrintThreadState(ThreadState.Background);
            PrintThreadState(ThreadState.Unstarted);
            PrintThreadState(ThreadState.Stopped);
            PrintThreadState(ThreadState.WaitSleepJoin);
            PrintThreadState(ThreadState.AbortRequested);
            PrintThreadState(ThreadState.Aborted);
            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped);
        }
    }
}
