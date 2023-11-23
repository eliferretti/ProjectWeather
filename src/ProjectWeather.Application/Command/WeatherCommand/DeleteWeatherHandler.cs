using MediatR;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Application.Command.WeatherCommand
{
    public class DeleteWeatherHandler : IRequestHandler<DeleteWeatherCommand, WeatherResponse>
    {
        private IRepository<Weather, string> _repository { get; }

        public DeleteWeatherHandler(IRepository<Weather, string> repository)
        {
            _repository = repository;
        }

        public async Task<WeatherResponse> Handle(DeleteWeatherCommand request, CancellationToken cancellationToken)
        {
            var weather = await _repository.GetSingleAsync(request.Id);
            await _repository.DeleteAsync(weather);
            return new WeatherResponse { WeatherId = request.Id, Message = "Deleted" }; 
        }
    }
}
