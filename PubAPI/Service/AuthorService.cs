using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PubAPI.Model;
using PublisherData;
using PublisherDomain;

namespace PubAPI.Service
{
    public class AuthorService
    {
        PubContext _context;
        private IMapper _mapper;
        public AuthorService(PubContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AuthorModel>> GetAllAuthors()
        {
            var authors = await _context.Author.ToListAsync();
            var autorModelList = _mapper.Map<List<AuthorModel>>(authors);
            //var authorDTOList = AuthorListToDTOList(authors);
            return autorModelList;
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            var author = await _context.Author.FindAsync(id);
            var authorModel = _mapper.Map<AuthorModel>(author);
            //var authorDto = AuthorToDto(author);
            return authorModel;
        }

        public async Task<bool> UpdateAuthor(int id, AuthorModel authorModel)
        {
            var res = 0;
            var author = _context.Author.Find(id);
            if (author != null)
            {
                author.FirstName = authorModel.FirstName;
                author.LastName = authorModel.LastName;
                _context.Entry(author).State = EntityState.Modified;
                res = await _context.SaveChangesAsync();
            }
            return (res > 0) ? true : false;

        }
        public async Task<bool> DeleteAuthorById(int id)
        {
            var res = 0;
            var author = await _context.Author.FindAsync(id);
            if (author != null)
            {
                _context.Author.Remove(author);
                res = await _context.SaveChangesAsync();
            }
            else
            {
                return false;
            }
            return (res > 0) ? true : false;
        }

        public async Task<bool> AddMultipleAuthors(List<AuthorModel> authorsModel)
        {
            var autorList = _mapper.Map<List<Author>>(authorsModel);
            await _context.Author.AddRangeAsync(autorList);
            var res = await _context.SaveChangesAsync();
            return (res > 0) ? true : false;
        }

        public async Task<bool> AddAuthor(AuthorModel authorModel)
        {
            var author = _mapper.Map<Author>(authorModel);
            //var author = FromDTOToAuthor(authorModel);
            _context.Author.Add(author);
            var res = await _context.SaveChangesAsync();
            return (res > 0) ? true : false;
        }
    }
}
