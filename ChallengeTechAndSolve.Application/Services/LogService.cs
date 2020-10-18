namespace ChallengeTechAndSolve.Application.Services
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using Serilog;
    using System;
    public class LogService : ILogService
    {
        #region Methods
        public void WriteDebug(string className, string method, decimal elapsedMs)
        {
            Log.Debug($"ClassName --> {className}: Method -> {method}: Miliseconds -> {elapsedMs}");
        }
        public void WriteError(string className, string method, Exception exception)
        {
            Log.Error($"ClassName --> {className}: Method -> {method}, Error{exception.Message}, InnerException{exception.InnerException}, StackTrace {exception.StackTrace}");
        } 
        #endregion
    }
}
