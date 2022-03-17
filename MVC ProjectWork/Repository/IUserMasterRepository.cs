using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ProjectWork.Repository
{
    public  interface IUserMasterRepository
    {
        IEnumerable<UserMaster> GetAll();
        UserMaster Get(int id);

    }
}
