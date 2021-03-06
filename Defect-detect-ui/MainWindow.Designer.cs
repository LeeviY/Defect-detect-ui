using System.Windows.Forms;

namespace Defect_detect_ui
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelStained = new System.Windows.Forms.Label();
            this.labelCracked = new System.Windows.Forms.Label();
            this.labelStainValue = new System.Windows.Forms.Label();
            this.labelCrackValue = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.trackBarDilate = new System.Windows.Forms.TrackBar();
            this.trackBarErode = new System.Windows.Forms.TrackBar();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.labelDilateValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelErodeValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelThresholdValue = new System.Windows.Forms.Label();
            this.trackBarArea = new System.Windows.Forms.TrackBar();
            this.trackBarCircularity = new System.Windows.Forms.TrackBar();
            this.trackBarConvexity = new System.Windows.Forms.TrackBar();
            this.trackBarInertia = new System.Windows.Forms.TrackBar();
            this.labelCircularityValue = new System.Windows.Forms.Label();
            this.labelConvexityValue = new System.Windows.Forms.Label();
            this.labelInertiaValue = new System.Windows.Forms.Label();
            this.labelAreaValue = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.labelCircularity = new System.Windows.Forms.Label();
            this.labelConvexity = new System.Windows.Forms.Label();
            this.labelInertia = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarErode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCircularity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarConvexity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInertia)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.imageBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.imageBox5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.imageBox6, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 584);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox1.Location = new System.Drawing.Point(0, 3);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(474, 286);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox2.Location = new System.Drawing.Point(474, 0);
            this.imageBox2.Margin = new System.Windows.Forms.Padding(0);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(474, 292);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox3.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox3.Location = new System.Drawing.Point(948, 0);
            this.imageBox3.Margin = new System.Windows.Forms.Padding(0);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(476, 292);
            this.imageBox3.TabIndex = 2;
            this.imageBox3.TabStop = false;
            // 
            // imageBox4
            // 
            this.imageBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox4.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox4.Location = new System.Drawing.Point(0, 295);
            this.imageBox4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(474, 286);
            this.imageBox4.TabIndex = 2;
            this.imageBox4.TabStop = false;
            // 
            // imageBox5
            // 
            this.imageBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox5.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox5.Location = new System.Drawing.Point(474, 292);
            this.imageBox5.Margin = new System.Windows.Forms.Padding(0);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(474, 292);
            this.imageBox5.TabIndex = 2;
            this.imageBox5.TabStop = false;
            // 
            // imageBox6
            // 
            this.imageBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox6.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBox6.Location = new System.Drawing.Point(948, 292);
            this.imageBox6.Margin = new System.Windows.Forms.Padding(0);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(476, 292);
            this.imageBox6.TabIndex = 2;
            this.imageBox6.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1424, 771);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.8702F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0525F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.0773F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.labelStained, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelCracked, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelStainValue, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelCrackValue, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonPrevious, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonNext, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonCapture, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonDefault, 4, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(361, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1063, 183);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // labelStained
            // 
            this.labelStained.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelStained.AutoSize = true;
            this.labelStained.Location = new System.Drawing.Point(19, 38);
            this.labelStained.Name = "labelStained";
            this.labelStained.Size = new System.Drawing.Size(49, 15);
            this.labelStained.TabIndex = 17;
            this.labelStained.Text = "Stained:";
            // 
            // labelCracked
            // 
            this.labelCracked.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCracked.AutoSize = true;
            this.labelCracked.Location = new System.Drawing.Point(15, 129);
            this.labelCracked.Name = "labelCracked";
            this.labelCracked.Size = new System.Drawing.Size(53, 15);
            this.labelCracked.TabIndex = 18;
            this.labelCracked.Text = "Cracked:";
            // 
            // labelStainValue
            // 
            this.labelStainValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStainValue.AutoSize = true;
            this.labelStainValue.Location = new System.Drawing.Point(74, 38);
            this.labelStainValue.Name = "labelStainValue";
            this.labelStainValue.Size = new System.Drawing.Size(38, 15);
            this.labelStainValue.TabIndex = 19;
            this.labelStainValue.Text = "label6";
            // 
            // labelCrackValue
            // 
            this.labelCrackValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCrackValue.AutoSize = true;
            this.labelCrackValue.Location = new System.Drawing.Point(74, 129);
            this.labelCrackValue.Name = "labelCrackValue";
            this.labelCrackValue.Size = new System.Drawing.Size(38, 15);
            this.labelCrackValue.TabIndex = 20;
            this.labelCrackValue.Text = "label7";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPrevious.Location = new System.Drawing.Point(905, 34);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(74, 23);
            this.buttonPrevious.TabIndex = 10;
            this.buttonPrevious.Text = "Prev";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonNext.Location = new System.Drawing.Point(985, 34);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCapture.Location = new System.Drawing.Point(905, 125);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(74, 23);
            this.buttonCapture.TabIndex = 16;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDefault.Location = new System.Drawing.Point(985, 125);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 4;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.trackBarDilate, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.trackBarErode, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.trackBarThreshold, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelDilateValue, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.labelErodeValue, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.labelThresholdValue, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.trackBarArea, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBarCircularity, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.trackBarConvexity, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.trackBarInertia, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelCircularityValue, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelConvexityValue, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelInertiaValue, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelAreaValue, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelArea, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCircularity, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelConvexity, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelInertia, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(361, 183);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // trackBarDilate
            // 
            this.trackBarDilate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarDilate.LargeChange = 1;
            this.trackBarDilate.Location = new System.Drawing.Point(3, 159);
            this.trackBarDilate.Name = "trackBarDilate";
            this.trackBarDilate.Size = new System.Drawing.Size(210, 21);
            this.trackBarDilate.TabIndex = 6;
            this.trackBarDilate.Scroll += new System.EventHandler(this.trackBarDilate_Scroll);
            // 
            // trackBarErode
            // 
            this.trackBarErode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarErode.LargeChange = 1;
            this.trackBarErode.Location = new System.Drawing.Point(3, 133);
            this.trackBarErode.Name = "trackBarErode";
            this.trackBarErode.Size = new System.Drawing.Size(210, 20);
            this.trackBarErode.TabIndex = 5;
            this.trackBarErode.Scroll += new System.EventHandler(this.trackBarErode_Scroll);
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarThreshold.LargeChange = 1;
            this.trackBarThreshold.Location = new System.Drawing.Point(3, 107);
            this.trackBarThreshold.Maximum = 30;
            this.trackBarThreshold.Minimum = -30;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(210, 20);
            this.trackBarThreshold.TabIndex = 2;
            this.trackBarThreshold.TickFrequency = 3;
            this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // labelDilateValue
            // 
            this.labelDilateValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDilateValue.AutoSize = true;
            this.labelDilateValue.Location = new System.Drawing.Point(291, 162);
            this.labelDilateValue.Name = "labelDilateValue";
            this.labelDilateValue.Size = new System.Drawing.Size(38, 15);
            this.labelDilateValue.TabIndex = 8;
            this.labelDilateValue.Text = "label1";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Erode:";
            // 
            // labelErodeValue
            // 
            this.labelErodeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelErodeValue.AutoSize = true;
            this.labelErodeValue.Location = new System.Drawing.Point(291, 135);
            this.labelErodeValue.Name = "labelErodeValue";
            this.labelErodeValue.Size = new System.Drawing.Size(38, 15);
            this.labelErodeValue.TabIndex = 7;
            this.labelErodeValue.Text = "label1";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dilate:";
            // 
            // labelThresholdValue
            // 
            this.labelThresholdValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelThresholdValue.AutoSize = true;
            this.labelThresholdValue.Location = new System.Drawing.Point(291, 109);
            this.labelThresholdValue.Name = "labelThresholdValue";
            this.labelThresholdValue.Size = new System.Drawing.Size(38, 15);
            this.labelThresholdValue.TabIndex = 3;
            this.labelThresholdValue.Text = "label1";
            // 
            // trackBarArea
            // 
            this.trackBarArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarArea.LargeChange = 1;
            this.trackBarArea.Location = new System.Drawing.Point(3, 3);
            this.trackBarArea.Maximum = 1000;
            this.trackBarArea.Name = "trackBarArea";
            this.trackBarArea.Size = new System.Drawing.Size(210, 20);
            this.trackBarArea.TabIndex = 0;
            this.trackBarArea.TickFrequency = 100;
            this.trackBarArea.Scroll += new System.EventHandler(this.trackBarArea_Scroll);
            // 
            // trackBarCircularity
            // 
            this.trackBarCircularity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarCircularity.LargeChange = 1;
            this.trackBarCircularity.Location = new System.Drawing.Point(3, 29);
            this.trackBarCircularity.Maximum = 100;
            this.trackBarCircularity.Name = "trackBarCircularity";
            this.trackBarCircularity.Size = new System.Drawing.Size(210, 20);
            this.trackBarCircularity.TabIndex = 1;
            this.trackBarCircularity.TickFrequency = 10;
            this.trackBarCircularity.Scroll += new System.EventHandler(this.trackBarCircularity_Scroll);
            // 
            // trackBarConvexity
            // 
            this.trackBarConvexity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarConvexity.LargeChange = 1;
            this.trackBarConvexity.Location = new System.Drawing.Point(3, 55);
            this.trackBarConvexity.Maximum = 100;
            this.trackBarConvexity.Name = "trackBarConvexity";
            this.trackBarConvexity.Size = new System.Drawing.Size(210, 20);
            this.trackBarConvexity.TabIndex = 2;
            this.trackBarConvexity.TickFrequency = 10;
            this.trackBarConvexity.Scroll += new System.EventHandler(this.trackBarConvexity_Scroll);
            // 
            // trackBarInertia
            // 
            this.trackBarInertia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarInertia.LargeChange = 1;
            this.trackBarInertia.Location = new System.Drawing.Point(3, 81);
            this.trackBarInertia.Maximum = 100;
            this.trackBarInertia.Name = "trackBarInertia";
            this.trackBarInertia.Size = new System.Drawing.Size(210, 20);
            this.trackBarInertia.TabIndex = 3;
            this.trackBarInertia.TickFrequency = 10;
            this.trackBarInertia.Scroll += new System.EventHandler(this.trackBarInertia_Scroll);
            // 
            // labelCircularityValue
            // 
            this.labelCircularityValue.AutoSize = true;
            this.labelCircularityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCircularityValue.Location = new System.Drawing.Point(291, 26);
            this.labelCircularityValue.Name = "labelCircularityValue";
            this.labelCircularityValue.Size = new System.Drawing.Size(67, 26);
            this.labelCircularityValue.TabIndex = 4;
            this.labelCircularityValue.Text = "label2";
            this.labelCircularityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelConvexityValue
            // 
            this.labelConvexityValue.AutoSize = true;
            this.labelConvexityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConvexityValue.Location = new System.Drawing.Point(291, 52);
            this.labelConvexityValue.Name = "labelConvexityValue";
            this.labelConvexityValue.Size = new System.Drawing.Size(67, 26);
            this.labelConvexityValue.TabIndex = 5;
            this.labelConvexityValue.Text = "label3";
            this.labelConvexityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInertiaValue
            // 
            this.labelInertiaValue.AutoSize = true;
            this.labelInertiaValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInertiaValue.Location = new System.Drawing.Point(291, 78);
            this.labelInertiaValue.Name = "labelInertiaValue";
            this.labelInertiaValue.Size = new System.Drawing.Size(67, 26);
            this.labelInertiaValue.TabIndex = 6;
            this.labelInertiaValue.Text = "label4";
            this.labelInertiaValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAreaValue
            // 
            this.labelAreaValue.AutoSize = true;
            this.labelAreaValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAreaValue.Location = new System.Drawing.Point(291, 0);
            this.labelAreaValue.Name = "labelAreaValue";
            this.labelAreaValue.Size = new System.Drawing.Size(67, 26);
            this.labelAreaValue.TabIndex = 2;
            this.labelAreaValue.Text = "label1";
            this.labelAreaValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelArea.Location = new System.Drawing.Point(219, 0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(66, 26);
            this.labelArea.TabIndex = 7;
            this.labelArea.Text = "Area:";
            this.labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCircularity
            // 
            this.labelCircularity.AutoSize = true;
            this.labelCircularity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCircularity.Location = new System.Drawing.Point(219, 26);
            this.labelCircularity.Name = "labelCircularity";
            this.labelCircularity.Size = new System.Drawing.Size(66, 26);
            this.labelCircularity.TabIndex = 8;
            this.labelCircularity.Text = "Circularity:";
            this.labelCircularity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelConvexity
            // 
            this.labelConvexity.AutoSize = true;
            this.labelConvexity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConvexity.Location = new System.Drawing.Point(219, 52);
            this.labelConvexity.Name = "labelConvexity";
            this.labelConvexity.Size = new System.Drawing.Size(66, 26);
            this.labelConvexity.TabIndex = 9;
            this.labelConvexity.Text = "Convexity:";
            this.labelConvexity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelInertia
            // 
            this.labelInertia.AutoSize = true;
            this.labelInertia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInertia.Location = new System.Drawing.Point(219, 78);
            this.labelInertia.Name = "labelInertia";
            this.labelInertia.Size = new System.Drawing.Size(66, 26);
            this.labelInertia.TabIndex = 10;
            this.labelInertia.Text = "Inertia:";
            this.labelInertia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Threshold offset:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 771);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarErode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCircularity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarConvexity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInertia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private Emgu.CV.UI.ImageBox imageBox4;
        private Emgu.CV.UI.ImageBox imageBox5;
        private Emgu.CV.UI.ImageBox imageBox6;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel2;
        private TrackBar trackBarArea;
        private TrackBar trackBarCircularity;
        private TrackBar trackBarConvexity;
        private TrackBar trackBarInertia;
        private Label labelCircularityValue;
        private Label labelConvexityValue;
        private Label labelInertiaValue;
        private Label labelAreaValue;
        private Label labelThresholdValue;
        private TrackBar trackBarThreshold;
        private Label labelArea;
        private Label labelCircularity;
        private Label labelConvexity;
        private Label labelInertia;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button buttonDefault;
        private TableLayoutPanel tableLayoutPanel3;
        private TrackBar trackBarErode;
        private TrackBar trackBarDilate;
        private Label labelErodeValue;
        private Label labelDilateValue;
        private Button buttonPrevious;
        private Button buttonNext;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonCapture;
        private Label labelStained;
        private Label labelCracked;
        private Label labelStainValue;
        private Label labelCrackValue;
    }
}