using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Реализация интерфейса <see = cref "ICollectionWrapper"/>
	/// для коллекции <see = cref "Dictionary<string, bool>"/>
	/// </summary>
	class Dictionary1Wrapper : ICollectionWrapper
	{
		/// <summary>
		/// Инициализация исходной коллекции
		/// </summary>
		Dictionary<string, bool> collection = new Dictionary<string, bool>();

		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.Dictionary1;
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
			if (!collection.ContainsKey(word))
				collection.Add(word, true);
		}

		/// <summary>
		/// Проверяет, содержит ли коллекция слово <see = cref "word"/>
		/// </summary>
		/// <param name="word">Слово для поиска в коллекции</param>
		/// <returns>true - если слово содержится в коллекции,
		/// false - в противном случае</returns>
		public bool Contains(string word)
		{
			return collection.ContainsKey(word);
		}

		/// <summary>
		/// Удаляет первое слово из коллекции
		/// </summary>
		public void DeleteOneWord()
		{
			collection.Remove(collection.ElementAt(0).Key);
		}
	}
}
