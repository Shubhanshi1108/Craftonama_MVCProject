using Craftonama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftonama.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository: IRepository<Category>
	{
		//we need to include methods which were not mentioned in IRepository
		void Update(Category obj);
	}
}
