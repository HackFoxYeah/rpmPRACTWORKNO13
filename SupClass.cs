using System;
using System.Windows.Controls;

namespace practWorkNo13
{
    internal class SupClass
    {
        public static void DoATask(float[,] data, TextBox tbResults)
        {
            int columnIndex = 0,
                previousAmount = 0,
                currentAmount = 0;

            float[] tempArr = new float[data.GetLength(0)];            
               
            for (int i = 0; i < data.GetLength(1); i++)
            {
                currentAmount = 0;    

                for (int j = 0; j < data.GetLength(0); j++)
                {
                    tempArr[j] = data[j, i];
                }

                for (int k = 0; k < tempArr.Length; k++)
                {
                    currentAmount = Array.FindAll<float>(tempArr, x => x == tempArr[k]).Length;

                    if (currentAmount > previousAmount)
                    {
                        previousAmount = currentAmount;
                        columnIndex = i + 1;
                    }
                }
            }

            tbResults.Text = columnIndex.ToString();
        }
    }
}