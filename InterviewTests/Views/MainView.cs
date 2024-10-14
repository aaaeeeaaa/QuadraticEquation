using Exercise1.Controllers;
using Exercise1.Entities;

namespace Exercise1.Views
{
    public class MainView
    {
        static void Main(string[] args)
        {
            MainController controller = new MainController();

            Console.WriteLine("Программа для решения квадратных уравнений.");
            
            string s = GetValidatedString();            

            //Получаем список уравнений из строки
            List<QuadEq> quads = controller.GetQuadEqs(s);
            //Отлавливаем ошибку
            if(quads == null)
            {
                Console.WriteLine("Не удалось считать коэффициенты");
                return;
            }
            
            //Класс для расчета уравнения
            QuadCount counter = new QuadCount();
           
            Console.WriteLine("\nРешение уравнений:");
            foreach (QuadEq quad in quads)
            {
                //Выводим само уравнение
                Console.WriteLine(quad.GetQuadEqString());
                //Считаем уравнение
                counter.Count(quad);
                //Выводим результаты
                Console.WriteLine(quad.GetQuadResultsString() + "\n"); 
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Получение ввода юзера
        /// </summary>
        /// <returns></returns>
        static string GetValidatedString()
        {
            bool b = true;
            string text = "";
            while (b)
            {
                Console.WriteLine("Введите 1 для ручного ввода, 2 - для загрузки из файла");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine("Введите значения коэффициентов a, b, c:");
                            //Считываем все уравнения, введенные пользователем из консоли
                            text = Console.ReadLine();
                            b = false;
                            break;
                        }
                    case "2":
                        {
                            //Я честно пытался реализовать открытие проводника по типу OpenFolderDialog, но у меня не вышло, так что довольствуемся тем, что есть                            
                            Console.WriteLine("Введите путь к файлу с коэффициентами:");

                            try
                            {
                                using StreamReader reader = new(Console.ReadLine().Replace("\"", ""));
                                text = reader.ReadToEnd();
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            b = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неожиданный ввод");
                            break;
                        }
                }
            }
            return text;
        }
    }
}