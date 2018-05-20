using AngularjsTraining.DbHelper;
using AngularjsTraining.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AngularjsTraining.Repositories
{
	public class IncidentsRepository : RepositoryBase<Incident>
	{
		/// <summary>
		/// База данных.
		/// </summary>
		private BankDbContext _db;

		public IncidentsRepository(BankDbContext db)
		{
			_db = db;
		}

		public override void Create(Incident entity)
		{
			var incident = entity ?? throw new ArgumentNullException(nameof(entity));
			_db.Incidents.Add(entity);
			_db.SaveChanges();
		}

		public override void Delete(int id)
		{
			var incident = _db.Incidents.Find(id);
			if (incident == null)
			{
				return;
			}
			_db.Incidents.Remove(incident);
			_db.SaveChanges();
		}

		public override Incident Get(int id)
		{
			return _db.Incidents.Find(id);
		}

		public IEnumerable<Incident> Load(int clientId)
		{
			return _db.Incidents.Where(incident => incident.ClientId == clientId).AsEnumerable();
		}

		public override IEnumerable<Incident> Load()
		{
			return _db.Incidents;
		}

		public override void Update(Incident entity)
		{
			var incident = entity ?? throw new ArgumentNullException(nameof(entity));
			var local = _db.Set<Incident>()
						.Local
						.FirstOrDefault(f => f.IncidentId == entity.IncidentId);
			if (local != null)
			{
				_db.Entry(local).State = EntityState.Detached;
			}
			_db.Entry(incident).State = EntityState.Modified;
			_db.SaveChanges();
		}

	}
}