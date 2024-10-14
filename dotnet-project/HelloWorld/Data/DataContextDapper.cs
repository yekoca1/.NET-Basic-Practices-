using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        //private IConfiguration _config; Buna gerek kalmadı
        private string _connectionString;
        public DataContextDapper (IConfiguration config)
        {
            //_config = config;
            _connectionString = config.GetConnectionString("DefaultConnection"); // Bağlantı linkini json dosyası aracılığı ile aldık.
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);          //DB ile üstteki stringi kullanarak bağlantı sağlar.
            return dbConnection.Query<T>(sql);
        }

        public T LoadSingleData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);          //DB ile üstteki stringi kullanarak bağlantı sağlar.
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)  //tabloya ekleme yapılıp yapılmadığını gösterir ..!
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);          //DB ile üstteki stringi kullanarak bağlantı sağlar.
            return (dbConnection.Execute(sql) > 0);  //Etkilenen satırlar 0'dan büyük mü değil mi diye gösterir -bool değer olması için-
        }

        public int ExecuteSqlWithRows(string sql)  //tabloya kaç satır ekleme yapıldığını  gösterir ..!
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);          //DB ile üstteki stringi kullanarak bağlantı sağlar.
            return dbConnection.Execute(sql);  //Etkilenen satırlar 0'dan büyük mü değil mi diye gösterir -bool değer olması için-
        }
    }
}















/**
        string connectionString = "server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true";
        IDbConnection dbConnection = new SqlConnection(connectionString);          //DB ile üstteki stringi kullanarak bağlantı sağlar.
        string sqlCommand = "SELECT GETDATE()";                                   // DB bağlantısının tarihinin son tarih olmasını sağlar.



**/