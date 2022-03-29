using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;


namespace Mapel.Models
{
    public class MapelContext : DbContext
    {
        public MapelContext(DbContextOptions<MapelContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sibaru; Uid = root; Pwd = ");
        }

        public List<MapelItem> GetAllMapel()
        {
            List<MapelItem> list = new List<MapelItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from mapel", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MapelItem()
                        {
                            id = reader.GetInt32("id_mapel"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            deskripsi = reader.GetString("deskripsi")
                        });
                    }
                }
            }
            return list;
        }
        public List<MapelItem> GetMapel(string id)
        {
            List<MapelItem> list = new List<MapelItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mapel WHERE id_mapel = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MapelItem()
                        {
                            id = reader.GetInt32("id_mapel"),
                            nama_mapel = reader.GetString("nama_mapel"),
                            deskripsi = reader.GetString("deskripsi")
                        });
                    }
                }
            }
            return list;
        }
        public MapelItem AddMapel(MapelItem mi)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into mapel (nama_mapel, deskripsi) values (@nama_mapel, @deskripsi)", conn);
                cmd.Parameters.AddWithValue("@nama_mapel", mi.nama_mapel);
                cmd.Parameters.AddWithValue("@deskripsi", mi.deskripsi);
                cmd.ExecuteReader();

            }
            return mi;
        }
    }
}
