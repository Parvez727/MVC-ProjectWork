using MVC_ProjectWork.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjectWork.Controllers
{
    public class Chapter8Controller : Controller
    {
        readonly IUserMasterRepository userRepository;
        public Chapter8Controller()
        {

        }
        public Chapter8Controller(IUserMasterRepository repository)
        {
            this.userRepository = repository;
        }
        public ActionResult User_Index()
        {
            var data = userRepository.GetAll();
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var data = userRepository.Get(id);
            return View(data);
        }

        // GET: Chapter8
        public ActionResult Index()
        {
            return View();
        }
    }
}