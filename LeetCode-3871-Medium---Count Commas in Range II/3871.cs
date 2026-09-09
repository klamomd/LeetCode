/* 
https://leetcode.com/problems/count-commas-in-range-ii/
*/

public class Solution {
	public long CountCommas(long n) {
		int currentNumberOfCommas = 0;
		long x = 999;
		
		long commas = 0;
		
		while (n > x)
		{
			// Add the number of commas for the current cluster of numbers.
			commas += x * currentNumberOfCommas;
			
			// Update n to exclude the current cluster of numbers from further calculations.
			n -= x;
			
			// Update number of commas for each number in the next cluster.
			currentNumberOfCommas++;
			
			// Update x.
			x = 999 * (long)Math.Pow(1000, currentNumberOfCommas);
		}
		
		// Add the number of numbers remaining in the current cluster.
		commas += currentNumberOfCommas * n;
		
		return commas;
	}
}