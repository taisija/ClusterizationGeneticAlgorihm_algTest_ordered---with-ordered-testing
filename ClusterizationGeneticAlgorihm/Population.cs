using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class Population
    {
        private Individual[] individualsList;
        private double[] individualFitnessList;
        private int populationQuantity;
        private int expectPopulationQuantity;
        private int expectPopulationQuantityIncrease = 2;

        public Population()
        {
            populationQuantity = 0;
            expectPopulationQuantity = 0;
        }
        public Population(int ExpectPopulationQuantity)
        {
            populationQuantity = 0;
            expectPopulationQuantity = ExpectPopulationQuantity;
            individualsList = new Individual[expectPopulationQuantity];
            individualFitnessList = new double[expectPopulationQuantity];
        }
        public Population(int ExpectPopulationQuantity, int ExpectPopulationQuantityIncrease)
        {
            populationQuantity = 0;
            expectPopulationQuantity = ExpectPopulationQuantity;
            individualsList = new Individual[expectPopulationQuantity];
            individualFitnessList = new double[expectPopulationQuantity];
            expectPopulationQuantityIncrease = ExpectPopulationQuantityIncrease;
        }
        public double[] IndividualFitnessList { get { return individualFitnessList;} }
        public int PopulationQuantity
        {
            get { return populationQuantity; }
        }
        public Individual GetIndividualByIndex(int ind)
        {
            if ((!(ind < 0)) && (ind < populationQuantity))
                return individualsList[ind];
            else
                return null;
        }
        public double GetFitnessByIndex(int ind)
        {
            if ((!(ind < 0)) && (ind < populationQuantity))
                return individualFitnessList[ind];
            else
                return 0;
        }
        public Individual ReplaseIndividualByIndex(int ind, Individual ch)
        {
            if ((!(ind < 0)) && (ind < populationQuantity))
            {
                individualsList[ind] = ch;
                return individualsList[ind];
            }
            else
                return null;
        }
        public bool SetFitnessByIndex(int ind, double value)
        {
            if ((!(ind < 0)) && (ind < populationQuantity))
            {
                individualFitnessList[ind] = value;
                return true;
            }
            else
                return false;
        }
        public bool SetIndividualByIndex(int ind, Individual indiv)
        {
            if ((!(ind < 0)) && (ind < populationQuantity))
            {
                individualsList[ind] = indiv;
                return true;
            }
            else
                return false;
        }
        public void SortListByFitness()
        {
            Individual indiv;
            double val;
            for (int i = 0; i < populationQuantity; i++)
                for (int j = i; j < populationQuantity; j++)
                {
                    if (individualFitnessList[i] < individualFitnessList[j])
                    {
                        indiv = individualsList[i];
                        val = individualFitnessList[i];
                        individualsList[i] = individualsList[j];
                        individualFitnessList[i] = individualFitnessList[j];
                        individualsList[j] = indiv;
                        individualFitnessList[j] = val;
                    }
                }
        }
        public int AddIndividual(Individual ch)
        {
            if (populationQuantity < expectPopulationQuantity)
            {
                individualsList[populationQuantity] = ch;
                populationQuantity++;
                return populationQuantity;
            }
            else
            {
                Individual[] chrList = individualsList;
                double[] fList = individualFitnessList;
                expectPopulationQuantity += expectPopulationQuantityIncrease;
                individualsList = new Individual[expectPopulationQuantity];
                individualFitnessList = new double[expectPopulationQuantity];
                for (int i = 0; i < populationQuantity; i++)
                {
                    individualsList[i] = chrList[i];
                    individualFitnessList[i] = fList[i];
                }
                individualsList[populationQuantity] = ch;
                populationQuantity++;
                return populationQuantity;
            }
        }
        public int AddIndividual(Individual[] ch)
        {
            int len = ch.Length;
            if ((populationQuantity+len) < expectPopulationQuantity)
            {
                for (int i = populationQuantity; i < expectPopulationQuantity; i++)
                {
                    individualsList[i] = ch[i - populationQuantity];
                    populationQuantity++;
                }
                return populationQuantity;
            }
            else
            {
                Individual[] chrList = individualsList;
                double[] fList = individualFitnessList;
                expectPopulationQuantity += len;
                individualsList = new Individual[expectPopulationQuantity];
                individualFitnessList = new double[expectPopulationQuantity];
                for (int i = 0; i < populationQuantity; i++)
                {
                    individualsList[i] = chrList[i];
                    individualFitnessList[i] = fList[i];
                }
                for (int i = populationQuantity; i < expectPopulationQuantity; i++)
                {
                    individualsList[i] = ch[i - populationQuantity];
                    populationQuantity++;
                }
                return populationQuantity;
            }
        }
    }
}
