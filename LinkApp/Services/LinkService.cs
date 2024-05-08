using LinkApp.Models;
using LinkApp.Repositories;

namespace LinkApp.Services
{
    public class LinkService
    {

        private ApplicationContext _applicationContext;

        public LinkService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Link FindById(int id) => _applicationContext.Links.SingleOrDefault(link => link.Id == id);

        public long Save(Link link)
        {


            _applicationContext.Links.Add(link);
            _applicationContext.SaveChanges();
            return link.Id;
        }
    }
}
