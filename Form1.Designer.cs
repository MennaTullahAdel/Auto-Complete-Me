namespace algo_prog
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Bubble_rb = new System.Windows.Forms.RadioButton();
            this.Merge_rb = new System.Windows.Forms.RadioButton();
            this.sort_gb = new System.Windows.Forms.GroupBox();
            this.unSorted_rb = new System.Windows.Forms.RadioButton();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.HELLO = new System.Windows.Forms.Label();
            this.Correct_listBox = new System.Windows.Forms.ListBox();
            this.Correct_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sort_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bubble_rb
            // 
            this.Bubble_rb.AutoSize = true;
            this.Bubble_rb.Location = new System.Drawing.Point(5, 38);
            this.Bubble_rb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bubble_rb.Name = "Bubble_rb";
            this.Bubble_rb.Size = new System.Drawing.Size(73, 21);
            this.Bubble_rb.TabIndex = 3;
            this.Bubble_rb.TabStop = true;
            this.Bubble_rb.Text = "Bubble";
            this.Bubble_rb.UseVisualStyleBackColor = true;
            // 
            // Merge_rb
            // 
            this.Merge_rb.AutoSize = true;
            this.Merge_rb.Location = new System.Drawing.Point(5, 63);
            this.Merge_rb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Merge_rb.Name = "Merge_rb";
            this.Merge_rb.Size = new System.Drawing.Size(69, 21);
            this.Merge_rb.TabIndex = 4;
            this.Merge_rb.TabStop = true;
            this.Merge_rb.Text = "Merge";
            this.Merge_rb.UseVisualStyleBackColor = true;
            // 
            // sort_gb
            // 
            this.sort_gb.BackColor = System.Drawing.Color.Linen;
            this.sort_gb.Controls.Add(this.unSorted_rb);
            this.sort_gb.Controls.Add(this.Merge_rb);
            this.sort_gb.Controls.Add(this.Bubble_rb);
            this.sort_gb.Location = new System.Drawing.Point(682, 369);
            this.sort_gb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sort_gb.Name = "sort_gb";
            this.sort_gb.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sort_gb.Size = new System.Drawing.Size(176, 139);
            this.sort_gb.TabIndex = 5;
            this.sort_gb.TabStop = false;
            this.sort_gb.Text = "Sort using";
            // 
            // unSorted_rb
            // 
            this.unSorted_rb.AutoSize = true;
            this.unSorted_rb.Location = new System.Drawing.Point(5, 89);
            this.unSorted_rb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.unSorted_rb.Name = "unSorted_rb";
            this.unSorted_rb.Size = new System.Drawing.Size(89, 21);
            this.unSorted_rb.TabIndex = 5;
            this.unSorted_rb.TabStop = true;
            this.unSorted_rb.Text = "un sorted";
            this.unSorted_rb.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(75, 207);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(575, 20);
            this.listBox2.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox1.Location = new System.Drawing.Point(75, 169);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(575, 36);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // HELLO
            // 
            this.HELLO.AutoSize = true;
            this.HELLO.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HELLO.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HELLO.Location = new System.Drawing.Point(215, 53);
            this.HELLO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HELLO.Name = "HELLO";
            this.HELLO.Size = new System.Drawing.Size(278, 91);
            this.HELLO.TabIndex = 8;
            this.HELLO.Text = "MOSS";
            // 
            // Correct_listBox
            // 
            this.Correct_listBox.FormattingEnabled = true;
            this.Correct_listBox.ItemHeight = 16;
            this.Correct_listBox.Location = new System.Drawing.Point(682, 169);
            this.Correct_listBox.Name = "Correct_listBox";
            this.Correct_listBox.Size = new System.Drawing.Size(176, 180);
            this.Correct_listBox.TabIndex = 9;
            this.Correct_listBox.DoubleClick += new System.EventHandler(this.Correct_listBox_DoubleClick);
            // 
            // Correct_label
            // 
            this.Correct_label.AutoSize = true;
            this.Correct_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Correct_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Correct_label.Location = new System.Drawing.Point(684, 135);
            this.Correct_label.Name = "Correct_label";
            this.Correct_label.Size = new System.Drawing.Size(174, 31);
            this.Correct_label.TabIndex = 10;
            this.Correct_label.Text = "Do you mean";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Timer";
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(891, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Correct_label);
            this.Controls.Add(this.Correct_listBox);
            this.Controls.Add(this.HELLO);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.sort_gb);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "MOSS SE";
            this.sort_gb.ResumeLayout(false);
            this.sort_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton Bubble_rb;
        private System.Windows.Forms.RadioButton Merge_rb;
        private System.Windows.Forms.GroupBox sort_gb;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton unSorted_rb;
        private System.Windows.Forms.Label HELLO;
        private System.Windows.Forms.ListBox Correct_listBox;
        private System.Windows.Forms.Label Correct_label;
        private System.Windows.Forms.Label label1;
    }
}

