using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avards.LogicContracts
{
    public interface IAvardsLogic
    {
        IEnumerable<Award> GetAll();

        Award GetById(int id);

        bool Add(Award avard);

        bool Delete(int id);
    }
}
