using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAwardData
    {
        IEnumerable<Award> GetAwards();
        int AddAward(Award award);
        Award GetAwardById(int id);
        IEnumerable<Award> GetAwardsByUser(int idUser);
        void SetAwardToUser(int idUser, int idAward);
        IEnumerable<Award> GetFreeAwards(int idUser);
        void CancelAwardToUser(int idUser, int idAward);

        void DeleteAward(int id);
        void UpdateAward(Award award);

        Award GetAwardByName(string name);

        IEnumerable<Award> GetAwardByLetterName(string letterName);
        IEnumerable<Award> GetAwardByPartName(string partName);
    }
}
