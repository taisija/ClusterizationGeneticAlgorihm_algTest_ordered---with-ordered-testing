using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClusterizationGeneticAlgorihm
{
    class TestingResultsOfClasterization
    {
        public TestingResultsOfClasterization()
        {
            samplesNumber = 0;
            currentSamplesNumber = 0;
        }
        public TestingResultsOfClasterization(int expectedSamplesNumber)
        {
            samplesNumber = expectedSamplesNumber;
            currentSamplesNumber = 0;
            samples = new Individual[expectedSamplesNumber];
        }
        public void AddBestSamplesFromPopulation(Population population, double threshold)
        {
            population.SortListByFitness();
            double[] fitness = population.IndividualFitnessList;
            int i = 0;
            while((fitness[i] > threshold) && (i < population.PopulationQuantity))
            {
                AddClasterizationSample(population.GetIndividualByIndex(i));
                i++;
            }
        }
        public int AddClasterizationSample(Individual individual)
        {
            if (samples != null)
            {
                if (currentSamplesNumber < samplesNumber)
                {
                    samples[currentSamplesNumber] = individual;
                    currentSamplesNumber++;
                }
                else
                {
                    Individual[] s = new Individual[samplesNumber + 1];
                    for (int i = 0; i < samplesNumber; i++)
                    {
                        s[i] = samples[i];
                    }
                    s[samplesNumber] = individual;
                    samplesNumber++;
                    samples = s;
                }
            }
            else
            {
                samples = new Individual[10];
                samples[0] = individual;
            }
            return samplesNumber;
        }
        //test data structure imageNum-filterNum-fitness-parameners
        //max filters number by default 325
        public void TestResults(double[,] testData, int rowsNumber, int columnsNumber)
        {
            resultsOfTesting = new double[currentSamplesNumber][];
            for (int k = 0; k < currentSamplesNumber; k++)
            {
                int setQuantity = 0;
                double[] temp = new double[325];
                double[,] currentSampleContent = ((ChromosomeTypeOne)samples[k].GetIndividualContent()[0]).ChromosomeContent;
                int[] currentSampleFilter = ((ChromosomeTypeTwo)samples[k].GetIndividualContent()[1]).ChromosomeContent;
                for (int j = 0; j < rowsNumber; j++)
                {
                    if (NumberExisting((int)testData[j, 1], currentSampleFilter))
                    {
                        for (int i = 0; i < (columnsNumber - 3); i++)
                        {
                            if ((currentSampleContent[i, 0] != 0) || (currentSampleContent[i, 1] != 1))
                            {
                                if ((testData[j, i + 3] >= currentSampleContent[i, 0]) && (testData[j, i + 3] <= currentSampleContent[i, 0]))
                                {
                                    temp[setQuantity] = testData[j, 2];
                                    setQuantity++;
                                }
                            }
                        }
                    }
                }
                resultsOfTesting[k] = new double[setQuantity];
                for (int i = 0; i < setQuantity; i++)
                    resultsOfTesting[k][i] = temp[i];
            }
        }
        private void TestResultsForParameters(double[,] testData, int rowsNumber, int columnsNumber)
        {
            resultsOfTesting = new double[currentSamplesNumber][];
            paramsOfTestingResultsIm = new double[currentSamplesNumber][];
            paramsOfTestingResultsFil = new double[currentSamplesNumber][];
            min_mean_number_resultsOfTesting = new double[currentSamplesNumber, 3];
            for (int k = 0; k < currentSamplesNumber; k++)
            {
                int setQuantity = 0;
                double[] temp = new double[3250];
                double[] tempParImageNum = new double[3250];
                double[] tempParFilterNum = new double[3250];
                double tempMin = 1;
                double tempMean = 0;
                int tempCount = 0;
                double[,] currentSampleContent = ((ChromosomeTypeOne)samples[k].GetIndividualContent()[0]).ChromosomeContent;
                int[] currentSampleFilter = ((ChromosomeTypeTwo)samples[k].GetIndividualContent()[1]).ChromosomeContent;
                int counter = 0;
                for (int j = 0; j < rowsNumber; j++)
                {
                    if (NumberExisting((int)testData[j, 1], currentSampleFilter))
                    {
                        counter = 0;
                        for (int i = 0; i < (columnsNumber - 3); i++)
                        {
                            if ((testData[j, i + 3] >= currentSampleContent[i, 0]) && (testData[j, i + 3] <= currentSampleContent[i, 1]))
                            {
                                counter++;
                            }
                        }
                        if (counter == (columnsNumber - 3))
                        {
                            temp[setQuantity] = testData[j, 2];//fitness
                            tempParImageNum[setQuantity] = testData[j, 0];//image №
                            tempParFilterNum[setQuantity] = testData[j, 1];//first filter №(not for all)
                            if (tempMin > testData[j, 2]) tempMin = testData[j, 2];
                            tempMean += testData[j, 2];
                            setQuantity++;
                        }
                    }
                }
                resultsOfTesting[k] = new double[setQuantity];
                paramsOfTestingResultsIm[k] = new double[setQuantity];
                paramsOfTestingResultsFil[k] = new double[setQuantity];
                for (int i = 0; i < setQuantity; i++)
                {
                    resultsOfTesting[k][i] = temp[i];
                    paramsOfTestingResultsIm[k][i] = tempParImageNum[i];
                    paramsOfTestingResultsFil[k][i] = tempParFilterNum[i];
                }
                //min_mean_number_resultsOfTesting[k, 0] = tempMin;
                //min_mean_number_resultsOfTesting = new double[currentSamplesNumber, 3];
                min_mean_number_resultsOfTesting[k, 0] = tempMin;
                min_mean_number_resultsOfTesting[k, 1] = tempMean/(double)setQuantity;
                min_mean_number_resultsOfTesting[k, 2] = setQuantity;
            }
        }
        private void TestResultsForParametersAndAnotherFitness(double[,] testData, int rowsNumber, int columnsNumber, double fitnessCoefficient)
        {
            resultsOfTesting = new double[currentSamplesNumber][];
            paramsOfTestingResultsIm = new double[currentSamplesNumber][];
            paramsOfTestingResultsFil = new double[currentSamplesNumber][];
            min_mean_number_resultsOfTesting = new double[currentSamplesNumber, 3];
            for (int k = 0; k < currentSamplesNumber; k++)
            {
                int setQuantity = 0;
                double[] temp = new double[3250];
                double[] tempParImageNum = new double[3250];
                double[] tempParFilterNum = new double[3250];
                double tempMin = 1;
                double tempMean = 0;
                int tempCount = 0;
                double[,] currentSampleContent = ((ChromosomeTypeOne)samples[k].GetIndividualContent()[0]).ChromosomeContent;
                int[] currentSampleFilter = ((ChromosomeTypeTwo)samples[k].GetIndividualContent()[1]).ChromosomeContent;
                int counter = 0;
                for (int j = 0; j < rowsNumber; j++)
                {
                    if (NumberExisting((int)testData[j, 1], currentSampleFilter))
                    {
                        counter = 0;
                        for (int i = 0; i < (columnsNumber - 3); i++)
                        {
                            if ((testData[j, i + 3] >= currentSampleContent[i, 0]) && (testData[j, i + 3] <= currentSampleContent[i, 1]))
                            {
                                counter++;
                            }
                        }
                        if (counter == (columnsNumber - 3))
                        {
                            temp[setQuantity] = testData[j, 2];//fitness
                            tempParImageNum[setQuantity] = testData[j, 0];//image №
                            tempParFilterNum[setQuantity] = testData[j, 1];//first filter №(not for all)
                            if (tempMin > testData[j, 2]) tempMin = testData[j, 2];
                            tempMean += testData[j, 2];
                            setQuantity++;
                        }
                    }
                }
                resultsOfTesting[k] = new double[setQuantity];
                paramsOfTestingResultsIm[k] = new double[setQuantity];
                paramsOfTestingResultsFil[k] = new double[setQuantity];
                for (int i = 0; i < setQuantity; i++)
                {
                    resultsOfTesting[k][i] = temp[i];
                    paramsOfTestingResultsIm[k][i] = tempParImageNum[i];
                    paramsOfTestingResultsFil[k][i] = tempParFilterNum[i];
                }
                //min_mean_number_resultsOfTesting[k, 0] = tempMin;
                //min_mean_number_resultsOfTesting = new double[currentSamplesNumber, 3];
                min_mean_number_resultsOfTesting[k, 0] = tempMin - 0.1 / (double)setQuantity;
                min_mean_number_resultsOfTesting[k, 1] = tempMean / (double)setQuantity;
                min_mean_number_resultsOfTesting[k, 2] = setQuantity;
            }
        }
        /* структура функции тестирования не изменилась, был использован объект класса testInfo 
         * с целью сокращения кода (класс встроенный и описан в конце файла)
         * */
        private void OrderedTestResultsForParameters(double[,] testData, int rowsNumber, int columnsNumber)
        {
            resultsOfTesting = new double[currentSamplesNumber][];
            paramsOfTestingResultsIm = new double[currentSamplesNumber][];
            paramsOfTestingResultsFil = new double[currentSamplesNumber][];
            paramsOfTestingResultsFilOrderNum = new int[currentSamplesNumber][];
            paramsOfTestingResultsFilDifference = new double[currentSamplesNumber][];
            min_mean_number_resultsOfTesting = new double[currentSamplesNumber, 3];
            for (int k = 0; k < currentSamplesNumber; k++)
            {
                TestInfo testInfo = new TestInfo(3250);
                double[,] currentSampleContent = ((ChromosomeTypeOne)samples[k].GetIndividualContent()[0]).ChromosomeContent;
                int[] currentSampleFilter = ((ChromosomeTypeTwo)samples[k].GetIndividualContent()[1]).ChromosomeContent;
                testInfo.SelectFittedImages(testData, rowsNumber, columnsNumber, 
                                            currentSampleContent, currentSampleFilter);
                testInfo.GetNumberOfFiltersByEffectiveness(testData, rowsNumber, columnsNumber,
                                            currentSampleContent, currentSampleFilter);
                resultsOfTesting[k] = new double[testInfo.SetQuantity];
                paramsOfTestingResultsIm[k] = new double[testInfo.SetQuantity];
                paramsOfTestingResultsFil[k] = new double[testInfo.SetQuantity];
                paramsOfTestingResultsFilOrderNum[k] = new int[testInfo.SetQuantity];
                for (int i = 0; i < testInfo.SetQuantity; i++)
                {
                    resultsOfTesting[k][i] = testInfo.Temp[i];
                    paramsOfTestingResultsIm[k][i] = testInfo.TempParImageNum[i];
                    paramsOfTestingResultsFil[k][i] = testInfo.TempParFilterNum[i];
                }
                min_mean_number_resultsOfTesting[k, 0] = testInfo.TempMin;
                min_mean_number_resultsOfTesting[k, 1] = testInfo.TempMean / (double)testInfo.SetQuantity;
                min_mean_number_resultsOfTesting[k, 2] = testInfo.SetQuantity;
                //добавить
                paramsOfTestingResultsFilOrderNum[k] = testInfo.NumberOfFilterByEffectiveness;
                paramsOfTestingResultsFilDifference[k] = testInfo.DifferenceOfEffectiveness;
            }
        }
        public bool SaveCurrentResultsWithAllParametersAndAnotherFitness(string fileName, double[,] testData, int rowsNumber, int columnsNumber, double fitnessCoefficient)
        {
            TestResultsForParametersAndAnotherFitness(testData, rowsNumber, columnsNumber,fitnessCoefficient);
            int len = resultsOfTesting.Length;
            int rowLen = 0;
            double[][] newData = resultsOfTesting;
            try
            {
                using (TextWriter writer = File.CreateText(fileName))
                {
                    for (int i = 0; i < len; i++)
                    {
                        rowLen = newData[i].Length;
                        writer.Write((rowLen).ToString() + " ");
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((newData[i][j]).ToString() + " ");
                        }
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((paramsOfTestingResultsIm[i][j]).ToString() + " ");
                        }
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((paramsOfTestingResultsFil[i][j]).ToString() + " ");
                        }
                        writer.WriteLine();
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        //сохраняет в том числе номер фильтра по "эффективности" и разницу фтнессса этого фильтра и самого эффективного
        public bool SaveCurrentResultsWithAllParameters(string fileName, double[,] testData, int rowsNumber, int columnsNumber)
        {
            //TestResultsForParameters(testData, rowsNumber, columnsNumber);
            OrderedTestResultsForParameters(testData, rowsNumber, columnsNumber);
            int len = resultsOfTesting.Length;
            int rowLen = 0;
            double[][] newData = resultsOfTesting;
            try
            {
                using (TextWriter writer = File.CreateText(fileName))
                {
                    for (int i = 0; i < len; i++)
                    {
                        rowLen = newData[i].Length;
                        writer.Write((rowLen).ToString() + " ");
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((newData[i][j]).ToString() + " ");
                        }
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((paramsOfTestingResultsIm[i][j]).ToString() + " ");
                        }
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((paramsOfTestingResultsFil[i][j]).ToString() + " ");
                        }
                        //дописываем номер фильтра для текущего изображения по значению фитнесс функции
                        writer.WriteLine();
                        writer.Write("Filtration scheme number by effectivness: ");
                        rowLen = paramsOfTestingResultsFilOrderNum[i].Length;
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((paramsOfTestingResultsFilOrderNum[i][j]).ToString() + " ");
                        }
                        writer.WriteLine("");
                        writer.Write("Difference between current filtretion scheme and best scheme for current image: ");
                        //дописываем разницу фитнесса выбранного фильтра и лучшего фильтра
                        rowLen = paramsOfTestingResultsFilDifference[i].Length;
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((paramsOfTestingResultsFilDifference[i][j]).ToString() + " ");
                        }
                        writer.WriteLine();
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        public bool SaveMin_Mean_NumberOfCurrentResults(string fileName, double[,] testData, int rowsNumber, int columnsNumber)
        {
            TestResultsForParameters(testData, rowsNumber, columnsNumber);
            int len = resultsOfTesting.Length;
            int rowLen = 0;
            double[][] newData = resultsOfTesting;
            try
            {
                using (TextWriter writer = File.CreateText(fileName))
                {
                    for (int i = 0; i < len; i++)
                    {
                        rowLen = newData[i].Length;
                        if (rowLen > 0)
                        {
                            writer.Write((min_mean_number_resultsOfTesting[i, 2]).ToString() + " ");
                            writer.Write((min_mean_number_resultsOfTesting[i, 0]).ToString() + " ");
                            writer.Write((min_mean_number_resultsOfTesting[i, 1]).ToString() + " ");
                            writer.WriteLine();
                        }
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        public bool SaveMin_Mean_NumberOfCurrentResultsAndAnotherFitness(string fileName, double[,] testData, int rowsNumber, int columnsNumber,double fitnessCoefficient)
        {
            TestResultsForParametersAndAnotherFitness(testData, rowsNumber, columnsNumber, fitnessCoefficient);
            int len = resultsOfTesting.Length;
            int rowLen = 0;
            double[][] newData = resultsOfTesting;
            try
            {
                using (TextWriter writer = File.CreateText(fileName))
                {
                    for (int i = 0; i < len; i++)
                    {
                        rowLen = newData[i].Length;
                        if (rowLen > 0)
                        {
                            writer.Write((min_mean_number_resultsOfTesting[i, 2]).ToString() + " ");
                            writer.Write((min_mean_number_resultsOfTesting[i, 0]).ToString() + " ");
                            writer.Write((min_mean_number_resultsOfTesting[i, 1]).ToString() + " ");
                            writer.WriteLine();
                        }
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        private bool NumberExisting(int currentNumber, int[] setForChoosing)
        {
            int num = setForChoosing.Length;
            for (int i = 0; i < num; i++)
            {
                if (setForChoosing[i] == currentNumber) return true;
            }
            return false;
        }
        public bool SearchClasterByParameters(double[] imageParameters, int parametersNumber, double[,] diapasons)
        {
            for (int i = 0; i < parametersNumber; i++)
            {
                if ((imageParameters[i] < diapasons[i, 0]) || (imageParameters[i] > diapasons[i, 1]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool SaveCurrentResults(string fileName)
        {
            int len = resultsOfTesting.Length;
            int rowLen = 0;
            double[][] newData = resultsOfTesting;
            try
            {
                using (TextWriter writer = File.CreateText(fileName))
                {
                    for (int i = 0; i < len; i++)
                    {
                        rowLen = newData[i].Length;
                        writer.Write((rowLen).ToString()+ " ");
                        for (int j = 0; j < rowLen; j++)
                        {
                            writer.Write((newData[i][j]).ToString() + " ");
                        }
                        writer.WriteLine();
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }
        /* встроенные класс, обеспечивающий основной функционал тестирования и сохранения результатов
         * в своих полях, результаты можно получить при помощи геттеров
         * */
        private class TestInfo {
            public TestInfo(int maxSetQuantity)
            {
                setQuantity = 0;
                temp = new double[maxSetQuantity];
                tempParImageNum = new double[maxSetQuantity];
                tempParFilterNum = new double[maxSetQuantity];
                tempMin = 1;
                tempMean = 0;
                tempCount = 0;
            }
            private bool NumberExisting(int currentNumber, int[] setForChoosing)
            {
                int num = setForChoosing.Length;
                for (int i = 0; i < num; i++)
                {
                    if (setForChoosing[i] == currentNumber) return true;
                }
                return false;
            }
            /* обеспечивает поиск и сохранение во внутренних полях класса списка значений фитнесс функции
             * схемы фильтрации на подходящих для особи изображениях, соответствующий список номеров изображений
             * номер схемы фильтрации (только 1-й), среднее значение фитнесса для всех изображений, 
             * удовлетворяющих схеме
             * */
            public void SelectFittedImages(double[,] testData, int rowsNumber, int columnsNumber,
                                         double[,] currentSampleContent, int[] currentSampleFilter){
                int counter = 0;
                for (int j = 0; j < rowsNumber; j++)
                {
                    if (NumberExisting((int)testData[j, 1], currentSampleFilter))
                    {
                        counter = 0;
                        for (int i = 0; i < (columnsNumber - 3); i++)
                        {
                            if ((testData[j, i + 3] >= currentSampleContent[i, 0]) && (testData[j, i + 3] <= currentSampleContent[i, 1]))
                            {
                                counter++;
                            }
                        }
                        /* если изображение подходит, то запоминаю его, фильтр и фитнесс,
                        * увеличиваю количество изображений setQuantity для этой особи */
                        if (counter == (columnsNumber - 3))
                        {
                            temp[setQuantity] = testData[j, 2];//fitness
                            tempParImageNum[setQuantity] = testData[j, 0];//image №
                            tempParFilterNum[setQuantity] = testData[j, 1];//first filter №(not for all)
                            if (tempMin > testData[j, 2]) tempMin = testData[j, 2];
                            tempMean += testData[j, 2];
                            setQuantity++;
                        }
                    }
                }
            }
            public void GetNumberOfFiltersByEffectiveness(double[,] testData, int rowsNumber, int columnsNumber,
                                         double[,] currentSampleContent, int[] currentSampleFilter){
                int counter;
                numberOfFilterByEffectiveness = new int[setQuantity];
                differenceOfEffectiveness = new double[setQuantity];
                for (int i = 0; i < setQuantity; i++)
                {
                    counter = 0;
                    numberOfFilterByEffectiveness[i] = 0;
                    differenceOfEffectiveness[i] = 0;
                    for (int j = 0; j < rowsNumber; j++)
                    {
                        //when we search out image, we need to inspect it
                        if (tempParImageNum[i] == testData[j, 0])
                        {
                            if (temp[i] < testData[j, 2])
                            {
                                numberOfFilterByEffectiveness[i]++;
                                if ((testData[j, 2] - temp[i]) > differenceOfEffectiveness[i])
                                    differenceOfEffectiveness[i] = testData[j, 2] - temp[i];
                            }
                        }
                    }
                }

            }
            public int SetQuantity { get { return setQuantity; } set { setQuantity = value; } }
            public double TempMin { get { return tempMin; } set { tempMin = value; } }
            public double TempMean { get { return tempMean; } set { tempMean = value; } }
            public int TempCount { get { return tempCount; } set { tempCount = value; } }
            public double[] Temp { get { return (temp); } }
            public double[] TempParImageNum { get { return (tempParImageNum); } }
            public double[] TempParFilterNum { get { return (tempParFilterNum); } }
            public double[] DifferenceOfEffectiveness { get { return (differenceOfEffectiveness); } }
            public int[] NumberOfFilterByEffectiveness { get { return (numberOfFilterByEffectiveness); } }

            private int setQuantity;
            private double[] temp;
            private double[] tempParImageNum;
            private double[] tempParFilterNum;
            private int[] numberOfFilterByEffectiveness;
            private double[] differenceOfEffectiveness;
            private double tempMin;
            private double tempMean;
            private int tempCount;
        }
        private double[][] resultsOfTesting;
        private double[][] paramsOfTestingResultsFil;
        private double[][] paramsOfTestingResultsIm;
        private int[][] paramsOfTestingResultsFilOrderNum;
        private double[][] paramsOfTestingResultsFilDifference;
        private double[,] min_mean_number_resultsOfTesting;
        private int currentSamplesNumber;
        private int samplesNumber;
        private Individual[] samples;
    }
}
