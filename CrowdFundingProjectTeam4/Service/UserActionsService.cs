using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public class UserActionsService: IUserActionsService
    {
        private readonly CrowdFundingTeam4DBContext dbContext;

        public UserActionsService(CrowdFundingTeam4DBContext adbContext)
        {
            adbContext = dbContext;
        }

        User IUserActionsService.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            User user = dbContext.User.Find(id);
            return user;
            //try { dbContext.SaveChanges(); }  should we save changes here?
            //catch { }
        }

        //this one may be not necessary, there is not is the diagram
        /*
        public List<User> ReadUsers()
        {
            return dbContext.User.ToList();
        }
        */


    }
}
