using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class Model
    {
        
        public double CurrentTime { get; set; }
        public double TimeStep { get; set; }
        public double ModulationCompleteTime { get; set; }
        public int TotalRequests { get; set; }
        public int RequestsLeft { get; set; }
        public int Step { get; set; }
        public Generator RequestGenerator { get; set; }
        public List<Phase> Phases { get; set; }

        public List<Request> CompletedRequests { get; set; }
        public List<Request> DeclinedRequests { get; set; }

        public List<Request> CurrentRequests
        {
            get
            {
                var result = new List<Request>();
                Phases.ForEach(phase => result.AddRange(phase.CurrentRequests));
                return result;
            }
        }

        public void AttachPhase(Phase phase)
        {
            Phases.Add(phase);
            phase.Model = this;
        }

        public void Refresh()
        {
            int i = Phases.Count - 1;
            while (i>=0)
            {
                Phases[i].Refresh();
                i--;
            }
        }

        public void Modulate()
        {
            var nextRequestTime = CurrentTime + RequestGenerator.GetNext();
            while(CompletedRequests.Count+DeclinedRequests.Count!=TotalRequests)
            {
                if(CurrentTime>nextRequestTime && RequestsLeft>0)
                {
                    var newRequest=new Request{StartTime=CurrentTime};
                    var firstNode=Phases.First(phase=>phase.Order==1).Nodes.First(node=>node.Order==1);
                    if(firstNode.CanAcceptRequest())
                    {
                        firstNode.AcceptRequest(newRequest);
                        //Console.Write("+");
                    }
                    else
                    {
                        newRequest.IsCompleted = false;
                        newRequest.CompleteTime = CurrentTime;
                        DeclinedRequests.Add(newRequest);
                        //Console.Write("-");
                    }
                    nextRequestTime = CurrentTime + RequestGenerator.GetNext();
                    RequestsLeft--;
                }
                Refresh();
                CurrentTime = CurrentTime + TimeStep;
                Step++;
            }
        }

        public Model()
        {
            Phases = new List<Phase>();
            CompletedRequests = new List<Request>();
            DeclinedRequests = new List<Request>();           
        }
        
    }
}
