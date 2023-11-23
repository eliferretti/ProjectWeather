using MediatR;
using ProjectWeather.Application.Dto;

namespace ProjectWeather.Application.Query
{
    public class GetWeathersQuery : IRequest<IEnumerable<WeatherDto>>
    {
    }
}
