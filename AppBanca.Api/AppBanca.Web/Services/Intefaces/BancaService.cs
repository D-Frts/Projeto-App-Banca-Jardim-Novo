using System.Net.Http.Json;

namespace AppBanca.Web.Services.Intefaces;

public abstract class BancaService<T> : IBancaService<T> where T : class
{
    private readonly HttpClient httpClient;
    private readonly ILogger<BancaService<T>> logger;

    public BancaService(HttpClient httpClient, ILogger<BancaService<T>> logger)
    {
        this.httpClient = httpClient;
        this.logger = logger;
    }

    public async Task AddItem(T item, string uri)
    {
        try
        {
            await httpClient.PostAsJsonAsync<T>(uri, item);
            return;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public virtual async Task DeleteItem(string uri)
    {
        try
        {
            await httpClient.DeleteAsync(uri);            

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<T> GetItem(int id, string uri)
    {
        try
        {
            var item = await httpClient.GetFromJsonAsync<T>(uri);
            return item;

        }
        catch (Exception ex)
        {
            logger.LogError($"Erro ao tentar acessar: {uri}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetItems(string uri)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<T>>(uri);
            
        }
        catch (Exception ex)
        {
            logger.LogError($"Erro ao tentar acessar: {uri}", ex.Message);
            throw;
        }
    }

    public virtual async Task UpdateItem(T obj, string uri)
    {
        await httpClient.PutAsJsonAsync<T>(uri, obj);
    }
}
