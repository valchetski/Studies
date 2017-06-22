using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class ModelObject
    {
        public PhaseNode Node { get; set; }

        public virtual int GetState()
        {
            return -1;
        }
       
        public List<Request> CurrentRequests { get; set; }

        
        public  bool CanTranspose ()
        {
            var nextNode = Node.NextNode();
            if (nextNode == null)
            {
                return true;
            }
            return Node.NextNode().CanAcceptRequest();
        }
        public virtual void TransposeRequest(Request request)
        {
            var nextNode = Node.NextNode();
            if( nextNode != null)
            {
                nextNode.AcceptRequest(request);
            }
            else
            {
                request.IsCompleted = true;
                request.CompleteTime = Node.Phase.Model.CurrentTime;
                Node.Phase.Model.CompletedRequests.Add(request);
            }
        }

        public virtual bool CanAcceptRequest ()
        {
            return false;
        }
        public virtual void AcceptRequest(Request request)
        { }

        public virtual List<Object> GetStatistics()
        { return null; }

        public virtual void Refresh()
        { }
        public  ModelObject(Object inicializeParameter)
        {
            CurrentRequests = new List<Request>();
        }
    }
}
