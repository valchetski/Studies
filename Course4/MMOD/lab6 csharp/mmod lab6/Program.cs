using System;
using System.Collections.Generic;
using System.Linq;

namespace MMOD_Lab6
{
    class Program
    {
        static void Main()
        {
            Model model = new Model
            {
                RequestGenerator = new ExponentialGenerator(new List<double> {1}),
                TimeStep = 0.01,
                TotalRequests = 1000,
                RequestsLeft = 1000
            };

            var firstGenerator = new OrdinarGenerator(new List<double> { 3, 9 });
            PhaseNode firstNode = new PhaseNode() { Order = 1 };
            firstNode.AttachObject(new RequestQueye(3));
            PhaseNode secondNode = new PhaseNode() { Order = 2 };
            secondNode.AttachObject(new Channel(firstGenerator));
            secondNode.AttachObject(new Channel(firstGenerator));
            secondNode.AttachObject(new Channel(firstGenerator));
            secondNode.AttachObject(new Channel(firstGenerator));
            secondNode.AttachObject(new Channel(firstGenerator));
            secondNode.AttachObject(new Channel(firstGenerator));
            Phase FirstPhase = new Phase() { Order = 1 };
            FirstPhase.AttachNode(firstNode);
            FirstPhase.AttachNode(secondNode);

            PhaseNode ThirdNodeQue = new PhaseNode() { Order = 1 };
            ThirdNodeQue.AttachObject(new RequestQueye(6));
            PhaseNode ThirdNode = new PhaseNode() { Order = 2 };
            var gauseGenerator = new GauseGenerator(new List<double> { 5, 1 });
            ThirdNode.AttachObject(new Channel(gauseGenerator));
            ThirdNode.AttachObject(new Channel(gauseGenerator));
            ThirdNode.AttachObject(new Channel(gauseGenerator));
            ThirdNode.AttachObject(new Channel(gauseGenerator));
            ThirdNode.AttachObject(new Channel(gauseGenerator));
            Phase SecondPhase = new Phase() { Order = 2 };
            SecondPhase.AttachNode(ThirdNodeQue);
            SecondPhase.AttachNode(ThirdNode);

            PhaseNode FourNode = new PhaseNode() { Order = 2 };
            var ThirdGenerator = new GauseGenerator(new List<double> { 5, 2 });
            FourNode.AttachObject(new Channel(ThirdGenerator));
            FourNode.AttachObject(new Channel(ThirdGenerator));
            FourNode.AttachObject(new Channel(ThirdGenerator));
            FourNode.AttachObject(new Channel(ThirdGenerator));
            FourNode.AttachObject(new Channel(ThirdGenerator));
            PhaseNode FourNodeTwo = new PhaseNode() { Order = 1 };
            FourNodeTwo.AttachObject(new RequestQueye(4));
            Phase ThirdPhase = new Phase() { Order = 3 };
            ThirdPhase.AttachNode(FourNodeTwo);
            ThirdPhase.AttachNode(FourNode);

            PhaseNode FiveNode = new PhaseNode() { Order = 1 };
            FiveNode.AttachObject(new RequestQueye(3));
            PhaseNode SixNode = new PhaseNode() { Order = 2 };
            SixNode.AttachObject(new Channel(gauseGenerator));
            SixNode.AttachObject(new Channel(gauseGenerator));
            SixNode.AttachObject(new Channel(gauseGenerator));
            SixNode.AttachObject(new Channel(gauseGenerator));
            SixNode.AttachObject(new Channel(gauseGenerator));
            SixNode.AttachObject(new Channel(gauseGenerator));
            Phase FourPhase = new Phase() { Order = 4 };
            FourPhase.AttachNode(FiveNode);
            FourPhase.AttachNode(SixNode);

            PhaseNode SevenNode = new PhaseNode() { Order = 1 };
            SevenNode.AttachObject(new RequestQueye(4));
            var generator = new TriangularGenerator(new List<double> { 2, 5 });
            //var generator = new TriangularGenerator(new List<double> { 2, 5 });
            var gauseGen2 = new GauseGenerator(new List<double> { 20, 1 });
            PhaseNode EightNode = new PhaseNode() { Order = 2 };
            EightNode.AttachObject(new Channel(gauseGen2));
            EightNode.AttachObject(new Channel(gauseGen2));
            EightNode.AttachObject(new Channel(gauseGen2));
            EightNode.AttachObject(new Channel(gauseGen2));
            EightNode.AttachObject(new Channel(gauseGen2));
            Phase FivePhase = new Phase() { Order = 5 };
            FivePhase.AttachNode(SevenNode);
            FivePhase.AttachNode(EightNode);

            model.AttachPhase(FirstPhase);
            model.AttachPhase(SecondPhase);
            model.AttachPhase(ThirdPhase);
            model.AttachPhase(FourPhase);
            model.AttachPhase(FivePhase);
            model.Modulate();

            Console.WriteLine("Количество заявок: {0}", model.TotalRequests);
            Console.WriteLine("Обслужено заявок: {0}", model.CompletedRequests.Count);
            Console.WriteLine("Потерянные (отказанные) заявки: {0}", model.DeclinedRequests.Count);
            Console.WriteLine("Процент завершенных заявок: {0}%", ((double)model.CompletedRequests.Count) / model.TotalRequests * 100);

            var channels = (from phase in model.Phases from phaseNode in phase.Nodes from obj in phaseNode.Objects select obj).OfType<Channel>().ToList();

            int i = 1;
            while (i <= model.Phases.Count)
            {
                var PhaseChannels = channels.Where(ch => ch.Node.Phase.Order == i);
                double WorkTime = 0;
                foreach (var chanel in PhaseChannels)
                {
                    var workCount = (double)((int)chanel.GetStatistics()[0]);
                    var waitCount = (double)((int)chanel.GetStatistics()[1]);
                    Console.WriteLine("[Фаза {0}] канал обработал = {1}%, ожидание  = {2}%", chanel.Node.Phase.Order, (workCount / model.Step * 100).ToString("#.##"), (waitCount / model.Step * 100));
                    WorkTime += workCount;
                }

                var PhaseLoad = WorkTime / model.Step / PhaseChannels.Count();
                Console.WriteLine("[Фаза {0}] загрузка = {1}%", i, PhaseLoad * 100);
                i++;
            }
            Console.ReadLine();

        }
    }
}
