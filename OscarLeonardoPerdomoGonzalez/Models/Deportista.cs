namespace OscarLeonardoPerdomoGonzalez.Models
{
    public class Deportista
    {
        public int DeportistaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public virtual ICollection<Halterofilia> Halterofilias { get; set; } = new List<Halterofilia>();
    }
}
