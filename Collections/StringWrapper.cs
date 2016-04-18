using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Реализация интерфейса <see = cref "ICollectionWrapper"/>
	/// для коллекции <see = cref "string[]"/>
	/// </summary>
	class StringWrapper : ICollectionWrapper
	{
		/// <summary>
		/// Инициализация исходной коллекции
		/// </summary>
		private string[] collection = new string[0];

		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.String;
			}
		}

		/// <summary>
		/// Возвращает число элементов в коллекции
		/// </summary>
		public int Count
		{
			get
			{
				return collection.Length;
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
			Array.Resize(ref collection, collection.Length + 1);
			collection[collection.Length - 1] = word;
		}

		/// <summary>
		/// Проверяет, содержит ли коллекция слово <see = cref "word"/>
		/// </summary>
		/// <param name="word">Слово для поиска в коллекции</param>
		/// <returns>true - если слово содержится в коллекции,
		/// false - в противном случае</returns>
		public bool Contains(string word)
		{
			return collection.Contains(word);
		}

		/// <summary>
		/// Удаляет первое слово из коллекции: меняет местами
		/// первый и послдний элемент коллекции и уменьшает размер массива на 1
		/// </summary>
		public void DeleteOneWord()
		{
			Array.Resize(ref collection, collection.Length - 1);
		}
	}
}
