using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Shop.Data.Models;

namespace Shop.Data.Repository {
    public class MovieRepository {

        public async Task<int> Insert(Movie item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Execute("insert into Movie values (@Id,@Name, @Title, @Overview, @Tagline, @Budget, @Revenue, @ImdbUrl, @TmdbUrl, @PosterUrl, @BackdropUrl, @OriginalLanguage, @ReleaseDate, @RunTime, @Price, @CreatedDate, @UpdatedDate, @UpdatedBy, @CreatedBy)", item);
            }
        }

        public async Task<int> Delete(Movie item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Movie>("Delete Id from Movie where id=@id", new { id = id });
            }
        }

        public async Task<int> Update (Movie item) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Movie>("Update Movie set from Movie where id=@id", new { id = id });
            }
        }

        public async Task<IEnumerable<Movie>> GetAll() {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.Query<Movie>("Select Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, RunTime, Price, CreatedDate, UpdatedDate, UpdatedBy, CreatedBy from Movie");
            }
        }

        public async Task<Movie> GetById(int id) {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) {
                return connection.QueryFirstOrDefault<Movie>("Select Id from Movie where id=@id", new { id = id });
            }
        }
    }
 }