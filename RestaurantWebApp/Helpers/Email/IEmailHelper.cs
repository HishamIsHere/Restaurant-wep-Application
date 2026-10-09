using WebAppTemplate.ViewModels;

namespace WebAppTemplate.Helpers.Email
{
    public interface IEmailHelper
    {
        void SendMessage(EmailViewModel model);
    }
}
