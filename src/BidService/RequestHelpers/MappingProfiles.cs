using AutoMapper;
using Contracts;

namespace BidService;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<Bid, BidDto>();
    CreateMap<Bid, BidPlaced>();
  }
}
