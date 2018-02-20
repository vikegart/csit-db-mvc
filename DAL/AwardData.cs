using Entities;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class AwardData : IAwardData
    {
        public int AddAward(Award award)
        {
            throw new NotImplementedException();
        }

        public void CancelAwardToUser(int idUser, int idAward)
        {
            throw new NotImplementedException();
        }

        public void DeleteAward(int id)
        {
            throw new NotImplementedException();
        }

        public Award GetAwardById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByLetterName(string letterName)
        {
            throw new NotImplementedException();
        }

        public Award GetAwardByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByPartName(string partName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwards()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardsByUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetFreeAwards(int idUser)
        {
            throw new NotImplementedException();
        }

        public void SetAwardToUser(int idUser, int idAward)
        {
            throw new NotImplementedException();
        }

        public void UpdateAward(Award award)
        {
            throw new NotImplementedException();
        }
    }
}
