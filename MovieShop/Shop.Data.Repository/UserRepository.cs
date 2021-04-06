using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class UserRepository {

        public async Task<int> Insert(User item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into User values (@Id, @FirstName, @LastName, @DateOfBirth,@Email,@HashedPassword,@Salt,@PhoneNumber,@TwoFactorEnabled,@LockoutEndDate,@LastLoginDateTime,@IsLocked,@AccessFailedCount)", item);
            }
        }

        public async Task<int> Delete(User item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<User>("Delete Id from User where id=@id", new { id = id });
            }
        }

        public async Task<int> Update(User item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<User>("Update User set from User where id=@id", new { id = id });
            }
        }

        public async Task<IEnumerable<User>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<User>("Select Id, FirstName, LastName, DateOfBirth, Email, HashedPassword, Salt, PhoneNUmber, TwoFactorEnabled, LackoutEndDate, LastLoginDateTime, IsLocked, AccessFailedCount from User");
            }
        }

        public async Task<User> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<User>("Select Id from User where Id=@Id", new { id = id });
            }
        }
    }
}