using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class GenreRepository {

        public async Task<int> Insert(Genre item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into Genre values (@Id,@Name)", item);
            }
        }

        public async Task<int> Delete(Genre item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Genre>("Delete Id from Genre where id=@id", new { id = id });
            }
        }

        public async Task<int> Update (Genre item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Genre>("Update Genre set from Genre where id=@id", new { id = id });
            }
        }

        public async Task<IEnumerable<Genre>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<Genre>("Select * from Genre");
            }
        }

        public async Task<Genre> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Genre>("Select Id from Genre where id=@id", new { id = id });
            }
        }
    }
 }