using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using MyApplication.Data.Entities;
using MyApplication.Repo;

namespace MyApplication.Web.Filters
{
    public class ExceptionHandlerAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private IUnitOfWork _uow;
        public ExceptionHandlerAttribute(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,
                    Type = filterContext.Exception.GetType().Name.ToString(),
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now,
                };

                await _uow.ExceptionLoggerRepository.Add(logger);
                await _uow.Save();
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml"
                };
            }
        }
    }
}
