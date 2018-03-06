using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUserData
    {
        IEnumerable<User> GetUsers();
        int AddUser(User user);
        User GetUserById(int id);

        void UpdateUser(User user);
        void DeleteUser(int id);

        User GetUserByName(string name);

        IEnumerable<User> GetUsersByLetterName(string letterName);
        IEnumerable<User> GetUsersByPartName(string partName);
    }
}
