using System.Text;

namespace RFSourceControllerApp.Model.Util
{
    class SettingsUtils
    {
        public static Encoding GetEncoding()
        {
            int codePage = Properties.Settings.Default.Encoding;
            if(codePage == 0)
            {
                return Encoding.Default;
            }

            return Encoding.GetEncoding(codePage);
        }

    }
}
