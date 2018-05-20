using AngularjsTraining.Models;
using AngularjsTraining.Repositories;
using System;
using System.Net;
using System.Web.Mvc;

namespace AngularjsTraining.Controllers
{
	[Route("clients")]
	public class ClientsController : Controller
	{
		private RepositoryBase<Client> _clientRepository;

		public ClientsController(RepositoryBase<Client> clientRepository)
		{
			_clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
		}

		[Route("load")]
		public JsonResult Load()
		{
			return Json(_clientRepository.Load(), JsonRequestBehavior.AllowGet);
		}

		[Route("get{id}")]
		public JsonResult Get(int id)
		{
			return Json(_clientRepository.Get(id), JsonRequestBehavior.AllowGet);
		}


		public HttpStatusCodeResult Create(Client entity)
		{
			_clientRepository.Create(entity);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		public HttpStatusCodeResult Update(Client entity)
		{
			_clientRepository.Update(entity);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		[Route("delete{id}")]
		public HttpStatusCodeResult Delete(int id)
		{
			_clientRepository.Delete(id);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}