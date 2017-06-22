using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    class Channel:ModelObject
    {
        private Generator CompleteTimeGenerator {get; set; }

        private double CurrentRequestCompleteTime { get; set; }

        private int WorkStatesCount { get; set; }
        private int WaitStatesCount { get; set; }
        public override int GetState()
        {
                if(CurrentRequests.Count==0)
                {
                    return 0;
                }
                if(CanTranspose())
                {
                    return 1;
                } 
                return 2; 
        }
        public override bool CanAcceptRequest()
        {
            return CurrentRequests.Count == 0;      
        }

        public override void AcceptRequest(Request request)
        {
            CurrentRequests.Add(request);
            request.CurrentObject=this;
            CurrentRequestCompleteTime=Node.Phase.Model.CurrentTime+CompleteTimeGenerator.GetNext();
        }

        public override void TransposeRequest(Request request)
        {
            request.PhasesTimes.Add(Node.Phase.Model.CurrentTime);
            base.TransposeRequest(request);
        }

        public override List<Object> GetStatistics()
        {         
                var result = new List<Object>();
                result.Add(WorkStatesCount);
                result.Add(WaitStatesCount);
                return result;           
        }

        public override void Refresh()
        {
            if(GetState()!=0)
            {
                if(GetState()==1)
                WorkStatesCount++;
                else
                {
                    WaitStatesCount++;
                }
                if (Node.Phase.Model.CurrentTime > CurrentRequestCompleteTime && CanTranspose())
                {
                    TransposeRequest(CurrentRequests.First());
                    CurrentRequests.Remove(CurrentRequests.First());
                }
            }         
        }
        public Channel(Object inicializeParameter):base (inicializeParameter)
        {
            CompleteTimeGenerator = (Generator)inicializeParameter;
        }
    }
}
