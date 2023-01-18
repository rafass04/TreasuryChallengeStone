using System.Collections.Generic;

namespace TreasuryChallenge.src.Services
{
    public interface IGenerateCodesService
    {
        List<string> GenerateCodes(int numberOfLines);
    }
}