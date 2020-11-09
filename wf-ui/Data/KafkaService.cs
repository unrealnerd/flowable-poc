using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace wf_ui.Data
{
    public class KafkaService : IDisposable
    {
        public IProducer<Null, string> Producer { get; set; }

        public KafkaService()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            Producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task Send(string message)
        {
            try
            {
                await Producer.ProduceAsync("article", new Message<Null, string> { Value = message });
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"{ex.Message}: \n {ex}");
            }
        }

        public void Dispose()
        {
            Producer.Dispose();
        }
    }
}
