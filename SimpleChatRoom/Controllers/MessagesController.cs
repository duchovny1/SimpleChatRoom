namespace SimpleChatRoom.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SimpleChatRoom.ViewModels;
    using SimpleChatRooms.Data;
    using SimpleChatRooms.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public MessagesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "All")]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByCreatedOnAscending()
        {
            return this.dbContext.Messages.OrderBy(x => x.CreatedOn).ToList();
        }

        [HttpPost(Name = "Create")]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreateBindingModel messageCreateBindingModel)
        {
            Message message = new Message
            {
                Content = messageCreateBindingModel.Content,
                User = messageCreateBindingModel.User,
                CreatedOn = DateTime.UtcNow
            };

            await this.dbContext.Messages.AddAsync(message);
            await this.dbContext.SaveChangesAsync();

            return this.Ok();
        }
    }
}
