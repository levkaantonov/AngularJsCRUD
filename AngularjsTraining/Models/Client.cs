namespace AngularjsTraining.Models
{
	/// <summary>
	/// Модель клиента.
	/// </summary>
	public class Client
	{
		/// <summary>
		/// Id клиента.
		/// </summary>
		public int ClientId { get; set; }

		/// <summary>
		/// ФИО.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Номер паспорта.
		/// </summary>
		public string PassportId { get; set; }

		/// <summary>
		/// Почта.
		/// </summary>
		public string Mail { get; set; }

		/// <summary>
		/// Номер телефона.
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Тип клиента.
		/// </summary>
		public int Type { get; set; }
	}
}