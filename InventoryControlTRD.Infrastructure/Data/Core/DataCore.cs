﻿using Dapper;
using InventoryControlTRD.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Core
{
    public class DataCore<T> : IDataCore<T> where T : class
    {
        public async Task ExecuteAsync(string query)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query);
            }
        }
        public async Task ExecuteAsync(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query,obj);
            }
        }

        public async Task ExecuteMultipleAsync(string query, IEnumerable<object> objList)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                await conn.ExecuteAsync(query, objList);
            }
        }
        public void Execute(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                conn.Execute(query, obj);
            }
        }
        public async Task<IEnumerable<T>> QueryAsync(string query)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return await conn.QueryAsync<T>(query);
            }
        }
        public async Task<IEnumerable<T>> QueryAsync(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return await conn.QueryAsync<T>(query,obj);
            }
        }
        public async Task<T> QuerySingleAsync(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return await conn.QueryFirstOrDefaultAsync<T>(query, obj);
            }
        }

        public IEnumerable<T> Query(string query, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return conn.Query<T>(query, obj);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<X>(string query, Func<T,X,T> func)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return await conn.QueryAsync<T,X,T>(query, func);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<X>(string query, Func<T, X, T> func, object obj)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                return await conn.QueryAsync<T, X, T>(query, func, param: obj, splitOn: "Id");
            }
        }

        public void ExecuteMultiple(string query, IEnumerable<object> objList)
        {
            using (SqlConnection conn = new SqlConnection(Connection.SqlConnectionString))
            {
                conn.Open();
                conn.Execute(query, objList);
            }
        }
    }
}
