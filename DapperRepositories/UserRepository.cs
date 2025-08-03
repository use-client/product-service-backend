using Dapper;
using ProductService.Models;
using ProductService.Data;


namespace ProductService.DapperRepositories
{
    public class UserRepository(IDbConnectionFactory connectionFactory) : IUserRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory = connectionFactory;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Users";
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Users WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }
    }
}