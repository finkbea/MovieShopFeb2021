using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class CastRepository {

        public async Task<int> Insert(Cast item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into Cast values (@Id,@Name, @Gender, @TmdbUrl, @ProfilePath)", item);
            }
        }

        public async Task<int> Delete(Cast item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Cast>("Delete Id from Cast where id=@id", new { id = id });
            }
        }

        public async Task<int> Update(Cast item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Cast>("Update Cast set from Cast where id=@id", new { id = id });
            }
        }

        public async Task<IEnumerable<Cast>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<Cast>("Select Id, Name, Gender, TmdbUrl, ProfilePath from Cast");
            }
        }

        public async Task<Cast> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Cast>("Select Id from Cast where id=@id", new { id = id });
            }
        }
    }
}