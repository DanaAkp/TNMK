using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNMK
{
    class KMZI
    {
        public static List<long> a = new List<long>();
        public static List<long> x = new List<long>();
        public static List<long> y = new List<long>();
        public static List<long> q = new List<long>();
        /// <summary>
        /// Счетчик для ЛРС
        /// </summary>
        public static int c = 0;
        /// <summary>
        /// Нахождение обратного элемента с помощью РАЕ
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        static public long InverseNumber(long A, long B, long C)
        {
            long nod;
            long x1;
            if (Math.Abs(A) < Math.Abs(B))
            {
                nod = NOD(B, A);
                x1 = y[y.Count - 2] * (C / nod);
            }
            else
            {
                nod = NOD(A, B);
                x1 = x[x.Count - 2] * (C / nod);
            }

            while (x1 > B / nod)
            {
                x1 -= B / nod;
            }
            return x1;
        }
        /// <summary>
        /// Возведение числа в степень по модулю
        /// </summary>
        /// <param name="n">число, возводимое в степень</param>
        /// <param name="deg">степень</param>
        /// <param name="modul">модуль</param>
        /// <returns></returns>
        static public long Exponentiation(long n, long deg, long modul)
        {
            string binaryCode = Convert.ToString(deg, 2);
            long m = n;
            for (int i = 1; i < binaryCode.Length; i++)
            {
                if (int.Parse(binaryCode[i].ToString()) == 0)
                {
                    n *= n;
                    n %= modul;
                }
                else
                {
                    n *= n;
                    n %= modul;
                    n *= m;
                    n %= modul;
                }
            }
            return n;
        }
        /// <summary>
        /// Детерминированная проверка числа на прототу
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static public bool CheckForSimplicity(long n)
        {
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Нахождение НОДа двух чисел
        /// </summary>
        /// <param name="numA"></param>
        /// <param name="numB"></param>
        /// <returns></returns>
        static public long NOD(long numA, long numB)
        {
            a.Clear(); x.Clear(); y.Clear(); q.Clear();

            long nod = 0; a.Add(Math.Abs(numA)); x.Add(1); y.Add(0); q.Add(0);

            a.Add(Math.Abs(numB)); x.Add(0); y.Add(1); q.Add(Math.Abs(numA) / Math.Abs(numB));

            for (int i = 2; a[i - 1] != 0; i++)
            {
                a.Add(a[i - 2] % a[i - 1]);
                if (a[i] != 0)
                {
                    q.Add(a[i - 1] / a[i]);
                }
                x.Add(x[i - 2] - x[i - 1] * q[i - 1]);
                y.Add(y[i - 2] - y[i - 1] * q[i - 1]);
            }
            if (numA < 0)
            {
                a[0] *= -1;
                x[x.Count - 2] *= -1;
            }
            if (numB < 0)
            {
                a[1] *= -1;
                y[y.Count - 2] *= -1;
            }
            nod = a[a.Count - 2];
            return nod;
        }
        /// <summary>
        /// Решение сравнения Ах+Ву=С
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static long DecisionCompare(long A, long B, long C)
        {
            long nod;
            long x1;
            if (Math.Abs(A) < Math.Abs(B))
            {
                nod = NOD(B, A);
                x1 = y[y.Count - 2] * (C / nod);
            }
            else
            {
                nod = NOD(A, B);
                x1 = x[x.Count - 2] * (C / nod);
            }
            while (x1 > B / nod)
            {
                x1 -= B / nod;
            } while (x1 < 0)
            {
                x1 += B / nod;
            }
            return x1;
        }
        /// <summary>
        /// Нахождение символа Якоби
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Lezhandr(long a, long n)
        {
            long SL = 1;
            long deg;
            if (Convert.ToInt32(Math.Sqrt(a)) == Convert.ToDouble(Math.Sqrt(a)))
                return 1;
            if (a < 0)
            {
                a *= -1;
                SL *= (int)Math.Pow(-1, (n - 1) / 2);
            }
            while (a != 0)
            {
                while (a > n)
                {
                    a -= n;
                }
                if (a == 1)
                    return SL;
                if (a == n)
                    return 0;
                if (a % 2 == 0)
                {
                    deg = 0;
                    while (a % 2 == 0)
                    {
                        deg += 1;
                        a /= 2;
                    }
                    if (deg % 2 != 0)
                        SL *= (int)Math.Pow(-1, (n * n - 1) / 8);
                }
                else
                {  //kzv
                    SL *= (int)Math.Pow(-1, (n - 1) * (a - 1) / 4);
                    long buf = a;
                    a = n;
                    n = buf;
                }
            }
            return SL;
        }
        /// <summary>
        /// Вычисление значение многочлена в точке по модулю
        /// </summary>
        /// <param name="koeff">Коэффициенты многочлена, начиная со старшего коэффициента</param>
        /// <param name="point">Значение в точке</param>
        /// <param name="mod">Модуль</param>
        /// <returns></returns>
        public static long Gorner(List<long> koeff, long point, long mod)
        {
            long buf = koeff[0];
            for (int i = 1; i < koeff.Count; i++)
            {
                buf *= point;
                buf += koeff[i];
                buf %= mod;
                while (buf > mod)
                    buf -= buf;

                while (buf < 0)
                    buf += buf;
            }
            return buf;
        }
        /// <summary>
        /// Факторизация числа
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Возвращает коллекцию ключ-значение, где ключ - это простое число, которое входит в разложение, а значение - это степень</returns>
        public static Dictionary<long, long> Factorization(long num)
        {
            Dictionary<long, long> dic = new Dictionary<long, long>();

            for (int i = 2; i <= num; i++)
            {
                if (CheckForSimplicity(i) && num % i == 0)
                {
                    int c = 0;
                    while (num % i == 0) { num /= i; c++; }
                    dic.Add(i, c);
                }
            }

            return dic;
        }
        /// <summary>
        /// Нахождение НОК двух чисел
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long NOK(long m, long n)
        {
            return m * n / NOD(m, n);
        }
        /// <summary>
        /// Деление многочлена на многочлен
        /// </summary>
        /// <param name="K1">Делимое</param>
        /// <param name="K2">Делитель</param>
        /// <param name="mod">модуль</param>
        /// <returns>Частное от деления</returns>
        public static long[] DivisionPolinom(long[] K1, long[] K2, long mod)
        {
            //  int deg = K1.Length - 1;
            long[] result = new long[(K1.Length - 1) - (K2.Length - 1) + 1];
            if (K2.Length > K1.Length) throw new Exception("Степень делимого многочлена должна быть выше делителя!");
            for (int i = K1.Length - 1; i >= 0; i--)
            {
                long[] buf = new long[K1.Length];
                if (i >= K2.Length - 1)
                {
                    result[i - (K2.Length - 1)] = K1[i];//разобраться с индексом, тк в рес должно быть меньше i

                    for (int k = 0; k < K2.Length; k++)
                    {
                        buf[i - (K2.Length - 1) + k] = result[i - (K2.Length - 1)] * K2[k];
                    }
                    for (int j = K1.Length - 1; j >= 0; j--)
                    {
                        buf[j] = K1[j] - buf[j];
                        buf[j] = numOnMod(buf[j], mod);
                    }
                    K1 = buf;//deg = i + K2.Length - 1;
                }
            }
            Array.Reverse(result);
            Array.Reverse(K1);
            //string s = "Коэффициенты многочлена: ";
            //for (int i = 0; i < result.Length; i++)
            //{
            //    s += result[i] + " ";
            //}
            //s += "\nКоэффициенты остатка: ";
            //for (int i = 0; i < K1.Length; i++)
            //    s += K1[i] + " ";
            return result;
        }
        /// <summary>
        /// Деление многочлена на многочлен
        /// </summary>
        /// <param name="K1">Делимое</param>
        /// <param name="K2">Делитель</param>
        /// <param name="mod">модуль</param>
        /// <returns>Остаток от деления</returns>
        public static long[] ModPolinom(long[] K1, long[] K2, long mod)
        {
            //  int deg = K1.Length - 1;
            if (K2.Length > K1.Length) throw new Exception("Степень делимого многочлена должна быть выше делителя!");
            long[] result = new long[(K1.Length - 1) - (K2.Length - 1) + 1];
            for (int i = K1.Length - 1; i >= 0; i--)
            {
                long[] buf = new long[K1.Length];
                if (i >= K2.Length - 1)
                {
                    result[i - (K2.Length - 1)] = K1[i];//разобраться с индексом, тк в рес должно быть меньше i

                    for (int k = 0; k < K2.Length; k++)
                    {
                        buf[i - (K2.Length - 1) + k] = result[i - (K2.Length - 1)] * K2[k];
                    }
                    for (int j = K1.Length - 1; j >= 0; j--)
                    {
                        buf[j] = K1[j] - buf[j];
                        buf[j] = numOnMod(buf[j], mod);
                    }
                    K1 = buf;//deg = i + K2.Length - 1;
                }
            }
            Array.Reverse(result);
            Array.Reverse(K1);
            //string s = "Коэффициенты многочлена: ";
            //for (int i = 0; i < result.Length; i++)
            //{
            //    s += result[i] + " ";
            //}
            //s += "\nКоэффициенты остатка: ";
            //for (int i = 0; i < K1.Length; i++)
            //    s += K1[i] + " ";
            return K1;
        }
        /// <summary>
        /// Возвращает число по модулю
        /// </summary>
        /// <param name="num"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static long numOnMod(long num, long mod)
        {
            while (num < 0) num += mod;
            while (num > mod) num -= mod;
            return num;
        }
        /// <summary>
        /// Нахождение периода ЛРП
        /// </summary>
        /// <param name="k">Длина нального вектора</param>
        /// <param name="max">Граница максимально возможного периода</param>
        /// <param name="ai">ЛРП</param>
        /// <returns>Период последовательности</returns>
        public static int Period(int k, int max, List<int> ai)
        {
            int t = 0;
            for (int i = k - 1; i < max; i++)
            {
                int b = 0;
                while (b != k && ai[i + b] == ai[b])
                {
                    b++;
                }
                if (b < k) t++;
                else break;
            }
            return t - 1 + k;
        }
        /// <summary>
        /// Вычисление ЛРП
        /// </summary>
        /// <param name="vector">Начальный вектор значений</param>
        /// <param name="max">Граница максимально возможного периода</param>
        /// <param name="Pi">Коэффициенты многочлена, записанные после переноса в левую часть</param>
        /// <param name="mod">Модуль</param>
        /// <returns>ЛРП</returns>
        public static List<int> LRP(List<int> vector, int max, List<int> Pi, int mod)
        {
            if (c > max)
                return newElement(vector, Pi, mod);
            c++;
            vector = LRP(vector, max, Pi, mod);
            return newElement(vector, Pi, mod);
        }
        /// <summary>
        /// Для ЛРП
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="Pi"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        static List<int> newElement(List<int> ls, List<int> Pi, int mod)
        {
            int buf = 0;
            for (int i = 0; i < Pi.Count; i++)
            {
                buf += ls[ls.Count - i - 1] * Pi[Pi.Count - i - 1];
            }
            ls.Add(buf % mod);
            return ls;
        }
    }
}
