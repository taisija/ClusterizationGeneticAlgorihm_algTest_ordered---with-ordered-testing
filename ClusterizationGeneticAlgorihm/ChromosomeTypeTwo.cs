using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class ChromosomeTypeTwo:Chromosome
    {
        private int[] numbers;
        private int currentGenesNumber;
        private int maxGenesNumber;

        public ChromosomeTypeTwo(int MaxGenesNumber)
        {
            maxGenesNumber = MaxGenesNumber;
            currentGenesNumber = 0;
            numbers = new int[maxGenesNumber];
        }
        public ChromosomeTypeTwo(int MaxGenesNumber, int[] ChromosomeContent)
        {
            maxGenesNumber = MaxGenesNumber;
            currentGenesNumber = 0;
            numbers =  new int[maxGenesNumber];
            currentGenesNumber = ChromosomeContent.Length;
            if (currentGenesNumber > MaxGenesNumber) currentGenesNumber = MaxGenesNumber;
            for (int i = 0; i < currentGenesNumber; i++)
            {
                numbers[i] = ChromosomeContent[i];
            }
        }
        public int GenesNumber { get { return currentGenesNumber; } }
        public int[] ChromosomeContent { get { return numbers; } }
        public bool ChangeChromosomeGene(int position, int gene)
        {
            if (GenesExisting(gene)) return false;
            if ((position >= 0) && (position < currentGenesNumber))
            {
                numbers[position] = gene;
                return true;
            }
            else if (((position >= 0) && (position < maxGenesNumber)))
            {
                numbers[currentGenesNumber] = gene;
                currentGenesNumber++;
                return true;
            }
            return false; 
        }
        private bool GenesExisting(int gene)
        {
            for (int i = 0; i < currentGenesNumber; i++)
            {
                if (gene == numbers[i]) return true;
            }
            return false;
        }
    }
}
