using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularjsTraining.Repositories
{
	/// <summary>
	/// Скелет репозитория.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class RepositoryBase<T> where T : class
	{
		/// <summary>
		/// Получить все записи.
		/// </summary>
		/// <returns></returns>
		public abstract IEnumerable<T> Load();

		/// <summary>
		/// Получить запись по id.
		/// </summary>
		/// <returns></returns>
		public abstract T Get(int id);

		/// <summary>
		/// Создать запись.
		/// </summary>
		/// <returns></returns>
		public abstract void Create(T entity);

		/// <summary>
		/// Обновить запись.
		/// </summary>
		/// <returns></returns>
		public abstract void Update(T entity);

		/// <summary>
		/// Удалить запись.
		/// </summary>
		/// <returns></returns>
		public abstract void Delete(int id);
	}
}