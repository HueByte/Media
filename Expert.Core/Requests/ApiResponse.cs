using System.Text.Json.Serialization;

namespace Expert.Core.Requests
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<string>? Errors { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        private ApiResponse(T? data, List<string>? errors, string? message) 
        {
            Data = data;
            Errors = errors;
            Message = message;
        }

        public static ApiResponse<T> Create(T? data, List<string>? errors = null, string? message = null) 
        {
            return new ApiResponse<T>(data, errors, message);
        }
    }
}
