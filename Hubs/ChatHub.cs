using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;
using RecipeCatalog.Model;

namespace RecipeCatalog.Hubs;

public class ChatHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> OnlineUsers = new();

    public override async Task OnConnectedAsync()
    {
        var username = Context.User?.Identity?.Name ?? Context.ConnectionId;
        OnlineUsers[Context.ConnectionId] = username;

        await Clients.All.SendAsync("UserListUpdate", OnlineUsers.Values.Distinct().ToList());
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        OnlineUsers.TryRemove(Context.ConnectionId, out _);
        await Clients.All.SendAsync("UserListUpdate", OnlineUsers.Values.Distinct().ToList());
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("Receive", user, message);
    }
    
    public async Task SendCategoryUpdate(Category category)
    {
        await Clients.All.SendAsync("CategoryUpdated", category);
    }
}