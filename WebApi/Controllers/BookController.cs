using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class BookController{
    private BookService _bookService;
    public BookController(BookService bookService){
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<List<BookDto>> GetBooks(){
        return await _bookService.GetBooks();
    }

    [HttpPost]
    public async Task<int> InsertBook(BookDto book){
        return await _bookService.InsertBook(book);
    }
    [HttpPut]
    public async Task<int> UpdateBook(BookDto book){
        return await _bookService.UpdateBook(book);
    }
    [HttpDelete]
    public async Task<int> DeleteBook(int id){
        return await _bookService.DeleteBook(id);
    }
}