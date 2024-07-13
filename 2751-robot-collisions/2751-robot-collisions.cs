public class Solution {
    
    public class Info {
        public int Pos { get; set; }
        public int Hel { get; set; }
        public char Dir { get; set; }
    }

    public static bool Comp(Info a, Info b) {
        return a.Pos < b.Pos;
    }
    
    
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        int n = positions.Length;
        List<Info> robots = new List<Info>(n);
        for (int i = 0; i < n; i++) {
            robots.Add(new Info { Pos = positions[i], Hel = healths[i], Dir = directions[i] });
        }

        robots.Sort((a, b) => Comp(a, b) ? -1 : 1);
        
        Stack<Info> st = new Stack<Info>();
        st.Push(robots[0]);

        for (int i = 1; i < n; i++) {
            while (st.Count > 0 && st.Peek().Dir == 'R' && robots[i].Dir == 'L') {
                var top = st.Pop();
                if (top.Hel == robots[i].Hel) {
                    robots[i].Hel = 0; // both are destroyed
                } else if (top.Hel < robots[i].Hel) {
                    robots[i].Hel -= 1; // curr robot survived
                } else if (top.Hel > robots[i].Hel) {
                    top.Hel -= 1; // top robot survived
                    st.Push(top);
                    robots[i].Hel = 0;
                }

                if (robots[i].Hel <= 0) {
                    break;
                }
            }

            if (robots[i].Hel > 0) {
                st.Push(robots[i]);
            }
        }

        Dictionary<int, int> mp = new Dictionary<int, int>();
        while (st.Count > 0) {
            var curr = st.Pop();
            mp[curr.Pos] = curr.Hel;
        }

        List<int> ans = new List<int>();
        for (int i = 0; i < n; i++) {
            if (mp.ContainsKey(positions[i])) {
                ans.Add(mp[positions[i]]);
            }
        }
        return ans;
    }
}