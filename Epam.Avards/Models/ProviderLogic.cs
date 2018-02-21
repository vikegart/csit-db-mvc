using Awards.CoreLogic;
using Awards.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Awards.Models
{
    public class ProviderLogic
    {
        static ProviderLogic()
        {
            UserLogic = new UserLogic();
            AwardLogic = new AwardLogic();
        }
        public static IUsersLogic UserLogic { get; }

        public static IAwardsLogic AwardLogic { get; }

    }
}