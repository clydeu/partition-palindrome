using FluentAssertions;
using Partition_Palindrom;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class PalindromePartitionerTests
    {
        private readonly PalindromePartitioner service;

        public PalindromePartitionerTests()
        {
            service = new PalindromePartitioner();
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { string.Empty, new List<string> { string.Empty } },
            new object[] { null, new List<string> { string.Empty } },
            new object[] { "aab", new List<string> { "a,a,b", "aa,b" } },
            new object[] { "geeks", new List<string> { "g,e,e,k,s", "g,ee,k,s" } },
            new object[] { "geeeks", new List<string> { "g,e,e,e,k,s", "g,ee,e,k,s", "g,e,ee,k,s", "g,eee,k,s" } },
            new object[] { "bcc", new List<string> { "b,c,c", "b,cc" } },
            new object[] { "nitin", new List<string> { "n,i,t,i,n", "n,iti,n", "nitin" } },
            new object[] { "balak", new List<string> { "b,a,l,a,k", "b,ala,k" } },
            new object[] { "racecAr", new List<string> { "r,a,c,e,c,A,r", "r,a,cec,A,r", "r,acecA,r", "racecAr" } },
            new object[] { "122322", new List<string> { "1,2,2,3,2,2", "1,2,2,3,22", "1,2,232,2", "1,22,3,2,2", "1,22,3,22", "1,22322" } }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void PartitionTest(string str, List<string> expectedResult)
        {
            var result = service.Partition(str);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
