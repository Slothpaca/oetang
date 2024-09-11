using System.Text.Json;
using TimesheetApp.Client.Models;

namespace TimesheetApp.Client.ApiServices;

public interface IUserApiService
{
    Task<UserModel> GetUser(int id);
}

public class UserApiService : IUserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<UserModel> GetUser(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5021/User/{id}");
        response.EnsureSuccessStatusCode();

        var contentStream = await response.Content.ReadAsStreamAsync();
        var userModel = await JsonSerializer.DeserializeAsync<UserModel>(contentStream);
        
        return userModel;
    }
}

