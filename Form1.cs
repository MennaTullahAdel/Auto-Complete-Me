using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace algo_prog
{
    public partial class Form1 : Form
    {
        private List<sentance> words = new List<sentance>();
        private tree Rt = new tree();
        private List<sentance> res_print = new List<sentance>();
        private tree myDictionary = new tree();
        private List<string> dictionaryWords = new List<string>();
        private List<string> correctWords = new List<string>();
        private int displayedListHight = 20;
        private int startDeleteIndex = 0;

        public Form1()
        {
            InitializeComponent();

            FileStream FS = new FileStream("Search Links (Medium).txt", FileMode.Open);
            StreamReader SR = new StreamReader(FS);
            while (SR.Peek() != -1)
            {
                string data = SR.ReadLine();
                string[] fields = data.Split(',');
                sentance record = new sentance();
                if (fields.Length > 1)
                {
                    record.weight = long.Parse(fields[0]);
                    record.word = fields[1];
                    words.Add(record);
                    Rt.Insert(record.word.ToLower(), record.weight);
                }
            }
            SR.Close();
            FS.Close();

            FileStream FS1 = new FileStream("Dictionary (Medium).txt", FileMode.Open);
            StreamReader SR1 = new StreamReader(FS1);
            while (SR1.Peek() != -1)
            {
                string data = SR1.ReadLine();
                data = data.ToLower();
                char x = data[0];
                if (x > '9' || x < '0')
                {
                    dictionaryWords.Add(data);
                    myDictionary.Insert(data, 1);
                }
            }
            SR1.Close();
            FS1.Close();

            listBox2.Visible = false;
            Correct_label.Visible = false;
            Correct_listBox.Visible = false;
            Bubble_rb.Checked = false;
            Merge_rb.Checked = true;
        }

        private void bubbleSort(List<sentance> words)
        {
            int length = words.Count;

            for (int i = 0; i < length; i++)
            {
                for (int j = length - 1; j > i ; j--)
                {
                    if (words[j - 1].weight < words[j].weight)
                    {
                        sentance temp = words[j];
                        words[j] = words[j - 1];
                        words[j - 1] = temp;
                    }
                }
            }
        }

        private void mergeSort(List<sentance> sentence, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                // Sort first and second halves
                mergeSort(sentence, left, middle);       // size of left_array  (n-1) /2
                mergeSort(sentence, middle + 1, right);  // size of right_array  (n-1) /2
                merge(sentence, left, middle, right);    // O(N)
            }
        }

        private sentance[] Rarr = new sentance [1500000];
        private sentance[] Larr = new sentance [1500000];
        private void merge(List<sentance> sentence, int left, int middle, int right) // 0(n) is size of input array 
        {
            int n1 = middle - left + 1;                                          // O(1)
            int n2 = right - middle;                                             // O(1)
            // Copy data to temp arrays Larr[] and Rarr[]
            for (int i = 0; i < n1; i++)                                         // O(n1) n1 is half on array size
                Larr[i] = sentence[i + left];                                    // O(1)
            for (int i = 0; i < n2; i++)                                         // O(n2) n2 is half on array size
                Rarr[i] = sentence[middle + i + 1];                              // O(1)
            int k = 0, j = 0, index = 0;
            // Merge the temp arrays back into array
            while (k < n1 && j < n2)                                             // O(n) n is size of input array
            {
                if (Larr[k].weight > Rarr[j].weight)                             // O(1)
                {
                    sentence[left + index] = Larr[k++];                          // O(1)
                }
                else
                {
                    sentence[left + index] = Rarr[j++];                          // O(1)
                }
                index++;                                                         // O(1)
            }
            // restore data into array
            if (k < n1)                                                          // O(n1) n1 is half on array size
                for (; k < n1; k++, index++)
                    sentence[left + index] = Larr[k];                            // O(1)
            else if (j < n2)
                for (; j < n2; j++, index++)                                     // O(n2) n2 is half on array size
                    sentence[left + index] = Rarr[j];                            // O(1)
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            listBox2.Size = new Size(listBox2.Size.Width, 20);
            listBox2.ScrollAlwaysVisible = false;
            listBox2.Visible = false;
            Correct_label.Visible = false;
            Correct_listBox.Items.Clear();
            Correct_listBox.Size = new Size(Correct_listBox.Size.Width, 20);
            Correct_listBox.Visible = false;
            Correct_listBox.ScrollAlwaysVisible = false;

            if (richTextBox1.Text != "")
            {
                bool isCorrectlySpelled = true;
                int textPartLength = 0;
                string[] allText = richTextBox1.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string textPart = " ";
                for (int i = allText.Length - 1; i >= 0; i--)
                {
                    if (allText[i] != "")
                    {
                        textPart = allText[i].ToLower();
                        textPartLength = textPart.Length;
                        break;
                    }
                }
                
                if (isCorrectlySpelled)
                {
                    if (richTextBox1.Text.EndsWith(" "))
                    {
                        richTextBox1.Select(richTextBox1.Text.Length - textPartLength - 1, textPartLength);
                    }
                    else
                    {
                        richTextBox1.Select(richTextBox1.Text.Length - textPartLength, textPartLength);
                    }
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Times New Roman", 10, FontStyle.Regular);

                    res_print = Rt.ResultWords(richTextBox1.Text.ToLower());

                    if (res_print.Count == 0)
                    {
                        isCorrectlySpelled = false;

                        if (textPart[0] > '9' || textPart[0] < '0')
                        {
                            if (myDictionary.Lookup(textPart))
                            {
                                isCorrectlySpelled = true;
                            }
                            else
                            {
                                startDeleteIndex = textPart.Length;
                                correctWords = correctedResults(textPart, dictionaryWords);
                                if (correctWords.Count > 0)
                                {
                                    Correct_label.Visible = true;
                                    Correct_listBox.Visible = true;
                                    if (correctWords.Count > 6)
                                    {
                                        Correct_listBox.Size = new Size(Correct_listBox.Size.Width, displayedListHight * 5);
                                        Correct_listBox.ScrollAlwaysVisible = true;
                                    }
                                    else
                                    {
                                        Correct_listBox.Size = new Size(Correct_listBox.Size.Width, displayedListHight * correctWords.Count);
                                        Correct_listBox.ScrollAlwaysVisible = false;
                                    }
                                    foreach (var item in correctWords)
                                    {
                                        Correct_listBox.Items.Add(item);
                                    }
                                }
                            }
                        }
                        if (isCorrectlySpelled)
                            res_print = SubStringRec(richTextBox1.Text.ToLower(), words);
                    }
                    if (Merge_rb.Checked)
                    {
                        mergeSort(res_print, 0, res_print.Count - 1);
                    }
                    else if (Bubble_rb.Checked)
                    {
                        bubbleSort(res_print);
                    }

                    if (res_print.Count > 0)
                    {
                        listBox2.Visible = true;
                        if (res_print.Count > 6)
                        {
                            listBox2.Size = new Size(listBox2.Size.Width, displayedListHight * 5);
                            listBox2.ScrollAlwaysVisible = true;
                        }
                        else
                        {
                            listBox2.Size = new Size(listBox2.Size.Width, displayedListHight * res_print.Count);
                            listBox2.ScrollAlwaysVisible = false;
                        }
                        List<string> p = new List<string>();
                        foreach (var item in res_print)
                        {
                            p.Add(item.word);
                        }
                        listBox2.DataSource = p;
                    }
                    
                }
                else
                {
                    richTextBox1.Select(richTextBox1.Text.Length - textPartLength - 1, textPartLength);
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionFont = new Font("Times New Roman", 10, FontStyle.Underline);
                }
                richTextBox1.Select(richTextBox1.Text.Length, 0);
            }
            watch.Stop();
            label1.Text = watch.Elapsed.ToString();
        }

        private int CalculateMinNumberOfWeightedChanges(string s1, string s2)
        {
            int s1length = s1.Length;
            int s2length = s2.Length;
            int[,] d = new int[s1length + 1, s2length + 1];

            for (int i = 0; i <= s1length; i++)
            {
                for (int j = 0; j <= s2length; j++)
                {
                    if (j == 0)
                    {
                        d[i, j] = i;
                    }
                    else if (i == 0)
                    {
                        d[i, j] = j;
                    }
                    else if (s2[j - 1] == s1[i - 1])
                    {
                        d[i, j] = d[i - 1, j - 1];
                    }
                    else
                    {
                        int min1 = d[i - 1, j] + 1;
                        int min2 = d[i, j - 1] + 1;
                        int min3 = d[i - 1, j - 1] + 1;
                        d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                    }
                }
            }
            return d[s1length, s2length];
        }

        private List<string> correctedResults(string word, List<string> dictionary)
        {
            List<string> tmp = new List<string>();
            int miniCost = 1000000;
            foreach (var item in dictionary)
            {
                int cost = CalculateMinNumberOfWeightedChanges(word, item);
                if (cost < miniCost && (word.Length == 1 || cost < word.Length))
                {
                    miniCost = cost;
                    tmp.Clear();
                    tmp.Add(item);
                }
                else if (cost == miniCost && (word.Length == 1 || cost < word.Length))
                {
                    tmp.Add(item);
                }
            }
            return tmp;
        }

        private void Correct_listBox_DoubleClick(object sender, EventArgs e)
        {
            string answer = Correct_listBox.SelectedItem.ToString();
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - startDeleteIndex);
            richTextBox1.Text += answer;
        }


        private List<sentance> SubStringRec(string word_, List<sentance> words_)
        {
            List<sentance> temporary_ = new List<sentance>();
            List<sentance> result_ = new List<sentance>();
            if (word_ != null)
            {
                string[] arr_ = word_.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr_.Length; i++)
                {
                    foreach (var child in words_)
                    {
                        string childWord = child.word.ToLower();

                        if (i < 1)
                        {
                            if (childWord.Contains(arr_[i]))
                            {
                                if (!result_.Contains(child))
                                {
                                    result_.Add(child);
                                    if (!temporary_.Contains(child))
                                    {
                                        temporary_.Add(child);
                                    }
                                }
                            }
                        }
                        else
                        {
                            result_.Clear();
                            foreach (var child_ in temporary_)
                            {
                                string childWord_ = child_.word.ToLower();
                                if (childWord_.Contains(arr_[i]))
                                {
                                    if (!result_.Contains(child_))
                                    {
                                        result_.Add(child_);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result_;
        }
    }
}
