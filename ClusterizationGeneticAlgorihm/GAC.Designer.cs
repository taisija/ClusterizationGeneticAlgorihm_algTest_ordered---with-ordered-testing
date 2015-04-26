namespace ClusterizationGeneticAlgorihm
{
    partial class GAC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxChromosomeType = new System.Windows.Forms.GroupBox();
            this.radioButtonOneChromosomeSpace = new System.Windows.Forms.RadioButton();
            this.radioButtonTwoChromosomeSpace = new System.Windows.Forms.RadioButton();
            this.crossoverRateLabel = new System.Windows.Forms.Label();
            this.textBoxCrossoverRate = new System.Windows.Forms.TextBox();
            this.labelMutationRate = new System.Windows.Forms.Label();
            this.textBoxMutationRate = new System.Windows.Forms.TextBox();
            this.textBoxPopulationQuantity = new System.Windows.Forms.TextBox();
            this.labelPopulationQuantity = new System.Windows.Forms.Label();
            this.textBoxGenerationsNumber = new System.Windows.Forms.TextBox();
            this.labelGenerationsNumber = new System.Windows.Forms.Label();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxMutationRate2 = new System.Windows.Forms.TextBox();
            this.labelMutationRate2 = new System.Windows.Forms.Label();
            this.textBoxCrossoverRate2 = new System.Windows.Forms.TextBox();
            this.labelCrossoverRate2 = new System.Windows.Forms.Label();
            this.openFileDialogLoadData = new System.Windows.Forms.OpenFileDialog();
            this.labelInitialParametersNumber = new System.Windows.Forms.Label();
            this.textBoxObservationsNumber = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxSeriesNumber = new System.Windows.Forms.TextBox();
            this.labelSeriesNumber = new System.Windows.Forms.Label();
            this.groupBoxAlgorithmType = new System.Windows.Forms.GroupBox();
            this.radioButtonSerialGA = new System.Windows.Forms.RadioButton();
            this.radioButtonParallelGA = new System.Windows.Forms.RadioButton();
            this.saveResultsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogTestData = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogTestData = new System.Windows.Forms.SaveFileDialog();
            this.buttonTestGA = new System.Windows.Forms.Button();
            this.textBoxTestingResultsSelectionThreshold = new System.Windows.Forms.TextBox();
            this.labelTestingResultsSelectionThreshold = new System.Windows.Forms.Label();
            this.checkBoxTest = new System.Windows.Forms.CheckBox();
            this.labelRunsNumber = new System.Windows.Forms.Label();
            this.textBoxRunsNumber = new System.Windows.Forms.TextBox();
            this.labelPercentOfChangeGeneInInitializationStep = new System.Windows.Forms.Label();
            this.textBoxPercentOfChangeGeneInInitializationStep = new System.Windows.Forms.TextBox();
            this.labelTournamentGroupQuantity = new System.Windows.Forms.Label();
            this.textBoxTournamentGroupQuantity = new System.Windows.Forms.TextBox();
            this.labelTransmissionRateBetweenParallelPopulations = new System.Windows.Forms.Label();
            this.textBoxTransmissionRateBetweenParallelPopulations = new System.Windows.Forms.TextBox();
            this.groupBoxChromosomeType.SuspendLayout();
            this.groupBoxAlgorithmType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxChromosomeType
            // 
            this.groupBoxChromosomeType.Controls.Add(this.radioButtonOneChromosomeSpace);
            this.groupBoxChromosomeType.Controls.Add(this.radioButtonTwoChromosomeSpace);
            this.groupBoxChromosomeType.Location = new System.Drawing.Point(354, 12);
            this.groupBoxChromosomeType.Name = "groupBoxChromosomeType";
            this.groupBoxChromosomeType.Size = new System.Drawing.Size(195, 69);
            this.groupBoxChromosomeType.TabIndex = 0;
            this.groupBoxChromosomeType.TabStop = false;
            this.groupBoxChromosomeType.Text = "Chromosome Type";
            // 
            // radioButtonOneChromosomeSpace
            // 
            this.radioButtonOneChromosomeSpace.AutoSize = true;
            this.radioButtonOneChromosomeSpace.Location = new System.Drawing.Point(7, 19);
            this.radioButtonOneChromosomeSpace.Name = "radioButtonOneChromosomeSpace";
            this.radioButtonOneChromosomeSpace.Size = new System.Drawing.Size(106, 17);
            this.radioButtonOneChromosomeSpace.TabIndex = 1;
            this.radioButtonOneChromosomeSpace.Text = "one chromosome";
            this.radioButtonOneChromosomeSpace.UseVisualStyleBackColor = true;
            // 
            // radioButtonTwoChromosomeSpace
            // 
            this.radioButtonTwoChromosomeSpace.AutoSize = true;
            this.radioButtonTwoChromosomeSpace.Checked = true;
            this.radioButtonTwoChromosomeSpace.Location = new System.Drawing.Point(6, 42);
            this.radioButtonTwoChromosomeSpace.Name = "radioButtonTwoChromosomeSpace";
            this.radioButtonTwoChromosomeSpace.Size = new System.Drawing.Size(105, 17);
            this.radioButtonTwoChromosomeSpace.TabIndex = 0;
            this.radioButtonTwoChromosomeSpace.TabStop = true;
            this.radioButtonTwoChromosomeSpace.Text = "two chromosome";
            this.radioButtonTwoChromosomeSpace.UseVisualStyleBackColor = true;
            // 
            // crossoverRateLabel
            // 
            this.crossoverRateLabel.AutoSize = true;
            this.crossoverRateLabel.Location = new System.Drawing.Point(359, 154);
            this.crossoverRateLabel.Name = "crossoverRateLabel";
            this.crossoverRateLabel.Size = new System.Drawing.Size(80, 13);
            this.crossoverRateLabel.TabIndex = 1;
            this.crossoverRateLabel.Text = "Crossover Rate";
            // 
            // textBoxCrossoverRate
            // 
            this.textBoxCrossoverRate.Location = new System.Drawing.Point(474, 151);
            this.textBoxCrossoverRate.Name = "textBoxCrossoverRate";
            this.textBoxCrossoverRate.Size = new System.Drawing.Size(75, 20);
            this.textBoxCrossoverRate.TabIndex = 2;
            this.textBoxCrossoverRate.Text = "0,7";
            // 
            // labelMutationRate
            // 
            this.labelMutationRate.AutoSize = true;
            this.labelMutationRate.Location = new System.Drawing.Point(359, 180);
            this.labelMutationRate.Name = "labelMutationRate";
            this.labelMutationRate.Size = new System.Drawing.Size(74, 13);
            this.labelMutationRate.TabIndex = 3;
            this.labelMutationRate.Text = "Mutation Rate";
            // 
            // textBoxMutationRate
            // 
            this.textBoxMutationRate.Location = new System.Drawing.Point(474, 177);
            this.textBoxMutationRate.Name = "textBoxMutationRate";
            this.textBoxMutationRate.Size = new System.Drawing.Size(75, 20);
            this.textBoxMutationRate.TabIndex = 4;
            this.textBoxMutationRate.Text = "0,1";
            // 
            // textBoxPopulationQuantity
            // 
            this.textBoxPopulationQuantity.Location = new System.Drawing.Point(474, 255);
            this.textBoxPopulationQuantity.Name = "textBoxPopulationQuantity";
            this.textBoxPopulationQuantity.Size = new System.Drawing.Size(75, 20);
            this.textBoxPopulationQuantity.TabIndex = 5;
            this.textBoxPopulationQuantity.Text = "50";
            // 
            // labelPopulationQuantity
            // 
            this.labelPopulationQuantity.AutoSize = true;
            this.labelPopulationQuantity.Location = new System.Drawing.Point(359, 258);
            this.labelPopulationQuantity.Name = "labelPopulationQuantity";
            this.labelPopulationQuantity.Size = new System.Drawing.Size(99, 13);
            this.labelPopulationQuantity.TabIndex = 6;
            this.labelPopulationQuantity.Text = "Population Quantity";
            // 
            // textBoxGenerationsNumber
            // 
            this.textBoxGenerationsNumber.Location = new System.Drawing.Point(474, 281);
            this.textBoxGenerationsNumber.Name = "textBoxGenerationsNumber";
            this.textBoxGenerationsNumber.Size = new System.Drawing.Size(75, 20);
            this.textBoxGenerationsNumber.TabIndex = 7;
            this.textBoxGenerationsNumber.Text = "50";
            // 
            // labelGenerationsNumber
            // 
            this.labelGenerationsNumber.AutoSize = true;
            this.labelGenerationsNumber.Location = new System.Drawing.Point(359, 284);
            this.labelGenerationsNumber.Name = "labelGenerationsNumber";
            this.labelGenerationsNumber.Size = new System.Drawing.Size(104, 13);
            this.labelGenerationsNumber.TabIndex = 8;
            this.labelGenerationsNumber.Text = "Generations Number";
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Location = new System.Drawing.Point(367, 427);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadData.TabIndex = 9;
            this.buttonLoadData.Text = "Load Data";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(474, 427);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxMutationRate2
            // 
            this.textBoxMutationRate2.Location = new System.Drawing.Point(474, 229);
            this.textBoxMutationRate2.Name = "textBoxMutationRate2";
            this.textBoxMutationRate2.Size = new System.Drawing.Size(75, 20);
            this.textBoxMutationRate2.TabIndex = 14;
            this.textBoxMutationRate2.Text = "0,1";
            // 
            // labelMutationRate2
            // 
            this.labelMutationRate2.AutoSize = true;
            this.labelMutationRate2.Location = new System.Drawing.Point(359, 232);
            this.labelMutationRate2.Name = "labelMutationRate2";
            this.labelMutationRate2.Size = new System.Drawing.Size(83, 13);
            this.labelMutationRate2.TabIndex = 13;
            this.labelMutationRate2.Text = "Mutation Rate 2";
            // 
            // textBoxCrossoverRate2
            // 
            this.textBoxCrossoverRate2.Location = new System.Drawing.Point(474, 203);
            this.textBoxCrossoverRate2.Name = "textBoxCrossoverRate2";
            this.textBoxCrossoverRate2.Size = new System.Drawing.Size(75, 20);
            this.textBoxCrossoverRate2.TabIndex = 12;
            this.textBoxCrossoverRate2.Text = "0,7";
            // 
            // labelCrossoverRate2
            // 
            this.labelCrossoverRate2.AutoSize = true;
            this.labelCrossoverRate2.Location = new System.Drawing.Point(359, 206);
            this.labelCrossoverRate2.Name = "labelCrossoverRate2";
            this.labelCrossoverRate2.Size = new System.Drawing.Size(89, 13);
            this.labelCrossoverRate2.TabIndex = 11;
            this.labelCrossoverRate2.Text = "Crossover Rate 2";
            // 
            // openFileDialogLoadData
            // 
            this.openFileDialogLoadData.FileName = "initialdata";
            this.openFileDialogLoadData.Filter = "\"Text files (*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // labelInitialParametersNumber
            // 
            this.labelInitialParametersNumber.AutoSize = true;
            this.labelInitialParametersNumber.Location = new System.Drawing.Point(359, 313);
            this.labelInitialParametersNumber.Name = "labelInitialParametersNumber";
            this.labelInitialParametersNumber.Size = new System.Drawing.Size(100, 13);
            this.labelInitialParametersNumber.TabIndex = 15;
            this.labelInitialParametersNumber.Text = "Parameters Number";
            // 
            // textBoxObservationsNumber
            // 
            this.textBoxObservationsNumber.Location = new System.Drawing.Point(474, 310);
            this.textBoxObservationsNumber.Name = "textBoxObservationsNumber";
            this.textBoxObservationsNumber.Size = new System.Drawing.Size(75, 20);
            this.textBoxObservationsNumber.TabIndex = 16;
            this.textBoxObservationsNumber.Text = "136";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 427);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(305, 23);
            this.progressBar.TabIndex = 17;
            // 
            // textBoxSeriesNumber
            // 
            this.textBoxSeriesNumber.Location = new System.Drawing.Point(474, 338);
            this.textBoxSeriesNumber.Name = "textBoxSeriesNumber";
            this.textBoxSeriesNumber.Size = new System.Drawing.Size(75, 20);
            this.textBoxSeriesNumber.TabIndex = 19;
            this.textBoxSeriesNumber.Text = "30";
            // 
            // labelSeriesNumber
            // 
            this.labelSeriesNumber.AutoSize = true;
            this.labelSeriesNumber.Location = new System.Drawing.Point(359, 341);
            this.labelSeriesNumber.Name = "labelSeriesNumber";
            this.labelSeriesNumber.Size = new System.Drawing.Size(76, 13);
            this.labelSeriesNumber.TabIndex = 18;
            this.labelSeriesNumber.Text = "Series Number";
            // 
            // groupBoxAlgorithmType
            // 
            this.groupBoxAlgorithmType.Controls.Add(this.radioButtonSerialGA);
            this.groupBoxAlgorithmType.Controls.Add(this.radioButtonParallelGA);
            this.groupBoxAlgorithmType.Location = new System.Drawing.Point(354, 90);
            this.groupBoxAlgorithmType.Name = "groupBoxAlgorithmType";
            this.groupBoxAlgorithmType.Size = new System.Drawing.Size(198, 51);
            this.groupBoxAlgorithmType.TabIndex = 2;
            this.groupBoxAlgorithmType.TabStop = false;
            this.groupBoxAlgorithmType.Text = "AlgorithmType";
            // 
            // radioButtonSerialGA
            // 
            this.radioButtonSerialGA.AutoSize = true;
            this.radioButtonSerialGA.Checked = true;
            this.radioButtonSerialGA.Location = new System.Drawing.Point(100, 19);
            this.radioButtonSerialGA.Name = "radioButtonSerialGA";
            this.radioButtonSerialGA.Size = new System.Drawing.Size(67, 17);
            this.radioButtonSerialGA.TabIndex = 21;
            this.radioButtonSerialGA.TabStop = true;
            this.radioButtonSerialGA.Text = "serial GA";
            this.radioButtonSerialGA.UseVisualStyleBackColor = true;
            // 
            // radioButtonParallelGA
            // 
            this.radioButtonParallelGA.AutoSize = true;
            this.radioButtonParallelGA.Location = new System.Drawing.Point(8, 19);
            this.radioButtonParallelGA.Name = "radioButtonParallelGA";
            this.radioButtonParallelGA.Size = new System.Drawing.Size(76, 17);
            this.radioButtonParallelGA.TabIndex = 20;
            this.radioButtonParallelGA.Text = "parallel GA";
            this.radioButtonParallelGA.UseVisualStyleBackColor = true;
            // 
            // saveResultsFileDialog
            // 
            this.saveResultsFileDialog.FileName = "res_initial.txt";
            this.saveResultsFileDialog.Filter = "\"Text files (*.txt)|*.txt\"";
            // 
            // openFileDialogTestData
            // 
            this.openFileDialogTestData.Filter = "\"Text files (*.txt)|*.txt|All files (*.*)|*.*\"";
            this.openFileDialogTestData.Title = "Open test data file";
            // 
            // saveFileDialogTestData
            // 
            this.saveFileDialogTestData.Filter = "\"Text files (*.txt)|*.txt\"";
            this.saveFileDialogTestData.Title = "Save test data file";
            // 
            // buttonTestGA
            // 
            this.buttonTestGA.Enabled = false;
            this.buttonTestGA.Location = new System.Drawing.Point(682, 427);
            this.buttonTestGA.Name = "buttonTestGA";
            this.buttonTestGA.Size = new System.Drawing.Size(75, 22);
            this.buttonTestGA.TabIndex = 20;
            this.buttonTestGA.Text = "TestGA";
            this.buttonTestGA.UseVisualStyleBackColor = true;
            this.buttonTestGA.Click += new System.EventHandler(this.buttonTestGA_Click);
            // 
            // textBoxTestingResultsSelectionThreshold
            // 
            this.textBoxTestingResultsSelectionThreshold.Location = new System.Drawing.Point(712, 151);
            this.textBoxTestingResultsSelectionThreshold.Name = "textBoxTestingResultsSelectionThreshold";
            this.textBoxTestingResultsSelectionThreshold.Size = new System.Drawing.Size(45, 20);
            this.textBoxTestingResultsSelectionThreshold.TabIndex = 21;
            this.textBoxTestingResultsSelectionThreshold.Text = "0,85";
            // 
            // labelTestingResultsSelectionThreshold
            // 
            this.labelTestingResultsSelectionThreshold.AutoSize = true;
            this.labelTestingResultsSelectionThreshold.Location = new System.Drawing.Point(567, 154);
            this.labelTestingResultsSelectionThreshold.Name = "labelTestingResultsSelectionThreshold";
            this.labelTestingResultsSelectionThreshold.Size = new System.Drawing.Size(101, 13);
            this.labelTestingResultsSelectionThreshold.TabIndex = 22;
            this.labelTestingResultsSelectionThreshold.Text = "Selection Threshold";
            // 
            // checkBoxTest
            // 
            this.checkBoxTest.AutoSize = true;
            this.checkBoxTest.Checked = true;
            this.checkBoxTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTest.Location = new System.Drawing.Point(585, 431);
            this.checkBoxTest.Name = "checkBoxTest";
            this.checkBoxTest.Size = new System.Drawing.Size(61, 17);
            this.checkBoxTest.TabIndex = 23;
            this.checkBoxTest.Text = "Testing";
            this.checkBoxTest.UseVisualStyleBackColor = true;
            // 
            // labelRunsNumber
            // 
            this.labelRunsNumber.AutoSize = true;
            this.labelRunsNumber.Location = new System.Drawing.Point(567, 180);
            this.labelRunsNumber.Name = "labelRunsNumber";
            this.labelRunsNumber.Size = new System.Drawing.Size(72, 13);
            this.labelRunsNumber.TabIndex = 25;
            this.labelRunsNumber.Text = "Runs Number";
            // 
            // textBoxRunsNumber
            // 
            this.textBoxRunsNumber.Location = new System.Drawing.Point(712, 177);
            this.textBoxRunsNumber.Name = "textBoxRunsNumber";
            this.textBoxRunsNumber.Size = new System.Drawing.Size(45, 20);
            this.textBoxRunsNumber.TabIndex = 24;
            this.textBoxRunsNumber.Text = "10";
            // 
            // labelPercentOfChangeGeneInInitializationStep
            // 
            this.labelPercentOfChangeGeneInInitializationStep.AutoSize = true;
            this.labelPercentOfChangeGeneInInitializationStep.Location = new System.Drawing.Point(567, 232);
            this.labelPercentOfChangeGeneInInitializationStep.Name = "labelPercentOfChangeGeneInInitializationStep";
            this.labelPercentOfChangeGeneInInitializationStep.Size = new System.Drawing.Size(130, 26);
            this.labelPercentOfChangeGeneInInitializationStep.TabIndex = 29;
            this.labelPercentOfChangeGeneInInitializationStep.Text = "Percent Of Change Gene \r\nIn Initialization Step";
            // 
            // textBoxPercentOfChangeGeneInInitializationStep
            // 
            this.textBoxPercentOfChangeGeneInInitializationStep.Location = new System.Drawing.Point(711, 238);
            this.textBoxPercentOfChangeGeneInInitializationStep.Name = "textBoxPercentOfChangeGeneInInitializationStep";
            this.textBoxPercentOfChangeGeneInInitializationStep.Size = new System.Drawing.Size(46, 20);
            this.textBoxPercentOfChangeGeneInInitializationStep.TabIndex = 28;
            this.textBoxPercentOfChangeGeneInInitializationStep.Text = "0,1";
            // 
            // labelTournamentGroupQuantity
            // 
            this.labelTournamentGroupQuantity.AutoSize = true;
            this.labelTournamentGroupQuantity.Location = new System.Drawing.Point(567, 206);
            this.labelTournamentGroupQuantity.Name = "labelTournamentGroupQuantity";
            this.labelTournamentGroupQuantity.Size = new System.Drawing.Size(138, 13);
            this.labelTournamentGroupQuantity.TabIndex = 27;
            this.labelTournamentGroupQuantity.Text = "Tournament Group Quantity";
            // 
            // textBoxTournamentGroupQuantity
            // 
            this.textBoxTournamentGroupQuantity.Location = new System.Drawing.Point(711, 203);
            this.textBoxTournamentGroupQuantity.Name = "textBoxTournamentGroupQuantity";
            this.textBoxTournamentGroupQuantity.Size = new System.Drawing.Size(46, 20);
            this.textBoxTournamentGroupQuantity.TabIndex = 26;
            this.textBoxTournamentGroupQuantity.Text = "4";
            // 
            // labelTransmissionRateBetweenParallelPopulations
            // 
            this.labelTransmissionRateBetweenParallelPopulations.AutoSize = true;
            this.labelTransmissionRateBetweenParallelPopulations.Location = new System.Drawing.Point(567, 284);
            this.labelTransmissionRateBetweenParallelPopulations.Name = "labelTransmissionRateBetweenParallelPopulations";
            this.labelTransmissionRateBetweenParallelPopulations.Size = new System.Drawing.Size(142, 26);
            this.labelTransmissionRateBetweenParallelPopulations.TabIndex = 31;
            this.labelTransmissionRateBetweenParallelPopulations.Text = "Transmission Rate Between \r\nParallel Populations";
            // 
            // textBoxTransmissionRateBetweenParallelPopulations
            // 
            this.textBoxTransmissionRateBetweenParallelPopulations.Location = new System.Drawing.Point(711, 290);
            this.textBoxTransmissionRateBetweenParallelPopulations.Name = "textBoxTransmissionRateBetweenParallelPopulations";
            this.textBoxTransmissionRateBetweenParallelPopulations.Size = new System.Drawing.Size(46, 20);
            this.textBoxTransmissionRateBetweenParallelPopulations.TabIndex = 30;
            this.textBoxTransmissionRateBetweenParallelPopulations.Text = "0,3";
            // 
            // GAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 463);
            this.Controls.Add(this.labelTransmissionRateBetweenParallelPopulations);
            this.Controls.Add(this.textBoxTransmissionRateBetweenParallelPopulations);
            this.Controls.Add(this.labelPercentOfChangeGeneInInitializationStep);
            this.Controls.Add(this.textBoxPercentOfChangeGeneInInitializationStep);
            this.Controls.Add(this.labelTournamentGroupQuantity);
            this.Controls.Add(this.textBoxTournamentGroupQuantity);
            this.Controls.Add(this.labelRunsNumber);
            this.Controls.Add(this.textBoxRunsNumber);
            this.Controls.Add(this.checkBoxTest);
            this.Controls.Add(this.labelTestingResultsSelectionThreshold);
            this.Controls.Add(this.textBoxTestingResultsSelectionThreshold);
            this.Controls.Add(this.buttonTestGA);
            this.Controls.Add(this.groupBoxAlgorithmType);
            this.Controls.Add(this.textBoxSeriesNumber);
            this.Controls.Add(this.labelSeriesNumber);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxObservationsNumber);
            this.Controls.Add(this.labelInitialParametersNumber);
            this.Controls.Add(this.textBoxMutationRate2);
            this.Controls.Add(this.labelMutationRate2);
            this.Controls.Add(this.textBoxCrossoverRate2);
            this.Controls.Add(this.labelCrossoverRate2);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonLoadData);
            this.Controls.Add(this.labelGenerationsNumber);
            this.Controls.Add(this.textBoxGenerationsNumber);
            this.Controls.Add(this.labelPopulationQuantity);
            this.Controls.Add(this.textBoxPopulationQuantity);
            this.Controls.Add(this.textBoxMutationRate);
            this.Controls.Add(this.labelMutationRate);
            this.Controls.Add(this.textBoxCrossoverRate);
            this.Controls.Add(this.crossoverRateLabel);
            this.Controls.Add(this.groupBoxChromosomeType);
            this.Name = "GAC";
            this.Text = "GAC";
            this.groupBoxChromosomeType.ResumeLayout(false);
            this.groupBoxChromosomeType.PerformLayout();
            this.groupBoxAlgorithmType.ResumeLayout(false);
            this.groupBoxAlgorithmType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxChromosomeType;
        private System.Windows.Forms.Label crossoverRateLabel;
        private System.Windows.Forms.TextBox textBoxCrossoverRate;
        private System.Windows.Forms.Label labelMutationRate;
        private System.Windows.Forms.TextBox textBoxMutationRate;
        private System.Windows.Forms.TextBox textBoxPopulationQuantity;
        private System.Windows.Forms.Label labelPopulationQuantity;
        private System.Windows.Forms.TextBox textBoxGenerationsNumber;
        private System.Windows.Forms.Label labelGenerationsNumber;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxMutationRate2;
        private System.Windows.Forms.Label labelMutationRate2;
        private System.Windows.Forms.TextBox textBoxCrossoverRate2;
        private System.Windows.Forms.Label labelCrossoverRate2;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadData;
        private System.Windows.Forms.Label labelInitialParametersNumber;
        private System.Windows.Forms.TextBox textBoxObservationsNumber;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox textBoxSeriesNumber;
        private System.Windows.Forms.Label labelSeriesNumber;
        private System.Windows.Forms.GroupBox groupBoxAlgorithmType;
        private System.Windows.Forms.RadioButton radioButtonSerialGA;
        private System.Windows.Forms.RadioButton radioButtonParallelGA;
        private System.Windows.Forms.RadioButton radioButtonOneChromosomeSpace;
        private System.Windows.Forms.RadioButton radioButtonTwoChromosomeSpace;
        private System.Windows.Forms.SaveFileDialog saveResultsFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogTestData;
        private System.Windows.Forms.SaveFileDialog saveFileDialogTestData;
        private System.Windows.Forms.Button buttonTestGA;
        private System.Windows.Forms.TextBox textBoxTestingResultsSelectionThreshold;
        private System.Windows.Forms.Label labelTestingResultsSelectionThreshold;
        private System.Windows.Forms.CheckBox checkBoxTest;
        private System.Windows.Forms.Label labelRunsNumber;
        private System.Windows.Forms.TextBox textBoxRunsNumber;
        private System.Windows.Forms.Label labelPercentOfChangeGeneInInitializationStep;
        private System.Windows.Forms.TextBox textBoxPercentOfChangeGeneInInitializationStep;
        private System.Windows.Forms.Label labelTournamentGroupQuantity;
        private System.Windows.Forms.TextBox textBoxTournamentGroupQuantity;
        private System.Windows.Forms.Label labelTransmissionRateBetweenParallelPopulations;
        private System.Windows.Forms.TextBox textBoxTransmissionRateBetweenParallelPopulations;
    }
}

