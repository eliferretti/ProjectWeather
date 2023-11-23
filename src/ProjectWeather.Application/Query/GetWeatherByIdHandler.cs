using AutoMapper;
using MediatR;
using ProjectWeather.Application.Dto;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Application.Query
{
    public class GetWeatherByIdHandler : IRequestHandler<GetWeatherByIdQuery, WeatherDto>
    {
        private IRepository<Weather, string> _repository { get; }
        private IMapper _mapper { get; init; }

        public GetWeatherByIdHandler(IRepository<Weather, string> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherDto> Handle(GetWeatherByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetSingleAsync(request.Id);

            var result = _mapper.Map<WeatherDto>(response);

            return await Task.FromResult(result);
        }
    }
}
