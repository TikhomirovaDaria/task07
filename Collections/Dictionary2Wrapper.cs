using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Реализация интерфейса <see = cref "ICollectionWrapper"/>
	/// для коллекции <see = cref "Dictionary<int, List<string>>"/>
	/// </summary>
	class Dictionary2Wrapper : ICollectionWrapper
	{
		/// <summary>
		/// Инициализация исходной коллекции
		/// </summary>
		Dictionary<int, List<string>> collection = new Dictionary<int, List<string>>();

		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.Dictionary2;
			}
		}

		/// <summary>
		/// Возвращает число элементов в коллекции
		/// </summary>
		public int Count
		{
			get
			{
				return collection.Count;
			}
		}

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
			int hash = word.GetHashCode();

			if (collection.ContainsKey(hash))
			{
				(collection[hash] as List<string>).Add(word);
				return;
			}

			collection.Add(hash, new List<string>() { word });
		}

		/// <summary>
		/// Проверяет, содержит ли коллекция слово <see = cref "word"/>
		/// </summary>
		/// <param name="word">Слово для поиска в коллекции</param>
		/// <returns>true - если слово содержится в коллекции,
		/// false - в противном случае</returns>
		public bool Contains(string word)
		{
			int hash = word.GetHashCode();
			if (!collection.ContainsKey(hash))
				return false;

			if ((collection[hash] as List<string>).Contains(word))
				return true;
			return false;
		}

		/// <summary>
		/// Удаляет первое слово из элемента коллекции <see = cref "Dictionary<int, List<string>>"/>
		/// В случае, если <see = cref "List<string>"/> оказывается пуст, то удаляется весь первый
		/// элемент коллекции <see = cref "Dictionary<int, List<string>>"/>
		/// </summary>
		public void DeleteOneWord()
		{
			var first = collection.First();
			first.Value.RemoveAt(0);

			if (first.Value.Count == 0)
				collection.Remove(first.Key);
		}

	}
}
