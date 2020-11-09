using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using wf_ui.Models;

namespace wf_ui.Data
{
    public class HistoryService
    {
        private readonly ILogger<HistoryService> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public HistoryService(ILogger<HistoryService> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<List<ServiceTask>> GetServiceTaskStates()
        {
            var http = _clientFactory.CreateClient("WorkflowService");
            var result = await http.GetStringAsync("/history/servicetasks");

            _logger.LogDebug($"Raw Result from API /history/servicetasks: {result}");
            return JsonSerializer.Deserialize<List<ServiceTask>>(result);
        }
    }
}