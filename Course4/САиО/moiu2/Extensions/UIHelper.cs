using System;
using System.Windows.Forms;

namespace Extensions
{
    public static class UiHelper
    {
        private static readonly Random Random = new Random();

        #region FillDataGridView

        public static void FillDataGridView(DataGridView dataGridView, int rowsCount, int columnsCount)
        {
            //Random random = new Random();
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            for (var i = 0; i < columnsCount; i++)
            {
                dataGridView.Columns.Add("", "");
            }
            dataGridView.Rows.Add(rowsCount - 1);

            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    dataGridView[j, i].Value = Random.Next(10);
                }
            }
        }

        public static void FillDataGridView<T>(DataGridView dataGridView, T[,] matrix)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            var rowsCount = matrix.GetLength(0);
            var columnsCount = matrix.GetLength(1);

            for (var i = 0; i < columnsCount; i++)
            {
                dataGridView.Columns.Add("", "");
            }
            if (rowsCount > 0)
            {
                dataGridView.Rows.Add(rowsCount);
            }

            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    dataGridView[j, i].Value = matrix[i, j];
                }
            }
        }

        public static void FillDataGridView<T>(DataGridView dataGridView, T[] vector)
        {
            var matrix = new T[vector.GetLength(0), 1];
            for (var i = 0; i < vector.GetLength(0); i++)
            {
                matrix[i, 0] = vector[i];
            }
            FillDataGridView(dataGridView, matrix);
        }


        #endregion

        #region Get Vector or Matrix

        public static T[] GetVector<T>(DataGridView dataGridView)
        {
            var matrix = GetMatrix<T>(dataGridView);
            var vector = new T[matrix.GetLength(0)];
            for (var i = 0; i < vector.GetLength(0); i++)
            {
                vector[i] = matrix[i, 0];
            }
            return vector;
        }


        public static T[,] GetMatrix<T>(DataGridView dataGridView)
        {
            var m = new T[dataGridView.RowCount, dataGridView.ColumnCount];
            for (var i = 0; i < m.GetLength(0); i++)
            {
                for (var j = 0; j < m.GetLength(1); j++)
                {
                    m[i, j] = (T)Convert.ChangeType(dataGridView[j, i].Value == "*" ? int.MaxValue : dataGridView[j, i].Value, typeof(T)); //check work
                }
            }
            return m;
        }

        #endregion

        #region Change count of row or columns in DataGridView

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of data stored in DataGridView</typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="rowCount"></param>
        public static void ChangeRowCount<T>(DataGridView dataGridView, int rowCount)
        {
            var currentRowCount = dataGridView.RowCount;
            if (dataGridView.ColumnCount > 0)
            {
                if (rowCount > currentRowCount)
                {
                    for (var i = 0; i < rowCount - currentRowCount; i++)
                    {
                        dataGridView.Rows.Add();

                        var valuesCount = dataGridView.ColumnCount;
                        var randomValues = GetRandomValues<T>(valuesCount);

                        for (var j = 0; j < valuesCount; j++)
                        {
                            dataGridView.Rows[dataGridView.RowCount - 1].Cells[j].Value = randomValues[j];
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < currentRowCount - rowCount; i++)
                    {
                        dataGridView.Rows.RemoveAt(dataGridView.RowCount - 1);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of data stored in DataGridView</typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="columnCount"></param>
        public static void ChangeColumnCount<T>(DataGridView dataGridView, int columnCount)
        {
            var currentColumnCount = dataGridView.ColumnCount;
            if (dataGridView.ColumnCount > 0)
            {
                if (columnCount > currentColumnCount)
                {
                    for (var i = 0; i < columnCount - currentColumnCount; i++)
                    {
                        dataGridView.Columns.Add("", "");

                        var valuesCount = dataGridView.RowCount;
                        var randomValues = GetRandomValues<T>(valuesCount);

                        for (var j = 0; j < valuesCount; j++)
                        {
                            dataGridView[dataGridView.ColumnCount - 1, j].Value = randomValues[j];
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < currentColumnCount - columnCount; i++)
                    {
                        dataGridView.Columns.RemoveAt(dataGridView.ColumnCount - 1);
                    }
                }
            }
        }

        private static string[] GetRandomValues<T>(int valuesCount)
        {
            var randomValues = new string[valuesCount];
            if (typeof(T) == typeof(int))
            {
                for (var i = 0; i < valuesCount; i++)
                {
                    randomValues[i] = Random.Next(1, 10).ToString();
                }
            }
            else
            {
                for (var i = 0; i < valuesCount; i++)
                {
                    randomValues[i] = "<=";
                }
            }
            return randomValues;
        }

        #endregion
    }
}
