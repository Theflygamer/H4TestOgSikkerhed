using NuGet.Common;

namespace H4TestOgSikkerhed.Data
{
    public interface IEmailService
    {
        public void SendTwoFactorCode(string code);
    }

    public class EmailToFileService : IEmailService
    {
        public void SendTwoFactorCode(string code)
        {
            // Gem token kode i en tekst fil som test
            File.WriteAllText("token.txt", code);
        }
    }
}
