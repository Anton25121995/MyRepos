using Library.DAL.Repositories;
using Library.Entities.Entities;

namespace Library.BLL.Services
{
    public class BrochureService : BaseService<Brochure>
    {
        private BrochureRepository repository;

        public override BaseRepository<Brochure> Repository
        {
            get { return repository; }
            set { if (repository == null) repository = new BrochureRepository(); }
        }

    }
}
