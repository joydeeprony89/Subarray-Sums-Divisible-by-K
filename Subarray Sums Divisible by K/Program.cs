using System;
using System.Collections.Generic;


// https://www.youtube.com/watch?v=QM0klnvTQzk
namespace Subarray_Sums_Divisible_by_K
{
  class Program
  {
    /*
     *   Input:  A = [4,5,0,-2,-3,1], K = 5
            Map  
            step 1 : {0:1}          a=4    sum=4  mod=4  count = 0+0 =0
            step 2 : {0:1,4:1}      a=5    sum=9  mod=4  count = 0+1 =1
            step 3 : {0:1,4:2}      a=0    sum=9  mod=4  count = 1+2 =3
            step 4 : {0:1,4:3}      a=-2   sum=7  mod=2  count = 3+0 =3  
            step 6 : {0:1,4:3,2:1}  a=-3   sum=4  mod=4  count = 3+3 =6
            step 7 : {0:1,4:4,2:1}  a=1    sum=5  mod=0  count = 6+1 =7
     */
    static void Main(string[] args)
    {
      var nums = new int[] { 4, 5, 0, -2, -3, 1 }; //-1, 2, 9 and k = 2
      int k = 5;
      Solution s = new Solution();
      var answer = s.SubarraysDivByK(nums, k);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int SubarraysDivByK(int[] nums, int k)
    {
      int count = 0;
      Dictionary<int, int> hash = new Dictionary<int, int>();
      hash.Add(0, 1); // as 0 is divisible of any no, so the count is 1.
      int sum = 0;
      for (int i = 0; i < nums.Length; i++)
      {
        sum += nums[i];
        int mod = sum % k;
        // if mod = -1 and k = 5 then we need either +4 to make it divisible by 5
        if (mod < 0) mod += k;
        if (hash.ContainsKey(mod)) count += hash[mod];
        if (!hash.ContainsKey(mod)) hash.Add(mod, 0);
        hash[mod]++;
      }

      return count;
    }
  }
}
