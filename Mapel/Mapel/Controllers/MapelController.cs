using Mapel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mapel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        //Get : api/mapel
        [HttpGet]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllMapel();
        }

        //Get :api/mapel{id} / dari id_mapel
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetMapel(id);
        }

        //Post
        [HttpPost]
        public ActionResult<MapelItem> AddMapel([FromForm] string nama_mapel, [FromForm] string deskripsi)
        {
            MapelItem mi = new MapelItem();
            mi.nama_mapel = nama_mapel;
            mi.deskripsi = deskripsi;

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(mi);
        }
    }
}
