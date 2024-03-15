using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Craftonama.DataAccess.Repository.IRepository
{
	//we created generic repository
	//"where T : class" => this ensures that T can be a class(reference type) not a value type( like int or string)
	public interface IRepository<T> where T : class
	{
		//eg- T == category
		IEnumerable<T> GetAll();

		/*This is lambda expression that specifies the criteria for filtering the entities*/
		T Get(Expression<Func<T, bool>> filter);
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
