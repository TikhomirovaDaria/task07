using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Реализация интерфейса <see = cref "ICollectionWrapper"/>
	/// </summary>
	class TikhomirovaDaria_TestCollection : ICollectionWrapper
	{
		/// <summary>
		/// Инициализация коллекции Dictionary<string, int>
		/// string - строка
		/// int - число ее повторений
		/// </summary>
		Dictionary<string, int> collection = new Dictionary<string, int>();

		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.TikhomirovaDaria_TestCollection;
			}
		}

		/// <summary>
		/// Возвращает число элементов в коллекции
		/// </summary>
		public int Count { get; private set; }

		/// <summary>
		/// Возвращает полное название типа коллекции, определенное в системе
		/// </summary>
		public string SystemTypeName
		{
			get
			{
				return collection.GetType().FullName;
			}
		}

		/// <summary>
		/// Добавляет слово <see = cref "word"/> в коллекцию
		/// </summary>
		/// <param name="word">Добавляемое слово</param>
		public void Add(string word)
		{
			if (!collection.ContainsKey(word))
			{
				collection.Add(word, 1);
				return;
			}

			collection[word]++;
		}

		/// <summary>
		/// Проверяет, содержит ли коллекция слово <see = cref "word"/>
		/// </summary>
		/// <param name="word">Слово для поиска в коллекции</param>
		/// <returns>true - если слово содержится в коллекции,
		/// false - в противном случае</returns>
		public bool Contains(string word)
		{
			if (collection.ContainsKey(word))
				return true;
			return false;
		}

		/// <summary>
		/// Удаляет первое слово из элемента коллекции <see = cref "Dictionary<string, int>"/> (уменьшает число слов на 1)
		/// В случае, если <see = cref "Value"/> оказывается нулю (все строки такого вида удалили), то удаляется весь первый
		/// элемент коллекции <see = cref "Dictionary<string, int>"/>
		/// </summary>		
		public void DeleteOneWord()
		{
			var first = collection.First();
			collection[first.Key]--;

			if (first.Value == 0)
				collection.Remove(first.Key);
		}
	}
}
