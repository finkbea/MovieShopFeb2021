using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class MovieGenreRepository {

        public async Task<int> Insert(MovieGenre item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into MovieGenre values (@MovieId, @GenreId)", item);
            }
        }

        public async Task<int> Delete(MovieGenre item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<MovieGenre>("Delete Id from MovieGenre where MovieId=@MovieId", new { id = id });
            }
        }

        public async Task<int> Update(MovieGenre item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<MovieGenre>("Update MovieGenre set from MovieGenre where MovieId=@MovieId", new { id = id });
            }
        }

        public async Task<IEnumerable<MovieGenre>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<MovieGenre>("Select * from MovieGenre");
            }
        }

        public async Task<MovieGenre> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<MovieGenre>("Select Id from MovieGenre where MovieId=@MovieId", new { id = id });
            }
        }
    }
}