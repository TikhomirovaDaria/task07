using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Реализация интерфейса <see = cref "ICollectionWrapper"/>
	/// для коллекции <see = cref "Hashtable(HashCode(), List<string>)"/>
	/// </summary>
	class Hashtable2Wrapper : ICollectionWrapper
	{
		/// <summary>
		/// Инициализация исходной коллекции
		/// </summary>
		Hashtable collection = new Hashtable();

		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.Hashtable2;
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
			List<string> items;
			int hash = word.GetHashCode();

			if (collection.ContainsKey(hash))
			{
				items = collection[hash] as List<string>;
				items.Add(word);
				return;
			}

			items = new List<string>() { word };
			collection.Add(hash, items);
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
		///Удаляет первое слово из элемента коллекции <see = cref "Hashtable(HashCode(), List<string>)"/>
		/// В случае, если <see = cref "List<string>"/> оказывается пуст, то удаляется весь первый
		/// элемент коллекции <see = cref "Hashtable(HashCode(), List<string>)"/>
		/// </summary>
		public void DeleteOneWord()
		{
			var it = collection.GetEnumerator();
			it.MoveNext();

			List<string> items = it.Value as List<string>;

			items.RemoveAt(0);

			if (items.Count == 0)
				collection.Remove(it.Key);
		}
	}
}
