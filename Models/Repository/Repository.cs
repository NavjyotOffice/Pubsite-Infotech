using InfotechVision.Models.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = context.Set<TEntity>().ToList();
            return entities;
        }
        
        public TEntity GetEntityByID(int? Id)
        {
            var entity = context.Set<TEntity>().Find(Id);
            return entity;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = context.Set<TEntity>().Where(predicate);
            return entities;
        }





        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }


        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }





        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        

        public string FileUpload(IFormFile formFile, string uploadFolder, string Type)
        {
            string fileName = string.Empty;
            if (formFile != null)
            {
                string Guid = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;
                fileName = Guid + Type + "_" + formFile.FileName;
                string filePath = Path.Combine(uploadFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return fileName;
        }
        
    }
}
