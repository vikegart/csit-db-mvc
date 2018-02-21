using Avards.CoreLogic;
using Awards.LogicContracts;
using DAL;
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
            ProviderDAL.AwardImageDAO.AddAwardImage(image);
        }

        public void CancelAwardToUser(int idUser, int idAward)
        {
            ProviderDAL.AwardDAO.CancelAwardToUser(idUser, idAward);
        }

        public int Create(Award award)
        {
            return ProviderDAL.AwardDAO.AddAward(award);
        }

        public void Delete(int id)
        {
            DeleteImage(id);
            ProviderDAL.AwardDAO.DeleteAward(id);
        }

        public void DeleteImage(int idAward)
        {
            ProviderDAL.AwardImageDAO.DeleteAwardImage(idAward);
        }

        public IEnumerable<Award> GetAll()
        {
            return ProviderDAL.AwardDAO.GetAwards().ToList();
        }

        public Award GetByID(int id)
        {
            return ProviderDAL.AwardDAO.GetAwardById(id);
        }

        public IEnumerable<Award> GetByIdUser(int idUser)
        {
            return ProviderDAL.AwardDAO.GetAwardsByUser(idUser).ToList();
        }

        public IEnumerable<Award> GetByLetterName(string letterName)
        {
            return ProviderDAL.AwardDAO.GetAwardByLetterName(letterName).ToList();
        }

        public Award GetByName(string name)
        {
            return ProviderDAL.AwardDAO.GetAwardByName(name);
        }

        public IEnumerable<Award> GetByPartName(string partName)
        {
            return ProviderDAL.AwardDAO.GetAwardByPartName(partName).ToList();
        }

        public IEnumerable<Award> GetFreeAwards(int idUser)
        {
            return ProviderDAL.AwardDAO.GetFreeAwards(idUser).ToList();
        }

        public Image GetImageByAward(int idAward, int newWidth, int maxHeight, bool reduceOnly)
        {
            Image image = ProviderDAL.AwardImageDAO.GetImageByAward(idAward);
            if (image != null)
            {
                image.Byte = ImageWorker.ResizeImage(image.Byte, newWidth, maxHeight, reduceOnly);
                return image;
            }
            return null;
        }

        public void SetAwardToUser(int idUser, int idAward)
        {
            ProviderDAL.AwardDAO.SetAwardToUser(idUser, idAward);
        }

        public void Update(Award award)
        {
            ProviderDAL.AwardDAO.UpdateAward(award);
        }

        public void UpdateImage(int idAward, Image newImage)
        {
            ProviderDAL.AwardImageDAO.Update(idAward, newImage);
        }
    }
}
