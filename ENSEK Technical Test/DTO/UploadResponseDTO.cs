namespace ENSEK_Technical_Test.DTO
{
    public class UploadResponseDto
    {
        public int TotalUploaded { get; set; }
        public int TotalSaved { get; set; }

        public Dictionary<int, string> Failures { get; set; } = new();
        public int TotalFailed => TotalUploaded - TotalSaved;
    }
}
