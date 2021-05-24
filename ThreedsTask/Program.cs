using System;

namespace ThreedsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ParaleledTasks parallelTask = new ParaleledTasks();
            parallelTask.Start();
        }
    }
}
