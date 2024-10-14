using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1.Entities
{
    public class QuadEq
    {
        public QuadEq(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }

        public float A { get; private set; }
        public float B { get; private set; }
        public float C { get; private set; }
        public QuadResult Result { get; set; }
        public string Log { get; set; }

        /// <summary>
        /// Возвращает уравнение, собранное из коэффициентов.
        /// </summary>
        /// <returns></returns>
        public string GetQuadEqString()
        {
            // Формируем часть уравнения для A
            string a = A == 1 ? "x^2" : A == -1 ? "-x^2" : A != 0 ? $"{A}x^2" : "";

            // Формируем часть уравнения для B
            string b = B == 1 ? (A == 0 ? "x" : "+x") : B == -1 ? "-x" : B > 0 ? $"+{B}x" : B < 0 ? $"{B}x" : "";

            // Формируем часть уравнения для C
            string c = C > 0 ? $"+{C}" : C < 0 ? $"{C}" : "";

            // Собираем уравнение
            string equation = $"{a}{b}{c}=0";

            // Если все коэффициенты равны 0, уравнение не существует
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b) && string.IsNullOrEmpty(c))
            {
                return "0=0";
            }

            return equation;
        }

        public string GetQuadResultsString()
        {           
            if(Result.X2 == null && Result.X1 == null)
                return Result.log;

            if(Result.X2 != null && Result.X1 != null)
                return string.Format("x1 = {0}; x2 = {1}", Result.X1, Result.X2);

            return Result.log + "\n" + string.Format("x = {0};", Result.X1);
        }
    }

    public class QuadResult
    {
        public object X1 { get; set; }
        public object X2 { get; set; }
        public string log { get; set; }
    }
}
