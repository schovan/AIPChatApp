using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Google.GenAI;
using Google.GenAI.Types;
using System.Collections.ObjectModel;
using AIPChatApp.Services;

namespace AIPChatApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private const string ModelName = "gemini-2.5-flash";

        private readonly Client _client;
        private readonly GenerateContentConfig _config;
  
        [ObservableProperty]
        private ObservableCollection<MessageViewModel> _messages = new ObservableCollection<MessageViewModel>();

        [ObservableProperty]
        private string _userInput;

        [ObservableProperty]
        private bool _isLoading;

        public MainViewModel(IApiKeyService apiKeyService)
        {
            var apiKey = apiKeyService.GetKey();
            _client = new Client(apiKey:apiKey);
            _config = new GenerateContentConfig
            {
                ThinkingConfig = new ThinkingConfig
                {
                    IncludeThoughts = true
                }
            };
            Write("Hello! I am your AI assistant. How can I help you today?");
        }

        [RelayCommand]
        private async Task SendMessageAsync()
        {
            if (string.IsNullOrWhiteSpace(UserInput) || IsLoading)
            {
                return;
            }

            var prompt = UserInput;
            Messages.Add(new MessageViewModel { Content = prompt, IsUser = true });
            UserInput = string.Empty;
            IsLoading = true;

            try
            {
                var stream = _client.Models.GenerateContentStreamAsync(model: ModelName, contents: prompt, config: _config);

                MessageViewModel thinkingMessage = CreateAndWrite("=== [THINKING PROCESS] ===");
                MessageViewModel finalMessage = null;

                await foreach (var response in stream)
                {
                    if (response.Candidates != null && response.Candidates.Count > 0)
                    {
                        foreach (var part in response.Candidates[0].Content.Parts)
                        {
                            if (part.Thought == true)
                            {
                                Append(thinkingMessage, part.Text);
                            }
                            else if (!string.IsNullOrEmpty(part.Text))
                            {
                                finalMessage ??= CreateAndWrite("=== [FINAL RESPONSE] ===");
                                Append(finalMessage, part.Text);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Write($"Error:\n\n{ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private MessageViewModel CreateAndWrite(string content)
        {
            var message = new MessageViewModel { Content = $"{content}\n\n", IsUser = false };
            Messages.Add(message);
            return message;
        }

        private void Write(string content)
        {
            Messages.Add(new MessageViewModel { Content = content, IsUser = false });
        }

        private void Append(MessageViewModel message, string content)
        {
            message.Content += content;
        }
    }
}
