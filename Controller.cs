using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	delegate void Print(string type, string text);
	delegate int InputInt(string text);
	delegate string InputString(string text);

	/// <summary>
	/// Класс, автоматизирующий процесс тестирования
	/// </summary>
	class Controller
	{
		/// <summary>
		/// Объект, проведящий серию тестов
		/// </summary>
		CollectionTester tester;

		/// <summary>
		/// Список тестируемых коллекций
		/// </summary>
		Dictionary<CollectionType, ICollectionWrapper> collections;

		/// <summary>
		/// Функция, организующая вывод результатов из текущего класса
		/// </summary>
		Print PrintResult;
		/// <summary>
		/// Функция, получающая пользовательское число
		/// </summary>
		InputInt InputSize;
		/// <summary>
		/// Функция, получающая пользовательский алфавит
		/// </summary>
		InputString InputAlphabet;

		/// <summary>
		/// Конструктор с параметрами
		/// Определяет способ общения с пользователем посредством функций ввода-вывода
		/// Инициализирует класс - тестировщик на основе полученных пользовательских параметров
		/// Создает список коллекций с доступм по ключу <see = cref "CollectionType"/>
		/// </summary>
		/// <param name="PrintResultFunc">Функция, организующая вывод результатов</param>
		/// <param name="InputSizeFunc">Функция, получающая пользовательское число</param>
		/// <param name="InputAlphabetFunc">Функция, получающая пользовательский алфавит</param>
		public Controller(Print PrintResultFunc, InputInt InputSizeFunc, InputString InputAlphabetFunc)
		{
			PrintResult = PrintResultFunc;
			InputSize = InputSizeFunc;
			InputAlphabet = InputAlphabetFunc;

			SetCollections();
			tester = new CollectionTester(AskOptions());
		}

		/// <summary>
		/// Получает от пользователя параметры тестов
		/// Если введенные данные имеют неверный формат - выбрасывает исключение <see = cref "ArgumentException"/>
		/// </summary>
		/// <returns>Объект класса <see = cref "CollectionType"/> с пользовательскими 
		/// параметрами тестов</returns>
		TestingOptions AskOptions()
		{
			int maxWordCount = InputSize("Enter Max Word Count: ");
			int charsInWord = InputSize("Enter number of chars in word: ");

			if (maxWordCount <= 0 || charsInWord <= 0)
				throw new ArgumentException("In AskOptions: wrong input of maxWordCount or charsInWord");

			string alphabet = InputAlphabet("Enter alphabet: ");

			return new TestingOptions(maxWordCount, charsInWord, alphabet);
		}

		/// <summary>
		/// Создает и инициализирует список всех тестируемых коллекций
		/// </summary>
		void SetCollections()
		{
			collections = new Dictionary<CollectionType, ICollectionWrapper>();

			collections.Add(CollectionType.ArrayList, new ArrayListWrapper());
			collections.Add(CollectionType.Dictionary1, new Dictionary1Wrapper());
			collections.Add(CollectionType.Dictionary2, new Dictionary2Wrapper());
			collections.Add(CollectionType.HashSet, new HashSetWrapper());
			collections.Add(CollectionType.Hashtable1, new Hashtable1Wrapper());
			collections.Add(CollectionType.Hashtable2, new Hashtable2Wrapper());
			collections.Add(CollectionType.List, new ListWrapper());
			collections.Add(CollectionType.SortedList, new SortedListWrapper());
			collections.Add(CollectionType.String, new StringWrapper());
			collections.Add(CollectionType.TikhomirovaDaria_TestCollection, new TikhomirovaDaria_TestCollection());
		}

		/// <summary>
		/// Функция сравнения затраченного в ходе теста времени для сортировки коллекций
		/// </summary>
		/// <param name="first">Первый сравниваемый элемент</param>
		/// <param name="second">Второй сравниваемый элемент</param>
		/// <returns>1 - если первый больше ворого, 0 - если они равны, -1 - в противном случае</returns>
		int Comparator(TestingResult first, TestingResult second)
		{
			if (first.SearchTime.ElapsedTicks > second.SearchTime.ElapsedTicks)
				return 1;

			else if (first.SearchTime.ElapsedTicks == second.SearchTime.ElapsedTicks)
				return 0;

			return -1;
		}

		/// <summary>
		/// Запускает тестирование коллекций, сортирует полученные в их ходе
		/// результаты по возрастанию времени поиска и передает пользователю
		/// </summary>
		public void TestAllCollections()
		{
			List<TestingResult> results = new List<TestingResult>();

			foreach (var collection in collections)
				results.Add(tester.TestCollection(collection.Value));

			results.Sort(Comparator);

			foreach (var result in results)
				PrintResult(result.CollectionType.ToString(), result.ToString());
		}
	}
}
