namespace LKM1_PAA.Models
{
    public class Kelas
    {
        public int id_kelas { get; set; }
        public string nama { get; set; } = string.Empty;
        public string nis { get; set; } = string.Empty;
        public string alamat { get; set; } = string.Empty;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
