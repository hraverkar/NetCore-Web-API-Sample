using MyMDB.Models;

namespace MyMDB.Data.EFCore
{
  public class EfCoreMovieRepository : EfCoreRepository<Movie, MyMDBContext>
  {
    public EfCoreMovieRepository(MyMDBContext context): base(context)
    {

    }

  }
}
