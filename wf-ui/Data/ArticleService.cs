using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using wf_ui.Models;

namespace wf_ui.Data
{
    public class ArticleService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly KafkaService _kafkaService;
        public ArticleService(IHttpClientFactory clientFactory, KafkaService kafkaService)
        {
            _clientFactory = clientFactory;
            _kafkaService = kafkaService;
        }

        public async Task SubmitArticleForReview(Article article)
        {
            await _kafkaService.Send(JsonSerializer.Serialize(article));
        }

        public async Task<List<Article>> GetArticlesForReviewAsync()
        {
            var http = _clientFactory.CreateClient("WorkflowService");
            var result = await http.GetStringAsync("/tasks?assignee=editors");

            return JsonSerializer.Deserialize<List<Article>>(result);
        }
        public async Task Approve(string id, bool state)
        {
            var http = _clientFactory.CreateClient("WorkflowService");
            var data = new StringContent(
                                JsonSerializer.Serialize(new { id, status = state }, null),
                                Encoding.UTF8,
                                "application/json");
            await http.PostAsync("/review", data);
        }

    }
}