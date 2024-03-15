using Craftonama.DataAccess.Data;
using Craftonama.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftonama.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private  ApplicationDbContext _db;
		public ICategoryRepository categoryRepo { get; private set; }

		public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
			categoryRepo = new CategoryRepository(_db);
        }

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
