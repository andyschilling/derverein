using System.Windows;
using DerVerein.Common;

namespace DerVerein
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}
