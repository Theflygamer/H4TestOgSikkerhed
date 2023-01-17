using NuGet.Common;

namespace H4TestOgSikkerhed.Data
{
    public static class MyEmailService
    {
        public static void SendTwoFactorCode(string code)
        {
            // Gem token kode i en tekst fil som test
            File.WriteAllText("token.txt", code);
        }
    }
}
