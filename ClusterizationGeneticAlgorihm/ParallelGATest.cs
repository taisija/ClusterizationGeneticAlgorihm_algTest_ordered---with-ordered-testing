using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class ParallelGATest
    {
        public ParallelGATest()
        {
            PGA = new ParallelGA();
            testingResultsSelectionThreshold = 0.85;
            /*numberOfParallelPopulations = 0;
            transmissionRateBetweenParallelPopulations = 0.3;
            tournamentGroupQuantity = 4;
            percentOfChangeGeneInInitializationStep = 0.1;*/
        }
        public ParallelGATest(double TestingResultsSelectionThreshold, double TransmissionRateBetweenParallelPopulations, int TournamentGroupQuantity,
            double PercentOfChangeGeneInInitializationStep, int ResultsInitialQuantity)
        {
            PGA = new ParallelGA();
            individualListInitialQuantity = ResultsInitialQuantity;
            individualList = new Individual[individualListInitialQuantity];
            testingResultsSelectionThreshold = TestingResultsSelectionThreshold;
            /*transmissionRateBetweenParallelPopulations = TransmissionRateBetweenParallelPopulations;
            tournamentGroupQuantity = TournamentGroupQuantity;
            percentOfChangeGeneInInitializationStep = PercentOfChangeGeneInInitializationStep;*/
            //settings
            PGA.PercentOfChangeGeneInInitializationStep = PercentOfChangeGeneInInitializationStep;
            PGA.TournamentGroupQuantity = TournamentGroupQuantity;
            PGA.TransmissionRateBetweenParallelPopulations = TransmissionRateBetweenParallelPopulations;
        }
        public Individual[] RunParallelGATest(int NumberOfParallelPopulations, TxtParser TextParser, int PopulationQuantity, double MutationRate, 
            double CrossoverRate, int GenerationsNumber, int NumberOfTestRuns)
        {
            for (currentTestNumber = 0; currentTestNumber < NumberOfTestRuns; currentTestNumber++)
            {
                PGA.RunGA(NumberOfParallelPopulations, TextParser, PopulationQuantity, MutationRate, CrossoverRate, GenerationsNumber);
                for (int j = 0; j < NumberOfParallelPopulations; j++)
                {
                    AddOneBestIndividualToList(PGA.PopulationList[j]);
                }
            }
            return individualList;
        }
        public Individual[] IndividualList { get { return individualList; } }
        public int IndividualListCounter { get { return individualListCounter; } }
        public int CurrentTestNumber { get { return currentTestNumber; } }
        private void AddBestIndividualsToList(Population population)
        {
            population.SortListByFitness();
            double[] fitness = population.IndividualFitnessList;
            int i = 0;
            while ((fitness[i] > testingResultsSelectionThreshold) && (i < population.PopulationQuantity))
            {
                AddIndividualToList(population.GetIndividualByIndex(i));
                i++;
            }
        }
        private void AddOneBestIndividualToList(Population population)
        {
            population.SortListByFitness();
            AddIndividualToList(population.GetIndividualByIndex(0));
        }
        private int AddIndividualToList(Individual individual)
        {
            if (individualList != null)
            {
                if (individualListCounter < individualListInitialQuantity)
                {
                    individualList[individualListCounter] = individual;
                    individualListCounter++;
                }
                else
                {
                    Individual[] s = new Individual[individualListInitialQuantity + 1];
                    for (int i = 0; i < individualListInitialQuantity; i++)
                    {
                        s[i] = individualList[i];
                    }
                    s[individualListInitialQuantity] = individual;
                    individualListCounter++;
                    individualListInitialQuantity++;
                    individualList = s;
                }
            }
            else
            {
                individualList = new Individual[10];
                individualList[0] = individual;
            }
            return individualListCounter;
        }
        private double testingResultsSelectionThreshold;
        private ParallelGA PGA;
        private int individualListCounter = 0;
        private int individualListInitialQuantity;
        private Individual[] individualList;
        private int currentTestNumber;
    }
}
