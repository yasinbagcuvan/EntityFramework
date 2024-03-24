using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama.BL.Manager.Abstract
{    //hangileri arasında dönüşüm olacak?
    //cevap:
    //TEntity'den TModel'a 
    //TModel'dan TEntity'ye
    public abstract class Manager<TModel, TEntity, TMapperProfile> : IManager<TModel> where TModel : class
        where TEntity : class
        where TMapperProfile : Profile, new()
    {

        protected IMapper _mapper;
        protected IRepository<TEntity> _repository;
        protected MapperConfiguration _config;


        public Manager()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddCollectionMappers();
            //    // Configuration code
            //});

            //constructor'da mapper'ın configurasyonunu yapıyoruz.
            //nereden nereye eşleştireceğini belirliyoruz.
            //TModel dan TEntity'ye ve TEntity'den TModel'a eşleme yap diyoruz.
            _config = new MapperConfiguration(cfg =>
            {

                //cfg.AddCollectionMappers();
                cfg.AddExpressionMapping().CreateMap<TModel, TEntity>().ReverseMap();
                cfg.AddProfile<TMapperProfile>();
            });


            _mapper = new Mapper(_config);
        }
        public TModel Add(TModel model)
        {
            //UI'dan gelen TModel'ı önce TEntity'ye eşleştirip çevirmemiz gerekli. TEntity'ye çevirince de IRepository kullanarak ekle.

            TEntity cevirilenEntity = _mapper.Map<TEntity>(model);
            _repository.Add(cevirilenEntity);
            model = _mapper.Map<TModel>(cevirilenEntity);
            return model;
        }


        public List<TModel> GetAll()
        {
            List<TEntity> EntitiesFromDb = _repository.GetAll().ToList();

            List<TModel> models = new List<TModel>();

            foreach (TEntity entity in EntitiesFromDb)
            {
                TModel model = _mapper.Map<TModel>(entity);
                models.Add(model);
            }

            return models;

        }
        public void Delete(TModel model)
        {
            TEntity convertedEntity = _mapper.Map<TEntity>(model);
            _repository.Delete(convertedEntity);
        }

        public TModel GetById(int id)
        {
            TEntity entity = _repository.GetById(id);

            TModel model = _mapper.Map<TModel>(entity);

            return model;
        }

        public void Remove(TModel model)
        {
            TEntity cevirilenEntity = _mapper.Map<TEntity>(model);
            _repository.Remove(cevirilenEntity);
        }

        public List<TModel> Search(Expression<Func<TModel, bool>> predicate)
        {

            Expression<Func<TEntity, bool>> predicateEntities = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);

            List<TEntity> filteredEntitiesFromDb = _repository.Search(predicateEntities).ToList();

            List<TModel> models = new List<TModel>();

            foreach (TEntity entity in filteredEntitiesFromDb)
            {
                TModel model = _mapper.Map<TModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public void Update(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _repository.Update(entity);

        }

        //Bize bir de include'lar da yapılan get metodları gerekli.
        public List<TModel> GetAllWithIncludes(params string[] navigationProperties)
        {
            //önce repository'deki GetAllWithIncludes metodunu çağır
            //Ama çağırınca TEntity tipinde gelir tabi.
            //Bİz de bunu yine yukarıda yaptığımız gibi bu listeyi TModel listesine döndüreceğiz.

            List<TEntity> entities = _repository.GetAllWithIncludes(navigationProperties).ToList();

            List<TModel> models = _mapper.Map<List<TModel>>(entities);

            return models;
        }

        public List<TModel> GetAllWithIncludes()
        {
            //DAL dan gelenleri TModel listesine yukarıdaki gibi dönüştürecek

            List<TEntity> entities = _repository.GetAllWithIncludes().ToList();

            List<TModel> models = _mapper.Map<List<TModel>>(entities);

            return models;

        }
    }
}
