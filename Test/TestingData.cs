using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task07
{
	/// <summary>
	/// Класс, генерирующий рандомные слова для тестов
	/// </summary>
	class TestingData
	{
		/// <summary>
		/// Иницалзация генератора случайных чисел
		/// </summary>
		Random rand = new Random();

		/// <summary>
		/// Слова, которые будут добавляться в коллекции
		/// </summary>
		List<string> wordsToAdd;

		/// <summary>
		/// Слова, по которым бдет осуществляться поиск в коллекциях
		/// </summary>
		List<string> wordsToSearch;

		/// <summary>
		/// Конструтор с парамером
		/// Заполняет коллекции данными для добавления и поиска в колллекциях
		/// </summary>
		/// <param name="options">Параметры тестов</param>
		public TestingData(TestingOptions options)
		{
			SetWordsToAdd(options);
			SetWordsToSearch(options, 20);
		}

		/// <summary>
		/// Возвращает список слов на добавление в коллекции
		/// </summary>
		/// <returns>Список слов для добавление в коллекции</returns>
		public List<string> GetWordsToAdd()
		{
			return wordsToAdd;
		}

		/// <summary>
		/// Возвращает список слов на поиск в коллекциях
		/// </summary>
		/// <returns>Список слов для поиска в коллекциях</returns>
		public List<string> GetWordsToSearch()
		{
			return wordsToSearch;
		}

		/// <summary>
		/// Генерация рандомных слов для добавления в коллекции
		/// </summary>
		/// <param name="options">Параметры теста</param>
		private void SetWordsToAdd(TestingOptions options)
		{
			wordsToAdd = new List<string>();

			for (int i = 0; i < options.MaxWordCount; i++)
				wordsToAdd.Add(CreateWord(options.CharsInWord, options.Alphabet));
		}

		/// <summary>
		/// Генерация рандомных слов для поиска в коллекциях
		/// </summary>
		/// <param name="options">Параметры теста</param>
		private void SetWordsToSearch(TestingOptions options, int percentage)
		{
			wordsToSearch = new List<string>();

			int count = percentage * options.MaxWordCount / 100;
			for (int i = 0; i < count / 2; i++)
			{
				wordsToSearch.Add(CreateWord(options.CharsInWord, options.Alphabet));
				wordsToSearch.Add(GetRandomWord(ref wordsToAdd));
			}
		}

		/// <summary>
		/// получает произвльное слово из коллекции <see = cref "words"/> 
		/// </summary>
		/// <param name="words">Коллекция, из которой надо взять слово</param>
		/// <returns>Полученное слово</returns>
		private string GetRandomWord(ref List<string> words)
		{
			return words[rand.Next(0, words.Count)];
		}

		/// <summary>
		/// Создание рандомного слова дляной <see = cref "CharsInWord"/>,
		/// состоящего из символов алфавита <see = cref "Alphabet"/>
		/// </summary>
		/// <param name="CharsInWord"></param>
		/// <param name="Alphabet"></param>
		/// <returns></returns>
		private string CreateWord(int CharsInWord, string Alphabet)
		{
			StringBuilder word = new StringBuilder();
			char letter;

			for (int i = 0; i < CharsInWord; i++)
			{
				letter = Alphabet[rand.Next(0, Alphabet.Count())];
				word.Append(letter);
			}
			return word.ToString();
		}
	}
}
