using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task07
{
	/// <summary>
	/// Класс, проодящий замеры времени операций 
	/// добавления, удаления и поиска для каждой коллекции
	/// </summary>
	class CollectionTester
	{
		/// <summary>
		/// параметры теста
		/// </summary>
		TestingOptions options;

		/// <summary>
		/// Начальные для проведения теста
		/// </summary>
		TestingData data;

		/// <summary>
		/// Конструктор с параметром
		/// Инициализирует <see = cref "options"/> пользовательскими
		/// параметрами теста и генерирует рандомные начальные данные 
		/// в соответствии с правлами в <see = cref "options"/>
		/// </summary>
		/// <param name="Options">Параметры тестов</param>
		public CollectionTester(TestingOptions Options)
		{
			options = Options;
			data = new TestingData(options);
		}

		/// <summary>
		/// Тест на скорость добавления элементов в <see = cref "сollection"/>
		/// </summary>
		/// <param name="collection">Тестируемая коллекция</param>
		/// <returns>Объект класса <see = cref "Stopwatch"/>,
		/// сдержащий сведения о зтраченном времени</returns>
		private Stopwatch AddTest(ICollectionWrapper collection)
		{

			List<string> words = data.GetWordsToAdd();
			Stopwatch addTime = new Stopwatch();

			addTime.Restart();

			for (int i = 0; i < words.Count; i++)
				collection.Add(words[i]);

			addTime.Stop();

			return addTime;
		}

		/// <summary>
		/// Тест на скорость удаления элементов из <see = cref "сollection"/>
		/// </summary>
		/// <param name="collection">Тестируемая коллекция</param>
		/// <returns>Объект класса <see = cref "Stopwatch"/>,
		/// сдержащий сведения о зтраченном времени</returns>
		private Stopwatch DeleteTest(ICollectionWrapper collection)
		{
			Stopwatch deleteTime = new Stopwatch();

			deleteTime.Restart();

			for (int i = 0; i < collection.Count; i++)
				collection.DeleteOneWord();

			deleteTime.Stop();
			return deleteTime;
		}

		/// <summary>
		/// Тест на скорость поиска элементов в <see = cref "сollection"/>
		/// </summary>
		/// <param name="collection">Тестируемая коллекция</param>
		/// <returns>Объект класса <see = cref "Stopwatch"/>,
		/// сдержащий сведения о зтраченном времени</returns>
		private Stopwatch SearchTest(ICollectionWrapper collection)
		{
			List<string> words = data.GetWordsToSearch();

			Stopwatch searchTime = new Stopwatch();
			searchTime.Restart();

			for (int i = 0; i < words.Count; i++)
				collection.Contains(words[i]);

			searchTime.Stop();
			return searchTime;
		}

		/// <summary>
		/// Проводит для текущей коллекции замеры времени на добавление, поиск и удаление
		/// и возвращает результат в виде объекта класса <param name="TestingResult">
		/// </summary>
		/// <param name="collection">Тестируемая коллекция</param>
		/// <returns>Результат испытаний</returns>
		public TestingResult TestCollection(ICollectionWrapper collection)
		{
			return new TestingResult(AddTest(collection),
									 DeleteTest(collection),
									 SearchTest(collection),
									 collection.CollectionType,
									 collection.SystemTypeName);
		}
	}
}
