using Npgsql;
namespace LKM1_PAA.Helper
{
    public class SqlDBHelper
    {
        private NpgsqlConnection _connection;
        private string _constr;

        public SqlDBHelper(string pConstr)
        {
            _constr = pConstr;
            _connection = new NpgsqlConnection();
            _connection.ConnectionString = _constr;
        }

        public NpgsqlCommand GetCommand(string query)
        {
            _connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;
            return cmd;
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
