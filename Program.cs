using System.Data;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        private static bool DopMenu = false;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите путь до файла: ");
                string path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.WriteLine("Ошибка: файл не был найден");
                    Console.WriteLine("Нажмите Escape, чтобы выйти или любую другу клавишу, чтобы продолжить");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    Console.Clear();
                }
                else
                {
                    if (Path.GetExtension(path) == ".txt")
                    {
                        TextConvert tc = new TextConvert();
                        Menu(tc.Deserialize(path));
                        break;
                    } 
                    else if (Path.GetExtension(path) == ".json")
                    {
                        JsonConverter jk = new JsonConverter();
                        Menu(jk.Deserialize(path));
                        break;
                    } 
                    else if (Path.GetExtension(path) == ".xml")
                    {
                        XmlConverter xc = new XmlConverter();
                        Menu(xc.Deserialize(path));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: недопустимый формат");
                        Console.WriteLine("Нажмите Escape, чтобы выйти или любую другу клавишу, чтобы продолжить");
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }
                    Console.Clear();
                }
            }
            Console.Clear();
            Console.WriteLine("Досвидания !");
        }
        static void DrewMenu(List<Figure> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element.Name);
                Console.WriteLine(element.Wight);
                Console.WriteLine(element.Height);
            }
        } 
        static void Menu(List<Figure> list)
        {
            Console.Clear();
            DrewMenu(list);
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                } 
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь полный путь с название и расширением файла (json,txt,xml), куда вы хоите сохранить его.");
                    SerializeExeption(Console.ReadLine(), list);
                    DrewMenu(list);
                }
            }
        }
        static void SerializeExeption(string PathForSave, List<Figure> list)
        {
            while (true)
            {
                if (Path.GetExtension(PathForSave) == ".txt")
                {
                    TextConvert tc = new TextConvert();
                    tc.Serialize(PathForSave, list);
                    break;
                }
                else if (Path.GetExtension(PathForSave) == ".json")
                {
                    JsonConverter jc = new JsonConverter();
                    jc.Serialize(PathForSave,list);
                    break;
                }
                else if (Path.GetExtension(PathForSave) == ".xml")
                {
                    XmlConverter xc = new XmlConverter();
                    xc.Serelialize(PathForSave, list);
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: неверное разрешение файла");
                    Console.WriteLine("Нажмите Escape, чтобы выйти или любую другу клавишу, чтобы продолжить");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Введите путь полный путь с название и расширением файла (json,txt,xml), куда вы хоите сохранить его.");
                PathForSave = Console.ReadLine();
            }
            Console.Clear();
        }
    }
}