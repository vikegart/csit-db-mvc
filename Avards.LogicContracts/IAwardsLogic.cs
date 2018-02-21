using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awards.LogicContracts
{
    public interface IAwardsLogic
    {
        IEnumerable<Award> GetAll();

        Award GetByID(int id);
        #region name
        Award GetByName(string name);
        IEnumerable<Award> GetByIdUser(int idUser);
        IEnumerable<Award> GetFreeAwards(int idUser);
        #endregion
        int Create(Award award);
        void Delete(int id);
        void Update(Award award);

        void SetAwardToUser(int idUser, int idAward);
        void CancelAwardToUser(int idUser, int idAward);

        void AddImage(Image image);
        Image GetImageByAward(int idUser, int newWidth, int maxHeight, bool reduceOnly);
        void DeleteImage(int idUser);
        void UpdateImage(int idAward, Image newImage);
    }
}
