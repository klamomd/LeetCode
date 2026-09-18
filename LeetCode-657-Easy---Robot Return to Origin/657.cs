public class Solution {
	public bool JudgeCircle(string moves) {
		int x = 0;
		int y = 0;

		foreach (char c in moves) {
			switch (c) {
				case 'U':
					y++;
					continue;
				case 'D':
					y--;
					continue;
				case 'L':
					x--;
					continue;
				case 'R':
					x++;
					continue;
				default:
					continue;
			}
		}

		return x == 0 && y == 0;
	}
}