using System;
using System.Runtime.InteropServices;
using SafeReader;

namespace ASD_lab1
{
    internal class Program
    {
        private static readonly ITaskSolver[] Tasks = {new Task0(), new Task1(), new Task2(), new Task3()};

        public static void Main(string[] args)
        {
            while (true)
                Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1\n2\n3\nExit 0\n");
                
            Extentions.SafeRunning(Menu, $"Index out of bound, should be between 0 and {Tasks.Length}");

            void Menu()
            {
                int task = ConsoleReader.ReadInt();
                Tasks[task].SolveTask();
            }
        }
    }
    interface ITaskSolver
    {
        void SolveTask();
    }

    public class Task0 : ITaskSolver
    {
        public void SolveTask()
        {
            Environment.Exit(0);
        }
    }

    public class Task1 : ITaskSolver
    {
        private enum Water
        {
            River,
            Lake
        }
        
        public void SolveTask()
        {
            Console.Clear();
            Water water = Water.Lake;
            Console.WriteLine("1 - River\n2 - Lake");
            Extentions.SafeRunning(() => water = (Water) (ConsoleReader.ReadInt() - 1), "Incorrect value, must be integer between 1 and 2");
            Console.WriteLine("Ship Velocity");
            double velocity = ConsoleReader.ReadDouble();
            double riverSpeed = 0;
            
            if (water == Water.River)
            {
                Extentions.SafeRunning(() => GetRiverSpeed(velocity),"River speed must be less than ship speed");

                void GetRiverSpeed(double v)
                {
                    Console.WriteLine("River Speed");
                    riverSpeed = ConsoleReader.ReadDouble();
                    if(riverSpeed > v)
                        throw new Exception();
                }
            }

            Console.WriteLine("Time");
            double time = ConsoleReader.ReadDouble();

            Console.WriteLine($"S = {(velocity - riverSpeed) * time}");
            
            Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("First Cell");
            Point<int> firstPos = GetIntPoint();
            Console.WriteLine("Second Cell");
            Point<int> secondPos = GetIntPoint();

            bool onDiagonal = Math.Abs(secondPos.x - firstPos.x) == Math.Abs(secondPos.y - firstPos.y);
            bool canBeat = onDiagonal || firstPos == secondPos || firstPos.x == secondPos.x ||
                           firstPos.y == secondPos.y;

            Console.WriteLine("Result " + canBeat);
            Console.ReadKey();

            Point<int> GetIntPoint()
            {
                Console.WriteLine("Input X (between 1-8)");
                int x = ConsoleReader.ReadInt(1,8,"Out of bounds");
                Console.WriteLine("Input Y (between 1-8)");
                int y = ConsoleReader.ReadInt(1, 8, "Out of bounds");

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