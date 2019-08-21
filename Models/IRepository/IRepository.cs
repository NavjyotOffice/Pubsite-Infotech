using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfotechVision.Models.IRepository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetEntityByID(int? Id);

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);


        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);


        string FileUpload(IFormFile formFile, string uploadFolder, string type, string title);
        void RemoveFileByName(string filePath);
    }
}
