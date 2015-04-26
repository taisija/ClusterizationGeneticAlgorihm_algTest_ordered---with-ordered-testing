using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class Individual
    {
        private Chromosome [] chromosomes;
        private int chromosomesNumber;

        public Individual(int ParametersNumber, int ChromosomesNumber)
        {
            chromosomesNumber = ChromosomesNumber;
            chromosomes = new Chromosome[chromosomesNumber];
            chromosomes[0] = new ChromosomeTypeOne(ParametersNumber);
        }
        public Individual(double[,] parameters, int parametersNumber)
        {
            chromosomesNumber = 1;
            chromosomes = new Chromosome[chromosomesNumber];
            chromosomes[0] = new ChromosomeTypeOne(parametersNumber, parameters);
        }
        public Individual(double[,] parameters, int parametersNumber, int[] parametersTwo, int parametersNumberTwo)
        {
            chromosomesNumber = 2;
            chromosomes = new Chromosome[chromosomesNumber];
            chromosomes[0] = new ChromosomeTypeOne(parametersNumber, parameters);
            chromosomes[1] = new ChromosomeTypeTwo(parametersNumberTwo, parametersTwo);
        }
        public Individual(Individual ind)
        {
            int len1 = ((ChromosomeTypeOne)ind.chromosomes[0]).GenesNumber;
            int len2 = ((ChromosomeTypeTwo)ind.chromosomes[1]).GenesNumber;
            double[,] CH1 = ((ChromosomeTypeOne)ind.chromosomes[0]).ChromosomeContent;
            int[] CH2 = ((ChromosomeTypeTwo)ind.chromosomes[1]).ChromosomeContent;
            double[,] ch1 = new double[len1, 2];
            int[] ch2 = new int[len2];
            for (int i = 0; i < len1; i++)
            {
                ch1[i, 0] = CH1[i, 0];
                ch1[i, 1] = CH1[i, 1];
            }
            for (int i = 0; i < len2; i++)
            {
                ch2[i] = CH2[i];
            }
            chromosomes = new Chromosome[2];
            chromosomes[0] = new ChromosomeTypeOne(((ChromosomeTypeOne)ind.chromosomes[0]).GenesNumber, ch1);
            chromosomes[1] = new ChromosomeTypeTwo(((ChromosomeTypeTwo)ind.chromosomes[1]).GenesNumber, ch2);
            chromosomesNumber = ind.ChromosomesNumber;
        }
        public int ChromosomesNumber { get { return chromosomesNumber; } }
        public Chromosome[] GetIndividualContent()
        {
            return chromosomes;
        }
        public bool SetIndividualContent(Chromosome [] ch)
        {
            for (int i = 0; i < chromosomesNumber; i++)
                chromosomes[i] = ch[i];
            return true;
        }
    }
}
