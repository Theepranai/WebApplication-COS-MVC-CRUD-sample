using System.Collections.Generic;
using System.Linq;
using WebApplication_COS_MVC_CRUD_sample.Models;

namespace WebApplication_COS_MVC_CRUD_sample.Services
{
    public class HomeService
    {
        private List<HomeModel> rto = new List<HomeModel>();

        public HomeService()
        {
            rto.Add(
                new HomeModel()
                {
                    Id = 1,
                    Name = "FristName",
                    LastName = "LastName",
                });
        }

        public List<HomeModel> GetAll()
        {
            return rto;
        }

        public List<HomeModel> Edit(HomeModel model)
        {
            rto = rto.Where(c => c.Id == model.Id)
                .Select(x => new HomeModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    LastName = model.LastName
                }).ToList();

            return rto;
        }

        public List<HomeModel> Add(HomeModel model)
        {
            var id = rto.Max(x => x.Id);
            model.Id = id + 1;
            rto.Add(model);
            return rto;
        }

        public List<HomeModel> Delete(int id)
        {
            rto.Remove(rto.FirstOrDefault(x => x.Id == id));
            return rto;
        }
    }
}