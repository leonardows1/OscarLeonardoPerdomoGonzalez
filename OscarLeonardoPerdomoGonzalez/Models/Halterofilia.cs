namespace OscarLeonardoPerdomoGonzalez.Models
{
    public class Halterofilia
    {
        public int HalterofiliaId { get; set; }
        public string Pais { get; set; } = string.Empty;
        public int DeportistaId { get; set; }
        public virtual Deportista Deportista { get; set; } = new();
        public int ArranqueKg { get; set; }
        public int EnvionKg { get; set; }
        public int TotalPeso { get; set; }
    }
}
