using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PubAPI.Interface;
using PubAPI.Model;
using PublisherData;
using PublisherDomain;

namespace PubAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        PubContext _context;
        private IMapper _mapper;
        public AuthorRepository(PubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AuthorModel> AddAuthor(AuthorModel authorModel)
        {
            var author = _mapper.Map<Author>(authorModel);
            _context.Author.Add(author);
            var res = await _context.SaveChangesAsync();
            authorModel.Id = author.Id;
            return (res > 0) ? authorModel : null;
        }

        public async Task<IEnumerable<AuthorModel>> AddMultipleAuthors(IEnumerable<AuthorModel> authorModelList)
        {
            var authorList = _mapper.Map<List<Author>>(authorModelList);
            await _context.Author.AddRangeAsync(authorList);
            var res = await _context.SaveChangesAsync();
            return (res == authorModelList.Count()) ? authorModelList : Enumerable.Empty<AuthorModel>() ;
        }

        public async Task<bool> DeleteAuthorById(int id)
        {
            int res = 0;
            var author = await _context.Author.FindAsync(id);
            if (author != null)
            {
                _context.Author.Remove(author);
                res = await _context.SaveChangesAsync();
            }
            return (res > 0) ? true : false;
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            var authors = await _context.Author.ToListAsync();
            var autorModelList = _mapper.Map<IEnumerable<AuthorModel>>(authors);
            return autorModelList;
        }

        public async Task<AuthorModel> GetAuthor(int id)
        {
            var author = await _context.Author.FindAsync(id);
            var authorModel = _mapper.Map<AuthorModel>(author);
            return authorModel;
        }

        public async Task<AuthorModel> UpdateAuthor(int id, AuthorModel authorModel)
        {
            var author = _context.Author.Find(id);
            authorModel.Id = 0;
            if (author != null)
            {
                author.FirstName = authorModel.FirstName;
                author.LastName = authorModel.LastName;
                _context.Entry(author).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                authorModel.Id = author.Id;
            }            
            return authorModel;
        }
    }
}
