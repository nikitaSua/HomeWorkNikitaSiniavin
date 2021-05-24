using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreedsTask.Tasks;

namespace ThreedsTask
{
    public class ParaleledTasks
    {
        private IEnumerable<ITask> tasks = from t in Assembly.GetExecutingAssembly().GetTypes()
                                           where t.GetInterfaces().Contains(typeof(ITask))
                                                    && t.GetConstructor(Type.EmptyTypes) != null
                                           select Activator.CreateInstance(t) as ITask;
        private IEnumerable<ITaskpPrameterized> parTasks = from t in Assembly.GetExecutingAssembly().GetTypes()
                                                           where t.GetInterfaces().Contains(typeof(ITaskpPrameterized))
                                                                    && t.GetConstructor(Type.EmptyTypes) != null
                                                           select Activator.CreateInstance(t) as ITaskpPrameterized;
        public void Start()
        {
            ITask[] resultTasks = tasks.ToArray();
            ITaskpPrameterized[] resultParamitresedTasks = parTasks.ToArray();
            Console.WriteLine("Enter start for paramentized task");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter end for paramentized task");
            int end = Convert.ToInt32(Console.ReadLine());
            Parametrs parametrs = new Parametrs(start, end);
            int numProc = Environment.ProcessorCount;
            List<Thread> threads = new List<Thread>();
            bool cycleVar = true;
            while (cycleVar)
            {
                int countAliveThread = CheckNumAliveThreads(threads);
                for (int i = 0; i < numProc - countAliveThread; i++)
                {
                    if (resultTasks.Length == 0)
                        break;
                    Thread thread = new Thread(resultTasks[0].Execute);
                    thread.Start();
                    threads.Add(thread);
                    resultTasks = resultTasks.Where(val => val != resultTasks[0]).ToArray();
                }
                countAliveThread = CheckNumAliveThreads(threads);
                for (int i = 0; i < numProc - countAliveThread; i++)
                {
                    if (resultParamitresedTasks.Length == 0)
                        break;
                    Thread thread = new Thread(new ParameterizedThreadStart(resultParamitresedTasks[0].ExecuteTask));
                    thread.Start(parametrs);
                    threads.Add(thread);
                    resultParamitresedTasks = resultParamitresedTasks.Where(val => val != resultParamitresedTasks[0]).ToArray();
                }
                if (resultTasks.Length == 0 && resultParamitresedTasks.Length == 0)
                    cycleVar = false;
            }
        }
        public int CheckNumAliveThreads(List<Thread> threads)
        {
            int countAliveThread = 0;
            foreach (var thread1 in threads)
            {
                if (thread1.IsAlive)
                    countAliveThread++;
            }
            return countAliveThread;
        }
    }
}
