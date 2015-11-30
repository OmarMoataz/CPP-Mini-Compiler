namespace DummyCppCompiler
{
    partial class Form1
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
            this.InputScreen = new System.Windows.Forms.TextBox();
            this.LexerOutput = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ParserOutput = new System.Windows.Forms.ListBox();
            this.ParseButton = new System.Windows.Forms.Button();
            this.LexerButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputScreen
            // 
            this.InputScreen.Location = new System.Drawing.Point(31, 31);
            this.InputScreen.Multiline = true;
            this.InputScreen.Name = "InputScreen";
            this.InputScreen.Size = new System.Drawing.Size(780, 190);
            this.InputScreen.TabIndex = 0;
            // 
            // LexerOutput
            // 
            this.LexerOutput.FormattingEnabled = true;
            this.LexerOutput.Location = new System.Drawing.Point(30, 29);
            this.LexerOutput.Name = "LexerOutput";
            this.LexerOutput.Size = new System.Drawing.Size(220, 186);
            this.LexerOutput.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClearButton);
            this.groupBox1.Controls.Add(this.InputScreen);
            this.groupBox1.Location = new System.Drawing.Point(82, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 269);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Screen";
            // 
            // ParserOutput
            // 
            this.ParserOutput.FormattingEnabled = true;
            this.ParserOutput.Location = new System.Drawing.Point(35, 31);
            this.ParserOutput.Name = "ParserOutput";
            this.ParserOutput.Size = new System.Drawing.Size(217, 173);
            this.ParserOutput.TabIndex = 5;
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(108, 226);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(75, 23);
            this.ParseButton.TabIndex = 6;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // LexerButton
            // 
            this.LexerButton.Location = new System.Drawing.Point(90, 226);
            this.LexerButton.Name = "LexerButton";
            this.LexerButton.Size = new System.Drawing.Size(75, 23);
            this.LexerButton.TabIndex = 7;
            this.LexerButton.Text = "Lexify";
            this.LexerButton.UseVisualStyleBackColor = true;
            this.LexerButton.Click += new System.EventHandler(this.LexerButton_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LexerOutput);
            this.groupBox2.Controls.Add(this.LexerButton);
            this.groupBox2.Location = new System.Drawing.Point(126, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 269);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lexer Output";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ParserOutput);
            this.groupBox3.Controls.Add(this.ParseButton);
            this.groupBox3.Location = new System.Drawing.Point(641, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 269);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parser Output";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(385, 227);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 579);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Mini Compiler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox InputScreen;
        private System.Windows.Forms.ListBox LexerOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ParserOutput;
        private System.Windows.Forms.Button ParseButton;
        private System.Windows.Forms.Button LexerButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

