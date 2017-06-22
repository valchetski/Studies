namespace Extensions.GraphHelper
{
    public class Vertex
    {
        private static int _lastId = 1;
        public int Id;
        public int? Potential;
        public int G, P;

        public static void ResetIndexes()
        {
            _lastId = 1;
        }

        public Vertex()
        {
            Id = _lastId++;
        }

        public override string ToString()
        {
            return $"Vertex {Id}  Potential={Potential}  P={P}  G={G}";
        }
    }
}
