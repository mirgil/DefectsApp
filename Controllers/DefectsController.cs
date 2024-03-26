using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace DefectsApp
{


    [ApiController]
    [Route("[controller]")]
    public class DefectsController : ControllerBase
    {
        DefectsContext _dbCtx;
        public DefectsController(DefectsContext ctx)
        {
            _dbCtx = ctx;
            
        }

        [EnableQuery]
        [HttpGet(Name = "GetDefects")]
        public IQueryable<Defect> Get()
        {
            return _dbCtx.Defects;
        }
    }
}
