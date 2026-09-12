// https://leetcode.com/problems/backspace-string-compare/description/

public class Solution {
	public bool BackspaceCompare(string s, string t) {
		var sStack = ProcessString(s);
		var tStack = ProcessString(t);
		
		if (sStack.Count != tStack.Count)
		{
			return false;
		}
		
		while (sStack.Count > 0)
		{
			if (sStack.Pop() != tStack.Pop())
			{
				return false;
			}
		}
		
		return true;
	}
	
	private Stack<char> ProcessString(string s)
	{
		Stack<char> stack = new();
		
		foreach (char c in s)
		{
			// Remove last character from stack, if any.
			if (c == '#')
			{
				if (stack.Count != 0)
				{
					stack.Pop();
				}
				
				continue;
			}
			
			// Add character to stack.
			stack.Push(c);
		}
		
		return stack;
	}
	
	
	/*
	// 1ST PASS: Decided to pass results back as strings and then compare those. 2nd pass changed course to return the generated stacks and compare those instead.
	
	public bool BackspaceCompare(string s, string t) {
		return ProcessString(s) == ProcessString(t);
	}
	
	private string ProcessString(string s)
	{
		Stack<char> stack = new();
		
		foreach (char c in s)
		{
			// Remove last character from stack, if any.
			if (c == '#')
			{
				if (stack.Count != 0)
				{
					stack.Pop();
				}
				
				continue;
			}
			
			// Add character to stack.
			stack.Push(c);
		}
		
		// Regurgitate remaining characters and dump them into a string to return (the reversed order doesn't matter, as it will be the same for any other strings processed by this function).
		StringBuilder sb = new();
		while (stack.Count > 0)
		{
			sb.Append(stack.Pop());
		}
		
		return sb.ToString();
	} */
}