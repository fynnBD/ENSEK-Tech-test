using ENSEK_Technical_Test.DTO;

namespace ENSEK_Technical_Test.Services
{
    public class CsvParseAndSaveService
    {
        private readonly ReadingValidatorService _readingValidatorService;
        private readonly ReadingSaverService _readingSaverService;
        private readonly CsvUploadService _csvUploadService;

        public CsvParseAndSaveService(CsvUploadService csvUploadService, ReadingValidatorService readingValidatorService, ReadingSaverService readingSaverService)
        {
            this._readingValidatorService = readingValidatorService;
            this._readingSaverService = readingSaverService;
            this._csvUploadService = csvUploadService;
        }

        public async Task<UploadResponseDto> CsvParseAndSave(IFormFile file)
        {
            Dictionary<int, string> errorDictionary = new Dictionary<int, string>();

            var results = _csvUploadService.GetReadingsFromCsv(file); //get results from file
            var validResults = _readingValidatorService.ValidateReadings(results, errorDictionary); //validate results
            validResults = _readingSaverService.SaveReadings(validResults, errorDictionary); //save results
            return await PrepareResponse(results.Count, validResults.Count, errorDictionary); //prepare result response
        }

        private async Task<UploadResponseDto> PrepareResponse(int totalReads, int validReads,
            Dictionary<int, string> errorDictionary)
        {
            UploadResponseDto response = new UploadResponseDto();
            response.TotalUploaded = totalReads;
            response.TotalSaved = validReads;

            foreach (var key in errorDictionary.Keys)
            {
                response.Failures.Add(key, errorDictionary[key]);
            }

            return response;
        }
    }
}
