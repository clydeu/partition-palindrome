using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Partition_Palindrom
{
    public class PalindromePartitioner
    {
        Dictionary<string, List<List<string>>> DP = new Dictionary<string, List<List<string>>>();

        public IEnumerable<string> Partition(string str)
        {
            var result = PartitionRecursion(str);
            ReversePartitions(ref result);

            return CombinePartitions(result);

            void ReversePartitions(ref List<List<string>> partitions)
            {
                foreach (var list in partitions)
                {
                    list.Reverse();
                }
            }

            IEnumerable<string> CombinePartitions(List<List<string>> partitions) =>
                partitions.Select(parts => string.Join(",", parts));

        }

        private List<List<string>> PartitionRecursion(string str)
        {
            var result = new List<List<string>>();

            if (string.IsNullOrEmpty(str))
            {
                result.Add(new List<string>());
                return result;
            }

            for (int i = 1; i <= str.Length; i++)
            {
                var (left, right) = GetStringPartitions(i);
                var partition = CreatePartition(left, right);
                result.AddRange(partition);
            }

            return result;

            (string left, string right) GetStringPartitions(int index) =>
                (str.Substring(0, index), str.Substring(index));

            List<List<string>> CreatePartition(string left, string right)
            {
                var parlist = new List<List<string>>();
                if (ValidatePalindrome(left))
                {
                    if (DP.ContainsKey(right))
                    {
                        parlist = DeepCopyList(DP[right]);
                    }
                    else
                    {
                        parlist = DeepCopyList(PartitionRecursion(right));
                        var newlist = DeepCopyList(parlist);
                        DP.Add(right, newlist);
                    }
                    AppendLeftToPartition(left, ref parlist);
                }

                return parlist;
            }

            void AppendLeftToPartition(string left, ref List<List<string>> parlist)
            {
                foreach (var list in parlist)
                {
                    list.Add(left);
                }
            }

            List<List<string>> DeepCopyList(List<List<string>> parlist) =>
                    parlist.Select(list => list.ToList()).ToList();

            bool ValidatePalindrome(string @string)
            {
                var isValid = true;
                for (int i = 0, j = @string.Length - 1; i < j; i++, j--)
                {
                    if (char.ToLower(@string[i]) != char.ToLower(@string[j]))
                    {
                        isValid = false;
                        break;
                    }
                }
                return isValid;
            }
        }
    }
}
