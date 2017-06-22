namespace Extensions.GraphHelper
{
    public class Edge
    {
        public Vertex From, To;
        public int Flow, Cost, Delta, Capacity;

        public override string ToString()
        {
            return $"Edge {From.Id}->{To.Id}  Flow={Flow}  Cost={Cost} Capacity = {Capacity}  Δ={Delta}";
        }
    }
}
