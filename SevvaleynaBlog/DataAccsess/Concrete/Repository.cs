using DataAccsess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext db;
        public Repository(DbContext _db)
        {
            db = _db;
        }

        public string Delete(Expression<Func<TEntity, bool>> where)
        {
            // TRY içersinde yazılan kod bloklarında hata yok ise sorunsuz çalışır
            //Hata var ise Catch bölümü çalışır ve kullanıcıya patlıyan projeyi değilde kendi verdiğimiz mesajı yönlendirmemize yarar 
            try
            {
                db.Remove(GetById(where));
                db.SaveChanges();
                return "Silme Başarılı";
            }
            catch (Exception)
            {

                return "Silme Başarısız";

            }
        }

        public IList<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();

        }

        public TEntity GetById(Expression<Func<TEntity, bool>> where)
        {
            return db.Set<TEntity>().Where(where).FirstOrDefault();
        }

        public string Insert(TEntity entity)
        {
            try
            {
                db.Add(entity);
                db.SaveChanges();
                return "Ekleme Başarılı";

            }
            catch (Exception)
            {

                return "Ekleme Başarılı";
            }
        }

        public string Update(TEntity entity)
        {
            try
            {
                db.Update(entity);
                db.SaveChanges();
                return "Güncelleme Başarılı";
            }
            catch (Exception)
            {

                return "Güncelleme Başarılı";

            }
        }
    }
}
