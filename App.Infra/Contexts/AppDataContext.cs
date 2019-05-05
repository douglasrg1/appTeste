using App.Domain.Entities;
using System;

namespace App.Infra.Context
{
    public class AppDataContext : IDisposable
    {
        //public SqlConnection Connection { get; set; }
        public AppDataContext()
        {
            //Connection = new SqlConnection(ConnectionSettings.ConnectionString);
            //Connection.Open();
        }

        public void Dispose()
        {
            //if (Connection.State != ConnectionState.Closed)
            //    Connection.Close();
        }
    }
}