using Awards.LogicContracts;
using Entities;
using IDAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avards.CoreLogic;

namespace Awards.CoreLogic
{
    public class UserLogic : IUsersLogic
    {
        public byte[] Download()
        {
            List<User> users = ProviderDAL.UserDAO.GetUsers().ToList();
            List<Award> awardsByUser;
            StringBuilder text = new StringBuilder();
            foreach (User user in users)
            {
                text.Append("Пользователь ");
                text.Append(user.Name);
                text.Append(" ");
                int age = Helpers.AgeCounter.GetAgeByBirthdate(user.Birthdate); //TODO: совпадают ли типы?
                text.Append(age);
                text.Append(" ");

                awardsByUser = new AwardDAO().GetAwardsByUser(user.ID).ToList();
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

        public int Create(User user)
        {
            return ProviderDAL.UserDAO.AddUser(user);
        }

        public void Delete(int id)
        {
            ProviderDAL.UserImageDAO.DeleteUserImage(id);
            ProviderDAL.UserDAO.DeleteUser(id);
        }

        public void Update(User user)
        {
            ProviderDAL.UserDAO.UpdateUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            return ProviderDAL.UserDAO.GetUsers().ToList();
        }

        public User GetByName(string name)
        {
            return ProviderDAL.UserDAO.GetUserByName(name);
        }

        public void AddImage(Image image)
        {
            ProviderDAL.UserImageDAO.AddUserImage(image);
        }

        public Image GetImageByUser(int idUser, int newWidth, int maxHeight, bool reduceOnly)
        {
            Image image = new UserImageDAO().GetImageByUser(idUser);
            if (image != null)
            {
                image.Byte = ImageWorker.ResizeImage(image.Byte, newWidth, maxHeight, reduceOnly);
                return image;
            }
            return null;
        }

        public void DeleteImage(int idUser)
        {
            ProviderDAL.UserImageDAO.DeleteUserImage(idUser);
        }

        public void UpdateImage(int idUser, Image newImage)
        {
            ProviderDAL.UserImageDAO.Update(idUser, newImage);
        }

        public IEnumerable<User> GetByLetterName(string letterName)
        {
            return ProviderDAL.UserDAO.GetUsersByLetterName(letterName).ToList();
        }

        public IEnumerable<User> GetByPartName(string partName)
        {
            return ProviderDAL.UserDAO.GetUsersByPartName(partName).ToList();
        }

        public User GetById(int id)
        {
            return ProviderDAL.UserDAO.GetUserById(id);
        }
    }
}
