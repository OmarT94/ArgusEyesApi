namespace ArgusEyesApi.Entities
{
    public class KundenImagesDaten
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[] Content { get; set; }

        public Metadaten Metadaten { get; set; }
        public int? MetadatenId { get; set; }

        public PunktKoordinaten PunktKoordinaten { get; set; }
        public int? PunktKoordinatenId { get; set; }
    }
}
