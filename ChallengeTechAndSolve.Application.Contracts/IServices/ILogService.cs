namespace ChallengeTechAndSolve.Application.Contracts.IServices
{
    using System;
    public interface ILogService
    {
        void WriteDebug(string className, string method, decimal elapsedMs);
        void WriteError(string className, string method, Exception errorMessage);
    }
}
