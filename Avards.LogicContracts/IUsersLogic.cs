using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avards.LogicContracts
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        bool Add(User user);

        bool Delete(int id);
    }
}
