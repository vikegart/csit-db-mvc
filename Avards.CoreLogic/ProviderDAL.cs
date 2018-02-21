using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avards.CoreLogic
{
    class ProviderDAL
    {
        public static IUserData UserDAO { get; }
        public static IAwardData AwardDAO { get; }
        public static IUserImageData UserImageDAO { get; }
        public static IAwardImageData AwardImageDAO { get; }
        static ProviderDAL()
        {
            UserDAO = new UserDAO();
            AwardDAO = new AwardDAO();
            UserImageDAO = new UserImageDAO();
            AwardImageDAO = new AwardImageDAO();
        }
    }
}
