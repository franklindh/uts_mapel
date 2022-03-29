namespace Mapel.Models
{
    public class MapelItem
    {
        private MapelContext _context;
        public int id { get; set; }
        public string nama_mapel { get; set; }
        public string deskripsi { get; set; }
    }
}
