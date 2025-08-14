public class Solution {
    public string LargestGoodInteger(string num) {
        if (num.Contains("999")) return "999";
        if (num.Contains("888")) return "888";
        if (num.Contains("777")) return "777";
        if (num.Contains("666")) return "666";
        if (num.Contains("555")) return "555";
        if (num.Contains("444")) return "444";
        if (num.Contains("333")) return "333";
        if (num.Contains("222")) return "222";
        if (num.Contains("111")) return "111";
        if (num.Contains("000")) return "000";
        return "";
    }
}