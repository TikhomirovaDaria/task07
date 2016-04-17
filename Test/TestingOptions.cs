using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Хранит параметры тестов
	/// </summary>
	class TestingOptions
	{
		/// <summary>
		/// Максимальное число для добавления в коллекции
		/// </summary>
		public int MaxWordCount { get; private set; }

		/// <summary>
		/// Число символов в слове
		/// </summary>
		public int CharsInWord { get; private set; }

		/// <summary>
		/// Символы, из которых составлены слова
		/// </summary>
		public string Alphabet { get; private set; }

		/// <summary>
		/// Конструктор по умолчанию
		/// Инициализирует поля класса пользовательскими параметрами
		/// </summary>
		/// <param name="maxWordCount">Максимальное число для добавления в коллекции</param>
		/// <param name="charsInWord">Число символов в слове</param>
		/// <param name="alphabet">Символы, из которых составлены слова</param>
		public TestingOptions(int maxWordCount, int charsInWord, string alphabet)
		{
			MaxWordCount = maxWordCount;
			CharsInWord = charsInWord;
			Alphabet = alphabet;
		}
	}
}
