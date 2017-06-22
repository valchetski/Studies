using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class PhaseNode
    {       
        public Phase Phase { get; set; }
        public int Order { get; set; }
        public List<Request> CurrentRequests 
        {
            get
            {
                var result = new List<Request>();
                Objects.ForEach(obj => result.AddRange(obj.CurrentRequests));
                return result;
            }
        }
        public List<ModelObject> Objects { get; set; }

        public void AcceptRequest(Request request)
        {
            int i = 0;
            while(Objects[i].CanAcceptRequest()!=true)
            {
                i++;
            }
            Objects[i].AcceptRequest(request);
        }
        public bool CanAcceptRequest() 
        {
                var result = false;
                int i = 0;
                while(i<Objects.Count)
                {
                    result = result || Objects[i].CanAcceptRequest();
                    i++;
                }
                return result;
        }
        public PhaseNode NextNode() 
        {
            
                var nextInPhaseNode = Phase.Nodes.FirstOrDefault(node => node.Order == Order + 1);
                if (nextInPhaseNode!=null)
                {
                    return nextInPhaseNode;
                }
                else
                {
                    var NextPhase=Phase.Model.Phases.FirstOrDefault(phase=>phase.Order==Phase.Order+1);
                    if(NextPhase!=null && NextPhase.Nodes.Count!=0)
                    {
                        return NextPhase.Nodes.First();
                    }
                    else
                    { 
                        return null; 
                    }
                }
            
        }

        public void AttachObject(ModelObject modelObject)
        {
            Objects.Add(modelObject);
            modelObject.Node = this;
        }


        public void Refresh()
        {
            int i = Objects.Count - 1;
            while (i >= 0)
            {
                Objects[i].Refresh();
                i--;
            }
        }
        public PhaseNode()
        {
            Objects = new List<ModelObject>();
        }

    }
}
