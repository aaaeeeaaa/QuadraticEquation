using Exercise1.Entities;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Controllers
{
    public class MainController
    {
        MainModel model;
        public MainController()
        {
            model = new MainModel();
        }

        /// <summary>
        /// Считывает значения коэффициентов для нескольких квадратных уравнений из строки.
        /// </summary>
        /// <param name="s">Строка со значениями коэффициентов</param>
        /// <returns>Возвращает список уравнений, извлеченных из строки. Ожидается, что значения для одного уравнения находятся на одной строке.</returns>
        public List<QuadEq> GetQuadEqs(string s)
        {
            if (s.Length == 0)
                return null;
            return model.GetQuadEqs(s);
        }

        internal void CountQuad(QuadEq quad)
        {
            throw new NotImplementedException();
        }
    }
}
