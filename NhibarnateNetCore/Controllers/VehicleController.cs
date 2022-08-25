using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhibarnateNetCore.ContextSession;
using System.Linq;

namespace NhibarnateNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapperSession _session;

        public VehicleController(IMapperSession session)
        {
            _session = session;
        }

        [HttpGet]
        [Route("GetVehicles")]
        public IActionResult Index()
        {
            var vehicles = _session.Vehicle.ToList();

            return Ok(vehicles);
        }
    }
}
