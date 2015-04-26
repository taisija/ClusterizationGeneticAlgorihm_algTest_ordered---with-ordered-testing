using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusterizationGeneticAlgorihm
{
    class Operator
    {
        /*Initial data are represented as a table of normalized data which was stored in order: 
         * image number, filter number, fitness, parameters.*/
        //for 2 chromosome
        public Population RandomInitialise(int PopulationQuantity, double[,] initialData, int rowsNumder, int columnsNumber)
        {
            Population popolation = new Population(PopulationQuantity);
            Random rnd = new Random();
            ChromosomeTypeOne ch1;
            ChromosomeTypeTwo ch2;
            Chromosome[] ch = new Chromosome[2];
            double first;
            double second;
            int counter = 2;
            for (int i = 0; i < PopulationQuantity; i++)
            {
                ch2 = new ChromosomeTypeTwo(2);
                ch1 = new ChromosomeTypeOne(columnsNumber - 3);
                counter = (int)(rnd.NextDouble() * (double)(columnsNumber / 2));
                for (int k = 0; k < counter; k++)
                {
                    first = rnd.NextDouble();
                    second = first + (1 - first) * rnd.NextDouble();
                    ch1.ChangeChromosomeGene((int)(rnd.NextDouble() * (double)ch1.GenesNumber), first, second);
                }
                ch2.ChangeChromosomeGene(0, (int)(rnd.NextDouble() * (double)324));
                ch[0] = ch1;
                ch[1] = ch2;
                Individual ind = new Individual(columnsNumber-3, 2);
                ind.SetIndividualContent(ch);
                popolation.AddIndividual(ind);
            }
            return popolation;
        }
        public Population InitialiseFromInitialData(int PopulationQuantity, double[,] initialData, int rowsNumber, int columnsNumber, double percentOfChangeGene)
        {
            Population popolation = new Population(PopulationQuantity);
            Random rnd = new Random();
            ChromosomeTypeOne ch1;
            ChromosomeTypeTwo ch2;
            Chromosome[] ch = new Chromosome[2];
            double first;
            double second;
            int counter = 2;
            int colum;
            int firstRow = 0;
            int secondRow = 0;
            int count;
            for (int i = 0; i < PopulationQuantity; i++)
            {
                ch2 = new ChromosomeTypeTwo(1);
                ch1 = new ChromosomeTypeOne(columnsNumber - 3);
                //for half of all genes
                counter = (int)(rnd.NextDouble() * (double)(columnsNumber * percentOfChangeGene));
                firstRow = (int)(rnd.NextDouble() * (double)rowsNumber);
                secondRow = (int)(rnd.NextDouble() * (double)rowsNumber);
                for (int k = 0; k < counter; k++)
                {
                    colum = (int)(rnd.NextDouble() * (double)ch1.GenesNumber);
                    count = 0;
                    /*while (initialData[firstRow, colum + 3] == initialData[secondRow, colum + 3] && (count < 100))
                    {
                        secondRow = (int)(rnd.NextDouble() * (double)rowsNumber);
                        count++;
                    }*/
                    first = initialData[firstRow, colum + 3];
                    second = initialData[secondRow, colum + 3];
                    if (first < second)
                        ch1.ChangeChromosomeGene(colum, first, second);
                    else
                        ch1.ChangeChromosomeGene(colum, second, first);
                }
                ch2.ChangeChromosomeGene(0, (int)initialData[firstRow, 1]);
                ch[0] = ch1;
                ch[1] = ch2;
                Individual ind = new Individual(columnsNumber - 3, 2);
                ind.SetIndividualContent(ch);
                popolation.AddIndividual(ind);
            }
            return popolation;
        }
        public Population FitnessEvaluationByMin(Population population, double[,] initialData, int rowsNumder, int columnsNumber)
        {
            int populationQuantity = population.PopulationQuantity;
            Chromosome[] ch;
            double min;
            for (int i = 0; i < populationQuantity; i++)
            {
                ch = population.GetIndividualByIndex(i).GetIndividualContent();
                min = GetMinimum(ObservationSet(((ChromosomeTypeTwo)ch[1]).ChromosomeContent, ((ChromosomeTypeOne)ch[0]).ChromosomeContent,initialData, rowsNumder, columnsNumber));
                population.SetFitnessByIndex(i, min);
            }
            return population;
        }
        public Population FitnessEvaluationByMinAndQuantity(Population population, double[,] initialData, int rowsNumder, int columnsNumber)
        {
            int populationQuantity = population.PopulationQuantity;
            Chromosome[] ch;
            double[] observationSet;
            double min;
            for (int i = 0; i < populationQuantity; i++)
            {
                ch = population.GetIndividualByIndex(i).GetIndividualContent();
                observationSet = ObservationSet(((ChromosomeTypeTwo)ch[1]).ChromosomeContent, ((ChromosomeTypeOne)ch[0]).ChromosomeContent, initialData, rowsNumder, columnsNumber);
                min = GetMinimum(observationSet) - 0.1/observationSet.Length;
                population.SetFitnessByIndex(i, min);
            }
            return population;
        }
        public Population FitnessEvaluationByMean(Population population, double[,] initialData, int rowsNumder, int columnsNumber)
        {
            int populationQuantity = population.PopulationQuantity;
            Chromosome[] ch; ;
            double mean;
            for (int i = 0; i < populationQuantity; i++)
            {
                ch = population.GetIndividualByIndex(i).GetIndividualContent();
                mean = GetMean(ObservationSet(((ChromosomeTypeTwo)ch[1]).ChromosomeContent, ((ChromosomeTypeOne)ch[0]).ChromosomeContent, initialData, rowsNumder, columnsNumber));
                population.SetFitnessByIndex(i, mean);
            }
            return population;
        }
        public Population FitnessEvaluationByMeanByIndex(Population population, double[,] initialData, int rowsNumder, int columnsNumber, int indx)
        {
            int populationQuantity = population.PopulationQuantity;
            Chromosome[] ch; ;
            double mean;
            if ((indx < populationQuantity) && (indx >= 0))
            {
                ch = population.GetIndividualByIndex(indx).GetIndividualContent();
                mean = GetMean(ObservationSet(((ChromosomeTypeTwo)ch[1]).ChromosomeContent, ((ChromosomeTypeOne)ch[0]).ChromosomeContent, initialData, rowsNumder, columnsNumber));
                population.SetFitnessByIndex(indx, mean);
            }
            return population;
        }
        public Population FitnessEvaluationByMinByIndex(Population population, double[,] initialData, int rowsNumder, int columnsNumber, int indx)
        {
            int populationQuantity = population.PopulationQuantity;
            if ((indx < populationQuantity) && (indx >= 0))
            {
                Chromosome[] ch; ;
                double min;
                ch = population.GetIndividualByIndex(indx).GetIndividualContent();
                min = GetMinimum(ObservationSet(((ChromosomeTypeTwo)ch[1]).ChromosomeContent, ((ChromosomeTypeOne)ch[0]).ChromosomeContent, initialData, rowsNumder, columnsNumber));
                population.SetFitnessByIndex(indx, min);
            }
            return population;
        }
        public Population FitnessEvaluationByMinAndQuantityByIndex(Population population, double[,] initialData, int rowsNumder, int columnsNumber, int indx)
        {
            int populationQuantity = population.PopulationQuantity;
            double[] observationSet;
            if ((indx < populationQuantity) && (indx >= 0))
            {
                Chromosome[] ch; ;
                double min;
                ch = population.GetIndividualByIndex(indx).GetIndividualContent();
                observationSet = ObservationSet(((ChromosomeTypeTwo)ch[1]).ChromosomeContent, ((ChromosomeTypeOne)ch[0]).ChromosomeContent, initialData, rowsNumder, columnsNumber);
                min = GetMinimum(observationSet) - 0.1 / observationSet.Length; ;
                population.SetFitnessByIndex(indx, min);
            }
            return population;
        }
        public Individual[] SelectionTournament(Population population, int tournamentGroupQuantity)
        {
            Individual[] ind = new Individual[2];
            Random rnd = new Random();
            int[] indx = new int[tournamentGroupQuantity];
            double max = 0;
            int indxOfMax = 0;
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < tournamentGroupQuantity; i++)
                {
                    indx[i] = (int)(((double)population.PopulationQuantity) * rnd.NextDouble());
                    if (population.GetFitnessByIndex(indx[i]) > max)
                    {
                        max = population.GetFitnessByIndex(indx[i]);
                        indxOfMax = indx[i];
                    }
                }
                ind[j] = population.GetIndividualByIndex(indxOfMax);
                max = 0;
                indxOfMax = 0;
            }
            return ind;
        }
        public Individual[] TwoPointCrossover(Individual[] parentIndividuals)
        {
            Individual[] offsprings = new Individual[2];
            double[,] parentOne;
            double[,] parentTwo;
            double[,] offspringOne, offspringTwo;//for type one chromosome
            int[] offspringSecondChromosome;
            int[] parentSecondChromosome;
            int crossPointOne, crossPointTwo;
            int num;//gens number in second chromosome in all individuals
            int gensNumberInSecondChromosome;//in current individual
            int parentForSecondChromosomeIndx;
            Random rnd = new Random();
            parentOne = ((ChromosomeTypeOne)parentIndividuals[0].GetIndividualContent()[0]).ChromosomeContent;
            parentTwo = ((ChromosomeTypeOne)parentIndividuals[1].GetIndividualContent()[0]).ChromosomeContent;
            num = ((ChromosomeTypeOne)parentIndividuals[1].GetIndividualContent()[0]).GenesNumber;
            crossPointOne = (int)(((double)num) * rnd.NextDouble());
            crossPointTwo = crossPointOne+(int)(((double)(num - crossPointOne)) * rnd.NextDouble());
            offspringOne = new double[num, 2];
            offspringTwo = new double[num, 2];
            for (int i = 0; i < crossPointOne; i++)
            {
                offspringOne[i, 0] = parentOne[i, 0];
                offspringTwo[i, 0] = parentTwo[i, 0];
                offspringOne[i, 1] = parentOne[i, 1];
                offspringTwo[i, 1] = parentTwo[i, 1];
            }
            for (int i = crossPointOne; i < crossPointTwo; i++)
            {
                offspringOne[i, 0] = parentTwo[i, 0];
                offspringTwo[i, 0] = parentOne[i, 0];
                offspringOne[i, 1] = parentTwo[i, 1];
                offspringTwo[i, 1] = parentOne[i, 1];
            } for (int i = crossPointTwo; i < num; i++)
            {
                offspringOne[i, 0] = parentOne[i, 0];
                offspringTwo[i, 0] = parentTwo[i, 0];
                offspringOne[i, 1] = parentOne[i, 1];
                offspringTwo[i, 1] = parentTwo[i, 1];
            }
            //rnd choose parent individual for first offspring chromosome type Two
            parentForSecondChromosomeIndx = (int)Math.Round(rnd.NextDouble());
            gensNumberInSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).GenesNumber;
            offspringSecondChromosome = new int[gensNumberInSecondChromosome];
            parentSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).ChromosomeContent;
            for (int i = 0; i < gensNumberInSecondChromosome; i++)
            {
                offspringSecondChromosome[i] = parentSecondChromosome[i];
            }
            offsprings[0] = new Individual(offspringOne, num, offspringSecondChromosome, gensNumberInSecondChromosome);
            //rnd choose parent individual for second offspring chromosome type Two
            parentForSecondChromosomeIndx = (int)Math.Round(rnd.NextDouble());
            gensNumberInSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).GenesNumber;
            offspringSecondChromosome = new int[gensNumberInSecondChromosome];
            parentSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).ChromosomeContent;
            for (int i = 0; i < gensNumberInSecondChromosome; i++)
            {
                offspringSecondChromosome[i] = parentSecondChromosome[i];
            }
            offsprings[1] = new Individual(offspringTwo, num, offspringSecondChromosome, gensNumberInSecondChromosome);
            return offsprings;
        }
        public Individual[] IntermediateRecombinationCrossover(Individual[] parentIndividuals)
        {
            Individual[] offsprings = new Individual[2];
            double[,] parentOne;
            double[,] parentTwo;
            double[,] offspringOne, offspringTwo;//for type one chromosome
            int[] offspringSecondChromosome;
            int[] parentSecondChromosome;
            int crossPointOne, crossPointTwo;
            int num;//gens number in second chromosome in all individuals
            int gensNumberInSecondChromosome;//in current individual
            int parentForSecondChromosomeIndx;
            double alpha = 1.0;
            double pO1, pO2, pT1, pT2;
            Random rnd = new Random();
            parentOne = ((ChromosomeTypeOne)parentIndividuals[0].GetIndividualContent()[0]).ChromosomeContent;
            parentTwo = ((ChromosomeTypeOne)parentIndividuals[1].GetIndividualContent()[0]).ChromosomeContent;
            num = ((ChromosomeTypeOne)parentIndividuals[1].GetIndividualContent()[0]).GenesNumber;
            offspringOne = new double[num, 2];
            offspringTwo = new double[num, 2];
            for (int i = 0; i < num; i++)
            {
                alpha = rnd.NextDouble();
                pO1 = parentOne[i, 0];
                pT1 = parentTwo[i, 0];
                pO2 = parentOne[i, 1];
                pT2 = parentTwo[i, 1];
                offspringOne[i, 0] = pO1 + alpha * (pT1 - pO1);
                offspringTwo[i, 0] = pT1 + alpha * (pO1 - pT1);
                offspringOne[i, 1] = pO2 + alpha * (pT2 - pO2);
                offspringTwo[i, 1] = pT2 + alpha * (pO2 - pT2);
            }
            //rnd choose parent individual for first offspring chromosome type Two
            parentForSecondChromosomeIndx = (int)Math.Round(rnd.NextDouble());
            gensNumberInSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).GenesNumber;
            offspringSecondChromosome = new int[gensNumberInSecondChromosome];
            parentSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).ChromosomeContent;
            for (int i = 0; i < gensNumberInSecondChromosome; i++)
            {
                offspringSecondChromosome[i] = parentSecondChromosome[i];
            }
            offsprings[0] = new Individual(offspringOne, num, offspringSecondChromosome, gensNumberInSecondChromosome);
            //rnd choose parent individual for second offspring chromosome type Two
            parentForSecondChromosomeIndx = (int)Math.Round(rnd.NextDouble());
            gensNumberInSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).GenesNumber;
            offspringSecondChromosome = new int[gensNumberInSecondChromosome];
            parentSecondChromosome = ((ChromosomeTypeTwo)parentIndividuals[parentForSecondChromosomeIndx].GetIndividualContent()[1]).ChromosomeContent;
            for (int i = 0; i < gensNumberInSecondChromosome; i++)
            {
                offspringSecondChromosome[i] = parentSecondChromosome[i];
            }
            offsprings[1] = new Individual(offspringTwo, num, offspringSecondChromosome, gensNumberInSecondChromosome);
            return offsprings;
        }
        public Population MutationRandom(Population population)
        {
            Random rnd = new Random();
            int indx = (int)(rnd.NextDouble()*(double)population.PopulationQuantity);
            Individual indiv = population.GetIndividualByIndex(indx);
            Chromosome[] ch = indiv.GetIndividualContent();
            ChromosomeTypeOne chr = (ChromosomeTypeOne)ch[0];
            double first = rnd.NextDouble();
            double second = first + (1-first)*rnd.NextDouble();
            chr.ChangeChromosomeGene((int)(rnd.NextDouble()*(double)chr.GenesNumber),first,second);
            indiv.SetIndividualContent(ch);
            population.SetIndividualByIndex(indx, indiv);
            return population;
        }
        public Population MutationRandomLowerBound(Population population)
        {
            Random rnd = new Random();
            int indx = (int)(rnd.NextDouble() * (double)population.PopulationQuantity);
            Individual indiv = population.GetIndividualByIndex(indx);
            Chromosome[] ch = indiv.GetIndividualContent();
            ChromosomeTypeOne chr = (ChromosomeTypeOne)ch[0];
            int indx_ch = (int)(rnd.NextDouble() * (double)chr.GenesNumber);
            double second = chr.ChromosomeContent[indx, 1];
            double first = second * rnd.NextDouble();
            chr.ChangeChromosomeGene(indx_ch, first, second);
            indiv.SetIndividualContent(ch);
            population.SetIndividualByIndex(indx, indiv);
            return population;
        }
        public Population MutationRandomUpperBound(Population population)
        {
            Random rnd = new Random();
            int indx = (int)(rnd.NextDouble() * (double)population.PopulationQuantity);
            Individual indiv = population.GetIndividualByIndex(indx);
            Chromosome[] ch = indiv.GetIndividualContent();
            ChromosomeTypeOne chr = (ChromosomeTypeOne)ch[0];
            int indx_ch = (int)(rnd.NextDouble() * (double)chr.GenesNumber);
            double first = chr.ChromosomeContent[indx, 0];
            double second = first + (1 - first) * rnd.NextDouble();
            chr.ChangeChromosomeGene(indx_ch, first, second);
            indiv.SetIndividualContent(ch);
            population.SetIndividualByIndex(indx, indiv);
            return population;
        }
        public Population MutationFromInitialData(Population population, double[,] initialData, int rowsNumber)
        {
            Random rnd = new Random();
            int indx = (int)(rnd.NextDouble() * (double)population.PopulationQuantity);
            Individual indiv = population.GetIndividualByIndex(indx);
            Chromosome[] ch = indiv.GetIndividualContent();
            ChromosomeTypeOne chr = (ChromosomeTypeOne)ch[0];
            int colum = (int)(rnd.NextDouble() * (double)chr.GenesNumber);
            int firstRow = (int)(rnd.NextDouble() * (double)rowsNumber);
            int secondRow = (int)(rnd.NextDouble() * (double)rowsNumber);
            int k = 0;
            while (initialData[firstRow, colum + 3] == initialData[secondRow, colum + 3] && (k < 100))
            {
                secondRow = (int)(rnd.NextDouble() * (double)rowsNumber);
                k++;
            }
            double first = initialData[firstRow, colum + 3];
            double second = initialData[secondRow, colum + 3];
            if (first < second)
                chr.ChangeChromosomeGene(colum, first, second);
            else
                chr.ChangeChromosomeGene(colum, second, first);
            indiv.SetIndividualContent(ch);
            population.SetIndividualByIndex(indx, indiv);
            return population;
        }
        public Population MutationFromInitialDataInSecondChromosome(Population population, double[,] initialData, int rowsNumber)
        {
            Random rnd = new Random();
            int indx = (int)(rnd.NextDouble() * (double)population.PopulationQuantity);
            Individual indiv = population.GetIndividualByIndex(indx);
            Chromosome[] ch = indiv.GetIndividualContent();
            ChromosomeTypeTwo chr = (ChromosomeTypeTwo)ch[1];
            int colum = 1;
            int row = (int)(rnd.NextDouble() * (double)rowsNumber);
            chr.ChangeChromosomeGene(0, (int)initialData[row, colum]);
            indiv.SetIndividualContent(ch);
            population.SetIndividualByIndex(indx, indiv);
            return population;
        }
        public Population ReductionSelecionScheme(Population population, Population temporaryPopulation)
        {
            population.SortListByFitness();
            temporaryPopulation.SortListByFitness();
            double[] oldP = population.IndividualFitnessList;
            double[] tempP = temporaryPopulation.IndividualFitnessList;
            int quantity = population.PopulationQuantity;
            int k = 0, j = 0, i = 0;
            while (k < quantity)
            {
                if (oldP[i] >= tempP[j])
                    {i++; k++;}
                else
                    {j++; k++;}
            }
            int t = 0;
            for (int l = i; l < quantity; l++)
            {
                population.ReplaseIndividualByIndex(l,temporaryPopulation.GetIndividualByIndex(t));
                t++;
            }
            return population;
        }
        /*public Population ReductionLocalReplacement(Population population, Population temporaryPopulation)
        {
            population.SortListByFitness();
            temporaryPopulation.SortListByFitness();

            return null;
        }*/
        private double[] ObservationSet(int[] filters, double[,] ranges, double[,] initialData, int rowsNumder, int columnsNumber)
        {
            double[] fitnessSet = new double[rowsNumder];
            int setQuantity = 0;
            int counter = 0;
            for (int j = 0; j < rowsNumder; j++)
            {
                if (FilterExisting((int)initialData[j, 1], filters))
                {
                    counter = 0;
                    for (int i = 0; i < (columnsNumber - 3); i++)
                    {
                        if ((initialData[j, i + 3] >= ranges[i, 0]) && (initialData[j, i + 3] <= ranges[i, 1]))
                        {
                            counter++;
                        }
                    }
                    if (counter == (columnsNumber - 3))
                    {
                        fitnessSet[setQuantity] = initialData[j, 2];
                        setQuantity++;
                    }
                }
            }
            double[] fs = fitnessSet;
            fitnessSet = new double[setQuantity];
            for (int i = 0; i < setQuantity; i++)
                fitnessSet[i] = fs[i];
            return fitnessSet;
        }
        private bool FilterExisting(int currentFilter, int[] setForChoosing)
        {
            int num = setForChoosing.Length;
            for (int i = 0; i < num; i++)
            {
                if (setForChoosing[i] == currentFilter) return true;
            }
            return false;
        }
        private double GetMinimum(double[] data)
        {
            int num = data.Length;
            if (num < 1) return 0;
            double min = 1;
            for (int i = 0; i < num; i++)
            {
                if (data[i] < min) min = data[i];
            }
            return min;
        }
        private double GetMean(double[] data)
        {
            int num = data.Length;
            if (num < 1) return 0;
            double mean = 0;
            for (int i = 0; i < num; i++)
            {
                mean += data[i];
            }
            mean /= num;
            return mean;
        }
    }
}
