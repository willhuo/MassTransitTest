using MassTransit;
using MassTransitTest.Mqs;
using TN.Message;

namespace MassTransitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("admin");
                    h.Password("admin");
                });

                cfg.ReceiveEndpoint(ep =>
                {
                    ep.Consumer<YourMessageConsumer>();
                });

                //cfg.ReceiveEndpoint("your_queue_name", ep =>
                //{
                //    ep.Consumer<YourMessageConsumer>();
                //});
            });

            busControl.Start();
            Console.WriteLine("bus start");

            try
            {
                Console.WriteLine("ready to pub mq msg");
                while (true)
                {                   
                    //busControl.Publish(new ITerminalRun
                    //{
                    //    TerminalNo = "0001282200000003",
                    //    Time=DateTime.Now,
                    //    Run=true
                    //});
                    //Console.WriteLine("mq msg pub over");
                    //Console.WriteLine("-------------------------");
                    Task.Delay(5000).Wait();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class YourMessageConsumer : IConsumer<ITerminalRun>
    {
        public Task Consume(ConsumeContext<ITerminalRun> context)
        {
            Console.WriteLine($"Received message: {context.Message.TerminalNo}");
            return Task.CompletedTask;
        }
    }
}
