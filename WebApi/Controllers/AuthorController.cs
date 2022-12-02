using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class AuthorController{
    private AuthorService _authorService;
    public AuthorController(AuthorService authorService){
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<List<AuthorDto>> GetAuthors(){
        return await _authorService.GetAuthors();
    }

    [HttpPost]
    public async Task<int> InsertAuthor(AuthorDto author){
        return await _authorService.InsertAuthor(author);
    }
    [HttpPut]
    public async Task<int> UpdateAuthor(AuthorDto author){
        return await _authorService.UpdateAuthor(author);
    }
    [HttpDelete]
    public async Task<int> DeleteAuthor(int id){
        return await _authorService.DeleteAuthor(id);
    }
}