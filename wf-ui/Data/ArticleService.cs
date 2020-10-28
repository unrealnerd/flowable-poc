using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace wf_ui.Data
{
    public class ArticleService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ArticleService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> SubmitArticleForReview()
        {
            var http = _clientFactory.CreateClient("WorkflowService");
            return await http.GetStringAsync("/tasks?assignee=editors");
        }


    }
}