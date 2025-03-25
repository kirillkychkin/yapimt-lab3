namespace yapimt_lab3
{
    partial class lexer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            выходToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
            tabPageAnalysis = new TabPage();
            buttonAnalyze = new Button();
            codeTextBox = new RichTextBox();
            codeTextBoxLabel = new Label();
            tabPageResult = new TabPage();
            panelSymbols = new Panel();
            textSymbols = new Label();
            labelSymbols = new Label();
            panelOperators = new Panel();
            textOperators = new Label();
            labelOperators = new Label();
            panelNumeric = new Panel();
            textNumeric = new Label();
            labelNumeric = new Label();
            panelStrings = new Panel();
            textStrings = new Label();
            labelStrings = new Label();
            panelIndentifiers = new Panel();
            textIdentifiers = new Label();
            labelIdentifiers = new Label();
            panelKeywords = new Panel();
            textKeywords = new Label();
            labelKeywords = new Label();
            panelSequence = new Panel();
            labelSequence = new Label();
            textSequence = new Label();
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageAnalysis.SuspendLayout();
            tabPageResult.SuspendLayout();
            panelSymbols.SuspendLayout();
            panelOperators.SuspendLayout();
            panelNumeric.SuspendLayout();
            panelStrings.SuspendLayout();
            panelIndentifiers.SuspendLayout();
            panelKeywords.SuspendLayout();
            panelSequence.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem, справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1159, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(53, 20);
            выходToolStripMenuItem.Text = "Выход";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(192, 22);
            exitToolStripMenuItem.Text = "Выход из программы";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(149, 22);
            aboutToolStripMenuItem.Text = "О программе";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageAnalysis);
            tabControl.Controls.Add(tabPageResult);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 24);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1159, 526);
            tabControl.TabIndex = 3;
            // 
            // tabPageAnalysis
            // 
            tabPageAnalysis.Controls.Add(buttonAnalyze);
            tabPageAnalysis.Controls.Add(codeTextBox);
            tabPageAnalysis.Controls.Add(codeTextBoxLabel);
            tabPageAnalysis.Location = new Point(4, 24);
            tabPageAnalysis.Name = "tabPageAnalysis";
            tabPageAnalysis.Padding = new Padding(3);
            tabPageAnalysis.Size = new Size(1151, 498);
            tabPageAnalysis.TabIndex = 0;
            tabPageAnalysis.Text = "Код на анализ";
            tabPageAnalysis.UseVisualStyleBackColor = true;
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Dock = DockStyle.Right;
            buttonAnalyze.Location = new Point(1071, 18);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(77, 477);
            buttonAnalyze.TabIndex = 2;
            buttonAnalyze.Text = "Анализировать";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // codeTextBox
            // 
            codeTextBox.Dock = DockStyle.Fill;
            codeTextBox.Location = new Point(3, 18);
            codeTextBox.Name = "codeTextBox";
            codeTextBox.Size = new Size(1145, 477);
            codeTextBox.TabIndex = 1;
            codeTextBox.Text = "";
            // 
            // codeTextBoxLabel
            // 
            codeTextBoxLabel.AutoSize = true;
            codeTextBoxLabel.Dock = DockStyle.Top;
            codeTextBoxLabel.Location = new Point(3, 3);
            codeTextBoxLabel.Name = "codeTextBoxLabel";
            codeTextBoxLabel.Size = new Size(275, 15);
            codeTextBoxLabel.TabIndex = 0;
            codeTextBoxLabel.Text = "Вставьте код, который нужно проанализировать";
            // 
            // tabPageResult
            // 
            tabPageResult.Controls.Add(panelSymbols);
            tabPageResult.Controls.Add(panelOperators);
            tabPageResult.Controls.Add(panelNumeric);
            tabPageResult.Controls.Add(panelStrings);
            tabPageResult.Controls.Add(panelIndentifiers);
            tabPageResult.Controls.Add(panelKeywords);
            tabPageResult.Controls.Add(panelSequence);
            tabPageResult.Location = new Point(4, 24);
            tabPageResult.Name = "tabPageResult";
            tabPageResult.Padding = new Padding(3);
            tabPageResult.Size = new Size(1151, 498);
            tabPageResult.TabIndex = 1;
            tabPageResult.Text = "Результат анализа";
            tabPageResult.UseVisualStyleBackColor = true;
            // 
            // panelSymbols
            // 
            panelSymbols.AutoScroll = true;
            panelSymbols.Controls.Add(textSymbols);
            panelSymbols.Controls.Add(labelSymbols);
            panelSymbols.Dock = DockStyle.Left;
            panelSymbols.Location = new Point(953, 137);
            panelSymbols.Name = "panelSymbols";
            panelSymbols.Size = new Size(190, 358);
            panelSymbols.TabIndex = 6;
            // 
            // textSymbols
            // 
            textSymbols.AutoSize = true;
            textSymbols.Location = new Point(6, 33);
            textSymbols.Name = "textSymbols";
            textSymbols.Size = new Size(38, 15);
            textSymbols.TabIndex = 1;
            textSymbols.Text = "label6";
            // 
            // labelSymbols
            // 
            labelSymbols.AutoSize = true;
            labelSymbols.Location = new Point(6, 3);
            labelSymbols.Name = "labelSymbols";
            labelSymbols.Size = new Size(92, 15);
            labelSymbols.TabIndex = 0;
            labelSymbols.Text = "Спец. символы";
            // 
            // panelOperators
            // 
            panelOperators.AutoScroll = true;
            panelOperators.Controls.Add(textOperators);
            panelOperators.Controls.Add(labelOperators);
            panelOperators.Dock = DockStyle.Left;
            panelOperators.Location = new Point(763, 137);
            panelOperators.Name = "panelOperators";
            panelOperators.Size = new Size(190, 358);
            panelOperators.TabIndex = 5;
            // 
            // textOperators
            // 
            textOperators.AutoSize = true;
            textOperators.Location = new Point(6, 33);
            textOperators.Name = "textOperators";
            textOperators.Size = new Size(38, 15);
            textOperators.TabIndex = 1;
            textOperators.Text = "label5";
            // 
            // labelOperators
            // 
            labelOperators.AutoSize = true;
            labelOperators.Location = new Point(6, 3);
            labelOperators.Name = "labelOperators";
            labelOperators.Size = new Size(70, 15);
            labelOperators.TabIndex = 0;
            labelOperators.Text = "Операторы";
            // 
            // panelNumeric
            // 
            panelNumeric.AutoScroll = true;
            panelNumeric.Controls.Add(textNumeric);
            panelNumeric.Controls.Add(labelNumeric);
            panelNumeric.Dock = DockStyle.Left;
            panelNumeric.Location = new Point(573, 137);
            panelNumeric.Name = "panelNumeric";
            panelNumeric.Size = new Size(190, 358);
            panelNumeric.TabIndex = 4;
            // 
            // textNumeric
            // 
            textNumeric.AutoSize = true;
            textNumeric.Location = new Point(6, 33);
            textNumeric.Name = "textNumeric";
            textNumeric.Size = new Size(38, 15);
            textNumeric.TabIndex = 1;
            textNumeric.Text = "label4";
            // 
            // labelNumeric
            // 
            labelNumeric.AutoSize = true;
            labelNumeric.Location = new Point(6, 3);
            labelNumeric.Name = "labelNumeric";
            labelNumeric.Size = new Size(124, 15);
            labelNumeric.TabIndex = 0;
            labelNumeric.Text = "Числовые константы";
            // 
            // panelStrings
            // 
            panelStrings.AutoScroll = true;
            panelStrings.Controls.Add(textStrings);
            panelStrings.Controls.Add(labelStrings);
            panelStrings.Dock = DockStyle.Left;
            panelStrings.Location = new Point(383, 137);
            panelStrings.Name = "panelStrings";
            panelStrings.Size = new Size(190, 358);
            panelStrings.TabIndex = 3;
            // 
            // textStrings
            // 
            textStrings.AutoSize = true;
            textStrings.Location = new Point(3, 33);
            textStrings.Name = "textStrings";
            textStrings.Size = new Size(38, 15);
            textStrings.TabIndex = 1;
            textStrings.Text = "label3";
            // 
            // labelStrings
            // 
            labelStrings.AutoSize = true;
            labelStrings.Location = new Point(6, 3);
            labelStrings.Name = "labelStrings";
            labelStrings.Size = new Size(129, 15);
            labelStrings.TabIndex = 0;
            labelStrings.Text = "Строковые константы";
            // 
            // panelIndentifiers
            // 
            panelIndentifiers.AutoScroll = true;
            panelIndentifiers.Controls.Add(textIdentifiers);
            panelIndentifiers.Controls.Add(labelIdentifiers);
            panelIndentifiers.Dock = DockStyle.Left;
            panelIndentifiers.Location = new Point(193, 137);
            panelIndentifiers.Name = "panelIndentifiers";
            panelIndentifiers.Size = new Size(190, 358);
            panelIndentifiers.TabIndex = 2;
            // 
            // textIdentifiers
            // 
            textIdentifiers.AutoSize = true;
            textIdentifiers.Location = new Point(6, 33);
            textIdentifiers.Name = "textIdentifiers";
            textIdentifiers.Size = new Size(38, 15);
            textIdentifiers.TabIndex = 1;
            textIdentifiers.Text = "label2";
            // 
            // labelIdentifiers
            // 
            labelIdentifiers.AutoSize = true;
            labelIdentifiers.Location = new Point(6, 3);
            labelIdentifiers.Name = "labelIdentifiers";
            labelIdentifiers.Size = new Size(103, 15);
            labelIdentifiers.TabIndex = 0;
            labelIdentifiers.Text = "Идентификаторы";
            // 
            // panelKeywords
            // 
            panelKeywords.AutoScroll = true;
            panelKeywords.Controls.Add(textKeywords);
            panelKeywords.Controls.Add(labelKeywords);
            panelKeywords.Dock = DockStyle.Left;
            panelKeywords.Location = new Point(3, 137);
            panelKeywords.Name = "panelKeywords";
            panelKeywords.Size = new Size(190, 358);
            panelKeywords.TabIndex = 1;
            // 
            // textKeywords
            // 
            textKeywords.AutoSize = true;
            textKeywords.Location = new Point(3, 33);
            textKeywords.Name = "textKeywords";
            textKeywords.Size = new Size(38, 15);
            textKeywords.TabIndex = 1;
            textKeywords.Text = "label1";
            // 
            // labelKeywords
            // 
            labelKeywords.AutoSize = true;
            labelKeywords.Location = new Point(3, 3);
            labelKeywords.Name = "labelKeywords";
            labelKeywords.Size = new Size(100, 15);
            labelKeywords.TabIndex = 0;
            labelKeywords.Text = "Ключевые слова";
            // 
            // panelSequence
            // 
            panelSequence.AutoScroll = true;
            panelSequence.Controls.Add(labelSequence);
            panelSequence.Controls.Add(textSequence);
            panelSequence.Dock = DockStyle.Top;
            panelSequence.Location = new Point(3, 3);
            panelSequence.Name = "panelSequence";
            panelSequence.Size = new Size(1145, 134);
            panelSequence.TabIndex = 0;
            // 
            // labelSequence
            // 
            labelSequence.AutoSize = true;
            labelSequence.Location = new Point(3, 0);
            labelSequence.Name = "labelSequence";
            labelSequence.Size = new Size(57, 15);
            labelSequence.TabIndex = 1;
            labelSequence.Text = "Лексемы";
            // 
            // textSequence
            // 
            textSequence.AutoSize = true;
            textSequence.Location = new Point(3, 28);
            textSequence.Name = "textSequence";
            textSequence.Size = new Size(38, 15);
            textSequence.TabIndex = 0;
            textSequence.Text = "label1";
            // 
            // lexer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 550);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "lexer";
            Text = "lexer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageAnalysis.ResumeLayout(false);
            tabPageAnalysis.PerformLayout();
            tabPageResult.ResumeLayout(false);
            panelSymbols.ResumeLayout(false);
            panelSymbols.PerformLayout();
            panelOperators.ResumeLayout(false);
            panelOperators.PerformLayout();
            panelNumeric.ResumeLayout(false);
            panelNumeric.PerformLayout();
            panelStrings.ResumeLayout(false);
            panelStrings.PerformLayout();
            panelIndentifiers.ResumeLayout(false);
            panelIndentifiers.PerformLayout();
            panelKeywords.ResumeLayout(false);
            panelKeywords.PerformLayout();
            panelSequence.ResumeLayout(false);
            panelSequence.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TabControl tabControl;
        private TabPage tabPageAnalysis;
        private TabPage tabPageResult;
        private Label codeTextBoxLabel;
        private RichTextBox codeTextBox;
        private Button buttonAnalyze;
        private Panel panelSequence;
        private Label textSequence;
        private Label labelSequence;
        private Panel panelIndentifiers;
        private Panel panelKeywords;
        private Label labelKeywords;
        private Label labelIdentifiers;
        private Panel panelStrings;
        private Label labelStrings;
        private Panel panelNumeric;
        private Label labelNumeric;
        private Panel panelOperators;
        private Label labelOperators;
        private Panel panelSymbols;
        private Label labelSymbols;
        private Label textSymbols;
        private Label textOperators;
        private Label textNumeric;
        private Label textStrings;
        private Label textIdentifiers;
        private Label textKeywords;
    }
}
