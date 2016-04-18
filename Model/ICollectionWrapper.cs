using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	/// Описывает базовые свойства и методы тестируемых коллекций
	/// </summary>
	interface ICollectionWrapper
	{
		/// <summary>
		/// Возвращает <see = cref "CollectionType"/> коллекции
		/// </summary>
		CollectionType CollectionType { get; }

		/// <summary>
		/// Возвращает полное название типа коллекции, определенное в системе
		/// </summary>
		string SystemTypeName { get; }

		/// <summary>
		/// Возвращает число элементов в коллекции
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Добавляет слово <see = cref "word"/> в коллекцию
		/// </summary>
		/// <param name="word">Добавляемое слово</param>
		void Add(string word);

		/// <summary>
		/// Удаляет одно слово из коллекции
		/// </summary>
		void DeleteOneWord();

		/// <summary>
		/// Проверяет, содержит ли коллекция слово <see = cref "word"/>
		/// </summary>
		/// <param name="word">Слово для поиска в коллекции</param>
		/// <returns>true - если слово содержится в коллекции,
		/// false - в противном случае</returns>
		bool Contains(string word);
	}
}
