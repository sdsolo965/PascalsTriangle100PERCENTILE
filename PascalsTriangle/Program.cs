using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class Solution
{
    public static void Main()
    {
        IList<int> rowNums = Solution.GetRow(30);
        Console.Write('[');
        for (int i = 0; i < rowNums.Count; i++)
        {
            if (i == rowNums.Count-1)
            {
                Console.Write(rowNums[i]);
            }
            else {Console.Write($"{rowNums[i]},");}
        }

        Console.Write(']');

    }
    public static IList<int> GetRow(int rowIndex)
    {
        List<int> rowNums = new List<int>();
        long r = (long)rowIndex;
        double half = Math.Floor((double) rowIndex / 2) + 1;

        for (int i = 0; i < half; i++)
        {
            if (i == 0) { rowNums.Add(1);}
            else if(i == 1) { rowNums.Add(rowIndex);}
            else
            {
                r = (r * (rowIndex + 1 - i)) / i;
                rowNums.Add((int)r);
            }
        }

        if (rowIndex % 2 == 0)
        {
            for (int i = (int)half - 2; i >= 0; i--)
            {
                rowNums.Add(rowNums[i]);
            }
        }
        else
        {
            for (int i = (int)half - 1; i >= 0; i--)
            {
                rowNums.Add(rowNums[i]);
            }
        }
        
        
        return rowNums;
    }
}
