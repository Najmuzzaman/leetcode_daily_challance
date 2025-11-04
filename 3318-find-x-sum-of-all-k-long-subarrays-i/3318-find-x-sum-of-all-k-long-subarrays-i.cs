public class Solution {
    public int[] FindXSum(int[] nums, int k, int x) {
        var results = new List<int> { };
        var len = nums.Length;
        if(x == k)
        {
            var sumK = 0;
            for(var i = 0; i < len - k + 1; i++)
            {
                if (i == 0)
                {
                    for (var j = 0; j < k; j++) sumK += nums[i + j];
                }
                else
                    sumK = sumK - nums[i - 1] + nums[i + k - 1];
                results.Add(sumK);
            }
            return results.ToArray();
        }
        // x < k
        var numFreqs = new int[51];
        var numsWithFreq = new List<int>[51];
        for (var i = 0; i < 50 ; i++)
        {
            numsWithFreq[i + 1] = new List<int> { };
        }
        for (var i = 0; i < len - k + 1; i++)
        {
            if(i == 0)
            {
                for (var j = 0; j < k; j++)
                {
                    numFreqs[nums[i + j]]++;
                    var freq = numFreqs[nums[i + j]];
                    numsWithFreq[freq].Add(nums[i + j]);
                    if(freq > 1)
                        numsWithFreq[freq - 1].Remove(nums[i + j]);
                }
            }
            else
            {
                var itemToRelease = nums[i - 1];
                var leftFreq = numFreqs[itemToRelease];
                numsWithFreq[leftFreq].Remove(itemToRelease);
                if (leftFreq > 1) numsWithFreq[leftFreq - 1].Add(itemToRelease);
                numFreqs[itemToRelease]--;

                var newItem = nums[i + k - 1];
                var rightFreq = numFreqs[newItem];
                numFreqs[newItem]++;
                var newRightFreq = numFreqs[newItem];
                if(newRightFreq > 1)
                    numsWithFreq[newRightFreq - 1].Remove(newItem);
                numsWithFreq[newRightFreq].Add(newItem);
            }

            //get the x items with biggest frequences
            var selectedItems = new List<int> { };
            var tfInd = len;
            while(selectedItems.Count < x)
            {
                while (tfInd > 0 && numsWithFreq[tfInd].Count == 0)
                {
                    tfInd--;
                }
                if (tfInd == 0) break;
                var nextFreqItems = numsWithFreq[tfInd];
                if (tfInd > 0 && selectedItems.Count + nextFreqItems.Count <= x)
                {
                    selectedItems.AddRange(nextFreqItems);
                }
                else if (tfInd > 0)
                {
                    nextFreqItems.Sort(new Comparison<int>((m, n) => n - m));
                    var remaining = x - selectedItems.Count;
                    for (var rem = 0; rem < remaining; rem++)
                        selectedItems.Add(nextFreqItems[rem]);
                }
                tfInd--;
            }
            var sum = 0;
            foreach(var item in selectedItems)
            {
                var itsFreq = numFreqs[item];
                sum += item * itsFreq;
            }
            results.Add(sum);
        }
        return results.ToArray();
    }
}