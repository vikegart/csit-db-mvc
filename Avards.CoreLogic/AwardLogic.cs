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
        private static List<Award> avards = new List<Award>();
        private int maxId = 0;

        public bool Add(Award avard)
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

            avard.ID = ++maxId;
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

        public IEnumerable<Award> GetAll()
        {
            return avards.Select(a => a);
        }

        public Award GetById(int id)
        {
            return avards.SingleOrDefault(a => a.ID == id);
        }
    }
}
