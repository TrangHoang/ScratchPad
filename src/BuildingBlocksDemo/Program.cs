﻿using System;
using System.Collections.Generic;
using System.Linq;
using Reusables.BuildingBlocks;
using Reusables.BuildingBlocks.Extensions;
using Reusables.BuildingBlocks.Linq;

namespace BuildingBlocksDemo
{
    internal class Program
    {
        private static void Main()
        {
            TradionalRoutine();

            Console.WriteLine("++++++++++++++++++++++++++++++++++");

            FuncChainingRoutine();

            Console.WriteLine("++++++++++++++++++++++++++++++++++");

            BlockStyleRoutine();

            Console.ReadLine();
        }

        private static void TradionalRoutine()
        {
            Enumerable.Range(1, 10)
                      .Select(x => x*x*x)
                      .Select(x => x/2)
                      .Where(x => x%2 == 1)
                      .ToList()
                      .ForEach(Console.WriteLine);
        }

        private static void FuncChainingRoutine()
        {
            Func<int, int, IEnumerable<int>> range = Enumerable.Range;

            var handler = range.FollowedBy(Select<int, int>.With(x => x*x*x))
                               .FollowedBy(Select<int, int>.With(x => x/2))
                               .FollowedBy(Where<int>.With(x => x%2 == 1))
                               .FollowedBy(ForEach<int>.With(Console.WriteLine));

            handler(1, 10);
        }

        private static void BlockStyleRoutine()
        {
            var request = new RangeRequest {Start = 1, Count = 10};

            var handler = new RangeEnumerator().FollowedBy(Select<int, int>.With(x => x*x*x))
                                               .FollowedBy(Select<int, int>.With(x => x/2))
                                               .FollowedBy(Where<int>.With(x => x%2 == 1))
                                               .FollowedBy(ForEach<int>.With(Console.WriteLine));

            handler.Handle(request);
        }
    }

    internal class RangeEnumerator : IRequestHandler<RangeRequest, IEnumerable<int>>
    {
        IEnumerable<int> IRequestHandler<RangeRequest, IEnumerable<int>>.Handle(RangeRequest request)
        {
            return Enumerable.Range(request.Start, request.Count);
        }
    }

    internal class RangeRequest
    {
        public int Start { get; set; }

        public int Count { get; set; }
    }
}
