using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext capContext=new ReCapContext()) 
            {
                var addenEntiry = capContext.Entry(entity);
                addenEntiry.State = EntityState.Added;
                capContext.SaveChanges();
            }
            //using (NorthwindContext context = new NorthwindContext())
        //    {
        //        var addedEntiry = context.Entry(entity);
        //        addedEntiry.State = EntityState.Added;
        //        context.SaveChanges();
        //    }

        }

        public void Delete(Car entity)
        {
            using (ReCapContext capContext=new ReCapContext())
            {
                var deletedEntiry = capContext.Entry(entity);
                deletedEntiry.State = EntityState.Deleted;
                capContext.SaveChanges();

            }
            //    using (NorthwindContext context = new NorthwindContext())
            //    {
            //        var deletedEntiry = context.Entry(entity);
            //        deletedEntiry.State = EntityState.Deleted;
            //        context.SaveChanges();
            //    }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext capContext=new ReCapContext())
            {
                return capContext.Set<Car>().SingleOrDefault(filter);

            }
            //    using (NorthwindContext context = new NorthwindContext())
            //    {
            //        return context.Set<Product>().SingleOrDefault(filter);
            //    }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext capContext=new ReCapContext())
            {
                return filter == null ? capContext.Set<Car>().ToList() : capContext.Set<Car>().Where(filter).ToList();

            }
            //    using (NorthwindContext context = new NorthwindContext())
            //    {
            //        return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();

            //    }
        }

        public void Update(Car entity)
        {
            using (ReCapContext capContext = new ReCapContext())
            {
                var updatedEntiry = capContext.Entry(entity);
                updatedEntiry.State = EntityState.Modified;
                capContext.SaveChanges();

            }
            //    using (NorthwindContext context = new NorthwindContext())
            //    {
            //        var updatedEntiry = context.Entry(entity);
            //        updatedEntiry.State = EntityState.Modified;
            //        context.SaveChanges();
            //    }
        }
    }
}
