﻿using Common.Utility;
using SQLAdmin.Dao;
using SQLServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Dao
{
    public class SQLServerDynamicRepertory : IDynamicRepertory
    {
        private string mDatabaseName = String.Empty;
        private string mTableName = String.Empty;

        protected SQLServerDBContext DBContext
        {
            get
            {
                return SQLServerDBContextScope.GetDBContext() as SQLServerDBContext;
            }
        }

        public SQLServerDynamicRepertory Use(string databaseName)
        {
            this.mDatabaseName = databaseName;
            return this;
        }

        public SQLServerDynamicRepertory DbSet(string tableName)
        {
            this.mTableName = tableName;
            return this;
        }

        public dynamic Add(dynamic t, bool isSaveChange = false)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> AddRange(IEnumerable<dynamic> dynamicObjects, bool isSaveChange = false)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> All(string where)
        {
            throw new NotImplementedException();
        }

        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string where)
        {
            throw new NotImplementedException();
        }

        public int Count(string where)
        {
            string sql = new SQLQuery().Select("count(*)")
                                      .From(this.mTableName)
                                      .Where(where)
                                      .Qenerate();
            return Convert.ToInt32(this.DBContext.SqlScaler(sql));
        }

        public bool Delete(string where, bool isSaveChange = false)
        {
            string sql = new SQLQuery().Delete(this.mTableName)
                                         .Where(where)
                                         .Qenerate();
            return this.DBContext.AccessQuery(sql) > 0;
        }

        public bool Delete(dynamic t, bool isSaveChange = false)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(IEnumerable<dynamic> dynamicObjects, bool isSaveChange = false)
        {
            throw new NotImplementedException();
        }

        public bool Exist(dynamic model)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> Filter(string where)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> Filter(string where, string orderBy)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> Filter(string where, string orderBy, out int total, int index = 0, int size = 50, bool isAsc = true)
        {
            string sql = new SQLQuery().Select("*")
                                       .From(this.mTableName)
                                       .Where(where)
                                       .OrderBy(orderBy)
                                       .Skip((index - 1) * size)
                                       .Take(size)
                                       .Qenerate();
            total = this.Count(where);
            return this.DBContext.SqlReader(sql).ToList();
        }

        public List<dynamic> Filter(string selected, string where, string orderBy, out int total, int index = 0, int size = 50, bool isAsc = true)
        {
            string sql = new SQLQuery().Select(selected)
                                       .From(this.mTableName)
                                       .Where(where)
                                       .OrderBy(orderBy, isAsc)
                                       .Skip((index - 1) * size)
                                       .Take(size)
                                       .Qenerate();
            total = this.Count(where);
            return this.DBContext.SqlReader(sql).ToList();
        }

        public List<dynamic> FilterSimple(string where)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> FilterWithNodynamicracking(string where)
        {
            throw new NotImplementedException();
        }

        public dynamic Find(string where)
        {
            throw new NotImplementedException();
        }

        public dynamic Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public dynamic Single(string where)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> SQLQuery(string sql)
        {
            return this.DBContext.SqlReader(sql).ToList();
        }

        public bool Update(dynamic t, string key = "ID", bool isSaveChange = false)
        {
            var field = (t as object).ToDictionary();
            var indexValue = field[key];
            field.Remove(key);
            string sql = new SQLQuery().Update(this.mTableName)
                          .Set(field)
                          .Where($"{key}='{indexValue}'")
                          .Qenerate();
            return this.DBContext.AccessQuery(sql) > 0;
        }

        public bool UpdateRange(IEnumerable<dynamic> dynamicObjects, string key = "ID", bool isSaveChange = false)
        {
            throw new NotImplementedException();
        }
    }
}
