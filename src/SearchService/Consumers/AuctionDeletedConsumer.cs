using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
{
  public async Task Consume(ConsumeContext<AuctionDeleted> context)
  {
    var item = await DB.Find<Item>().OneAsync(context.Message.Id);

    if (item == null) throw new Exception("item not found");

    await item.DeleteAsync();
  }
}
