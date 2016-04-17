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
	/// для коллекции <see = cref "ArrayList"/>
	/// </summary>
	class ArrayListWrapper : ICollectionWrapper
	{
		/// <summary>
		/// Инициализация исходной коллекции
		/// </summary>
		ArrayList collection = new ArrayList();

		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		public CollectionType CollectionType
		{
			get
			{
				return CollectionType.ArrayList;
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
			collection.Add(word);
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
		/// Удаляет первое слово из коллекции
		/// </summary>
		public void DeleteOneWord()
		{
			collection.RemoveAt(0);
		}
	}
}
