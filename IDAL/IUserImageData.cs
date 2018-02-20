using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUserImageData
    {
        Image GetImageByUser(int idUser);

        void AddUserImage(Image image);

        void DeleteUserImage(int idAward);

        void Update(int idUser, Image newImage);
    }
}
