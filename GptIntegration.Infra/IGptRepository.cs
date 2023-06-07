using GptIntegration.Domain;

namespace GptIntegration.Infra
{
    public interface IGptRepository
    {
        Task<string> GenerateContent(GptEntity request);
    }
}