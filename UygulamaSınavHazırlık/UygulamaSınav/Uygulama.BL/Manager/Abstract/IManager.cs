using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama.BL.Manager.Abstract
{
    public interface IManager<TModel> where TModel : class
    {
        //ekleme, silme, güncelleme getirme vb.... işlemleri yazmamız gerekir.
        //içerisine gönderileni ekleyecek
        public TModel Add(TModel model);


        //içerisine gönderileni gerçekten silecek
        public void Remove(TModel model);

        public void Delete(TModel model);
        //içerisine gönderileni güncellecek
        public void Update(TModel model);

        //içerisine id'ye göre varlığı getirecek
        public TModel GetById(int id);


        //Dönüş tipinin henüz belleğe alınmasını istemiyoruz. Çünkü daha önümüzde başka katmanlar da var. En son aşamada, kullanıcıya gösterilirken List olarak yapalım ki o zaman belleğe yüklensin.

        //Arada bir katman olduğu için direkt belleğe yüklennmiş halini getirmiyor da daha hafif bir halini getiriip onu yukarıya iletiyor.

        //Daha sonra yukarıda (başka katmanda) bu List olarak getirilecek.
        //Yani belleğe yüklecek.

        public List<TModel> GetAll();


        //burada kriter yazılacak. Bu kritere göre arama yapılıp sonuç gelecek. (ya da yoksa gelmeyecek :) )
        public List<TModel> Search(Expression<Func<TModel, bool>> predicate);

        public List<TModel> GetAllWithIncludes(params string[] navigationProperties);

        public List<TModel> GetAllWithIncludes();
    }
}
