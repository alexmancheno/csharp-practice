using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
   
    class Program
    {
        static void Main (string[] args)
        {
            //Operation op = num => { Console.WriteLine}
            Action<int> op = num => { Console.WriteLine("{0} * 2 = {1}", num, num * 2); };

            op(2);

            Func<int, int> op2 = x => { return x * 2; };

            Console.WriteLine(op2(10));
        }
    }

    public class Person
    {
        private string _name;
        private ClockTower _tower;

        public Person(string n, ClockTower t)
        {
            _name = n;
            _tower = t;

            _tower.Chime += () =>


        

    }

    public delegate void ChimeEventHandler();
    public class ClockTower
    {
        public event ChimeEventHandler Chime;

        public void ChimeFivePM()
        {
            Chime();
        }

        public void ChimeSixAM()
        {
            Chime();
        }
    }
 }
