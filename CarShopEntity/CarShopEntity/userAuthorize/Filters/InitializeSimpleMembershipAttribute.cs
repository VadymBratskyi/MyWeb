using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using userAuthorize.Models;
using WebMatrix.WebData;

namespace userAuthorize.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized; 

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //происходит один раз при старте приложения
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                //отключаем миграцию
                Database.SetInitializer<UserContext>(null);
                try
                {
                    using (var context = new UserContext())
                    {
                        if (!context.Database.Exists())
                        {
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    WebSecurity.InitializeDatabaseConnection("AccountConnection", "System.Data.SqlClient","UserProfile","UserId","UserName",true);
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
            }
        }
    }
}