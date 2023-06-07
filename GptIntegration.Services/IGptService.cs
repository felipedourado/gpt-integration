using GptIntegration.Domain;

namespace GptIntegration.Services
{
    public interface IGptService
    {
        Task<ConversationResponseModel> ProcessConversation(ConversationRequestModel aDGenerateRequestModel);
    }
}