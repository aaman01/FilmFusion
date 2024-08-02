using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Rest_api_Assignments.Models.DBModel;

namespace Rest_api_Assignments.Repository
{
	public class  BaseRepository<T> where T :class
    {
        private readonly string _connectionString;

        public BaseRepository (string connectionString)
		{
            _connectionString = connectionString;
        }

        public IEnumerable<T> GetAll(string query )
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query);
        }

        public T Get(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query,parameters);
        }

        public int Add(string query, object parameters)
        {
            using var connections = new SqlConnection(_connectionString);
            return connections.Query<int>(query, parameters).FirstOrDefault();
        }

        public void Delete(string query, object parameters)
        {
            using var connections = new SqlConnection(_connectionString);
            connections.Query(query, parameters);
        }

        public void Update (string query, object paramters)
        {
            using var connections = new SqlConnection(_connectionString);
            connections.Query(query, paramters);
        }

        //movies

        public int AddMovie(object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
           return connection.Query<int>("usp_insert_movie", parameters,commandType:CommandType.StoredProcedure).FirstOrDefault();
        }

        public void UpdateMovie(object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Query("usp_update_movie", parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Actor> GetActorList(string query, object paramters)
        {
            using var connections = new SqlConnection(_connectionString);
            return connections.Query<Actor>(query, paramters);
        }

        public IEnumerable<Genre> GetGenreList(string query, object paramters)
        {
            using var connections = new SqlConnection(_connectionString);
            return connections.Query<Genre>(query, paramters);
        }

        public IEnumerable<T> GetByYor(string query, object paramters)
        {
            using var connections = new SqlConnection(_connectionString);
            return connections.Query<T>(query, paramters);
        }



    }
}

