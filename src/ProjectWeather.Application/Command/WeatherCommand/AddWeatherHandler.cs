using AutoMapper;
using MediatR;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class AddWeatherHandler : IRequestHandler<AddWeatherCommand, WeatherResponse>
    {
        private readonly IWeatherRepository _repository;
        private readonly IMapper _mapper;

        public AddWeatherHandler(IWeatherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherResponse> Handle(AddWeatherCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Weather>(request.Weather);
            await _repository.AddAsync(result);
            var response = new WeatherResponse { WeatherId = result.Id };
            return await Task.FromResult(response);
        }
    }
}
