using AutoMapper;
using AutoMappingDemo.Models;
using System.Linq;

namespace AutoMappingDemo.MapProfiles
{
    public class SongInfoDtoProfile : Profile
    {
        public SongInfoDtoProfile()
        {
            this.CreateMap<Song, SongInfoDto>()
                    .ForMember(x => x.Artists, options =>
                        options.MapFrom(x => string.Join(", ", x.SongArtists.Select(a => a.Artist.Name))));
        }
    }
}
