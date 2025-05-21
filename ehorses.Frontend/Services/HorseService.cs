using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ehorses.Models;

public class HorseService
{
    private readonly HttpClient _httpClient;

    public HorseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Alle Pferde abrufen
    public async Task<List<Horse>> GetAllHorsesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Horse>>("api/horses");
    }

    // Ein Pferd hinzufügen
    public async Task AddHorseAsync(Horse horse)
    {
        var response = await _httpClient.PostAsJsonAsync("api/horses", horse);
        response.EnsureSuccessStatusCode();
    }

    // Ein Pferd löschen
    public async Task DeleteHorseAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/horses/{id}");
        response.EnsureSuccessStatusCode();
    }
}