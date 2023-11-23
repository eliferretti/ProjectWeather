using AutoMapper;
using MediatR;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class UpdateWeatherHandler : IRequestHandler<UpdateWeatherCommand, WeatherResponse>
    {
        private IRepository<Weather, string> _repository { get; }
        private IMapper _mapper { get; init; }

        public UpdateWeatherHandler(IRepository<Weather, string> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WeatherResponse> Handle(UpdateWeatherCommand request, CancellationToken cancellationToken)
        {        
            var result = _mapper.Map<Weather>(request.Weather);
            await _repository.UpdateAsync(result);
            return await Task.FromResult(new WeatherResponse { WeatherId = result.Id, Message = "Update success" });
        }
    }
}
