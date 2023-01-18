using System.Runtime.InteropServices;

namespace H4TestOgSikkerhed.Data
{
    public class MyResourceHandler
    {
        public bool TryCreateFile(string path, string filename, out string error)
        {
            char sep = Path.DirectorySeparatorChar;
            string sysPath;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                sysPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            else
            {
                sysPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            sysPath = Path.Combine(sysPath, "H4TestOgSikkerhed");
            path = Path.Combine(sysPath, path);

            try
            {
                Directory.CreateDirectory(sysPath);
                Directory.CreateDirectory(path);
                FileStream file = File.Create($"{path}{sep}{filename}");
                file.Close();
                File.WriteAllText($"{path}{sep}{filename}", "File created by Blazor Server");
                error = "";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

            return true;
        }
    }
}
