using Dapper;

public class AuthorService
{
    private readonly DapperContext _context;
    public AuthorService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<AuthorDto>> GetAuthors()
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = "Select id as Id, first_name as firstname, last_name as lastname from authors";
            var result = await connection.QueryAsync<AuthorDto>(sql);
            return result.ToList();
        }
    }

    public async Task<int> InsertAuthor(AuthorDto author){
        using (var connection = _context.CreateConnection())
        {
            var sql = $"Insert into authors(first_name,last_name) values('{author.FirstName}','{author.LastName}')";
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> UpdateAuthor(AuthorDto author){
        using (var connection = _context.CreateConnection())
        {
            var sql = $"Update authors set first_name = '{author.FirstName}', last_name = '{author.LastName}' where id = {author.Id}";
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeleteAuthor(int id){
        using (var connection = _context.CreateConnection())
        {
            var sql = $"Delete from authors where id = {id}";
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
    
}