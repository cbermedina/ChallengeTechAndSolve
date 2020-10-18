namespace ChallengeTechAndSolve.CrossCutting.Filters
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using ChallengeTechAndSolve.Common.Clasess;
    using Microsoft.AspNetCore.Mvc.Filters;
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        #region Properties
        private readonly ILogService _serviceLog; 
        #endregion

        #region Constructor
        public HandleExceptionAttribute(ILogService serviceLog)
        {
            _serviceLog = serviceLog;
        } 
        #endregion

        #region Methods
        /// <summary>
        /// On Exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var lastException = context.Exception.GetBaseException();

            var isException = lastException as NotificationException;
            _serviceLog.WriteError(isException.ClassName, isException.Method, isException.Exception);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 500;
            base.OnException(context);
        }

        #endregion
    }
}
