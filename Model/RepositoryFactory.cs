using Model.Database;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RepositoryFactory
    {
        private static RepositoryFactory _repositoryFactory = null; 
        private AppDbContext _context;

        // ctor
        public RepositoryFactory()
        {
            _context = new AppDbContext();
        }
        public static RepositoryFactory GetRepositoryFactory()
        {
            if (_repositoryFactory == null)
            {
                return new RepositoryFactory();
            }
            return _repositoryFactory;
        }


        public IUserRepository UserRepository
        {
            get
            {
                return new UserRepository(_context);
            }
        }
        public IFindRepository FindRepository
        {
            get
            {
                return new FindRepository(_context);
            }
        }
        public IImageRepository ImageRepository
        {
            get
            {
                return new ImageRepository();
            }
        }

    }
}
