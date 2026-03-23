using AppSoutenance.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AppSoutenance.Services
{
    /// <summary>
    /// Service de base utilisant ADO.NET pour MariaDB
    /// </summary>
    public abstract class BaseServiceADO
    {
        protected readonly string _connectionString;

        public BaseServiceADO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connBdSenSoutenance"]?.ConnectionString
                ?? "server=localhost;port=3306;database=soutenance_db;uid=root;password=passer";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        protected int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        protected object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        protected DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Classe de résultat pour les opérations de service
    /// </summary>
    public class ServiceResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public static ServiceResult<T> Success(T data, string message = "")
        {
            return new ServiceResult<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static ServiceResult<T> Failure(string message)
        {
            return new ServiceResult<T>
            {
                IsSuccess = false,
                Message = message
            };
        }

        public static ServiceResult<T> Failure(List<string> errors)
        {
            return new ServiceResult<T>
            {
                IsSuccess = false,
                Errors = errors,
                Message = string.Join(Environment.NewLine, errors)
            };
        }
    }
}
