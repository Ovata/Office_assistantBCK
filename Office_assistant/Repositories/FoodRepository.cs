using Office_assistant.Context;
using Office_assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Office_assistant.Repositories
{
    public class FoodRepository : _dataRepository<Food>
    {
        readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Food entity)
        {
            _context.Foods.Add(entity);
            //if (_context.Foods.Any(x => x.Email == entity.Email))
            //    throw new AppException("This User can not have multiple stores ");
            _context.SaveChanges();
        }

        public void Delete(Food stores)
        {
            _context.Foods.Remove(stores);
            _context.SaveChanges();
        }

        public Food Get(int id)
        {
            return _context.Foods
                   //.Include(cs => cs.Customers)
                   //.ThenInclude(cu => cu.User)
                   //.Include(p => p.Products)
                   //.ThenInclude(f => f.Files)
                   //.Include(r => r.Review)
                   //.Include(u => u.User)
                   //.Include(i => i.StoreImage)
                   //.Include(w => w.Wallet)
                   .FirstOrDefault(c => c.Id == id);
        }
        //public IQueryable<Stores> Gettores(int id)
        //{
        //    return _context.Stores
        //        .Where(u => u.UserId == id);
        //}
        public IEnumerable<Food> GetAll()
        {
            return _context.Foods
                //.Include(cs => cs.Customers)
                //.Include(p => p.Products)
                //.ThenInclude(f => f.Files)
                //.Include(r => r.Review)
                .ToList();
        }

        public void Update(Food food, Food entity)
        {

            food.Name = entity.Name;
            food.Food_name = entity.Food_name;
            food.Price = entity.Price;
            //stores.PhoneNumber = entity.PhoneNumber;
            //stores.Description = entity.Description;
            _context.SaveChanges();
        }

        //public Stores GetStoreByUserId(int id)
        //{
        //    return _context.Stores
        //        .Where(u => u.UserId == id)
        //        .Include(us => us.User)
        //        .FirstOrDefault(c => c.StoreId == id);

        //}
    }

}
