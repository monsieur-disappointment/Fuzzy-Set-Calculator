using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace FuzzySetCalc
{
    class FuzzySet
    {
        private List<double> lowBorder = new List<double>();
        private List<double> highBorder = new List<double>();
        private List<double> alphaLevels = new List<double>();

        public FuzzySet(List<double> lvls, List<double> low, List<double> high)
        {
            alphaLevels.AddRange(lvls);
            alphaLevels.Sort();

            for (int i = 0; i < lvls.Count; i++) {
                int n = i;
                if (alphaLevels[i] != lvls[i])
                    n = lvls.IndexOf(alphaLevels[i]);
                lowBorder.Add(low[n]);
                highBorder.Add(high[n]);
            }
        }
        private static double AdditionalValue(double x1, double y1, double x2, double y2, double xv)
        {
            double k = (y2 - y1) / (x2 - x1);
            double b = y1 - k * x1;
            return xv * k + b;
        }
        private static Tuple<double, double> FindClosest(List<double> elem, double target)
        {
            List<double> tmp = new List<double>(elem);
            for (int i = 0; i < tmp.Count; i++)
                tmp[i] -= target;
            tmp.Sort();

            for (int i = 1; i < tmp.Count; i++)
                if (tmp[i] > 0 && tmp[i - 1] < 0) return new Tuple<double, double>(tmp[i - 1] + target, tmp[i] + target);
            return new Tuple<double, double>(-1.0, -1.0);
        }
        private static double CompFactor(int count, List<double> low, List<double> high) {
            double tmpSum = 0.0;
            for (int i = 0; i < count; i++)
                tmpSum += low[i] + high[i];
            return tmpSum / count;
        }
        public List<List<double>> ToList() {
            return new List<List<double>>{ alphaLevels, lowBorder, highBorder };
        }
        public static FuzzySet operator +(FuzzySet a, FuzzySet b)
        {
            List<double> tmpLevels = new List<double>(a.alphaLevels);
            List<double> tmpLow = new List<double>();
            List<double> tmpHigh = new List<double>();

            tmpLevels.AddRange(b.alphaLevels);
            tmpLevels = new HashSet<double>(tmpLevels).ToList();

            foreach (double n in tmpLevels)
            {
                if (a.alphaLevels.Contains(n) && b.alphaLevels.Contains(n))
                {
                    int ia = a.alphaLevels.IndexOf(n);
                    int ib = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[ia] + b.lowBorder[ib]);
                    tmpHigh.Add(a.highBorder[ia] + b.highBorder[ib]);
                }
                else if (b.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, n);
                    double avl = AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);
                    double avh = AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(avl + b.lowBorder[i]);
                    tmpHigh.Add(avh + b.highBorder[i]);
                }
                else if (a.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, n);
                    double bvl = AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);
                    double bvh = AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = a.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[i] + bvl);
                    tmpHigh.Add(a.highBorder[i] + bvh);
                }
            }
            return new FuzzySet(tmpLevels, tmpLow, tmpHigh);
        }

        public static FuzzySet operator -(FuzzySet a, FuzzySet b)
        {
            List<double> tmpLevels = new List<double>(a.alphaLevels);
            List<double> tmpLow = new List<double>();
            List<double> tmpHigh = new List<double>();

            tmpLevels.AddRange(b.alphaLevels);
            tmpLevels = new HashSet<double>(tmpLevels).ToList();
            foreach (double n in tmpLevels)
            {
                if (a.alphaLevels.Contains(n) && b.alphaLevels.Contains(n))
                {
                    int ia = a.alphaLevels.IndexOf(n);
                    int ib = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[ia] - b.highBorder[ib]);
                    tmpHigh.Add(a.highBorder[ia] - b.lowBorder[ib]);
                }
                else if (b.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, n);
                    double avl = AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);
                    double avh = AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = b.alphaLevels.IndexOf(n);

                    tmpLow.Add(avl - b.highBorder[i]);
                    tmpHigh.Add(avh - b.lowBorder[i]);
                }
                else if (a.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, n);
                    double bvl = AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);
                    double bvh = AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = a.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[i] - bvh);
                    tmpHigh.Add(a.highBorder[i] - bvl);
                }
            }
            return new FuzzySet(tmpLevels, tmpLow, tmpHigh);
        }

        public static FuzzySet operator *(FuzzySet a, FuzzySet b)
        {
            List<double> tmpLevels = new List<double>(a.alphaLevels);
            List<double> tmpLow = new List<double>();
            List<double> tmpHigh = new List<double>();

            tmpLevels.AddRange(b.alphaLevels);
            tmpLevels = new HashSet<double>(tmpLevels).ToList();
            foreach (double n in tmpLevels)
            {
                if (a.alphaLevels.Contains(n) && b.alphaLevels.Contains(n))
                {
                    int ia = a.alphaLevels.IndexOf(n);
                    int ib = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[ia] * b.lowBorder[ib]);
                    tmpHigh.Add(a.highBorder[ia] * b.highBorder[ib]);
                }
                else if (b.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, n);
                    double avl = AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);
                    double avh = AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(avl * b.lowBorder[i]);
                    tmpHigh.Add(avh * b.highBorder[i]);
                }
                else if (a.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, n);
                    double bvl = AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);
                    double bvh = AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = a.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[i] * bvl);
                    tmpHigh.Add(a.highBorder[i] * bvh);
                }
            }
            return new FuzzySet(tmpLevels, tmpLow, tmpHigh);
        }

        public static FuzzySet operator /(FuzzySet a, FuzzySet b)
        {
            List<double> tmpLevels = new List<double>(a.alphaLevels);
            List<double> tmpLow = new List<double>();
            List<double> tmpHigh = new List<double>();

            tmpLevels.AddRange(b.alphaLevels);
            tmpLevels = new HashSet<double>(tmpLevels).ToList();
            foreach (double n in tmpLevels)
            {
                if (a.alphaLevels.Contains(n) && b.alphaLevels.Contains(n))
                {
                    int ia = a.alphaLevels.IndexOf(n);
                    int ib = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[ia] / b.highBorder[ib]);
                    tmpHigh.Add(a.highBorder[ia] / b.lowBorder[ib]);
                }
                else if (b.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, n);
                    double avl = AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);
                    double avh = AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = b.alphaLevels.IndexOf(n);
                    tmpLow.Add(avl / b.highBorder[i]);
                    tmpHigh.Add(avh / b.lowBorder[i]);
                }
                else if (a.alphaLevels.Contains(n))
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, n);
                    double bvl = AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);
                    double bvh = AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], n);

                    int i = a.alphaLevels.IndexOf(n);
                    tmpLow.Add(a.lowBorder[i] / bvh);
                    tmpHigh.Add(a.highBorder[i] / bvl);
                }
            }
            return new FuzzySet(tmpLevels, tmpLow, tmpHigh);
        }
        public static bool operator ==(FuzzySet a, FuzzySet b)
        {
            if (a.alphaLevels.Count < b.alphaLevels.Count)
            {
                a.alphaLevels.AddRange(b.alphaLevels);
                a.alphaLevels = new HashSet<double>(a.alphaLevels).ToList();

                for (int i = a.lowBorder.Count; i < a.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, a.alphaLevels[i]);
                    a.lowBorder.Add(AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                    a.highBorder.Add(AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                }
            }
            if (a.alphaLevels.Count > b.alphaLevels.Count) {
                b.alphaLevels.AddRange(a.alphaLevels);
                b.alphaLevels = new HashSet<double>(b.alphaLevels).ToList();

                for (int i = b.lowBorder.Count; i < b.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, b.alphaLevels[i]);
                    b.lowBorder.Add(AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                    b.highBorder.Add(AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                }
            }
            return CompFactor(a.alphaLevels.Count, a.lowBorder, a.highBorder) == CompFactor(b.alphaLevels.Count, b.lowBorder, b.highBorder);
        }
        public static bool operator !=(FuzzySet a, FuzzySet b)
        {
            if (a.alphaLevels.Count < b.alphaLevels.Count)
            {
                a.alphaLevels.AddRange(b.alphaLevels);
                a.alphaLevels = new HashSet<double>(a.alphaLevels).ToList();

                for (int i = a.lowBorder.Count; i < a.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, a.alphaLevels[i]);
                    a.lowBorder.Add(AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                    a.highBorder.Add(AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                }
            }
            if (a.alphaLevels.Count > b.alphaLevels.Count)
            {
                b.alphaLevels.AddRange(a.alphaLevels);
                b.alphaLevels = new HashSet<double>(b.alphaLevels).ToList();

                for (int i = b.lowBorder.Count; i < b.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, b.alphaLevels[i]);
                    b.lowBorder.Add(AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                    b.highBorder.Add(AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                }
            }
            return CompFactor(a.alphaLevels.Count, a.lowBorder, a.highBorder) != CompFactor(b.alphaLevels.Count, b.lowBorder, b.highBorder);
        }
        public static bool operator >(FuzzySet a, FuzzySet b)
        {
            if (a.alphaLevels.Count < b.alphaLevels.Count)
            {
                a.alphaLevels.AddRange(b.alphaLevels);
                a.alphaLevels = new HashSet<double>(a.alphaLevels).ToList();

                for (int i = a.lowBorder.Count; i < a.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, a.alphaLevels[i]);
                    a.lowBorder.Add(AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                    a.highBorder.Add(AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                }
            }
            if (a.alphaLevels.Count > b.alphaLevels.Count)
            {
                b.alphaLevels.AddRange(a.alphaLevels);
                b.alphaLevels = new HashSet<double>(b.alphaLevels).ToList();

                for (int i = b.lowBorder.Count; i < b.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, b.alphaLevels[i]);
                    b.lowBorder.Add(AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                    b.highBorder.Add(AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                }
            }
            return CompFactor(a.alphaLevels.Count, a.lowBorder, a.highBorder) > CompFactor(b.alphaLevels.Count, b.lowBorder, b.highBorder);
        }
        public static bool operator <(FuzzySet a, FuzzySet b)
        {
            if (a.alphaLevels.Count < b.alphaLevels.Count)
            {
                a.alphaLevels.AddRange(b.alphaLevels);
                a.alphaLevels = new HashSet<double>(a.alphaLevels).ToList();

                for (int i = a.lowBorder.Count; i < a.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, a.alphaLevels[i]);
                    a.lowBorder.Add(AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                    a.highBorder.Add(AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                }
            }
            if (a.alphaLevels.Count > b.alphaLevels.Count)
            {
                b.alphaLevels.AddRange(a.alphaLevels);
                b.alphaLevels = new HashSet<double>(b.alphaLevels).ToList();

                for (int i = b.lowBorder.Count; i < b.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, b.alphaLevels[i]);
                    b.lowBorder.Add(AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                    b.highBorder.Add(AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                }
            }
            return CompFactor(a.alphaLevels.Count, a.lowBorder, a.highBorder) < CompFactor(b.alphaLevels.Count, b.lowBorder, b.highBorder);
        }
        public static bool operator >=(FuzzySet a, FuzzySet b)
        {
            if (a.alphaLevels.Count < b.alphaLevels.Count)
            {
                a.alphaLevels.AddRange(b.alphaLevels);
                a.alphaLevels = new HashSet<double>(a.alphaLevels).ToList();

                for (int i = a.lowBorder.Count; i < a.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, a.alphaLevels[i]);
                    a.lowBorder.Add(AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                    a.highBorder.Add(AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                }
            }
            if (a.alphaLevels.Count > b.alphaLevels.Count)
            {
                b.alphaLevels.AddRange(a.alphaLevels);
                b.alphaLevels = new HashSet<double>(b.alphaLevels).ToList();

                for (int i = b.lowBorder.Count; i < b.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, b.alphaLevels[i]);
                    b.lowBorder.Add(AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                    b.highBorder.Add(AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                }
            }
            return CompFactor(a.alphaLevels.Count, a.lowBorder, a.highBorder) >= CompFactor(b.alphaLevels.Count, b.lowBorder, b.highBorder);
        }
        public static bool operator <=(FuzzySet a, FuzzySet b)
        {
            if (a.alphaLevels.Count < b.alphaLevels.Count)
            {
                a.alphaLevels.AddRange(b.alphaLevels);
                a.alphaLevels = new HashSet<double>(a.alphaLevels).ToList();

                for (int i = a.lowBorder.Count; i < a.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(a.alphaLevels, a.alphaLevels[i]);
                    a.lowBorder.Add(AdditionalValue(tmp.Item1, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.lowBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                    a.highBorder.Add(AdditionalValue(tmp.Item1, a.highBorder[a.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, a.highBorder[a.alphaLevels.IndexOf(tmp.Item2)], a.alphaLevels[i]));
                }
            }
            if (a.alphaLevels.Count > b.alphaLevels.Count)
            {
                b.alphaLevels.AddRange(a.alphaLevels);
                b.alphaLevels = new HashSet<double>(b.alphaLevels).ToList();

                for (int i = b.lowBorder.Count; i < b.alphaLevels.Count; i++)
                {
                    Tuple<double, double> tmp = FindClosest(b.alphaLevels, b.alphaLevels[i]);
                    b.lowBorder.Add(AdditionalValue(tmp.Item1, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.lowBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                    b.highBorder.Add(AdditionalValue(tmp.Item1, b.highBorder[b.alphaLevels.IndexOf(tmp.Item1)], tmp.Item2, b.highBorder[b.alphaLevels.IndexOf(tmp.Item2)], b.alphaLevels[i]));
                }
            }
            return CompFactor(a.alphaLevels.Count, a.lowBorder, a.highBorder) <= CompFactor(b.alphaLevels.Count, b.lowBorder, b.highBorder);
        }
    }
}
