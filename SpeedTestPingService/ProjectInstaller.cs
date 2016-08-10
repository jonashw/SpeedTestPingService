using System.Collections;
using System.ComponentModel;

namespace SpeedTestPingService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            /* This code modifies the ImagePath registry key, which typically contains the 
             * full path to the executable for the Windows Service, by adding the default parameter values.
             * The quotation marks around the path (and around each individual parameter) are required for
             * the service to start up correctly. To change the startup parameters for this Windows Service,
             * users can change the parameters given in the ImagePath registry key, although the better way
             * is to change it programmatically and expose the functionality to users in a friendly way
             * (for example, in a management or configuration utility).  
             * Source: https://msdn.microsoft.com/en-us/library/zt39148a(v=vs.110).aspx 
             */
            const string defaultPingIntervalInMinutes = "20";
            Context.Parameters["assemblypath"] = 
                "\"" + Context.Parameters["assemblypath"] + "\" \"" + defaultPingIntervalInMinutes + "\"";
            base.OnBeforeInstall(savedState);
        }
    }
}