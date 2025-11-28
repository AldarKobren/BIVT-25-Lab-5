using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                double avg = 0;
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    avg = sum / count;
                }
                else
                {
                    avg = 0;
                }
                answer[i] += avg;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxValue = int.MinValue;
            int maxcols = 0, maxrows = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxrows = i;
                        maxcols = j;
                    }
                }
            }
            answer = new int[rows - 1, cols - 1];
            int newi = 0; int newj = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxrows) continue;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxcols) continue;
                    answer[newi, newj] = matrix[i, j];
                    newj++;
                }
                newi++;
                newj = 0;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxindex = 0;
                int maxValue = int.MinValue;
                for (int j = 0; j < cols; j++)
                {
                    if ((matrix[i, j] > maxValue))
                    {
                        maxValue = matrix[i, j];
                        maxindex = j;
                    }
                }
                for (int j = maxindex; j < cols - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, cols - 1] = maxValue;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {

                int maxValue = int.MinValue;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }
                for (int j = 0; j < cols - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, cols - 1] = maxValue;
                answer[i, cols] = matrix[i, cols - 1];

            }

            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            answer = new int[count];
            count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[count] = matrix[i, j];
                        count++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxValue = int.MinValue;
            int maxindex = 0;

            if (rows != cols) return;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxindex = i;
                }
            }
            int negindex = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negindex = i;
                    break;
                }
            }
            if (negindex != -1 && negindex != maxindex)
            {
                for (int i = 0; i < cols; i++)
                {
                    int temp = matrix[negindex, i];
                    matrix[negindex, i] = matrix[maxindex, i];
                    matrix[maxindex, i] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxValue = int.MinValue;
            int maxindex = 0;
            if (cols < 2 || array.Length != cols)
            {
                return;
            }
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, cols - 2] > maxValue)
                {
                    maxValue = matrix[i, cols - 2];
                    maxindex = i;
                }
            }
            for (int i = 0; i < cols; i++)
            {
                matrix[maxindex, i] = array[i];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                int maxValue = int.MinValue;
                int maxindex = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j, i] > maxValue)
                    {
                        maxValue = matrix[j, i];
                        maxindex = j;
                    }
                }
                int half = rows / 2;

                if (maxindex < half)
                {
                    int sum = 0;
                    for (int j = maxindex + 1; j < rows; j++)
                    {
                        sum += matrix[j, i];
                    }

                    matrix[0,i] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i += 2)
            {
                if (i == rows - 1)
                {
                    break;
                }
                int maxrow = int.MinValue;
                int maxindex = 0;
                int maxrowchet = int.MinValue;
                int maxindexchet = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxrow)
                    {
                        maxrow = matrix[i, j];
                        maxindex = j;
                    }
                }
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i + 1, j] > maxrowchet)
                    {
                        maxrowchet = matrix[i + 1, j];
                        maxindexchet = j;
                    }
                }
                int temp = matrix[i, maxindex];
                matrix[i, maxindex] = matrix[i + 1, maxindexchet];
                matrix[i + 1, maxindexchet] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int maxValue = int.MinValue;
            int maxindex = 0;
            if (row != col)
            {
                return;
            }
            for (int i = 0; i < row; i++)
            {
                if ((matrix[i, i] > maxValue))
                {
                    maxValue = matrix[i, i];
                    maxindex = i;
                }
            }
            for (int i = 0; i < row; i++)
            {
                if (i == maxindex)
                {
                    break;
                }
                for (int j = i+1; j < col; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[,] tempmaxtrix = new int[row, col];
            int[] count = new int[row];
            int[] index = new int[row];

            for (int i = 0; i < row; i++)
            {
                int sum = 0;
                for (int j = 0; j < col; j++)
                {
                    tempmaxtrix[i, j] = matrix[i, j];
                    if (matrix[i, j] > 0)
                    {
                        sum++;
                    }
                }
                count[i] = sum;
                index[i] = i;
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 1; j < row; j++)
                {
                    if (count[j - 1] < count[j])
                    {
                        (count[j - 1], count[j]) = (count[j], count[j - 1]);
                        (index[j - 1], index[j]) = (index[j], index[j - 1]);
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = tempmaxtrix[index[i], j];
                }
            }

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            double totalSum = 0;
            int totalCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        totalSum += array[i][j];
                        totalCount++;
                    }
                }
            }

            double totalAverage = totalSum / totalCount;

            int keepCount = 0;
            bool[] keepRow = new bool[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null || array[i].Length == 0)
                {
                    keepRow[i] = false;
                    continue;
                }

                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                }

                double rowAverage = rowSum / array[i].Length;

                if (rowAverage >= totalAverage)
                {
                    keepRow[i] = true;
                    keepCount++;
                }
                else
                {
                    keepRow[i] = false;
                }
            }
            answer = new int[keepCount][];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (keepRow[i])
                {
                    answer[index] = array[i];
                    index++;
                }
            }
            // end

            return answer;
        }
    }
}
