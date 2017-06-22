using System;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using Extensions.GraphHelper;

namespace MaximalFlowTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var from = new[] { 6, 6, 1, 1, 3, 3, 2, 2, 4, 4, 5 };
            var to = new[] { 1, 3, 3, 4, 2, 5, 4, 5, 7, 5, 7 };
            var flow = new[] { 4, 5, 2, 2, 1, 6, 1, 0, 2, 1, 7 };
            var capacity = new[] { 4, 9, 2, 4, 1, 6, 1, 10, 2, 1, 9 };

            VerticiesCountTextBox.Text = to.Max().ToString();
            EdgesCountTextBox.Text = from.Length.ToString();

            UiHelper.FillDataGridView(FromVerticiesDataGridView, from);
            UiHelper.FillDataGridView(ToVerticiesDataGridView, to);
            UiHelper.FillDataGridView(FlowDataGridView, flow);
            UiHelper.FillDataGridView(CapacityDataGridView, capacity);
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var from = UiHelper.GetVector<int>(FromVerticiesDataGridView);
            var to = UiHelper.GetVector<int>(ToVerticiesDataGridView);
            var flow = UiHelper.GetVector<int>(FlowDataGridView);
            var capacity = UiHelper.GetVector<int>(CapacityDataGridView);

            var verticiesCount = Convert.ToInt32(VerticiesCountTextBox.Text);
            var edgesCount = Convert.ToInt32(EdgesCountTextBox.Text);

            var maximalFlowTask = new MaximalFlow(verticiesCount);

            for (var i = 0; i < edgesCount; i++)
            {
                maximalFlowTask.Graph.AddEdge(new Edge { From = maximalFlowTask.Graph.GetVertex(from[i]), To = maximalFlowTask.Graph.GetVertex(to[i]), Flow = flow[i], Capacity = capacity[i] });
            }
            //TODO: think how to enter S and T verticies
            var S = 6;//change when choose new graph
            var T = 7;

            maximalFlowTask.FindMaximalFlow(maximalFlowTask.Graph.GetVertex(S), maximalFlowTask.Graph.GetVertex(T));

            DetailedSolutionrichTextBox.Text = maximalFlowTask.Graph.ToString();

            var s = maximalFlowTask.Graph.GetIncidentalEdges(maximalFlowTask.Graph.GetVertex(T)).Cast<Edge>().Sum(edge => edge.Flow);
            DetailedSolutionrichTextBox.Text += $"\nFlow: {s}";
        }

        private void VerticiesCountTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int verticiesCount;
            if (int.TryParse(text, out verticiesCount))
            {

            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = UiHelper.GetVector<int>(ToVerticiesDataGridView).Max().ToString();
            }
        }

        private void EdgesCountTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int edgesCount;
            if (int.TryParse(text, out edgesCount))
            {
                UiHelper.ChangeRowCount<int>(FromVerticiesDataGridView, edgesCount);
                UiHelper.ChangeRowCount<int>(ToVerticiesDataGridView, edgesCount);
                UiHelper.ChangeRowCount<int>(FlowDataGridView, edgesCount);
                UiHelper.ChangeRowCount<int>(CapacityDataGridView, edgesCount);
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = UiHelper.GetVector<int>(FromVerticiesDataGridView).Length.ToString();
            }
        }
    }
}
