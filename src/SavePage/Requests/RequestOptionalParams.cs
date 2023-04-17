namespace SavePage.Requests
{
    public class RequestOptionalParams
    {
        /// <summary>
        /// Page viewport width in pixels
        /// Example: 800
        /// Default: 1440
        /// Plans: Basic/Pro
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Page viewport height in pixels
        /// Example: 600
        /// Default: 900
        /// Plans: Basic/Pro
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Request full page render
        /// Example: true
        /// Default: false
        /// Plans: Basic/Pro
        /// </summary>
        public bool? Fullpage { get; set; }

        /// <summary>
        /// Resize screenshot image based on width in pixels
        /// Example: 400
        /// Default: -
        /// Plans: Basic/Pro
        /// </summary>
        public int? Thumb_width { get; set; }

        /// <summary>
        /// Wait for the specified number of seconds after the webpage has loaded
        /// Example: 2
        /// Default: 0
        /// Plans: Basic/Pro
        /// </summary>
        public int? Delay { get; set; }

        /// <summary>
        /// Prevent cookie banners and popups from being displayed
        /// Example: true
        /// Default: false
        /// Plans: All
        /// </summary>
        public bool? Nocookie { get; set; }

        /// <summary>
        /// Prevent ads, tracking, and analytics code
        /// Example: true
        /// Default: false
        /// Plans: All
        /// </summary>
        public bool? Noads { get; set; }

        /// <summary>
        /// Image format, jpeg or png are accepted
        /// Example: jpeg
        /// Default: jpeg
        /// Plans: All
        /// </summary>
        public Format? Format { get; set; }

        /// <summary>
        /// Refresh the screenshot if the cached version is older than n seconds
        /// Example: 3600
        /// Default: -
        /// Plans: All
        /// </summary>
        public int? Refresh { get; set; }

        /// <summary>
        /// Custom User-Agent header
        /// Example: Firefox 77
        /// Default: -
        /// Plans: All
        /// </summary>
        public string? User_agent { get; set; }

        /// <summary>
        /// Custom Accept-Language header
        /// Example: en-US
        /// Default: -
        /// Plans: All
        /// </summary>
        public string? Accept_language { get; set; }

        /// <summary>
        /// Specify the time in seconds for Cache-Control response header
        /// Limited to POST requests for security reasons. This data should be sent in the POST request body
        /// Currently not supported by library - only get request (Author)
        /// Example: 3600
        /// Default: -
        /// Plans: All
        /// </summary>
        public int? Maxage { get; set; }

        /// <summary>
        /// Pass login or other information stored in the Cookie data
        /// Example: 600
        /// Default: 900
        /// Plans: All
        /// </summary>
        public string? Cookie { get; set; }

        /// <summary>
        /// Required when using API Secret word, md5(URL+APISecret)
        /// Example: 8udI3nt3xidnwq90In
        /// Default: -
        /// Plans: All
        /// </summary>
        public string? Hash { get; set; }
    }

    public enum Format
    {
        Jpeg,
        Png
    }
}