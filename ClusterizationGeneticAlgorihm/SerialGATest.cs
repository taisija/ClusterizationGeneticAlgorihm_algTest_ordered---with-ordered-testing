using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class SerialGATest
    {
        public SerialGATest()
        {
            SGA = new SerialGA();
            testingResultsSelectionThreshold = 0.85;
        }
        public SerialGATest(double TestingResultsSelectionThreshold, int TournamentGroupQuantity,
            double PercentOfChangeGeneInInitializationStep, int ResultsInitialQuantity)
        {
            SGA = new SerialGA();
            individualListInitialQuantity = ResultsInitialQuantity;
            individualList = new Individual[individualListInitialQuantity];
            testingResultsSelectionThreshold = TestingResultsSelectionThreshold;
            //settings
            SGA.PercentOfChangeGeneInInitializationStep = PercentOfChangeGeneInInitializationStep;
            SGA.TournamentGroupQuantity = TournamentGroupQuantity;
        }
        public Individual[] RunSerialGATest(int SeriesNumber, TxtParser TextParser, int PopulationQuantity, double MutationRate, 
            double CrossoverRate, int GenerationsNumber, int NumberOfTestRuns)
        {
            for (currentTestNumber = 0; currentTestNumber < NumberOfTestRuns; currentTestNumber++)
            {
                SGA.RunGA(SeriesNumber, TextParser, PopulationQuantity, MutationRate, CrossoverRate, GenerationsNumber);
                for (int j = 0; j < SeriesNumber; j++)
                {
                    AddOneBestIndividualToList(SGA.PopulationList[j]);
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
        private SerialGA SGA;
        private int individualListCounter = 0;
        private int individualListInitialQuantity;
        private Individual[] individualList;
        private int currentTestNumber;
    }
}
