using AngularjsTraining.DbHelper;
using AngularjsTraining.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AngularjsTraining.Repositories
{
	/// <summary>
	/// Репозиторий клиентов.
	/// </summary>
	public class ClientsRepository : RepositoryBase<Client>
	{
		/// <summary>
		/// База данных.
		/// </summary>
		private BankDbContext _db;

		public ClientsRepository(BankDbContext db)
		{
			_db = db;
		}

		public override void Create(Client entity)
		{
			var client = entity ?? throw new ArgumentNullException(nameof(entity));
			_db.Clients.Add(entity);
			_db.SaveChanges();
		}

		public override void Delete(int id)
		{
			var client = _db.Clients.Find(id);
			if (client == null)
			{
				return;
			}
			_db.Clients.Remove(client);
			_db.SaveChanges();
		}

		public override Client Get(int id)
		{
			return _db.Clients.Find(id);
		}

		public override IEnumerable<Client> Load()
		{
			return _db.Clients;
		}

		public override void Update(Client entity)
		{
			var client = entity ?? throw new ArgumentNullException(nameof(entity));
			var local = _db.Set<Client>()
						.Local
						.FirstOrDefault(f => f.ClientId == entity.ClientId);
			if (local != null)
			{
				_db.Entry(local).State = EntityState.Detached;
			}
			_db.Entry(client).State = EntityState.Modified;
			_db.SaveChanges();
		}
	}
}