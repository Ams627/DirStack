using Microsoft.VisualStudio.TestTools.UnitTesting;
using DirStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace DirStack.Tests
{
    [TestClass()]
    public class DirStackTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var stack = new DirStack(5);
            stack.Add("hello");
            stack.Add("world");
            stack.Add("fred");

            var res1 = stack.GetList(2);
            res1.Should().ContainInOrder("fred", "world");
            var res2 = stack.GetList(2);
            res2.Should().ContainInOrder("fred", "world");

            stack.Add("jim");
            stack.Add("sally");

            var res3 = stack.GetList(5);
            res3.Should().ContainInOrder("sally", "jim", "fred", "world", "hello");
            stack.Count.Should().Be(5);

            stack.Add("sheila");
            stack.Count.Should().Be(5);
            var res4 = stack.GetList(5);
            res4.Should().ContainInOrder("sheila", "sally", "jim", "fred", "world").And.HaveCount(5);

            stack.Add("fred");
            stack.Count.Should().Be(5);
            var res5 = stack.GetList(5);
            res5.Should().ContainInOrder("fred", "sheila", "sally", "jim", "world");

            stack.Add("fred");
            stack.Add("fred");
            stack.Add("fred");
            stack.Add("fred");
            stack.Add("fred");

            var res6 = stack.GetList(5);
            res6.Should().ContainInOrder("fred", "sheila", "sally", "jim", "world");

            stack.Add("world");
            stack.Add("world");
            stack.Add("world");
            stack.Add("world");
            stack.Add("world");

            var res7 = stack.GetList(5);
            res7.Should().ContainInOrder("world", "fred", "sheila", "sally", "jim");
        }
    }
}