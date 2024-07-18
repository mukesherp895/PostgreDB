using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgreDB.DataAccess.Repositories;
using PostgreDB.Model.DomainModels;
using PostgreDB.Model.Dtos;

namespace PostgreDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostgreFuncSpController : ControllerBase
    {
        private readonly IPostgreSQLRepository _postgreSQLRepository;

        public PostgreFuncSpController(IPostgreSQLRepository postgreSQLRepository)
        {
            _postgreSQLRepository = postgreSQLRepository;
        }
        [HttpPost("BsToAd")]
        public async Task<IActionResult> ConvertBsToAd([FromBody] ConvertAdToBsReqDto convertAdToBsReqDto)
        {
            try
            {
                return Ok(await _postgreSQLRepository.ConvertAdToBs(convertAdToBsReqDto));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpGet("FiscalYear")]
        public async Task<IActionResult> FiscalYear(string fiscalYear)
        {
            try
            {
                var fiscalYears = await _postgreSQLRepository.FiscalYear(fiscalYear);
                return Ok(fiscalYears);
            }
            catch (Exception ex)
            {
                return Ok(new List<DateMaps>());
            }
        }
    }
}
