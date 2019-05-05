using App.Shared;
using Npgsql;
using System;
using System.Data;

namespace App.Infra.Context
{
    public class AppDataContext : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }
        public AppDataContext()
        {
            Connection = new NpgsqlConnection(ConnectionSettings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}