using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthenticatorProject {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Managing several independent forms.
            // Setting the number to 1, as we launch the initial form.
            Utilities.FormsCount = 1;
            FrmAuthenticator auth = new FrmAuthenticator(args);
            auth.Show();
            Application.Run();
        }
    }
}
