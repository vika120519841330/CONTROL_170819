using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_170819.Interfaces;
using TEST_170819.Models;

namespace TEST_170819.Filters
{
    public class FilterFixRequestAttribute : FilterAttribute, IActionFilter
    {
        public T GetService<T>(ActionExecutedContext filterContext)
        {
            return (T)DependencyResolver.Current.GetService(typeof(T));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logService = GetService<IRequestRepository>(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                logService.FixLog(new FixRequest()
                {
                    UserId = HttpContext.Current.User.Identity.Name,
                    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    ActionName = filterContext.ActionDescriptor.ActionName,
                    GetDateTime = DateTime.Now,
                    CorrelationId = Guid.NewGuid().ToString()
                
            });
            }
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new HttpNotFoundResult();
        }
    }
}