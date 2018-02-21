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

        public int Create(User user)
        {
            return new UserData().AddUser(user);
        }

        public void Delete(int id)
        {
            new UserImageData().DeleteUserImage(id);
            new UserData().DeleteUser(id);
        }

        public void Update(User user)
        {
           new UserData().UpdateUser(user);
        }

        public IEnumerable<User> GetAll()
        {
            return new UserData().GetUsers().ToList();
        }

        public User GetByName(string name)
        {
            return new UserData().GetUserByName(name);
        }

        public void AddImage(Image image)
        {
            new UserImageData().AddUserImage(image);
        }

        public Image GetImageByUser(int idUser, int newWidth, int maxHeight, bool reduceOnly)
        {
            Image image = new UserImageData().GetImageByUser(idUser);
            if (image != null)
            {
                image.Byte = ImageWorker.ResizeImage(image.Byte, newWidth, maxHeight, reduceOnly);
                return image;
            }
            return null;
        }

        public void DeleteImage(int idUser)
        {
            new UserImageData().DeleteUserImage(idUser);
        }

        public void UpdateImage(int idUser, Image newImage)
        {
            new UserImageData().Update(idUser, newImage);
        }

        public IEnumerable<User> GetByLetterName(string letterName)
        {
            return new UserData().GetUsersByLetterName(letterName).ToList();
        }

        public IEnumerable<User> GetByPartName(string partName)
        {
            return new UserData().GetUsersByPartName(partName).ToList();
        }

        public User GetById(int id)
        {
            return new UserData().GetUserById(id);
        }
    }
}
