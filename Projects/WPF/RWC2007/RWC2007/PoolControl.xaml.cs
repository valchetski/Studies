using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using RWC2007.Plays;

namespace RWC2007
{
    
    public partial class PoolControl
    {
        private string pool;
        public string Pool
        {
            get
            {
                return pool; 
            }
            set
            {
                pool = value;
                Initialize();
            }
        }
        public PoolControl()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            PoolGroupBox.Header = "Pool " + pool;
            FillPoolDataGrid();
            FillPoolResultsDataGrid();
        }

        private void FillPoolDataGrid()
        {
            PoolDataGrid.Columns.Clear();

            List<string> teams = TeamPool.GetTeamsByPool(pool);

            const int width = 80;
            for (int i = 0; i < teams.Count + 1; i++)
            {
                var column = new DataGridTextColumn
                {
                    Header = i != 0 ? teams[i-1] : "",
                    Binding = new Binding($"[{i}]"),
                    MinWidth = width,
                    MaxWidth = width,
                    Width = width,
                };
                PoolDataGrid.Columns.Add(column);
            }

            var rows = new List<object>();
            for (int i = 0; i < teams.Count; i++)
            {
                var row = new string[teams.Count + 1];
                row[0] = teams[i];
                for (int j = 1; j < row.Length; j++)
                {
                    if (j == i + 1)
                    {
                        row[j] = "X";
                    }
                    else
                    {
                        row[j] = GameResultForTeam.GetGoals(teams[i], teams[j - 1]);
                    }
                }
                rows.Add(row);
            }
            PoolDataGrid.ItemsSource = rows;
        }

        private void FillPoolResultsDataGrid()
        {
            PoolResultsDataGrid.Columns.Clear();

            const int width = 80;
            var headers = new[] {"Team", "Points"};
            for (int i = 0; i < headers.Length; i++)
            {
                var column = new DataGridTextColumn
                {
                    Header = headers[i],
                    Binding = new Binding($"[{i}]"),
                    MinWidth = width,
                    MaxWidth = width,
                    Width = width,
                };
                PoolResultsDataGrid.Columns.Add(column);
            }

            IOrderedEnumerable<KeyValuePair<string, int>> teamsAndPoints = Game.GetTeamsAndPoints(Pool);

            var rows = new List<object>();
            foreach (var item in teamsAndPoints)
            {
                var row = new string[headers.Length];
                row[0] = item.Key;
                row[1] = item.Value.ToString();
                rows.Add(row);
            }
            
            PoolResultsDataGrid.ItemsSource = rows;
        }

        private void PoolDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            DataGridCellInfo dataGridCellInfo = dataGrid.SelectedCells[0];
            var row = (string[]) dataGridCellInfo.Item;

            int rowIndex = dataGrid.Items.IndexOf(row);
            int columnIndex = dataGridCellInfo.Column.DisplayIndex;

            if (columnIndex != 0 && rowIndex != columnIndex - 1)
            {
                string firstTeam = row[0];
                string secondTeam = ((string[]) dataGrid.Items[columnIndex - 1])[0];

                GameResultWindow gameResultWindow = new GameResultWindow(firstTeam, secondTeam, Pool);
                gameResultWindow.ShowDialog();

                FillPoolDataGrid();
                FillPoolResultsDataGrid();
            }

        }
    }
}
