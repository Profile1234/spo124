using System;
using Model;

namespace ConsoleLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Elements mas = null;
            float o, p;
            string switch_on;

            while (true) 
            {
                try
                {
                    Console.WriteLine("Создать 1) Резистор, 2) конденсатор, 3) катушку индуктивности, 0) Выход");
                    switch_on = Console.ReadLine();

                    switch (switch_on)
                    {
                        case "1":
                            Console.Write("R = ");
                            p = (float)Convert.ToDouble(Console.ReadLine());
                            mas = new Resistor(p);
                            break;
                        case "2":
                            Console.Write("omega = ");
                            o = (float)Convert.ToDouble(Console.ReadLine());
                            Console.Write("C = ");
                            p = (float)Convert.ToDouble(Console.ReadLine());
                            mas = new Capacitor(o, p);
                            break;
                        case "3":
                            Console.Write("omega = ");
                            o = (float)Convert.ToDouble(Console.ReadLine());
                            Console.Write("L = ");
                            p = (float)Convert.ToDouble(Console.ReadLine());
                            mas = new Inductance(o, p);
                            break;
                        case "0":
                            break;
                        default:
                            throw new Exception("Неверный пункт меню");
                    }

                    if (switch_on == "0")
                        break;

                    Console.WriteLine($"\t {mas.ComplexResistance()}");
                    mas = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\tОшибка: {e.Message}");
                }
            }

            Console.ReadLine();
        }
    }
}
