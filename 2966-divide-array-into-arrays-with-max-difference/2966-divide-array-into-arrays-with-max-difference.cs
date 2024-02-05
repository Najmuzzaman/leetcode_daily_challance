public class Solution {
    public int[][] DivideArray(int[] nums, int k) {
        int n = nums.Length;
        List<List<int>> result = new List<List<int>>();
        Array.Sort(nums);
        List<int> list = new List<int>();
        int first = 0;
        bool flag = true;
        for(int i=0;i<n && flag;i++)
        {
            if(list.Count==0)
            {
                list.Add(nums[i]);
                first = nums[i];
            }
            else
            {
                if(list.Count==3)
                {
                    result.Add(list);
                    list = new List<int>();
                    list.Add(nums[i]);
                    first = nums[i];
                }
                else if ( (nums[i]-first) <=k)
                {
                    list.Add(nums[i]);
                }
                else
                {
                    if (list.Count == 3)
                    {
                        result.Add(list);
                        list = new List<int>();
                        list.Add(nums[i]);
                        first = nums[i];
                    }
                    else
                        flag = false;
                }
            }
        }
        if(list.Count==3)
            result.Add(list);
        else 
            flag=false;
        if (flag)
        {
            int[][] arrayResult = new int[result.Count][];
            for (int i = 0; i < result.Count; i++)
            {
                arrayResult[i] = result[i].ToArray();
            }
            return arrayResult; 
        }
        else
        {
            return new int[][] { };
        }
    }
}