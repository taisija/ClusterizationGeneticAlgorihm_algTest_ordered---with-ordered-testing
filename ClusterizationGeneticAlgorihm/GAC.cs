using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ClusterizationGeneticAlgorihm
{
    public partial class GAC : Form
    {
        private TxtParser txtParser;
        private TxtParser txtParserForTest;
        private SerialGA SGA;
        private ParallelGA PGA;
        private SerialGATest SGAT;
        private ParallelGATest PGAT;
        private Operator oper;
        private Individual[] parentIndiv;
        private Individual[] offspringsIndiv;
        private TestingResultsOfClasterization testingResult;
        private int crossoveRate;
        private int mutationRate;
        private Population population;
        private Population tempPopulation;
        private string resultFileName;
        private string resultTestFileName;
        private int generation = 0;
        private int generationNumber;
        private System.Windows.Forms.Timer myTimer;
        private bool endActionFlag = false;
        private bool searchClick = false;
        public GAC()
        {
            InitializeComponent();
            myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += timer_Tick;
            myTimer.Interval = 5000;
            myTimer.Enabled = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (checkBoxTest.Checked)
            {
                if (radioButtonSerialGA.Checked)
                {
                    if (searchClick)
                        progressBar.Value = SGAT.CurrentTestNumber;
                }
                else
                {
                    if (searchClick)
                        progressBar.Value = PGAT.CurrentTestNumber;
                }
            }
            else
            {
                if (radioButtonSerialGA.Checked)
                {
                    if (searchClick)
                        progressBar.Value = SGA.Series;
                }
                else
                {
                    if (searchClick)
                        progressBar.Value = PGA.Generation;

                }
            }
            //this.Refresh();
            if (endActionFlag)
            {
                myTimer.Stop();
                progressBar.Value = 0;
                searchClick = false;
                buttonSearch.Enabled = false;
            }
        }
        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            if (openFileDialogLoadData.ShowDialog() == DialogResult.OK)
            {
                txtParser = new TxtParser(openFileDialogLoadData.FileName, int.Parse(textBoxObservationsNumber.Text));
                if (openFileDialogTestData.ShowDialog() == DialogResult.OK)
                {
                    txtParserForTest = new TxtParser(openFileDialogTestData.FileName, int.Parse(textBoxObservationsNumber.Text));
                    if (this.checkBoxTest.Checked)
                        this.buttonTestGA.Enabled = true;
                    else
                        this.buttonSearch.Enabled = true;
                }
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            testingResult = new TestingResultsOfClasterization(100);
            SGA = new SerialGA();
            PGA = new ParallelGA();
            searchClick = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = int.Parse(textBoxGenerationsNumber.Text);
            if (saveResultsFileDialog.ShowDialog() == DialogResult.OK)
            {
                resultFileName = saveResultsFileDialog.FileName;
                if (saveFileDialogTestData.ShowDialog() == DialogResult.OK)
                {
                    resultTestFileName = saveFileDialogTestData.FileName;
                    Thread st = new Thread(Search);
                    st.IsBackground = true;
                    st.Start();
                }
            }
        }
        private void Search()
        {
            if (radioButtonSerialGA.Checked)
            {
                SGA.RunGA(int.Parse(textBoxSeriesNumber.Text), txtParser, int.Parse(textBoxPopulationQuantity.Text), double.Parse(textBoxMutationRate.Text), double.Parse(textBoxCrossoverRate.Text), int.Parse(textBoxGenerationsNumber.Text));
                for (int i = 0; i < int.Parse(textBoxSeriesNumber.Text); i++)
                {
                    testingResult.AddBestSamplesFromPopulation(SGA.PopulationList[i], 0.85);
                }
            }
            else
            {
                PGA.RunGA(int.Parse(textBoxSeriesNumber.Text), txtParser, int.Parse(textBoxPopulationQuantity.Text), double.Parse(textBoxMutationRate.Text), double.Parse(textBoxCrossoverRate.Text), int.Parse(textBoxGenerationsNumber.Text));
                for (int i = 0; i < int.Parse(textBoxSeriesNumber.Text); i++)
                {
                    testingResult.AddBestSamplesFromPopulation(PGA.PopulationList[i], 0.85);
                }
            }
            endActionFlag = true;
            testingResult.SaveCurrentResultsWithAllParameters(resultFileName, txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
            testingResult.SaveCurrentResultsWithAllParameters(resultTestFileName, txtParserForTest.Numbers, txtParserForTest.NumberOfLines, txtParserForTest.NumberOfColumns);

        }

        private void buttonTestGA_Click(object sender, EventArgs e)
        {
            //Testing
            testingResult = new TestingResultsOfClasterization(100);
            SGAT = new SerialGATest(double.Parse(textBoxTestingResultsSelectionThreshold.Text), int.Parse(textBoxTournamentGroupQuantity.Text),
                double.Parse(textBoxPercentOfChangeGeneInInitializationStep.Text), 100);
            PGAT = new ParallelGATest(double.Parse(textBoxTestingResultsSelectionThreshold.Text),
                double.Parse(textBoxTransmissionRateBetweenParallelPopulations.Text), int.Parse(textBoxTournamentGroupQuantity.Text),
                double.Parse(textBoxPercentOfChangeGeneInInitializationStep.Text), 100);
            searchClick = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = int.Parse(textBoxRunsNumber.Text);
            if (saveResultsFileDialog.ShowDialog() == DialogResult.OK)
            {
                resultFileName = saveResultsFileDialog.FileName;
                if (saveFileDialogTestData.ShowDialog() == DialogResult.OK)
                {
                    resultTestFileName = saveFileDialogTestData.FileName;
                    Thread st = new Thread(SearchTest);
                    st.IsBackground = true;
                    st.Start();
                }
            }
        }
        private void SearchTest()
        {
            if (radioButtonSerialGA.Checked)
            {
                SGAT.RunSerialGATest(int.Parse(textBoxSeriesNumber.Text), txtParser, int.Parse(textBoxPopulationQuantity.Text), 
                    double.Parse(textBoxMutationRate.Text), double.Parse(textBoxCrossoverRate.Text), int.Parse(textBoxGenerationsNumber.Text),
                    int.Parse(textBoxRunsNumber.Text));
                for (int i = 0; i < SGAT.IndividualListCounter; i++)
                {
                    testingResult.AddClasterizationSample(SGAT.IndividualList[i]);
                }
            }
            else
            {
                PGAT.RunParallelGATest(int.Parse(textBoxSeriesNumber.Text), txtParser, int.Parse(textBoxPopulationQuantity.Text), 
                    double.Parse(textBoxMutationRate.Text), double.Parse(textBoxCrossoverRate.Text), int.Parse(textBoxGenerationsNumber.Text),
                    int.Parse(textBoxRunsNumber.Text));
                for (int i = 0; i < PGAT.IndividualListCounter; i++)
                {
                    testingResult.AddClasterizationSample(PGAT.IndividualList[i]);
                }
            }
            endActionFlag = true;
            testingResult.SaveCurrentResultsWithAllParameters(resultFileName, txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
            //testingResult.SaveCurrentResultsWithAllParametersAndAnotherFitness(resultFileName + "AnotherFitness.txt", txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns, 0.1);
            testingResult.SaveMin_Mean_NumberOfCurrentResults(resultFileName + "min.txt", txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns);
            //testingResult.SaveMin_Mean_NumberOfCurrentResultsAndAnotherFitness(resultFileName + "AnotherFitnessMin.txt", txtParser.Numbers, txtParser.NumberOfLines, txtParser.NumberOfColumns, 0.1);
            testingResult.SaveCurrentResultsWithAllParameters(resultTestFileName, txtParserForTest.Numbers, txtParserForTest.NumberOfLines, txtParserForTest.NumberOfColumns);
            testingResult.SaveMin_Mean_NumberOfCurrentResults(resultTestFileName + "min.txt", txtParserForTest.Numbers, txtParserForTest.NumberOfLines, txtParserForTest.NumberOfColumns);
        }
    }
}
