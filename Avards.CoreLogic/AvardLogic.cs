using Avards.LogicContracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avards.CoreLogic
{
    public class AvardLogic : IAvardsLogic
    {
        private static List<Avard> avards = new List<Avard>();
        private int maxId = 0;

        public bool Add(Avard avard)
        {
            if (avard == null)
            {
                throw new ArgumentNullException(nameof(avard));
            }

            if (string.IsNullOrWhiteSpace(avard.Description))
            {
                throw new ArgumentException("Description");
            }

            if (string.IsNullOrWhiteSpace(avard.Title))
            {
                throw new ArgumentException("Title");
            }

            avard.Id = ++maxId;
            avard.Title = "Hardcoded Test";
            avard.Description = "Hardcoded Description gg";
            avards.Add(avard);

            return true;
        }

        public bool Delete(int id)
        {
            var avard = this.GetById(id);

            if (avard != null)
            {
                avards.Remove(avard);
                return true;
            }

            return false;
        }

        public IEnumerable<Avard> GetAll()
        {
            return avards.Select(a => a);
        }

        public Avard GetById(int id)
        {
            return avards.SingleOrDefault(a => a.Id == id);
        }
    }
}
