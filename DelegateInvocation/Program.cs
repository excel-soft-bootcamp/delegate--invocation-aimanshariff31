using System;

namespace DelegationInvoke
{
    class Program
    {
        public class Invocate
        {
            static public void M1() { }
            static public void M2(string data) { }
            public int M3(int x) { return x; }
            public int ArgumentMethod5(int data) { return data; }
            public bool M4(string data, string msg) { return true; }
            public static double Calculate(int x, double y) { return x + y; }

            public void Update(int newNumber) { System.Console.WriteLine(newNumber); }

            public void Delete(string key) { }
        }
        static void FunctionsAsAnArguments(Action oj, Action<string> oj2, Func<int, int> oj3,
                                            Func<string, string, bool> oj4, Func<int, double, double>
                                            CalculateOj, Action<int> UpdateOj, Action<string> DeleteOj)
        {
            //Invoke Delegate objects
            oj.Invoke();
            oj2.Invoke("string");
            int parameter = oj3.Invoke(5);
            bool result = oj4.Invoke("string1", "string2");
            double paramter = CalculateOj.Invoke(1, 3.3);
            UpdateOj.Invoke(31);
            DeleteOj.Invoke("Aiman");
        }

        static void Main(string[] args)
        {
            Invocate _instance = new Invocate();

            //Call FunctionAsAnArguments 

            Action c1 = new Action(Invocate.M1);
            Action<string> c2 = new Action<string>(Invocate.M2);
            Func<int, int> c3 = new Func<int,int>(_instance.M3);
            Func<string, string, bool> c4 = new Func<string, string, bool>(_instance.M4);
            Func<int, double, double> _calcu = new Func<int, double, double>(Invocate.Calculate);
            Action<int> _update = new Action<int>(_instance.Update);
            Action<string> _del = new Action<string>(_instance.Delete);

            FunctionsAsAnArguments(c1, c2, c3, c4, _calcu, _update, _del);
        }



    }
}
