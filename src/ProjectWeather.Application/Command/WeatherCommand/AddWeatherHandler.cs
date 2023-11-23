using AutoMapper;
using MediatR;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class AddWeatherHandler : IRequestHandler<AddWeatherCommand, WeatherResponse>
    {
        private readonly IRepository<Weather, string> _repository;
        private readonly IMapper _mapper;

        public AddWeatherHandler(IRepository<Weather, string> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherResponse> Handle(AddWeatherCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Weather>(request.Weather);
            await _repository.SaveAsync(result);
            return await Task.FromResult(new WeatherResponse { WeatherId = result.Id, Message = "Success" });
        }
    }
}
