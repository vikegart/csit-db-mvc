using Awards.LogicContracts;
using Entities;
using IDAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awards.CoreLogic
{
    class UserLogic : IUsersLogic
    {
        public byte[] Download()
        {
            List<User> users = new UserData().GetUsers().ToList();
            List<Award> awardsByUser;
            StringBuilder text = new StringBuilder();
            foreach (User user in users)
            {
                text.Append("Пользователь ");
                text.Append(user.Name);
                text.Append(" ");

                awardsByUser = new AwardData().GetAwardsByUser(user.ID).ToList();
                int count = awardsByUser.Count;
                if (count == 0)
                {
                    text.Append("Награды отстутствуют");
                }
                else
                {
                    text.Append(" Награжден: ");
                    for (int i = 0; i < count; i++)
                    {
                        text.Append(awardsByUser[i].Title);
                        if (i != count - 1)
                            text.Append(", ");
                        else
                            text.Append(".");
                    }
                }
                text.AppendLine();
            }
            return Encoding.Unicode.GetBytes(text.ToString());
        }

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
