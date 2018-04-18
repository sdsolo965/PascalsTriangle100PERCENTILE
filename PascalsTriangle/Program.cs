using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class Solution
{
    /*
     * Scored in 100th percentile for runtime out of 144k submissions.
     * Problem has a 38% submission acceptance rate.
     */
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
        //Get half way point of row since second half is a mirror.
        double half = Math.Floor((double) rowIndex / 2) + 1;
        //Place 0 and 1 in row are always '1' and 'rowIndex' respectively
        //Else calculate position with formula
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
        //Add mirrored numbers for a even row and odd # of positions.
        //Last calculated position doesn't repeat.
        if (rowIndex % 2 == 0)
        {
            for (int i = (int)half - 2; i >= 0; i--)
            {
                rowNums.Add(rowNums[i]);
            }
        }
        //Else add mirrored numbers for odd row with even # of positions.
        //Last calculated position repeats.
        else
        {
            for (int i = (int)half - 1; i >= 0; i--)
            {
                rowNums.Add(rowNums[i]);
            }
        }
        //Return list to print to console.
        return rowNums;
    }
}
