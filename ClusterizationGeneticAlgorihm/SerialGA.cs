using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class SerialGA
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
        private int series = 0;
        private double percentOfChangeGeneInInitializationStep = 0.1;
        private int tournamentGroupQuantity = 4;

        public double PercentOfChangeGeneInInitializationStep
        {
            get { return percentOfChangeGeneInInitializationStep; }
            set { percentOfChangeGeneInInitializationStep = value; }
        }
        public int TournamentGroupQuantity { get { return tournamentGroupQuantity; } set { tournamentGroupQuantity = value; } }
        public int Series { get { return series; } }
        public int Generation { get { return generation; } }
        public int GenerationNumber { get { return generationNumber; } }
        public Population[] PopulationList {get {return population;}}
        public void RunGA(int runsNumber, TxtParser textParser, int populationQuantity, double MutationRate, double CrossoverRate, int GenerationsNumber)
        {
            txtParser = textParser;
            population = new Population[runsNumber];
            oper = new Operator();
            for (series = 0; series < runsNumber; series++)
            {
                population[series] = oper.InitialiseFromInitialData(populationQuantity, txtParser.Numbers, txtParser.NumberOfLines,
                    txtParser.NumberOfColumns, percentOfChangeGeneInInitializationStep);
                tempPopulation = new Population(populationQuantity);
                mutationRate = (int)(MutationRate * population[series].PopulationQuantity);
                crossoveRate = (int)(CrossoverRate * population[series].PopulationQuantity);
                generationNumber = GenerationsNumber;
                population[0] = oper.FitnessEvaluationByMinAndQuantity(population[0], txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
                for (generation = 0; generation < generationNumber; generation++)
                {
                    population[series].SortListByFitness();
                    for (int i = 0; i < crossoveRate; i++)
                    {
                        parentIndiv = oper.SelectionTournament(population[series], 4);
                        offspringsIndiv = oper.TwoPointCrossover(parentIndiv);
                        tempPopulation.AddIndividual(offspringsIndiv);
                    }
                    for (int i = 0; i < mutationRate; i++)
                    {
                        population[series] = oper.MutationFromInitialData(population[series], txtParser.Numbers, txtParser.NumberOfLines);
                        population[series] = oper.MutationFromInitialDataInSecondChromosome(population[series], txtParser.Numbers, txtParser.NumberOfLines);
                    }
                    population[series] = oper.FitnessEvaluationByMinAndQuantity(population[series], txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
                    population[series] = oper.ReductionSelecionScheme(population[series], tempPopulation);
                }
            }
        }
    }
}
