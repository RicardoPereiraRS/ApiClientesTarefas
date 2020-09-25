using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
	[EnableCors("CorsApi")]
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{

	}
}
