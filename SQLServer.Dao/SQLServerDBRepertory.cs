﻿using SQLAdmin.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLAdmin.Domain;
using System.Data.SqlClient;
using System.Data;

namespace SQLServer.Dao
{
    public class SQLServerDBRepertory : IRepertory
    {
        protected SQLServerDBContext DBContext
        {
            get
            {
                return SQLServerDBContextScope.DBContext as SQLServerDBContext;
            }
        }

        public bool Connect()
        {
            using (var conn = this.DBContext.GetConnect())
            {
                return conn != null;
            }
        }

        public List<Database> GetDatabases()
        {
            string sql = "SELECT * FROM Master..SysDatabases ORDER BY crdate";
            var dataTable = this.DBContext.SqlReader(sql);
            List<Database> databases = new List<Database>();
            foreach(DataRow row in dataTable.Rows)
            {
                Database database = new Database()
                {
                    Id = Guid.NewGuid(), //row["dbid"].ToString(),
                    Name = row["name"].ToString()
                };
                databases.Add(database);
            }
            return databases;
        }

        public List<Table> GetTables(string dbName)
        {
            string sql = $"SELECT * FROM {dbName}..SysObjects Where XType='U' ORDER BY Name";
            var dataTable = this.DBContext.SqlReader(sql);
            List<Table> tables = new List<Table>();
            foreach(DataRow row in dataTable.Rows)
            {
                Table table = new Table()
                {
                    Id = row["id"].ToString(),
                    Name = row["name"].ToString(),
                };
                tables.Add(table);
            }
            return tables;
        }
    }
}
