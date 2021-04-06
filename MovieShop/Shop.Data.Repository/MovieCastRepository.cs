using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class MovieCastRepository {

        public async Task<int> Insert(MovieCast item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into MovieCast values (@MovieId, @CastId, @Character)", item);
            }
        }

        public async Task<int> Delete(MovieCast item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<MovieCast>("Delete Id from MovieCast where MovieId=@MovieId", new { id = id });
            }
        }

        public async Task<int> Update(MovieCast item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<MovieCast>("Update MovieCast set from MovieCast where MovieId=@MovieId", new { id = id });
            }
        }

        public async Task<IEnumerable<MovieCast>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<MovieCast>("Select MovieId, CastId, Character from MovieCast");
            }
        }

        public async Task<MovieCast> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<MovieCast>("Select Id from MovieCast where MovieId=@MovieId", new { id = id });
            }
        }
    }
}