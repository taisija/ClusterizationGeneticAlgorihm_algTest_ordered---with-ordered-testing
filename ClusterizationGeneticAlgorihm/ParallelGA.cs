using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class ParallelGA
    {
        private TxtParser txtParser;
        private Operator oper;
        private Individual[] parentIndiv;
        private Individual[] offspringsIndiv;
        private int crossoveRate;
        private int mutationRate;
        private Population[] population;
        private Population tempPopulation;
        private int generation = 0;
        private int generationNumber = 0;
        //parameters
        private int series = 0;
        private double transmissionRateBetweenParallelPopulations = 0.3;
        private int tournamentGroupQuantity = 4;
        private double percentOfChangeGeneInInitializationStep = 0.1;

        public int Series { get { return series; } }
        public double TransmissionRateBetweenParallelPopulations {
            get { return transmissionRateBetweenParallelPopulations; }
            set { transmissionRateBetweenParallelPopulations = value; }
        }
        public int TournamentGroupQuantity { get { return tournamentGroupQuantity; } set { tournamentGroupQuantity = value; } }
        public double PercentOfChangeGeneInInitializationStep { 
            get { return percentOfChangeGeneInInitializationStep; }
            set { percentOfChangeGeneInInitializationStep = value; }
        }
        public int Generation { get { return generation; } }
        public int GenerationNumber { get { return generationNumber; } }
        public Population[] PopulationList { get { return population; } }

        public void RunGA(int numberOfParallelPopulations, TxtParser textParser, int populationQuantity, double MutationRate, double CrossoverRate, int GenerationsNumber)
        {
            txtParser = textParser;
            population = new Population[numberOfParallelPopulations];
            oper = new Operator();
            Random rnd = new Random();
            int indx = 0;
            for (series = 0; series < numberOfParallelPopulations; series++)
            {
                population[series] = oper.InitialiseFromInitialData(populationQuantity, txtParser.Numbers, 
                    txtParser.NumberOfLines, txtParser.NumberOfColumns, percentOfChangeGeneInInitializationStep);
                mutationRate = (int)(MutationRate * population[series].PopulationQuantity);
                crossoveRate = (int)(CrossoverRate * population[series].PopulationQuantity);
                generationNumber = GenerationsNumber;
                population[series] = oper.FitnessEvaluationByMinAndQuantity(population[series], txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
            }
            for (generation = 0; generation < generationNumber; generation++)
            {
                if (rnd.NextDouble() < transmissionRateBetweenParallelPopulations)
                {
                    for (series = 1; series < numberOfParallelPopulations; series++)
                    {
                        indx = (int)(rnd.NextDouble() * (double)population[series].PopulationQuantity);
                        Individual indiv = population[series].GetIndividualByIndex(indx);
                        population[series].SetIndividualByIndex(indx, population[series - 1].GetIndividualByIndex(indx));
                        population[series - 1].SetIndividualByIndex(indx, indiv);
                        oper.FitnessEvaluationByMinAndQuantityByIndex(population[series - 1], txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns, indx);
                        oper.FitnessEvaluationByMinAndQuantityByIndex(population[series], txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns, indx);
                    }
                }
                for (series = 0; series < numberOfParallelPopulations; series++)
                {
                    tempPopulation = new Population(populationQuantity);
                    population[series].SortListByFitness();
                    for (int i = 0; i < crossoveRate; i++)
                    {
                        parentIndiv = oper.SelectionTournament(population[series], tournamentGroupQuantity);
                        offspringsIndiv = oper.TwoPointCrossover(parentIndiv);
                        //offspringsIndiv = oper.IntermediateRecombinationCrossover(parentIndiv);
                        tempPopulation.AddIndividual(offspringsIndiv);
                    }
                    for (int i = 0; i < mutationRate; i++)
                    {
                        tempPopulation = oper.MutationFromInitialData(tempPopulation, txtParser.Numbers, txtParser.NumberOfLines);
                        tempPopulation = oper.MutationFromInitialDataInSecondChromosome(tempPopulation, txtParser.Numbers, txtParser.NumberOfLines);
                    }
                    population[series] = oper.FitnessEvaluationByMinAndQuantity(population[series], txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
                    population[series] = oper.ReductionSelecionScheme(population[series], tempPopulation);
                    population[series].SortListByFitness();
                }
            }
        }
    }
}
