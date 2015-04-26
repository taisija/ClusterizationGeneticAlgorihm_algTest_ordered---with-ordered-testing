using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClusterizationGeneticAlgorihm
{
    class TxtParser
    {
        private double[,] numbers;
        private int numberOfLines;
        private int numberOfColumns;

        public double[,] Numbers
        {
            get { return numbers; }
        }
        public int NumberOfLines
        {
            get { return numberOfLines; }
        }
        public int NumberOfColumns
        {
            get { return numberOfColumns; }
        }

        public TxtParser(string FileName, int ColumnsNumber)
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(FileName);
                numberOfLines = lines.Length;
                numberOfColumns = ColumnsNumber;
                using (TextReader reader = File.OpenText(FileName))
                {
                    numbers = new double[numberOfLines,numberOfColumns];
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        string text = reader.ReadLine();
                        string[] nbits = text.Split(' ');
                        for (int j = 0; j < numberOfColumns; j++)
                        {
                            numbers[i, j] = double.Parse(nbits[j]);
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                }

            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                MessageBox.Show(".txt file not found");
            }
        }
    }

}
