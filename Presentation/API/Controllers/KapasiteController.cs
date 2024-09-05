
using Business.Abstrac;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KapasiteController : ControllerBase
    {
        private readonly IAkisRepository _akisRepository;
        private readonly ISpotRepository _spotRepository;
        private readonly IInoviceRepository _ınoviceRepository;

        public KapasiteController(ISpotRepository spotRepository, IAkisRepository akisRepository, IInoviceRepository ınoviceRepository)
        {
            _spotRepository = spotRepository;
            _akisRepository = akisRepository;
            _ınoviceRepository = ınoviceRepository;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllKapasite()
        {
            var kapasiteler = await _spotRepository.GetAllAsync();
            return Ok(kapasiteler);
        }

        [HttpGet("get-by-period")]
        public async Task<IActionResult> GetKapasiteByPeriod(int month, int year)
        {
            var kapasiteler = await _spotRepository.GetByPeriodAsync(month, year);
            return Ok(kapasiteler);
        }

        [HttpGet("get-total")]
        public async Task<IActionResult> GetTotalKapasiteByMonth(int month, int year)
        {
            var totalKapasite = await _spotRepository.GetTotalCapacityByMonthAsync(month, year);
            return Ok(totalKapasite);
        }
        

        [HttpGet("get-rapor")]
        public async Task<IActionResult> GetRapor(int kurum_id)
        {

            var sonuc= await _ınoviceRepository.GetTotalInoviceByKurumIdAsync(kurum_id);
            return Ok(sonuc);

        }

    }

}
