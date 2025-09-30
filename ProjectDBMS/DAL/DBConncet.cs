using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectDBMS.DAL
{
    public class DBConnect
    {
        private static string _username;
        private static string _password;
        private static string _server = "localhost";      // tên server
        private static string _database = "GiaoVienNhanVien";  // tên database

        private static string _connectionString;     // chuỗi kết nối

        // ✅ Gọi khi login thành công
        public static void Initialize(string username, string password)
        {
            _username = username;
            _password = password;

            _connectionString = $@"
                Server={_server},1433;
                Database={_database};
                User Id={_username};
                Password={_password};
                Encrypt=false;
                TrustServerCertificate=true;
                MultipleActiveResultSets=true;
                Connection Timeout=30;";
        }

        // ✅ Lấy DataTable từ query (view hoặc function)
        public DataTable GetData(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ✅ Thực thi Stored Procedure trả về DataTable
        public DataTable ExecuteProc(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ✅ Thực thi Stored Procedure không trả về dữ liệu (INSERT/UPDATE/DELETE)
        public int ExecuteNonQuery(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // ✅ Thực thi Stored Procedure trả về 1 giá trị duy nhất (ví dụ SCOPE_IDENTITY)
        public object ExecuteScalar(string procName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
