using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubAPI.Model;
using PubAPI.Repository;
using PublisherData;
using PublisherDomain;

namespace PubAPI.Service
{
    public class AuthorService
    {
        private AuthorRepository _repository;
        public AuthorService(AuthorRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            
            var autorModelList = await _repository.GetAllAuthors();
            return autorModelList;
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            var author = await _repository.GetAuthor(id);
            return author;
        }

        public async Task<AuthorModel> UpdateAuthor(int id, AuthorModel authorModel)
        {
            var author = await _repository.UpdateAuthor(id, authorModel);
            if(author.Id != 0) 
            {
                return authorModel;
            }
            return null;
        }
        public async Task<bool> DeleteAuthorById(int id)
        {
            var res = await _repository.DeleteAuthorById(id);
            return res;
        }

        public async Task<IEnumerable<AuthorModel>> AddMultipleAuthors(IEnumerable<AuthorModel> authorsModel)
        {
            var authors = await _repository.AddMultipleAuthors(authorsModel);
            return authors;
        }

        public async Task<AuthorModel> AddAuthor(AuthorModel authorModel)
        {
            var author = await _repository.AddAuthor(authorModel);
            return author;
        }
    }
}
