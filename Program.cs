using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	class Program
	{
		/// <summary>
		/// Тчка начала работы программы
		/// </summary>
		static void Main(string[] args)
		{
			/// <summary>
			/// Создание объекта класса <see = cref "Controller"/>
			/// и передача ему в качестве параметров функций-трансляторов для общения
			/// класса <see = cref "Controller"/> с пользователем
			/// </summary>
			Controller controller = new Controller(PrintResult, InputSize, InputAlphabet);

			Console.Clear();

			/// <summary>
			/// Начало тестирования всех коллекций
			/// </summary>
			controller.TestAllCollections();

			Console.ReadKey();
		}

		/// <summary>
		/// Печать полученых от класса <see = cref "Controller"/> результатов на консоль
		/// </summary>
		/// <param name="type">идентификатор коллекции</param>
		/// <param name="text">Результаты тестирования</param>
		static void PrintResult(string type, string text)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(type);
			Console.ResetColor();

			Console.WriteLine(string.Format("{0}\n", text));
		}

		/// <summary>
		/// Корректный ввод неотрицательного числа с консоли
		/// </summary>
		/// <param name="text">Приграшение для ввода</param>
		static int InputSize(string text)
		{
			Console.Clear();
			int size = -1;

			while (true)
			{
				Console.Write(text);
				if (Int32.TryParse(Console.ReadLine(), out size) && size > 0)
					break;

				Console.WriteLine("Wrong input\n");
			}

			return size;
		}

		/// <summary>
		/// Ввод строки с консоли
		/// </summary>
		/// <param name="text">Приграшение для ввода</param>
		static string InputAlphabet(string text)
		{
			Console.Clear();
			Console.Write(text);
			return Console.ReadLine();
		}
	}
}
