using AutoMapper;
using MediatR;
using ProjectWeather.Application.Dto;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Interfaces;

namespace ProjectWeather.Application.Query
{
    public class GetWeathersHandler : IRequestHandler<GetWeathersQuery, IEnumerable<WeatherDto>>
    {
        private readonly IRepository<Weather, string> _repository;
        private readonly IMapper _mapper;

        public GetWeathersHandler(IRepository<Weather, string> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WeatherDto>> Handle(GetWeathersQuery request, CancellationToken cancellationToken)
        {
            var weathers = await _repository.GetAll();
            
            var result = _mapper.Map<List<WeatherDto>>(weathers);

            return result;
        }
    }
}
