using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternConsole
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private List<T> _entities = new List<T>();
        public IEnumerable<T> GetAll()
        {
            return _entities;
        }
        public T Get(int id)
        {
            // LINQ를 사용하여 ID가 일치하는 첫 번째 엔티티를 찾습니다.
            // 이 코드는 T 타입이 Id 속성을 가지고 있다고 가정합니다.
            // 실제로는 T에 대한 더 구체적인 제약 조건이 필요할 수 있습니다.
            return _entities.FirstOrDefault(e => (e as dynamic).Id == id);
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }
        public void Update(T entity)
        {
            // 업데이트 로직은 실제 구현에 따라 달라질 수 있습니다.
            // 이 예제에서는 단순화를 위해 생략되었습니다.
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
