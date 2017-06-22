using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class RequestQueye:ModelObject
    {
        private int Capacity { get; set; }

        public override bool CanAcceptRequest()
        {
             return CurrentRequests.Count < Capacity; 
        }
        public override int GetState()
        {
                return CurrentRequests.Count;
        }

        public override void AcceptRequest(Request request)
        {
            CurrentRequests.Add(request);
            request.CurrentObject = this;
        }

        public override void TransposeRequest(Request request)
        {
            base.TransposeRequest(request);
            CurrentRequests.Remove(request);
        }

        public override void Refresh()
        {
                while (CanTranspose() && CurrentRequests.Count > 0)
                {
                        TransposeRequest(CurrentRequests.Last());
                }
        }
        public RequestQueye(Object inicializeParameter):base(inicializeParameter)
        {
            Capacity = (int)inicializeParameter;
        }
    }
}
