using System.IO;
using OpenAIChat.Views;

namespace OpenAIChat.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IDialogService _dialogService;
        private readonly string _keyFilePath;

        public ApiKeyService(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _keyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.txt");
        }

        public string GetKey()
        {
            if (!File.Exists(_keyFilePath))
            {
                var key = _dialogService.ShowDialog<ApiKeyView, string>();
                File.WriteAllText(_keyFilePath, key);
                return key;
            }
            return File.ReadAllText(_keyFilePath);
        }
    }
}
