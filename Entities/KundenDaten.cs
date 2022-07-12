using System.ComponentModel.DataAnnotations;

namespace ArgusEyesApi.Entities
{
    public class KundenDaten
    {
        [Key]
        public int Id { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public int? Alter { get; set; }
        public string? Strasse { get; set; }
        public int? Hausnummer { get; set; }
        public int? Plz { get; set; }
    }
}
