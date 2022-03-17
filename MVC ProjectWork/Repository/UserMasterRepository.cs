using MVC_ProjectWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ProjectWork.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        private List<UserMaster> users = new List<UserMaster>();
        private int Id = 1;
        public UserMasterRepository()
        {
            // Add products for the Demonstration
            Add(new UserMaster { Name = "User1", EmailID = "user1@test.com", MobileNo = "1234567890" });
            Add(new UserMaster { Name = "User2", EmailID = "user2@test.com", MobileNo = "1234567890" });
            Add(new UserMaster { Name = "User3", EmailID = "user3@test.com", MobileNo = "1234567890" });
        }
        public UserMaster Add(UserMaster item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.ID = Id++;
            users.Add(item);
            return item;
        }


        public UserMaster Get(int id)
        {
            return users.FirstOrDefault(x => x.ID == id);
        }
        public IEnumerable<UserMaster> GetAll()
        {
            return users;
        }


    }
}