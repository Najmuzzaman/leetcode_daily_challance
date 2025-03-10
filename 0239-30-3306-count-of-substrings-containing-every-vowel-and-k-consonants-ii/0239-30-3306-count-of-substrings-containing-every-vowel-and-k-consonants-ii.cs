public class Solution {
    public long CountOfSubstrings(string word, int k) {
        return solve(word, k) - solve(word, k + 1);
    }
    public long solve(string word, int k) 
    {
        HashSet<char> vowelsSet = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        Dictionary<char, int> freqVowels = new Dictionary<char, int>();

        int n = word.Length, l = 0, r = 0;
        long consonants = 0, res = 0;

        while (r < n) {
            if (vowelsSet.Contains(word[r])) {
                if (!freqVowels.ContainsKey(word[r]))
                    freqVowels[word[r]] = 0;
                freqVowels[word[r]]++;
            }
            else {
                ++consonants;
            }

            while (freqVowels.Count == 5 && consonants >= k) {
                if (vowelsSet.Contains(word[l])) {
                    freqVowels[word[l]]--;
                    if (freqVowels[word[l]] == 0)
                        freqVowels.Remove(word[l]);
                }
                else {
                    --consonants;
                }
                ++l;
            }

            res += l;
            ++r;
        }

        return res;
    }
}