using Dapper;

public class BookService
{
    private readonly DapperContext _context;
    public BookService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<BookDto>> GetBooks()
    {
        using (var connection = _context.CreateConnection())
        {
            var sql = "Select id as Id, book_name as bookname, author_id as authorid from books";
            var result = await connection.QueryAsync<BookDto>(sql);
            return result.ToList();
        }
    }

    public async Task<int> InsertBook(BookDto book){
        using (var connection = _context.CreateConnection())
        {
            var sql = $"Insert into books(book_name,author_id) values('{book.BookName}',{book.AuthorId})";
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> UpdateBook(BookDto book){
        using (var connection = _context.CreateConnection())
        {
            var sql = $"Update books set book_name = '{book.BookName}', author_id = {book.AuthorId} where id = {book.Id}";
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeleteBook(int id){
        using (var connection = _context.CreateConnection())
        {
            var sql = $"Delete from books where id = {id}";
            var result = await connection.ExecuteAsync(sql);
            return result;
        }
    }
    
}