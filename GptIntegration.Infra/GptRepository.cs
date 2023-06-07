using GptIntegration.Domain;
using Microsoft.Extensions.Configuration;
using OpenAI_API;

namespace GptIntegration.Infra
{
    public class GptRepository : IGptRepository
    {
        private readonly IConfiguration _configuration;

        public GptRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateContent(GptEntity request)
        {
            var apiKey = _configuration.GetSection("OpenAiSettings:GChatAPIKEY").Value;
            //  var apiModel = _configuration.GetSection("OpenAiSettings:Model").Value;

            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            try
            {
                var r = api.Chat.CreateConversation();
                r.AppendUserInput(request.Prompt);
                var result = await r.GetResponseFromChatbotAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
