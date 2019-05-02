using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhishDetect
{
    class naivebayes
    {

        private DataSet dataSet = new DataSet();

        public DataSet DataSet
        {
            get { return dataSet; }
            set { dataSet = value; }
        }


        static Random ran = new Random(25); // 25 gives a nice demo

        static void Main(DataTable table)
        {
            try
            {
                Console.WriteLine("\nBegin Naive Bayes Classification demo\n");
                Console.WriteLine("Demo will classify sex based on occpation, dominance, height\n");

                string[] attributes = new string[] { "occupation", "dominance", "height", "sex" };

                string[][] attributeValues = new string[attributes.Length][];  // could scan values from raw data
                attributeValues[0] = new string[] { "administrative", "construction", "education", "technology" };
                attributeValues[1] = new string[] { "left", "right" };
                attributeValues[2] = new string[] { "short", "medium", "tall" };
                attributeValues[3] = new string[] { "male", "female" };

                double[][] numericAttributeBorders = new double[1][];     // there may be several numeric variables
                numericAttributeBorders[0] = new double[] { 64.0, 71.0 }; // height range: [57.0 to 78.0]

                Console.WriteLine("Generating 40 lines of occupation, dominance, height, sex data\n");
                string[] data = MakeData(40);

                Console.WriteLine("First 4 lines of training data are:\n");

                for (int i = 0; i < 4; ++i)
                    Console.WriteLine(data[i]);
                Console.WriteLine("\n");

                Console.WriteLine("Converting numeric height data to categorical data on 64.0 71.0\n");

                string[] binnedData = BinData(data, attributeValues, numericAttributeBorders);  // convert numeric heights to categories

                Console.WriteLine("First 4 lines of binned training data are:\n");
                for (int i = 0; i < 4; ++i)
                    Console.WriteLine(binnedData[i]);
                Console.WriteLine("\n");

                Console.WriteLine("Scanning binned data to compute joint and dependent counts\n");
                int[][][] jointCounts = MakeJointCounts(binnedData, attributes, attributeValues);
                int[] dependentCounts = MakeDependentCounts(jointCounts, 2);
                Console.WriteLine("Total male = " + dependentCounts[0]);
                Console.WriteLine("Total female = " + dependentCounts[1]);
                Console.WriteLine("");

                ShowJointCounts(jointCounts, attributeValues);

                // classify the sex of a person whose occupation is education, is right-handed, and is tall
                string occupation = "education";
                string dominance = "right";
                string height = "tall";

                bool withLaplacian = true;  // prevent joint counts with 0

                Console.WriteLine("Using Naive Bayes " + (withLaplacian ? "with" : "without") + " Laplacian smoothing to classify when:");
                Console.WriteLine(" occupation = " + occupation);
                Console.WriteLine(" dominance = " + dominance);
                Console.WriteLine(" height = " + height);
                Console.WriteLine("");

                int c = Classify(occupation, dominance, height, jointCounts, dependentCounts, withLaplacian, 3);
                if (c == 0)
                    Console.WriteLine("\nData case is most likely male");
                else if (c == 1)
                    Console.WriteLine("\nData case is most likely female");

                Console.WriteLine("\nEnd demo\n");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        } // Main

        static string[] MakeData(int numRows) // make dummy data
        {
            string[] result = new string[numRows];
            for (int i = 0; i < numRows; ++i)
            {
                string sex = MakeSex();
                string occupation = MakeOccupation(sex);
                string dominance = MakeDominance(sex);
                string height = MakeHeight(sex);
                string s = occupation + "," + dominance + "," + height + "," + sex;
                result[i] = s;
            }
            return result;
        }

        static string MakeSex()
        {
            int r = ran.Next(0, 19);
            if (r >= 0 && r <= 11) return "male"; // 60%
            else if (r >= 12 && r <= 19) return "female"; // 40%
            return "error";
        }

        static string MakeDominance(string sex)
        {
            double p = ran.NextDouble();
            if (sex == "male")
            {
                if (p < 0.33) return "left"; else return "right";
            }
            else if (sex == "female")
            {
                if (p < 0.20) return "left"; else return "right";
            }
            return "error";
        }

        static string MakeOccupation(string sex)
        {
            int r = ran.Next(0, 20);
            if (sex == "male")
            {
                if (r == 0) return "administrative"; // 5%
                else if (r >= 1 && r <= 6) return "construction"; // 30%
                else if (r >= 7 && r <= 9) return "education"; // 15%
                else if (r >= 10 && r <= 19) return "technology"; // 50%
            }
            else if (sex == "female")
            {
                if (r >= 0 & r <= 9) return "administrative"; // 50%
                else if (r == 10) return "construction"; // 5%
                else if (r >= 11 & r <= 15) return "education";  // 25%
                else if (r >= 16 && r <= 19) return "technology"; // 20%
            }
            return "error";
        }

        static string MakeHeight(string sex)
        {
            int bucket = 0;  // height bucket: 0 = short, 1 = medium, 2 = tall
            double p = ran.NextDouble();
            if (p < 0.1587) bucket = 0;
            else if (p > 0.8413) bucket = 2;
            else bucket = 1; // p = (2 * 0.3413) = 0.6826

            double hi = 0.0;
            double lo = 0.0;

            if (sex == "male")
            {
                if (bucket == 0) { lo = 60.0; hi = 66.0; }
                else if (bucket == 1) { lo = 66.0; hi = 72.0; }
                else if (bucket == 2) { lo = 72.0; hi = 78.0; }
            }
            else if (sex == "female")
            {
                if (bucket == 0) { lo = 57.0; hi = 63.0; }
                else if (bucket == 1) { lo = 63.0; hi = 69.0; }
                else if (bucket == 2) { lo = 69.0; hi = 75.0; }
            }

            double resultAsDouble = (hi - lo) * ran.NextDouble() + lo;
            return resultAsDouble.ToString("F1");
        }

        static string[] BinData(string[] data, string[][] attributeValues, double[][] numericAttributeBorders)
        {
            // convert numeric height to "short", "medium", or "tall". assumes data is occupation,dominance,height,sex
            string[] result = new string[data.Length];
            string[] tokens;
            double heightAsDouble;
            string heightAsBinnedString;

            for (int i = 0; i < data.Length; ++i)
            {
                tokens = data[i].Split(',');
                heightAsDouble = double.Parse(tokens[2]);
                if (heightAsDouble <= numericAttributeBorders[0][0]) // short
                    heightAsBinnedString = attributeValues[2][0];
                else if (heightAsDouble >= numericAttributeBorders[0][1]) // tall
                    heightAsBinnedString = attributeValues[2][2];
                else
                    heightAsBinnedString = attributeValues[2][1]; // medium

                string s = tokens[0] + "," + tokens[1] + "," + heightAsBinnedString + "," + tokens[3];
                result[i] = s;
            }
            return result;
        }

        static int[][][] MakeJointCounts(string[] binnedData, string[] attributes, string[][] attributeValues)
        {
            // assumes binned data is occupation, dominance, height, sex
            // result[][][] -> [attribute][att value][sex]
            // ex: result[0][3][1] is the count of (occupation) (technology) (female), i.e., the count of technology AND female

            int[][][] jointCounts = new int[attributes.Length - 1][][]; // note the -1 (no sex)

            jointCounts[0] = new int[4][]; // 4 occupations
            jointCounts[1] = new int[2][]; // 2 dominances
            jointCounts[2] = new int[3][]; // 3 heights

            jointCounts[0][0] = new int[2]; // 2 sexes for administrative
            jointCounts[0][1] = new int[2]; // construction
            jointCounts[0][2] = new int[2]; // education
            jointCounts[0][3] = new int[2]; // tedchnology

            jointCounts[1][0] = new int[2]; // left
            jointCounts[1][1] = new int[2]; // right

            jointCounts[2][0] = new int[2]; // short
            jointCounts[2][1] = new int[2]; // medium
            jointCounts[2][2] = new int[2]; // tall

            for (int i = 0; i < binnedData.Length; ++i)
            {
                string[] tokens = binnedData[i].Split(',');

                int occupationIndex = AttributeValueToIndex(0, tokens[0]);
                int dominanceIndex = AttributeValueToIndex(1, tokens[1]);
                int heightIndex = AttributeValueToIndex(2, tokens[2]);
                int sexIndex = AttributeValueToIndex(3, tokens[3]);

                ++jointCounts[0][occupationIndex][sexIndex];  // occupation and sex count
                ++jointCounts[1][dominanceIndex][sexIndex];
                ++jointCounts[2][heightIndex][sexIndex];
            }

            return jointCounts;
        }

        static int AttributeValueToIndex(int attribute, string attributeValue)
        {
            // we could do this programmatically (maybe with a Dictionary) but a crude approach is more clear
            if (attribute == 0)
            {
                if (attributeValue == "administrative") return 0;
                else if (attributeValue == "construction") return 1;
                else if (attributeValue == "education") return 2;
                else if (attributeValue == "technology") return 3;
            }
            else if (attribute == 1)
            {
                if (attributeValue == "left") return 0;
                else if (attributeValue == "right") return 1;
            }
            else if (attribute == 2)
            {
                if (attributeValue == "short") return 0;
                else if (attributeValue == "medium") return 1;
                else if (attributeValue == "tall") return 2;
            }
            else if (attribute == 3)
            {
                if (attributeValue == "male") return 0;
                else if (attributeValue == "female") return 1;
            }
            return -1; // error
        }

        static void ShowJointCounts(int[][][] jointCounts, string[][] attributeValues)
        {
            for (int k = 0; k < 2; ++k)
            {
                for (int i = 0; i < jointCounts.Length; ++i)
                    for (int j = 0; j < jointCounts[i].Length; ++j)
                        Console.WriteLine(attributeValues[i][j].PadRight(15) + "& " + attributeValues[3][k].PadRight(6) + " = " + jointCounts[i][j][k]);
                Console.WriteLine(""); // separate sexes
            }
        }

        static int[] MakeDependentCounts(int[][][] jointCounts, int numDependents)
        {
            int[] result = new int[numDependents];
            for (int k = 0; k < numDependents; ++k)  // male then female
                for (int j = 0; j < jointCounts[0].Length; ++j) // scanning attribute 0 = occupation. could use any attribute
                    result[k] += jointCounts[0][j][k];

            return result;
        }

        static int Classify(string occupation, string dominance, string height, int[][][] jointCounts, int[] dependentCounts, bool withSmoothing, int xClasses)
        {
            double partProbMale = PartialProbability("male", occupation, dominance, height, jointCounts, dependentCounts, withSmoothing, xClasses);
            double partProbFemale = PartialProbability("female", occupation, dominance, height, jointCounts, dependentCounts, withSmoothing, xClasses);
            double evidence = partProbMale + partProbFemale;
            double probMale = partProbMale / evidence;
            double probFemale = partProbFemale / evidence;

            //Console.WriteLine("Partial prob of male   = " + partProbMale.ToString("F6"));
            //Console.WriteLine("Partial prob of female = " + partProbFemale.ToString("F6"));

            Console.WriteLine("Probability of male   = " + probMale.ToString("F4"));
            Console.WriteLine("Probability of female = " + probFemale.ToString("F4"));
            if (probMale > probFemale) // could use a threshold
                return 0;
            else
                return 1;
        }

        static double PartialProbability(string sex, string occupation, string dominance, string height, int[][][] jointCounts, int[] dependentCounts, bool withSmoothing, int xClasses)
        {
            int sexIndex = AttributeValueToIndex(3, sex);

            int occupationIndex = AttributeValueToIndex(0, occupation);
            int dominanceIndex = AttributeValueToIndex(1, dominance);
            int heightIndex = AttributeValueToIndex(2, height);

            int totalMale = dependentCounts[0];
            int totalFemale = dependentCounts[1];
            int totalCases = totalMale + totalFemale;

            int totalToUse = 0;
            if (sex == "male") totalToUse = totalMale;
            else if (sex == "female") totalToUse = totalFemale;

            double p0 = (totalToUse * 1.0) / (totalCases); // prob of either male or female
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;

            if (withSmoothing == false)
            {
                p1 = (jointCounts[0][occupationIndex][sexIndex] * 1.0) / totalToUse;  // conditional prob of male (or female, depending on sex parameter) given the occupation
                p2 = (jointCounts[1][dominanceIndex][sexIndex] * 1.0) / totalToUse;   // conditional prob of the specified sex, given the specified domnance
                p3 = (jointCounts[2][heightIndex][sexIndex] * 1.0) / totalToUse;      // condition prob given specified height
            }
            else if (withSmoothing == true) // Laplacian smoothing to avoid 0-count joint probabilities
            {
                p1 = (jointCounts[0][occupationIndex][sexIndex] + 1) / ((totalToUse + xClasses) * 1.0);  // add 1 to count in numerator, add number x classes in denominator
                p2 = (jointCounts[1][dominanceIndex][sexIndex] + 1) / ((totalToUse + xClasses) * 1.0);   // conditional prob of the specified sex, given the specified domnance
                p3 = (jointCounts[2][heightIndex][sexIndex] + 1) / ((totalToUse + xClasses) * 1.0);
            }

            //return p0 * p1 * p2 * p3; // risky if any very small values
            return Math.Exp(Math.Log(p0) + Math.Log(p1) + Math.Log(p2) + Math.Log(p3));
        }

        static int AnalyzeJointCounts(int[][][] jointCounts)
        {
            // check for any joint-counts that are 0 which could blow up Naive Bayes
            int zeroCounts = 0;

            for (int i = 0; i < jointCounts.Length; ++i) // attribute
                for (int j = 0; j < jointCounts[i].Length; ++j) // value
                    for (int k = 0; k < jointCounts[i][j].Length; ++k) // sex
                        if (jointCounts[i][j][k] == 0)
                            ++zeroCounts;
            return zeroCounts;
        }

    } // class Program
} // ns
