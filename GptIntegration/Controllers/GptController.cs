using GptIntegration.Domain;
using GptIntegration.Domain.Exceptions;
using GptIntegration.Services;
using Microsoft.AspNetCore.Mvc;

namespace GptIntegration.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GptController : ControllerBase
    {
        private readonly IGptService _gptService;

        public GptController(IGptService gptService)
        {
            _gptService = gptService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ValidationErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConversationResponseModel>> Conversation(ConversationRequestModel request)
        {
            try
            {
                var response = await _gptService.ProcessConversation(request);

                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
