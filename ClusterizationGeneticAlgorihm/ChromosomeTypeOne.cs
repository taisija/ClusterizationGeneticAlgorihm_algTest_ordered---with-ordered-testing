using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class ChromosomeTypeOne:Chromosome
    {
        private double[,] ranges;
        private int currentRangesNumber;
        private static int maxRangesNumber;

        public ChromosomeTypeOne(int MaxRangesNumber)
        {
            maxRangesNumber = MaxRangesNumber;
            currentRangesNumber = 0;
            ranges = new double[maxRangesNumber,2];
            for (int i = 0; i < maxRangesNumber; i++)
            {
                ranges[i, 0] = -1;
                ranges[i, 1] = 1;
            }
        }
        public ChromosomeTypeOne(int MaxRangesNumber, double [,] ChromosomeContent)
        {
            maxRangesNumber = MaxRangesNumber;
            currentRangesNumber = 0;
            ranges = new double[maxRangesNumber, 2];
            for (int i = 0; i < maxRangesNumber; i++)
            {
                ranges[i, 0] = ChromosomeContent[i, 0];
                ranges[i, 1] = ChromosomeContent[i, 1];
                if ((ChromosomeContent[i, 1] - ChromosomeContent[i, 0]) < 1) currentRangesNumber++;
            }
        }
        public int GenesNumber { get { return maxRangesNumber; } }
        public double[,] ChromosomeContent { get { return ranges; } }
        public bool ChangeChromosomeGene(int position, double lowBoundary, double upperBoundary)
        {
            if ((position >= 0) && (position < maxRangesNumber))
            {
                if ((ChromosomeContent[position, 1] - ChromosomeContent[position, 0]) == 1) currentRangesNumber++;
                if ((upperBoundary - lowBoundary) == 1) currentRangesNumber--;
                ranges[position, 0] = lowBoundary;
                ranges[position, 1] = upperBoundary;
                return true;
            }
            return false; 
        }
    }
}
