using PubAPI.Model;

namespace PubAPI.Interface
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorModel>> GetAllAuthors();
        Task<AuthorModel> GetAuthor(int id);
        Task<AuthorModel> AddAuthor(AuthorModel authorModel);
        Task<IEnumerable<AuthorModel>> AddMultipleAuthors(IEnumerable<AuthorModel> authorModelList);
        Task<AuthorModel> UpdateAuthor(int id, AuthorModel authorModel);
        Task<bool> DeleteAuthorById(int id);
    }
}
