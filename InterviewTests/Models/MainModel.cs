using Exercise1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    /// <summary>
    /// Вся основная логика программы
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// Считывает значения коэффициентов для нескольких квадратных уравнений из строки.
        /// </summary>
        /// <param name="s">Строка со значениями коэффициентов</param>
        /// <returns>Возвращает список уравнений, извлеченных из строки. Ожидается, что значения для одного уравнения находятся на одной строке.</returns>
        public List<QuadEq> GetQuadEqs(string s)
        {
            List<QuadEq> quads = new List<QuadEq>();
            foreach(string row in s.Split("\n"))
            {
                var value = GetQuadEq(row);
                if (value != null) 
                    quads.Add(value);
            }
            return quads.Count() > 0 ? quads : null;
        }

        public QuadEq GetQuadEq(string s)
        {
            string log = ""; // Тут будут сохранены комментарии по ошибкам при попытке конвертировать строку 

            s = s.Trim();
            s = s.Replace(".", ",");

            string[] coeffs = s.Split(' ');

            float a = 1, b = 1, c = 0;

            try
            {
                a = float.Parse(coeffs[0]);
            }
            catch
            {
                log = "Ошибка";
            }
            try
            {
                b = float.Parse(coeffs[1]);
            }
            catch
            {
                log = "Ошибка";
            }
            try
            {
                c = float.Parse(coeffs[2]);
            }
            catch
            {
                log = "Ошибка";
            }

            if (log != "")
                return null;

            QuadEq quad = new QuadEq(a, b, c);
            quad.Log = log;
            return quad;
        }
    }
}
