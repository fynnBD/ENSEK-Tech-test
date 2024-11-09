using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.DTO;
using ENSEK_Technical_Test.Services.Repository;

namespace ENSEK_Technical_Test.Services
{
    public class CsvParseAndSaveService
    {
        private readonly ReadingValidatorService readingValidatorService;
        private readonly ReadingRepository readingRepository;
        private readonly CSVUploadService csvUploadService;

        public CsvParseAndSaveService(CSVUploadService csvUploadService, ReadingValidatorService readingValidatorService, ReadingRepository readingRepository)
        {
            this.readingValidatorService = readingValidatorService;
            readingRepository = readingRepository;
            this.csvUploadService = csvUploadService;
        }

        public UploadResponseDTO CsvParseAndSave(IFormFile file)
        {
            Dictionary<int, string> errorDictionary = new Dictionary<int, string>();
            var results = csvUploadService.GetReadingsFromCSV(file);
            var validResults = readingValidatorService.ValidateReadings(results, errorDictionary);
            var validResults = readingRepository.SaveAll()
            return prepareResponse(results.Count, validResults.Count, errorDictionary);
        }

        private UploadResponseDTO prepareResponse(int totalReads, int validReads,
            Dictionary<int, string> errorDictionary)
        {
            UploadResponseDTO response = new UploadResponseDTO();
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
