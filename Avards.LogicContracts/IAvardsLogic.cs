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
        IEnumerable<Avard> GetAll();

        Avard GetById(int id);

        bool Add(Avard avard);

        bool Delete(int id);
    }
}
