using EFCoreCodeFirstSample.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class FilmsManager : IDataRepository<Films>
    {
        readonly MyAppContext _filmsContext;
        public FilmsManager(MyAppContext context)
        {
            _filmsContext = context;
        }
        public IEnumerable<Films> GetAll()
        {
            return _filmsContext.Films.ToList();
        }
        public Films Get(long id)
        {
            return _filmsContext.Films
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Films entity)
        {
            _filmsContext.Films.Add(entity);
            _filmsContext.SaveChanges();
        }
        public void Update(Films unit, Films entity)
        {
            unit.NameFilm = entity.NameFilm;
            unit.ReleaseData = entity.ReleaseData;
            unit.Country = entity.Country;
            unit.DescriptionId = entity.DescriptionId;
            _filmsContext.SaveChanges();
        }
        public void Delete(Films unit)
        {
            _filmsContext.Films.Remove(unit);
            _filmsContext.SaveChanges();
        }
    }
}
