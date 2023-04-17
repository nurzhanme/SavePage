using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SavePage.Requests;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace SavePage
{
    public class SavePageClient
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        [ActivatorUtilitiesConstructor]
        public SavePageClient(IOptions<SavePageOptions> options, HttpClient httpClient) : this(options.Value, httpClient)
        {
        }

        public SavePageClient(SavePageOptions options, HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri(string.IsNullOrWhiteSpace(options.ApiBaseAddress) ? "https://api.savepage.io/v1/" : options.ApiBaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

            if (string.IsNullOrWhiteSpace(options.ApiKey))
            {
                throw new ArgumentException(nameof(options.ApiKey));
            }
            _apiKey = options.ApiKey;
        }

        public async Task<byte[]> GetAsync(string q, RequestOptionalParams? request = null)
        {
            q = WebUtility.UrlEncode(q);

            var queryBuilder = new StringBuilder($"?key={_apiKey}&{nameof(q)}={q}");

            if (request != null)
            {
                if (request.Width.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Width).ToLower()}={request.Width.Value}");
                }

                if (request.Height.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Height).ToLower()}={request.Height.Value}");
                }

                if (request.Fullpage.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Fullpage).ToLower()}={request.Fullpage.Value.ToString().ToLower()}");
                }

                if (request.Thumb_width.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Thumb_width).ToLower()}={request.Thumb_width.Value}");
                }

                if (request.Delay.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Delay).ToLower()}={request.Delay.Value}");
                }

                if (request.Nocookie.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Nocookie).ToLower()}={request.Nocookie.Value.ToString().ToLower()}");
                }

                if (request.Noads.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Noads).ToLower()}={request.Noads.Value.ToString().ToLower()}");
                }

                if (request.Format.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Format).ToLower()}={request.Format.Value.ToString().ToLower()}");
                }

                if (request.Refresh.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Refresh).ToLower()}={request.Refresh.Value}");
                }

                if (!string.IsNullOrEmpty(request.User_agent))
                {
                    queryBuilder.Append($"&{nameof(request.User_agent).ToLower()}={WebUtility.UrlEncode(request.User_agent)}");
                }

                if (!string.IsNullOrEmpty(request.Accept_language))
                {
                    queryBuilder.Append($"&{nameof(request.Accept_language).ToLower()}={request.Accept_language}");
                }

                if (request.Maxage.HasValue)
                {
                    queryBuilder.Append($"&{nameof(request.Maxage).ToLower()}={request.Maxage.Value}");
                }

                if (!string.IsNullOrEmpty(request.Cookie))
                {
                    queryBuilder.Append($"&{nameof(request.Cookie).ToLower()}={request.Cookie}");
                }

                if (!string.IsNullOrEmpty(request.Hash))
                {
                    queryBuilder.Append($"&{nameof(request.Hash).ToLower()}={request.Hash}");
                }
            }

            var response = await _httpClient.GetAsync(queryBuilder.ToString()).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        
            return data;
        }
    }
}