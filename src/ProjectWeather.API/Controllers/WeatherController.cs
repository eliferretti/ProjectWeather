using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectWeather.Application.Command.WeatherCommand;
using ProjectWeather.Application.Dto;
using ProjectWeather.Application.Query;
using System.Net.Mime;

namespace ProjectWeather.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WeatherResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<WeatherResponse>> AddWeather([FromBody] AddWeatherCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return response;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<AddWeatherDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<AddWeatherDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetWeathersQuery(), cancellationToken);

            return result;
        }
    }
}
