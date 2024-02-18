using WebApplicationRememberAll.DbConnector;
using WebApplicationRememberAll.Models;

namespace WebApplicationRememberAll.Repositories;

public class SlavesRepository
{
    private CsharpGroupSlaveDbContext _db;

    public SlavesRepository(CsharpGroupSlaveDbContext db)
    {
        _db = db;
    }

    public List<Slafe> GetAll()
    {
        return _db.Slaves.OrderBy(item => item.Id).ToList();
    }
}