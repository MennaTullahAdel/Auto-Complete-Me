using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_prog
{
    class tree
    {
        private sentance _root;

        public tree()
        {
            _root = new sentance("", 0);
        }
        public void Insert(string word, long weight)
        {
            //call insertrec to start from the root
            InsertRec(word, weight, _root);
        }
        private void InsertRec(string wordPart, long weight, sentance curNode)
        {
            var matches = Matched_chars(wordPart, curNode);
            if ((matches == 0) || (curNode == _root) ||
               ((matches > 0) && (matches < wordPart.Length) && (matches >= curNode.word.Length)))
            {
                //no matches or tree is empty or there 's a node contain substring of the word 
                bool inserted = false;

                var newWordPart = wordPart.Substring(matches, wordPart.Length - matches);

                {
                    foreach (var child in curNode.SubNodes)
                        // check on subnode if its first char is the same of  first newWordPart 
                        if (child.word.StartsWith(newWordPart[0].ToString()))
                        {

                            inserted = true;
                            InsertRec(newWordPart, weight, child);
                        }

                    if (inserted == false)
                    {
                        curNode.SubNodes.Add(new sentance(newWordPart, weight));
                        //else add subnode with newsentancePart
                    }

                }
            }
            else if (matches < wordPart.Length)
            {
                //  make word in the current node is matched chars of Previous word and new word
                string commonRoot = wordPart.Substring(0, matches);
                string Previous = curNode.word.Substring(matches, curNode.word.Length - matches);
                string New = wordPart.Substring(matches, wordPart.Length - matches);
                curNode.word = commonRoot;

                //   create node called  previousNode contain the last of Previous word and its weight.
                var previousNode = new sentance(Previous, curNode.weight);
                previousNode.SubNodes.AddRange(curNode.SubNodes);
                curNode.weight = 0;

                curNode.SubNodes.Clear();
                curNode.SubNodes.Add(previousNode);

                //   create node called newNode contain the last of new word and its weight.
                var newNode = new sentance(New, weight);
                curNode.SubNodes.Add(newNode);


            }

        }
        private int Matched_chars(string word, sentance curNode)
        {
            // # of matched char  node & word
            int matches = 0;
            int min = 0;

            if (curNode.word.Length >= word.Length)
                min = word.Length;
            else if (curNode.word.Length < word.Length)
                min = curNode.word.Length;
            if (min > 0)
                for (int i = 0; i < min ; i++)
                {
                    //if two characters at the same position have the same value we have one more match
                    if (word[i] == curNode.word[i])
                        matches++;
                    else
                        //if at any position the two strings have different characters break the loop
                        break;
                }
            return matches;
        }

        public List<sentance> ResultWords(string word)
        {
            return ResultWordsRec(word, _root);
        }

        private string acc = "";
        private List<sentance> ResultWordsRec(string wordPart, sentance curNode)
        {
            var matches = Matched_chars(wordPart, curNode);
            List<sentance> tmp = new List<sentance>();
            bool wordCheck = true;
            if (curNode == _root)
            {
                var newWordPart = wordPart.Substring(matches, wordPart.Length - matches);
                foreach (var child in curNode.SubNodes)
                {
                    wordCheck = true;
                    int len1 = Math.Min(child.word.Length, newWordPart.Length);
                    for (int i = 0; i < len1; i++)
                    {
                        if (child.word[i] != newWordPart[i])
                        {
                            wordCheck = false;
                            break;
                        }
                    }
                    if (wordCheck)
                        return ResultWordsRec(newWordPart, child);
                }
            }
            else if ((matches > 0) && (matches < wordPart.Length) && (matches >= curNode.word.Length))
            {
                var newLabel = wordPart.Substring(matches, wordPart.Length - matches);
                if (acc == "")
                    acc = curNode.word;
                foreach (var child in curNode.SubNodes)
                {
                    wordCheck = true;
                    int len2 = Math.Min(child.word.Length, newLabel.Length);
                    for (int i = 0; i < len2; i++)
                    {
                        if (child.word[i] != newLabel[i])
                        {
                            wordCheck = false;
                            break;
                        }
                    }
                    if (wordCheck)
                    {
                        acc += child.word;
                        return ResultWordsRec(newLabel, child);
                    }
                }
            }
            else if (matches > 0)
            {
                if (acc == "")
                    acc = curNode.word;
                AddToList(curNode, tmp, acc);
            }
            acc = "";
            return tmp;
        }

        private void AddToList(sentance node, List<sentance> tmp, string res)
        {
            if (node.weight != 0)
            {
                //Terminate
                tmp.Add(new sentance(res, node.weight));
            }
            if (node.SubNodes.Count == 0)
            {
                return;
            }

            foreach (var child in node.SubNodes)
            {
                res += child.word;
                AddToList(child, tmp, res);
                res = res.Remove(res.Length - child.word.Length);
            }
        }

        public bool Lookup(string word)
        {
            return LookupRec(word, _root);
        }

        private bool LookupRec(string wordPart, sentance curNode)
        {
            var matches = Matched_chars(wordPart, curNode);

            if ((curNode == _root) ||
                ((matches > 0) && (matches < wordPart.Length) && (matches >= curNode.word.Length)))
            {

                var newWordPart = wordPart.Substring(matches, wordPart.Length - matches);
                foreach (var child in curNode.SubNodes)
                    if (child.word.StartsWith(newWordPart[0].ToString()))
                        return LookupRec(newWordPart, child);

                return false;
            }
            else if (matches == curNode.word.Length && curNode.weight != 0)
            {
                return true;
            }
            else
                return false;
        }

        
    }
}
