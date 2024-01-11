using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
{
  private readonly IMapper _mapper;

  public AuctionUpdatedConsumer(IMapper mapper)
  {
    _mapper = mapper;
  }

  public async Task Consume(ConsumeContext<AuctionUpdated> context)
  {
    var item = _mapper.Map<Item>(context.Message);
    await DB.Update<Item>()
      .Match(x => x.ID == context.Message.Id)
      .ModifyOnly(x => new
      {
        x.Color,
        x.Make,
        x.Mileage,
        x.Year,
        x.Model
      }, item)
      .ExecuteAsync();
  }
}
