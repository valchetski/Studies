using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOD_Lab6
{
    public class Phase
    {
        public Model Model { get; set; }
        public int Order { get; set; }
        public List<PhaseNode> Nodes { get; set; }

        public List<Request> CurrentRequests
        {
            get
            {
                var result = new List<Request>();
               Nodes.ForEach(node => result.AddRange(node.CurrentRequests));
                return result;
            }
        }

        public void AttachNode(PhaseNode node)
        {
            Nodes.Add(node);
            node.Phase = this;
        }

        public void Refresh()
        {
            int i = Nodes.Count - 1;
            while (i >= 0)
            {
                Nodes[i].Refresh();
                i--;
            }
        }

        public Phase()
        {
            Nodes = new List<PhaseNode>();
        }
    }
}
