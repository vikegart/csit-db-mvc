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
            new AwardImageData().AddAwardImage(image);
        }

        public void CancelAwardToUser(int idUser, int idAward)
        {
            new AwardData().CancelAwardToUser(idUser, idAward);
        }

        public int Create(Award award)
        {
            return new AwardData().AddAward(award);
        }

        public void Delete(int id)
        {
            DeleteImage(id);
            new AwardData().DeleteAward(id);
        }

        public void DeleteImage(int idAward)
        {
            new AwardImageData().DeleteAwardImage(idAward);
        }

        public IEnumerable<Award> GetAll()
        {
            return new AwardData().GetAwards().ToList();
        }

        public Award GetByID(int id)
        {
            return new AwardData().GetAwardById(id);
        }

        public IEnumerable<Award> GetByIdUser(int idUser)
        {
            return new AwardData().GetAwardsByUser(idUser).ToList();
        }

        public IEnumerable<Award> GetByLetterName(string letterName)
        {
            return new AwardData().GetAwardByLetterName(letterName).ToList();
        }

        public Award GetByName(string name)
        {
            return new AwardData().GetAwardByName(name);
        }

        public IEnumerable<Award> GetByPartName(string partName)
        {
            return new AwardData().GetAwardByPartName(partName).ToList();
        }

        public IEnumerable<Award> GetFreeAwards(int idUser)
        {
            return new AwardData().GetFreeAwards(idUser).ToList();
        }

        public Image GetImageByAward(int idAward, int newWidth, int maxHeight, bool reduceOnly)
        {
            Image image = new AwardImageData().GetImageByAward(idAward);
            if (image != null)
            {
                image.Byte = ImageWorker.ResizeImage(image.Byte, newWidth, maxHeight, reduceOnly);
                return image;
            }
            return null;
        }

        public void SetAwardToUser(int idUser, int idAward)
        {
            new AwardData().SetAwardToUser(idUser, idAward);
        }

        public void Update(Award award)
        {
            new AwardData().UpdateAward(award);
        }

        public void UpdateImage(int idAward, Image newImage)
        {
            new AwardImageData().Update(idAward, newImage);
        }
    }
}
