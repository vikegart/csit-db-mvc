using Awards.LogicContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awards.CoreLogic
{
    public class AwardLogic : IAwardsLogic
    {
        public void AddImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void CancelAwardToUser(int idUser, int idAward)
        {
            throw new NotImplementedException();
        }

        public int Create(Award award)
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

        public IEnumerable<Award> GetAll()
        {
            throw new NotImplementedException();
        }

        public Award GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetByIdUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public Award GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetFreeAwards(int idUser)
        {
            throw new NotImplementedException();
        }

        public Image GetImageByAward(int idUser, int newWidth, int maxHeight, bool reduceOnly)
        {
            throw new NotImplementedException();
        }

        public void SetAwardToUser(int idUser, int idAward)
        {
            throw new NotImplementedException();
        }

        public void Update(Award award)
        {
            throw new NotImplementedException();
        }

        public void UpdateImage(int idAward, Image newImage)
        {
            throw new NotImplementedException();
        }
    }
}
