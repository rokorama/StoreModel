using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModel.Contexts;

namespace StoreModel
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private StoreItemContext _context = null;
        private DbSet<T> table = null;
        public List<T> Items
        {
            get { return GetAll(); }
            set { }
        }

        public string[] ColumnNames
        {
            get { return typeof(T).GetProperties()
                                  .Select(property => property.Name)
                                  .ToArray(); }
            set { }
        }

        public GenericRepository()
        {
            this._context = new StoreItemContext();
            table = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}