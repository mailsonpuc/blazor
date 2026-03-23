using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace primeFlix.Services;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MovieService> _logger;
    private const string ApiBaseUrl = "https://api.themoviedb.org/3/";
    private const string ApiKey = "eeac4c9a0f1c7fcd156702106b123192";
    private const string Language = "pt-BR";

    public MovieService(HttpClient httpClient, ILogger<MovieService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<MovieResponse?> GetNowPlayingMovies(int page = 1)
    {
        try
        {
            var url = $"{ApiBaseUrl}movie/now_playing?api_key={ApiKey}&language={Language}&page={page}";
            _logger.LogInformation($"Requisitando: {url}");
            
            var response = await _httpClient.GetFromJsonAsync<MovieResponse>(url);
            
            if (response != null)
            {
                _logger.LogInformation($"Filmes em exibição carregados com sucesso. Total: {response.Results.Count}");
            }
            
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao buscar filmes em exibição: {ex.Message}");
            return null;
        }
    }

    public async Task<MovieResponse?> GetPopularMovies(int page = 1)
    {
        try
        {
            var url = $"{ApiBaseUrl}movie/popular?api_key={ApiKey}&language={Language}&page={page}";
            _logger.LogInformation($"Requisitando: {url}");
            
            var response = await _httpClient.GetFromJsonAsync<MovieResponse>(url);

            
            
            if (response != null)
            {
                _logger.LogInformation($"Filmes populares carregados com sucesso. Total: {response.Results.Count}");
            }
            
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao buscar filmes populares: {ex.Message}");
            return null;
        }
    }

    public async Task<MovieDetail?> GetMovieDetails(int movieId)
    {
        try
        {
            var url = $"{ApiBaseUrl}movie/{movieId}?api_key={ApiKey}&language={Language}";
            _logger.LogInformation($"Requisitando: {url}");
            
            var response = await _httpClient.GetFromJsonAsync<MovieDetail>(url);
            
            if (response != null)
            {
                _logger.LogInformation($"Detalhes do filme {movieId} carregados com sucesso.");
            }
            
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Erro ao buscar detalhes do filme {movieId}: {ex.Message}");
            return null;
        }
    }
}

public class MovieResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; } = new();
    
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}

public class Movie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("overview")]
    public string Overview { get; set; } = string.Empty;
    
    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = string.Empty;
    
    [JsonPropertyName("backdrop_path")]
    public string BackdropPath { get; set; } = string.Empty;
    
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;
    
    [JsonPropertyName("genre_ids")]
    public List<int> GenreIds { get; set; } = new();
    
    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }
    
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; } = string.Empty;
    
    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; } = string.Empty;
}

public class MovieDetail : Movie
{
    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; } = new();
    
    [JsonPropertyName("runtime")]
    public int Runtime { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
}

public class Genre
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
