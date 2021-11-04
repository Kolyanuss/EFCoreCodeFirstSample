using EFCoreCodeFirstSampleWEBAPI.Models.DataManager.Interface;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreCodeFirstSampleWEBAPI.Models.DataManager
{
    public class FilmsManager : IFilmsManager<Films>
    {
        readonly MyAppContext _filmsContext;
        public FilmsManager(MyAppContext filmsContext)
        {
            _filmsContext = filmsContext;
        }

        /*private RepositoryWrapper _repositoryWrapper;
        public FilmsManager(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }*/

        public IEnumerable<Films> GetAll()
        {
            //return _repositoryWrapper.Films.GetAll();
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
            unit.FKDescriptionId = entity.FKDescriptionId;
            _filmsContext.SaveChanges();
        }
        public void Delete(Films unit)
        {
            _filmsContext.Films.Remove(unit);
            _filmsContext.SaveChanges();
        }
    }
}
