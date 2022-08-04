namespace ArgusEyesApi.Dtos
{
    public class KundenDatenImagesDto
    {
        public string Content { get; set; }
        public byte[] ContentFile { get; set; } //this has the image
        public string? FileType { get; set; }//the ext type of the image
        public string? FileName { get; set; }//the name of the img
        //public int HelligkeitDto { get; set; }
        //public int KontrastDto { get; set; }
        //public int XDto { get; set; }
        //public int YDto { get; set; }
        //public string? TextDto { get; set; }
        public string NameDto { get; set; }
        public string ImagePathDto { get; set; }
    } 
}
