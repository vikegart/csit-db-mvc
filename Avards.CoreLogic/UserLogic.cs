using Avards.LogicContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avards.CoreLogic
{
    class UserLogic : IUsersLogic
    {
        private static List<User> users = new List<User>();
        private int maxId = 0;

        public bool Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("Name");
            }


            user.Id = ++maxId; //TODO: make normal data
            user.Name = "Hardcoded Name";
            user.Birthdate = new DateTime();

            var today = DateTime.Today;
            var age = today.Year - user.Birthdate.Year;

            users.Add(user);

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
