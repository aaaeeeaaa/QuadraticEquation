using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Entities
{
    public class QuadCount
    {
        //Для будущей реулизации других методов решения
        public enum EMethods { Дискриминант = 0, Виет = 1  } //Можно наполнять

        private EMethods method = EMethods.Дискриминант;
        public void Count(QuadEq quad) 
        {
            QuadResult Result = new QuadResult();

            switch (method)
            {
                case EMethods.Дискриминант:
                    {
                        //D = b^2 – 4ac
                        float D = MathF.Pow(quad.B, 2) - 4 * quad.A * quad.C;

                        switch (D)
                        {
                            case 0:
                                {
                                    Result.X1 = -(quad.B / (2 * quad.A));
                                    Result.X2 = null;
                                    Result.log = "Один корень. Дискриминант = 0";
                                    break;
                                }
                            case >0:
                                {
                                    Result.X1 = (-quad.B + MathF.Sqrt(D)) / (2 * quad.A);
                                    Result.X2 = (-quad.B - MathF.Sqrt(D)) / (2 * quad.A);
                                    break;
                                }
                            case <0:
                                {
                                    Result.X1 = null;
                                    Result.X2 = null;
                                    Result.log = "Нет корней. Отрицательный дискриминант";
                                    break;
                                }
                        }

                        break;
                    }
                default:
                    {

                        break;
                    }
                
            }

            quad.Result = Result;
        }
    }
}
