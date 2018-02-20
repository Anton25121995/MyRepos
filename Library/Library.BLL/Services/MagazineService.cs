using Library.DAL.Repositories;
using Library.Entities.Entities;

namespace Library.BLL.Services
{
    public class MagazineService : BaseService<Magazine>
    {
        private MagazineRepository repository;

        public override BaseRepository<Magazine> Repository
        {
            get { return repository; }
            set { if (repository == null) repository = new MagazineRepository(); }
        }
    }
}
