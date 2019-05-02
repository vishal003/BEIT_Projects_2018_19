using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    public class ID3
    {
        public string ReturnString { get; set; }

        private readonly bool _instanceFieldsInitialized = false;

        public ID3()
        {
            if (!_instanceFieldsInitialized)
            {
                InitializeInstanceFields();
                _instanceFieldsInitialized = true;
            }
        }

        private void InitializeInstanceFields()
        {
            _root = new TreeNode(this);
        }

        private int _numAttributes;
        private string[] _attributeNames;
        private ArrayList[] _domains;

        private class DataPoint
        {
            private readonly ID3 _outerInstance;

            public readonly int[] Attributes;
            public DataPoint(ID3 outerInstance, int numAttributes)
            {
                _outerInstance = outerInstance;
                Attributes = new int[numAttributes];
            }
        }

        public class TreeNode
        {
            private readonly ID3 _outerInstance;

            public double Entropy;
            public ArrayList Data;
            public int DecompositionAttribute;
            public int DecompositionValue;
            public TreeNode[] Children;
            public TreeNode Parent;
            public TreeNode(ID3 outerInstance)
            {
                _outerInstance = outerInstance;
                Data = new ArrayList();
            }
        }

        private TreeNode _root;

        protected virtual int GetSymbolValue(int attribute, string symbol)
        {
            int index = _domains[attribute].IndexOf(symbol);
            if (index < 0)
            {
                _domains[attribute].Add(symbol);
                return _domains[attribute].Count - 1;
            }
            return index;
        }

        protected virtual int[] GetAllValues(ArrayList data, int attribute)
        {
            var values = new ArrayList();
            int num = data.Count;
            for (int i = 0; i < num; i++)
            {
                var point = (DataPoint)data[i];
                var symbol = (string)_domains[attribute][point.Attributes[attribute]];
                int index = values.IndexOf(symbol);
                if (index == -1)
                {
                    values.Clear();
                    values.Add(symbol);
                }
                else
                {
                    values.Clear();
                    values.Add(symbol);
                }
            }

            var array = new int[values.Count];
            for (int i = 0; i < array.Length; i++)
            {
                string symbol = (string)values[i];
                array[i] = _domains[attribute].IndexOf(symbol);
            }
            values = null;
            return array;
        }

        protected virtual ArrayList GetSubset(ArrayList data, int attribute, int value)
        {
            var subset = new ArrayList();
            int num = data.Count;
            for (int i = 0; i < num; i++)
            {
                var point = (DataPoint)data[i];
                if (point.Attributes[attribute] == value)
                {
                    subset.Add(point);
                }
            }
            return subset;
        }

        protected virtual ArrayList GetComplement(ArrayList data, ArrayList oldset)
        {
            var subset = new ArrayList();
            int num = data.Count;
            for (int i = 0; i < num; i++)
            {
                var point = (DataPoint)data[i];
                int index = oldset.IndexOf(point);
                if (index < 0)
                {
                    subset.Add(point);
                }
            }
            return subset;
        }

        protected virtual double CalculateEntropy(ArrayList data)
        {
            int numdata = data.Count;
            if (numdata == 0)
            {
                return 0;
            }
            int attribute = _numAttributes - 1;
            //System.out.println(attribute + "attribute");
            int numvalues = _domains[attribute].Count;
            double sum = 0;
            for (int i = 0; i < numvalues; i++)
            {
                int count = 0;
                for (int j = 0; j < numdata; j++)
                {
                    var point = (DataPoint)data[j];
                    if (point.Attributes[attribute] == i)
                    {
                        count++;
                    }
                    //System.out.println(i + "\t" + j + ":" + point.attributes[attribute]);
                }
                double probability = 1.0 * count / numdata;
                if (count > 0)
                {
                    sum += -probability * Math.Log(probability);
                }
            }
            return sum;
        }

        protected virtual bool AlreadyUsedToDecompose(TreeNode node, int attribute, int value)
        {
            if (node.Children != null)
            {
                if (node.DecompositionAttribute == attribute && node.DecompositionValue == value)
                {
                    return true;
                }
            }
            if (node.Parent == null)
            {
                return false;
            }
            return AlreadyUsedToDecompose(node.Parent, attribute, value);
        }

        protected virtual void DecomposeNode(TreeNode node)
        {
            double bestEntropy;
            bool selected = false;
            int selectedAttribute = 0;
            int selectedValue = 0;
            int numdata = node.Data.Count;
            int numinputattributes = _numAttributes - 1;
            double initialEntropy = bestEntropy = node.Entropy = CalculateEntropy(node.Data);
            //System.out.println("Entropy of " + node + "=" + node.entropy);
            System.Console.WriteLine(@"Entropy of " + node + @"=" + node.Entropy);
            if (node.Entropy == 0)
            {
                return;
            }
            for (int i = 0; i < numinputattributes; i++)
            {
                int numvalues = _domains[i].Count;
                for (int j = 0; j < numvalues; j++)
                {
                    if (AlreadyUsedToDecompose(node, i, j))
                    {
                        continue;
                    }
                    var subset = GetSubset(node.Data, i, j);
                    if (subset.Count == 0)
                    {
                        continue;
                    }
                    var complement = GetComplement(node.Data, subset);
                    var e1 = CalculateEntropy(subset);
                    var e2 = CalculateEntropy(complement);
                    var entropy = (e1 * subset.Count + e2 * complement.Count) / numdata;
                    if (!(entropy < bestEntropy)) continue;
                    selected = true;
                    bestEntropy = entropy;
                    selectedAttribute = i;
                    selectedValue = j;
                }
            }
            if (selected == false)
            {
                return;
            }
            node.DecompositionAttribute = selectedAttribute;
            node.DecompositionValue = selectedValue;
            node.Children = new TreeNode[2];
            node.Children[0] = new TreeNode(this)
            {
                Parent = node,
                Data = GetSubset(node.Data, selectedAttribute, selectedValue)
            };
            node.Children[1] = new TreeNode(this) { Parent = node };

            for (int j = 0; j < numdata; j++)
            {
                var point = (DataPoint)node.Data[j];
                if (node.Children[0].Data.IndexOf(point) >= 0)
                {
                    continue;
                }
                node.Children[1].Data.Add(point);
            }
            DecomposeNode(node.Children[0]);
            DecomposeNode(node.Children[1]);
            node.Data = null;
        }

        public virtual int ReadData(string filename)
        {
            System.IO.FileStream @in = null;
            try
            {
                Stream s = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                s.Close();
                @in = new FileStream(filename, FileMode.Open);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unable to open data file: " + filename + "\n" + e);
                return 0;
            }
            var bin = new System.IO.StreamReader(@in);
            string input;
            while (true)
            {
                input = bin.ReadLine();
                if (input == null)
                {
                    Console.Error.WriteLine("No data found in the data file: " + filename + "\n");
                    return 0;
                }
                if (input.StartsWith("//", StringComparison.Ordinal))
                {
                    continue;
                }
                if (input.Equals(""))
                {
                    continue;
                }
                break;
            }
            String[] tokenizer = input.Split('\t');
            _numAttributes = tokenizer.Count();
            if (_numAttributes <= 1)
            {
                Console.Error.WriteLine("Read line: " + input);
                Console.Error.WriteLine("Could not obtain the names of attributes in the line");
                Console.Error.WriteLine("Expecting at least one input attribute and one output attribute");
                return 0;
            }
            _domains = new ArrayList[_numAttributes];
            for (int i = 0; i < _numAttributes; i++)
            {
                _domains[i] = new ArrayList();
            }
            _attributeNames = new string[_numAttributes];
            for (int i = 0; i < _numAttributes; i++)
            {
                _attributeNames[i] = tokenizer[i];
            }
            while (true)
            {
                input = bin.ReadLine();
                if (input == null)
                {
                    break;
                }
                if (input.StartsWith("//", StringComparison.Ordinal))
                {
                    continue;
                }
                if (input.Equals(""))
                {
                    continue;
                }

                tokenizer = input.Split('\t');
                int numtokens = tokenizer.Count();
                if (numtokens != _numAttributes)
                {
                    Console.Error.WriteLine("Read " + _root.Data.Count + "data");
                    Console.Error.WriteLine("Last line read: " + input);
                    Console.Error.WriteLine("Expecting " + _numAttributes + "attributes");
                    return 0;
                }
                var point = new DataPoint(this, _numAttributes);
                for (int i = 0; i < _numAttributes; i++)
                {
                    point.Attributes[i] = GetSymbolValue(i, tokenizer[i]);
                }
                _root.Data.Add(point);
            }
            bin.Close();
            return 1;
        }

        protected virtual void PrintTree(TreeNode node, string tab)
        {
            int outputattr = _numAttributes - 1;
            if (node.Children == null)
            {
                int[] values = GetAllValues(node.Data, outputattr);
                if (values.Length == 1)
                {
                    ReturnString += "\t" + "return" + " " + _attributeNames[outputattr] + "=\"" + _domains[outputattr][values[0]] + "\";" + Environment.NewLine;
                    return;
                }
                ReturnString += tab + "\t" + _attributeNames[outputattr] + "= " + Environment.NewLine + "{" + Environment.NewLine;
                for (int i = 0; i < values.Length; i++)
                {
                    ReturnString += "\"" + _domains[outputattr][values[i]] + "\"" + Environment.NewLine;
                    if (i != values.Length - 1)
                    {
                        ReturnString += " , " + Environment.NewLine;
                    }
                }
                ReturnString += " };" + Environment.NewLine;
                return;
            }
            ReturnString += tab + "if(" + _attributeNames[node.DecompositionAttribute] + "== \"" + _domains[node.DecompositionAttribute][node.DecompositionValue] + "\") " + Environment.NewLine + "{" + Environment.NewLine;
            PrintTree(node.Children[0], tab + "\t" + Environment.NewLine);
            ReturnString += tab + "} " + Environment.NewLine + "else" + Environment.NewLine + "{" + Environment.NewLine;
            PrintTree(node.Children[1], tab + "\t" + Environment.NewLine);
            ReturnString += tab + "}" + Environment.NewLine;
        }

        public virtual void CreateDecisionTree()
        {
            DecomposeNode(_root);
            PrintTree(_root, "");
        }
    }
}