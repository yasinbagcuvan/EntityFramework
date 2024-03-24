using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama.DAL.Repository.Abstract
{
    public interface IRepository<T>
    {
        //içerisine gönderileni ekleyecek
        public void Add(T entity);

        //içerisine gönderileni gerçekten silecek
        public void Remove(T entity);

        public void Delete(T entity);
        //içerisine gönderileni güncellecek
        public void Update(T entity);

        //içerisine id'ye göre varlığı getirecek
        public T GetById(int id);


        //Dönüş tipinin henüz belleğe alınmasını istemiyoruz. Çünkü daha önümüzde başka katmanlar da var. En son aşamada, kullanıcıya gösterilirken List olarak yapalım ki o zaman belleğe yüklensin.

        //Arada bir katman oılduğu için direkt belleğe yüklennmiş halini getirmiyor da daha hafif bir halini getiriip onu yukarıya iletiyor.

        //Daha sonra yukarıda (başka katmanda) bu List olarak getirilecek.
        //Yani belleğe yüklecek.

        public IQueryable<T> GetAll();


        //burada kriter yazılacak. Bu kritere göre arama yapılıp sonuç gelecek. (ya da yoksa gelmeyecek :) )
        public IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        public IQueryable<T> GetAllWithIncludes(params string[] navigationProperties);

        public IQueryable<T> GetAllWithIncludes();
    }
}
