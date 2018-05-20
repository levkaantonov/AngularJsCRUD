using System;

namespace AngularjsTraining.Models
{
	/// <summary>
	/// Обращение.
	/// </summary>
	public class Incident
	{
		/// <summary>
		/// Id обращения.
		/// </summary>
		public int IncidentId { get; set; }

		/// <summary>
		/// Ид клиента.
		/// </summary>
		public int ClientId { get; set; }

		/// <summary>
		/// Тема.
		/// </summary>
		public string Theme { get; set; }

		/// <summary>
		/// Содержание.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Дата.
		/// </summary>
		public DateTime Date { get; set; }
	}
}