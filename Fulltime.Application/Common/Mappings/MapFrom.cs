using AutoMapper;

namespace Fulltime.Application.Common.Mappings
{
    public class MapFrom<T>: IMapFrom<T>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }

    }
}
