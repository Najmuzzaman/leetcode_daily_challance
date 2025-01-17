public class Solution {
    public bool DoesValidArrayExist(int[] derived) {
        int sum=derived.Sum();
        return sum % 2==0;
    }
}