namespace ArgusEyesApi.Helper
{
    public static class ImageHelper
    {
        public static byte[] ToByteArray(Stream stream)
        {
            using (stream)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }
    }
}
