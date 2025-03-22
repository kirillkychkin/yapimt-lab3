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
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageAnalysis.SuspendLayout();
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
            tabControl.Location = new Point(12, 27);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1135, 523);
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
            tabPageAnalysis.Size = new Size(1127, 495);
            tabPageAnalysis.TabIndex = 0;
            tabPageAnalysis.Text = "Код на анализ";
            tabPageAnalysis.UseVisualStyleBackColor = true;
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Location = new Point(1034, 48);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(77, 44);
            buttonAnalyze.TabIndex = 2;
            buttonAnalyze.Text = "Анализировать";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // codeTextBox
            // 
            codeTextBox.Location = new Point(6, 33);
            codeTextBox.Name = "codeTextBox";
            codeTextBox.Size = new Size(1022, 459);
            codeTextBox.TabIndex = 1;
            codeTextBox.Text = "";
            // 
            // codeTextBoxLabel
            // 
            codeTextBoxLabel.AutoSize = true;
            codeTextBoxLabel.Location = new Point(6, 15);
            codeTextBoxLabel.Name = "codeTextBoxLabel";
            codeTextBoxLabel.Size = new Size(275, 15);
            codeTextBoxLabel.TabIndex = 0;
            codeTextBoxLabel.Text = "Вставьте код, который нужно проанализировать";
            // 
            // tabPageResult
            // 
            tabPageResult.Location = new Point(4, 24);
            tabPageResult.Name = "tabPageResult";
            tabPageResult.Padding = new Padding(3);
            tabPageResult.Size = new Size(1127, 495);
            tabPageResult.TabIndex = 1;
            tabPageResult.Text = "Результат анализа";
            tabPageResult.UseVisualStyleBackColor = true;
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
    }
}
