using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Uygulama.DAL.Context;
using Uygulama.DAL.Enums;

namespace Uygulama.DAL.Repository.Abstract
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly UygulamaDbContext _db;
        //neden entities?
        //çünkü hangi türde varlıklar olduğunu bilmiyoruz.
        //T yerine ne gönderilirse o olacak 

        //gönderilecek tipte olan varlıklarımız 
        protected DbSet<T> entities;

        public Repository(UygulamaDbContext db)
        {
            _db = db;
            entities = _db.Set<T>();
        }
        public void Add(T entity)
        {
            //içerisine gelen T tipinde (türü değişir) gelen entity'yi db'ye ekle

            //durumunu eklendi yap
            entity.Status = Status.Created;

            //oluşturulma tarihini o anın tarihi yap
            entity.CreatedDate = DateTime.Now;

            //ekle
            entities.Add(entity);
            _db.SaveChanges();


        }


        public IQueryable<T> GetAll()
        {
            //silinenleri getirmemesi lazım
            return entities.AsNoTracking();
        }

        public T GetById(int id)
        {
            //silinenleri getirmemesi lazım

            return entities.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(T entity)
        {
            //gerçekten silecek (tablodan silecek)
            entities.Remove(entity);
            _db.SaveChanges();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            //silinenleri getirmeyecek ve filtreleyecek
            var all = entities.AsNoTracking();
            return all.Where(predicate);
        }

        public void Update(T entity)
        {
            if (entity.Status != Status.Deleted)
            {
                //güncelleme tarihi o anın tarihi
                entity.UpdatedDate = DateTime.Now;

                //Oluşturulma tarihi
                //entity.CreatedDate = GetById(entity.Id).CreatedDate;

                //statüyü güncellendi yap

                //silindi değilse updated yap.

                entity.Status = Status.Updated;
            }
            _db.Entry(entity).State = EntityState.Modified;

            entities.Update(entity);

            _db.SaveChanges();

        }
        public void Delete(T entity)
        {

            //silinme tarihini o anın tarihine ata
            //_db.Entry(entity).State = EntityState.Detached;
            entity.DeletedDate = DateTime.Now;

            //statusunü deleted yapacak ama tablodan silmeyecek
            entity.Status = Status.Deleted;

            //_db.SaveChanges();
            //güncelleme işlemini yap
            Update(entity);

        }

        public IQueryable<T> GetAllWithIncludes(params string[] navigationProperties)
        {
            //burada navigation prop.ları include edeceğiz.

            IQueryable<T> query = _db.Set<T>();

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query;
        }

        public IQueryable<T> GetAllWithIncludes()
        {
            //bütün navigation prop.'ları include et :)


            IQueryable<T> query = _db.Set<T>();

            //önce türünün ne olduğunu bilemediğimiz T yapıp new'leyerek oluşturuyoruz.

            T instance = new T();

            //sonra bu varlığın türünü edinebilmek için GetType() metodunu çağırırız.

            Type type = instance.GetType();

            //Sonra bu türün prop.larını alalım.

            PropertyInfo[] properties = type.GetProperties();


            //IEntity interface'inden türeyenlerin hepsi içerisinde döngü ile dön
            //Hem IEntitye'den türeyenleri bulmak lazım hem de bunların bütün prop.larını almak lazım
            foreach (PropertyInfo propInfo in properties.Where(pl => pl.PropertyType.GetInterfaces().Where(i => i.Name == "IEntity").Any()).ToList())
            {
                query = query.Include(propInfo.Name);
            }

            return query;

        }


    }
}
