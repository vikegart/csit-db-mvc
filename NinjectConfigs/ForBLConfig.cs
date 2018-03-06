using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Ninject;
using IDAL;
using DAL;
using Awards.CoreLogic;
using Awards.LogicContracts;

namespace NinjectConfigs
{
    public class ForBLConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<SQLDALConfig>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DataAccess"].ConnectionString);

            kernel
                .Bind<IAwardData>()
                .To<DAL.AwardDAO>()
                .InSingletonScope();

            kernel
                .Bind<IUserData>()
                .To<DAL.UserDAO>()
                .InSingletonScope();

            kernel
                .Bind<IUserImageData>()
                .To<DAL.UserImageDAO>()
                .InSingletonScope();

            kernel
                .Bind<IAwardImageData>()
                .To<DAL.AwardImageDAO>()
                .InSingletonScope();

            kernel
                .Bind<IAwardsLogic>()
                .To<Awards.CoreLogic.AwardLogic>()
                .InSingletonScope();

            kernel
                .Bind<IUsersLogic>()
                .To<Awards.CoreLogic.UserLogic>()
                .InSingletonScope();
        }
    }
}
