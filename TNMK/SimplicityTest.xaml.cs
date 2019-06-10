using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TNMK
{
    /// <summary>
    /// Логика взаимодействия для SimplicityTest.xaml
    /// </summary>
    public partial class SimplicityTest : Window
    {
        public SimplicityTest()
        {
            InitializeComponent();
        }
        private void Test1(string number, string numberOfIter)
        {
            try
            {
                long n; int K;
                if (number == "") throw new Exception("Введите число для проверки");
                if (numberOfIter == "") throw new Exception("Введите количество проверок");


                if (long.TryParse(number, out n)) throw new Exception("Неверный формат ввода числа!");
                if (int.TryParse(numberOfIter, out K)) throw new Exception("Неверный формат ввода количества проверок!");

                string s = "";
                for (int i = 2; i < K + 2; i++)
                {
                    if (KMZI.NOD(i, n) != 1)
                    {
                        s = n.ToString() + " - составное!\n";
                        s += n.ToString() + " = " + i.ToString() + " * " + n / i;
                        return;
                    }
                    long d = KMZI.Exponentiation(i, n - 1, n);
                    if (d != 1)
                    {
                        s = n.ToString() + " - составное!\n";
                        s += i.ToString() + "^" + (n - 1).ToString() + " = " + d.ToString() + "(mod " + n.ToString() + ")";
                        return;
                    }
                }
                s = n.ToString() + " - возможно простое";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }

        }
        private void Test2(string number, string numberOfIter)
        {
            try
            {
                long n; int K;
                if (number == "") throw new Exception("Введите число для проверки");
                if (numberOfIter == "") throw new Exception("Введите количество проверок");


                if (long.TryParse(number, out n)) throw new Exception("Неверный формат ввода числа!");
                if (int.TryParse(numberOfIter, out K)) throw new Exception("Неверный формат ввода количества проверок!");

                string s = "";
                for (int i = 2; i < K + 2; i++)
                {
                    if (KMZI.NOD(i, n) != 1)
                    {
                        s = n.ToString() + " - составное!\n";
                        s += n.ToString() + " = " + i.ToString() + " * " + n / i;
                        return;
                    }
                    long d = KMZI.Lezhandr(i, n);
                    if (d < 0) d += n;
                    if (d != KMZI.Exponentiation(i, (n - 1) / 2, n))
                    {
                        s = n.ToString() + " - составное!\n";
                        s += "SL( " + i.ToString() + "," + n.ToString() + ") = " + d.ToString() + "(mod " + n.ToString() + ")\n";
                        return;
                    }
                }
                s = n.ToString() + " - возможно простое";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }

        private void Test3(string number, string numberOfIter)
        {
            try
            {
                long n; int K;
                if (number == "") throw new Exception("Введите число для проверки");
                if (numberOfIter == "") throw new Exception("Введите количество проверок");


                if (long.TryParse(number, out n)) throw new Exception("Неверный формат ввода числа!");
                if (int.TryParse(numberOfIter, out K)) throw new Exception("Неверный формат ввода количества проверок!");

                string str = "";
                for (int i = 2; i < K + 2; i++)
                {
                    if (KMZI.NOD(i, n) != 1)
                    {
                        str = n.ToString() + " - составное!\n";
                        str += n.ToString() + " = " + i.ToString() + " * " + n / i;
                        return;
                    }
                    int s = 1;
                    long t = (n - 1) / (int)Math.Pow(2, s);
                    long d = KMZI.Exponentiation(i, t, n);
                    while ((int)Math.Pow(2, s) > ((n - 1) / 3) + 1)
                    {
                        if (KMZI.Exponentiation(d, (long)Math.Pow(2, s), n) == n - 1)
                        {
                            str = n.ToString() + " - составное!\n";
                            return;
                        }
                        s++;
                    }
                }
                str = n.ToString() + " - возможно простое";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
        }
    }
}
