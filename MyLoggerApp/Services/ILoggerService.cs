using MyLoggerApp.Services;

namespace MyLogger
{
    public interface ILoggerService
    {
        void ChooseNewAction();
        void SetHelperService(IHelperService service = null);
        void StartLoggerLogic();
    }
}