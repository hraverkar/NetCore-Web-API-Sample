using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MyMDB.Data;

namespace MyMDB.Controllers
{
  [Microsoft.AspNetCore.Components.Route("api/[controller]")]
  [ApiController]
  public abstract class MyMDBController<TEntity, TRepository> : ControllerBase
    where TEntity : class, IEntity
    where TRepository : IRepository<TEntity>
  {
    private readonly TRepository repository;

    public MyMDBController(TRepository repository)
    {
      this.repository = repository;
    }

    //Get : api/[controller]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TEntity>>> Get()
    {
      return await repository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TEntity>> Get(Guid Id)
    {
      var movie = await repository.Get(Id);
      if(movie == null)
      {
        return NotFound();
      }
      return movie;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, TEntity movie)
    {
      if(id != movie.Id)
      {
        return BadRequest();
      }
      await repository.Update(movie);
      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult> Post(TEntity movie)
    {
      await repository.Add(movie);
      return CreatedAtAction("Get", new
      {
        id = movie.Id
      }, movie);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TEntity>> Delete (Guid id)
    {
      var movie = await repository.Delete(id);
      if(movie == null)
      {
        return NotFound();
      }
      return movie;
    }
  }
}
