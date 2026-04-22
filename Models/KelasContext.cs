using LKM1_PAA.Helper;
using Npgsql;

namespace LKM1_PAA.Models
{
    public class KelasContext
    {
        private string __constr;
        private string __errormsg = string.Empty;

        public KelasContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<Kelas> Listmurid()
        {
            List<Kelas> list = new List<Kelas>();
            string query = "SELECT * FROM kelas ORDER BY id_kelas";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using NpgsqlCommand cmd = db.GetCommand(query);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(datamurid(reader));
            }
            catch (Exception ex) { __errormsg = ex.Message; }
            finally { db.CloseConnection(); }
            return list;
        }

        public Kelas? getmuridid(int id)
        {
            Kelas? kelas = null;
            string query = "SELECT * FROM kelas WHERE id_kelas = @id";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using NpgsqlCommand cmd = db.GetCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                using NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    kelas = datamurid(reader);
            }
            catch (Exception ex) { __errormsg = ex.Message; }
            finally { db.CloseConnection(); }
            return kelas;
        }

        public bool tambahmurid(Kelas kelas)
        {
            string query = @"INSERT INTO kelas (nama, nis, alamat, created_at, updated_at)
                             VALUES (@nama, @nis, @alamat, NOW(), NOW())";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using NpgsqlCommand cmd = db.GetCommand(query);
                BindParameters(cmd, kelas);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { __errormsg = ex.Message; return false; }
            finally { db.CloseConnection(); }
        }

        public bool updatemurid(int id, Kelas kelas)
        {
            string query = @"UPDATE kelas
                             SET nama = @nama, nis = @nis, alamat = @alamat, updated_at = NOW()
                             WHERE id_kelas = @id";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using NpgsqlCommand cmd = db.GetCommand(query);
                BindParameters(cmd, kelas);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { __errormsg = ex.Message; return false; }
            finally { db.CloseConnection(); }
        }

        public bool hapusmurid(int id)
        {
            string query = "DELETE FROM kelas WHERE id_kelas = @id";
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                using NpgsqlCommand cmd = db.GetCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { __errormsg = ex.Message; return false; }
            finally { db.CloseConnection(); }
        }

        private static Kelas datamurid(NpgsqlDataReader reader)
        {
            return new Kelas()
            {
                id_kelas = Convert.ToInt32(reader["id_kelas"]),
                nama = reader["nama"].ToString()!,
                nis = reader["nis"].ToString()!,
                alamat = reader["alamat"].ToString()!,
                created_at = Convert.ToDateTime(reader["created_at"]),
                updated_at = Convert.ToDateTime(reader["updated_at"]),
            };
        }

        private static void BindParameters(NpgsqlCommand cmd, Kelas kelas)
        {
            cmd.Parameters.AddWithValue("@nama", kelas.nama);
            cmd.Parameters.AddWithValue("@nis", kelas.nis);
            cmd.Parameters.AddWithValue("@alamat", kelas.alamat);
        }

        public string GetErrorMessage() => __errormsg;
    }
}
