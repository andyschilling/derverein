using Microsoft.Practices.Unity;

namespace DerVerein.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel(IUnityContainer container) 
            : base(container)
        {
        }
    }
}