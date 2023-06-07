using GptIntegration.Domain;
using GptIntegration.Domain.Exceptions;
using GptIntegration.Infra;
using Microsoft.AspNetCore.Http;

namespace GptIntegration.Services
{
    public class GptService : IGptService
    {
        private readonly IGptRepository _gptRepository;

        public GptService(IGptRepository gptRepository)
        {
            _gptRepository = gptRepository;
        }

        public async Task<ConversationResponseModel> ProcessConversation(ConversationRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Message))
                throw new HttpReturnException(StatusCodes.Status400BadRequest, ValidationErrorModel.MountErrorList("Texto inválido!"));

            var result = await _gptRepository.GenerateContent(new GptEntity { Prompt = request.Message });

            return new ConversationResponseModel
            {
                Success = true,
                AnswerContent = result,
            };
        }
    }
}
