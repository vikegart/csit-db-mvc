using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awards.LogicContracts
{
    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByName(string name);

        IEnumerable<User> GetByLetterName(string letterName);
        IEnumerable<User> GetByPartName(string partName);

        int Create(User user);
        void Delete(int id);
        void Update(User user);

        void AddImage(Image image);
        Image GetImageByUser(int idUser, int newWidth, int maxHeight, bool reduceOnly);
        void DeleteImage(int idUser);
        void UpdateImage(int idUser, Image newImage);
        byte[] Download();
    }
}
