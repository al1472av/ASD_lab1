using System;
using SafeReader;

namespace ASD_lab1
{
    internal class Program
    {
        private static ITaskSolver[] tasks = {new Task1(), new Task2(), new Task3()};

        public static void Main(string[] args)
        {
            while (true)
                Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("1\n2\n3\nExit 0\n");

            do
            {
                int task = ConsoleReader.ReadInt();
                if (task == 0) Environment.Exit(0);
                if (task > 0 && task < tasks.Length)
                {
                    tasks[task].SolveTask();
                    break;
                }

                Console.WriteLine("Incorrect number");
            } while (true);
        }
    }

    interface ITaskSolver
    {
        void SolveTask();
    }

    public class Task1 : ITaskSolver
    {
        public void SolveTask()
        {
        }
    }

    public class Task2 : ITaskSolver
    {
        public void SolveTask()
        {
            Console.Clear();
            Console.WriteLine("Input X");
            double input = ConsoleReader.ReadDouble();
            Console.WriteLine($"Result {Calculate(input)}\nPress any key to continue");
            Console.ReadKey();

            double Calculate(double x) => Math.Pow(x + 1, 2) + 2 * (x + 1) / 4;
        }
    }

    public class Task3 : ITaskSolver
    {
        public void SolveTask()
        {
            Point<int> firstPos = GetIntPoint();
            Point<int> secondPos = GetIntPoint();

            bool onDiagonal = Math.Abs(secondPos.x - firstPos.x) == Math.Abs(secondPos.y - firstPos.y);
            bool canBeat = onDiagonal || firstPos == secondPos || firstPos.x == secondPos.x ||
                           firstPos.y == secondPos.y;

            Console.WriteLine("Result " + canBeat);
            Console.ReadKey();

            Point<int> GetIntPoint()
            {
                Console.WriteLine("Input first cell X (between 1-8)");
                int x = ConsoleReader.ReadInt();
                Console.WriteLine("Input first cell Y (between 1-8)");
                int y = ConsoleReader.ReadInt();

                return new Point<int>(x, y);
            }
        }
    }

    struct Point<T>
    {
        public T x { get; }
        public T y { get; }

        public Point(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Point<T> first, Point<T> second)
        {
            return Equals(first.x, second.x) && Equals(first.y, second.y);
        }

        public static bool operator !=(Point<T> first, Point<T> second)
        {
            return !(first == second);
        }
    }
}