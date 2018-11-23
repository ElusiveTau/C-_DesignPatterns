using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Command;

namespace ex_DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoker = new Invoker();
            var thorbot = new Robot("Thor");

            thorbot.Move(Robot.Direction.Down, 5);

            Console.ReadKey();
        }
    }

    // Another receiver
    internal class Robot
    {
        public enum Direction { Up, Down, Left, Right };

        private string _name;
        private int _moveLimit;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Robot(string name, int maxMoves=100)
        {
            Name = name;
            MoveLimit = maxMoves;
        }

        public int MoveLimit
        {
            get => _moveLimit;
            set => _moveLimit = value;
        }

        public void Move(Direction moveDirection, int movementvalue)
        {
            Console.WriteLine($"{Name}: Move<{moveDirection}, {movementvalue}>");
            MoveLimit -= movementvalue;
        }
    }

}
