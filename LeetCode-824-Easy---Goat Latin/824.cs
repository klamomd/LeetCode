// https://leetcode.com/problems/goat-latin/

public class Solution {
	readonly string vowels = "aeiouAEIOU";
	
	public string ToGoatLatin(string sentence) {
		// Split sentence on spaces
		var words = sentence.Split(' ');
		
		StringBuilder result = new();
		
		for (int i = 0; i < words.Length; i++)
		{
			// Append mutated word.
			result.Append(Mutate(words[i].AsSpan(), i + 1));
			
			// Add a space if not at the end.
			if (i != words.Length - 1)
			{
				result.Append(' ');
			}
		}
		
		// Return result.
		return result.ToString();
	}
	
	private string Mutate(ReadOnlySpan<char> s, int i)
	{
		StringBuilder result = new();
		
		// Move first char to back, if consonant.
		if (!IsVowel(s[0]))
		{
			result.Append(s[1..]);
			result.Append(s[0]);
		}
		else
		{
			result.Append(s);
		}
		
		// Always append "ma".
		result.Append("ma");
		
		// Add "a" times the index `i`.
		while (i-- > 0)
		{
			result.Append('a');
		}
		
		return result.ToString();
	}
	
	private bool IsVowel(char c)
	{
		return vowels.Contains(c);
	}
}