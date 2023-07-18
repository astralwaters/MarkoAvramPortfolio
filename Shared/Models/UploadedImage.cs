namespace Shared.Models
{
	public class UploadedImage
	{
        public string NewImageFileExtension { get; set; }
        //base64  string represents binary
        public string NewImageBase64Content { get; set; }
        public string OldImagePath { get; set; }
    }
}
