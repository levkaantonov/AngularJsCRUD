using AngularjsTraining.Models;
using AngularjsTraining.Repositories;
using System;
using System.Net;
using System.Web.Mvc;

namespace AngularjsTraining.Controllers
{
	[Route("incidents")]
	public class IncidentsController : Controller
    {
		private RepositoryBase<Incident> _incidentsRepository;

		public IncidentsController(RepositoryBase<Incident> incidentsRepository)
		{
			_incidentsRepository = incidentsRepository ?? throw new ArgumentNullException(nameof(incidentsRepository));
		}

		[Route("load{id}")]
		public JsonResult Load(int id)
		{
			return Json((_incidentsRepository as IncidentsRepository).Load(id), JsonRequestBehavior.AllowGet);
		}

		[Route("get{id}")]
		public JsonResult Get(int id)
		{
			return Json(_incidentsRepository.Get(id), JsonRequestBehavior.AllowGet);
		}


		public HttpStatusCodeResult Create(Incident entity)
		{
			_incidentsRepository.Create(entity);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		public HttpStatusCodeResult Update(Incident entity)
		{
			_incidentsRepository.Update(entity);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		[Route("delete{id}")]
		public HttpStatusCodeResult Delete(int id)
		{
			_incidentsRepository.Delete(id);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}