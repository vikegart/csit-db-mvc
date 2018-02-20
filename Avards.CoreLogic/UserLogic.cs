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
        public void AddImage(Image image)
        {
            throw new NotImplementedException();
        }

        public int Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteImage(int idUser)
        {
            throw new NotImplementedException();
        }

        public byte[] Download()
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

        public IEnumerable<User> GetByLetterName(string letterName)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByPartName(string partName)
        {
            throw new NotImplementedException();
        }

        public Image GetImageByUser(int idUser, int newWidth, int maxHeight, bool reduceOnly)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateImage(int idUser, Image newImage)
        {
            throw new NotImplementedException();
        }
    }
}
