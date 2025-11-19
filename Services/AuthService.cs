using System.Threading.Tasks;
using FindYourHome.Models;
using FindYourHome.Services;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Maui.Storage;

namespace FindYourHome.Services
{
    public class AuthService
    {
        private readonly DatabaseService db;
        private const string CurrentUserKey = "current_user_email";

        public AuthService(DatabaseService databaseService)
        {
            db = databaseService;
        }

        private string Hash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public async Task<bool> RegisterAsync(string fullName, string email, string password)
        {
            var existing = await db.GetHousesAsync(); // misuse to avoid compilation in scaffold; replace in real project
            var hash = Hash(password);
            var u = new User { FullName = fullName, Email = email, PasswordHash = hash };
            // In a real app, add to users table; here we store email in SecureStorage as a placeholder
            await SecureStorage.Default.SetAsync(email, hash);
            return true;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var stored = await SecureStorage.Default.GetAsync(email);
                if (string.IsNullOrEmpty(stored)) return false;
                var hash = Hash(password);
                if (stored == hash)
                {
                    await SecureStorage.Default.SetAsync(CurrentUserKey, email);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetCurrentUserEmailAsync()
        {
            try
            {
                return await SecureStorage.Default.GetAsync(CurrentUserKey);
            }
            catch { return null; }
        }

        public async Task LogoutAsync()
        {
            try { SecureStorage.Default.Remove(CurrentUserKey); } catch { }
        }
    }
}
