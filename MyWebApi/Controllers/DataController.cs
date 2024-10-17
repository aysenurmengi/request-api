using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstract;
using ServiceLayer.Concrete;
using ServiceLayer.Models;
using System.Security;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MyDataModel>>> Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] FilterTypeEnum type)
        {
            try
            {
                // servisten metod ile verilen parametrelerle veri alıyoruz
                var data = await _dataService.GetFilteredDataAsync(startDate, endDate, type);
                return Ok(data);
            }
            catch (Exception)
            {

                return StatusCode(500, "Veri alınırken bir hata oluştu: ");
            }
            
        }

    }
}
