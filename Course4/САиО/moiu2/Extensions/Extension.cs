using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Extensions
{
    public static class Extension
    {
        public static DenseMatrix SelectColumns(this DenseMatrix mtx, IEnumerable<int> indexes)
        {
            var cols = indexes.Select(index => (DenseVector) mtx.Column(index)).ToList();
            return DenseMatrix.OfColumns(cols[0].Count, cols.Count, cols);
        }

        public static DenseMatrix SelectRows(this DenseMatrix mtx, IEnumerable<int> indexes)
        {
            var rows = indexes.Select(index => (DenseVector) mtx.Row(index)).ToList();
            return DenseMatrix.OfRows(rows.Count, rows[0].Count, rows);
        }

        public static DenseVector Select(this DenseVector v, IEnumerable<int> indexes)
        {
            var cols = indexes.Select(index => v[index]).ToList();
            return DenseVector.OfEnumerable(cols);
        }

        public static DenseVector Insert(this DenseVector vector, double value = 0)
        {
            return DenseVector.Create(vector.Count + 1, i => i < vector.Count ? vector[i] : value);
        }

        public static DenseMatrix RoundMatrix(this DenseMatrix matrix)
        {
            for (var i = 0; i < matrix.RowCount; i++)
            {
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = Math.Round(matrix[i, j], 5);
                }
            }
            return matrix;
        }

        public static DenseVector RoundVector(this DenseVector vector)
        {
            for (var i = 0; i < vector.Count; i++)
            {
                vector[i] = Math.Round(vector[i], 5);
            }
            return vector;
        }

        public static DenseMatrix Identity(int order)
        {
            DenseMatrix denseMatrix = new DenseMatrix(order);
            for (int index = 0; index < order; ++index)
                denseMatrix.Values[index * order + index] = 1.0;
            return denseMatrix;
        }

        public static bool IsInteger(this DenseVector d)
        {
            return d.All(x => x.IsInteger());
        }

        public static bool IsInteger(this double d)
        {
            return Math.Abs(Math.Round(d) - d) < 0.01f;
        }

        public static double Frac(this double d)
        {
            var f = Math.Abs(d);
            if (d.IsInteger())
                return 0;
            f -= (double)decimal.Floor((decimal)d);
            if (d < 0)
                f = Math.Abs(f - 2);
            return f;
        }
    }
}
