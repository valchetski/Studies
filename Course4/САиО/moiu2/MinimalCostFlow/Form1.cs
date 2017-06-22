using System;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using Extensions.GraphHelper;

namespace MinimalCostFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*var from = new[] { 1, 6, 2, 6, 6, 3, 5, 5, 3 };
            var to = new[]   { 2, 1, 6, 5, 3, 2, 3, 4, 4 };
            var flow = new[] { 1, 0, 0, 0, 9, 3, 0, 5, 1 };
            var cost = new[] { 1, -2, 3, 4, 3, 3, 4, 1, 5 };*/

            var from = new[] { 1, 1, 2, 2, 2, 3, 4, 5, 6, 7, 7, 7, 7, 8, 8, 9 };
            var to = new[]   { 2, 8, 7, 6, 3, 9, 3, 4, 5, 3, 4, 9, 5, 7, 9, 6 };
            var flow = new[] { 2, 7, 3, 0, 4, 0, 0, 3, 4, 0, 0, 0, 5, 0, 0, 2 };
            var cost = new[] { 9, 5, 5, 3, 1, -2, -3, 6, 8, -1, 4, 1, 7, 2, 2, 6 };

            VerticiesCountTextBox.Text = from.Max().ToString();
            EdgesCountTextBox.Text = from.Length.ToString();

            UiHelper.FillDataGridView(FromVerticiesDataGridView, from);
            UiHelper.FillDataGridView(ToVerticiesDataGridView, to);
            UiHelper.FillDataGridView(FlowDataGridView, flow);
            UiHelper.FillDataGridView(CostDataGridView, cost);
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var from = UiHelper.GetVector<int>(FromVerticiesDataGridView);
            var to = UiHelper.GetVector<int>(ToVerticiesDataGridView);
            var flow = UiHelper.GetVector<int>(FlowDataGridView);
            var cost = UiHelper.GetVector<int>(CostDataGridView);

            var verticiesCount = Convert.ToInt32(VerticiesCountTextBox.Text);
            var edgesCount = Convert.ToInt32(EdgesCountTextBox.Text);

            var minimalCostTask = new MinimalCostFlow(verticiesCount);

            for (var i = 0; i < edgesCount; i++)
            {
                minimalCostTask.Graph.AddEdge(new Edge { From = minimalCostTask.Graph.GetVertex(from[i]), To = minimalCostTask.Graph.GetVertex(to[i]), Flow = flow[i], Cost = cost[i] });
            }

            minimalCostTask.SolveMinimalCostFlowTask();

            DetailedSolutionrichTextBox.Text = minimalCostTask.DetailedSolutionMinimalCostFlow;
        }

        private void VerticiesCountTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int verticiesCount;
            if (int.TryParse(text, out verticiesCount))
            {

            }
            else if(!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = UiHelper.GetVector<int>(FromVerticiesDataGridView).Max().ToString();
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
                UiHelper.ChangeRowCount<int>(CostDataGridView, edgesCount);
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox) sender).Text = UiHelper.GetVector<int>(FromVerticiesDataGridView).Length.ToString();
            }
        }
    }
}
