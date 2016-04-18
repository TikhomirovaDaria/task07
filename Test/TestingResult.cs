using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07
{
	/// <summary>
	///  Хранит результаты тестирования
	/// </summary>
	class TestingResult
	{
		/// <summary>
		/// Время добавления элементов
		/// </summary>
		public Stopwatch AddTime { get; private set; }

		/// <summary>
		/// Время удалния элементов
		/// </summary>
		public Stopwatch DeleteTime { get; private set; }

		/// <summary>
		/// Время поиска элементов
		/// </summary>
		public Stopwatch SearchTime { get; private set; }

		/// <summary>
		/// Тип <see = cref "CollectionType"/> протестированной коллекции
		/// </summary>
		public CollectionType CollectionType { get; private set; }

		/// <summary>
		/// Системный тип протестированной коллекции
		/// </summary>
		public string SystemTypeName { get; private set; }

		/// <summary>
		/// Конструктор по умолчанию
		/// Создает новый элемент данного класса с пользовательскими параметрами
		/// </summary>
		/// <param name="addTime">Время добавления элементов в коллекцию</param>
		/// <param name="deleteTime">Время удаления элементов из коллекции</param>
		/// <param name="searchTime">Время поиска элементов в коллекции</param>
		/// <param name="collectionType"><see = cref "CollectionType"/> протестированной коллекции</param>
		/// <param name="systemTypeName">Системный тип протестированной коллекции</param>
		public TestingResult(Stopwatch addTime, Stopwatch deleteTime, Stopwatch searchTime, CollectionType collectionType, string systemTypeName)
		{
			AddTime = addTime;
			DeleteTime = deleteTime;
			SearchTime = searchTime;
			CollectionType = collectionType;
			SystemTypeName = systemTypeName;
		}

		/// <summary>
		/// Перегруженная функция
		/// Предоставляет данные о результатах теста в виде строки
		/// </summary>
		/// <returns>Строка с результатами тестирования</returns>
		public override string ToString()
		{
			string[] result = {
				string.Format("SystemTypeName: {0}\n\n", SystemTypeName),
				string.Format("Add Time:   \t{0}\t ticks\n", AddTime.ElapsedTicks),
				string.Format("Search Time:\t{0}\t ticks\n", SearchTime.ElapsedTicks),
				string.Format("Delete Time:\t{0}\t ticks\n", DeleteTime.ElapsedTicks)
							  };

			return string.Format("{0}{1}{2}{3}", result[0], result[1], result[2], result[3]);
		}
	}
}
