using Ecohub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecohub.Controllers
{
    [ApiController]
    [Route("api/v1/pontocoleta/[controller]")]
    public class PontoColetaController
    {
        private readonly IPontoColetaService _pontoColetaService;

        public PontoColetaController(IPontoColetaService pontoColetaService)
        {
            _pontoColetaService = pontoColetaService ?? throw new ArgumentException();
        }
    }
}
