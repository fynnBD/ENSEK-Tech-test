using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ENSEK_Technical_Test.DTO
{
    public class UploadResponseDTO
    {
        public int TotalUploaded { get; set; }
        public int TotalSaved { get; set; }

        public Dictionary<int, string> Failures { get; set; }
        public int TotalFailed => TotalUploaded - TotalSaved;

        public UploadResponseDTO()
        {
            this.Failures = new Dictionary<int, string>();
        }



    }
}
