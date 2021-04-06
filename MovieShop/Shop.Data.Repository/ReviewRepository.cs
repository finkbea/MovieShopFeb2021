using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class ReviewRepository {

        public async Task<int> Insert(Review item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into Review values (@MovieId, @UserId, @Rating, @ReviewText)", item);
            }
        }

        public async Task<int> Delete(Review item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Review>("Delete Id from Review where id=@id", new { id = id });
            }
        }

        public async Task<int> Update(Review item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Review>("Update Review set from Review where id=@id", new { id = id });
            }
        }

        public async Task<IEnumerable<Review>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<Review>("Select MovieId, UserId, Rating, ReviewText from Review");
            }
        }

        public async Task<Review> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Review>("Select Id from Review where MovieId=@MovieId", new { id = id });
            }
        }
    }
}