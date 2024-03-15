using Craftonama.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftonama.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository categoryRepo { get; }
		void Save();
		
	}
}
