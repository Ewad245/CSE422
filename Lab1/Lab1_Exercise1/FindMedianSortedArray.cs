
namespace Lab1_Exercise1
{
    public class FindMedianSortedArray()
    {
        public double Solution(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                var temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int m = nums1.Length;
            int n = nums2.Length;
            int left = 0;
            int right = m;

            while (left <= right)
            {
                int partition1 = (left + right) / 2;
                int partition2 = (m + n + 1) / 2 - partition1;

                int maxLeft1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
                int minRight1 = (partition1 == m) ? int.MaxValue : nums1[partition1];

                int maxLeft2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];
                int minRight2 = (partition2 == n) ? int.MaxValue : nums2[partition2];

                if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
                {
                    if ((m + n) % 2 == 0)
                    {
                        return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxLeft1, maxLeft2);
                    }
                }
                else if (maxLeft1 > minRight2)
                {
                    right = partition1 - 1;
                }
                else
                {
                    left = partition1 + 1;
                }
            }
            
            throw new ArgumentException("Input array are not sorted");
        }
    }
}