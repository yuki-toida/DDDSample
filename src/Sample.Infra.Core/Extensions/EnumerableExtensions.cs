using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Infra.Core.Extensions
{
    /// <summary>
    /// Collections.Generic名前空間の拡張機能です
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// コレクションの要素を一つずつ処理します。
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// コレクションの要素をIdex付で一つずつ処理します。
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in source)
            {
                action(item, index++);
            }
        }

        /// <summary>
        /// ページング対象シーケンスの最大要素数
        /// </summary>
        private const int PaginateMaxElementCount = 1500;

        /// <summary>
        /// シーケンスをページングして返す
        /// </summary>
        /// <param name="source">対象となるシーケンス</param>
        /// <param name="take">1ページに表示する要素数</param>
        /// <param name="current">現在のページ数</param>
        /// <returns>ページングされたシーケンス</returns>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int take, int current)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = source as T[] ?? source.ToArray();
            if (enumerable.Count() > PaginateMaxElementCount)
                throw new ArgumentException($"ページング対象のシーケンスの要素数が{PaginateMaxElementCount}件を超えています。");

            return enumerable.Skip(take * (current - 1)).Take(take);
        }

        /// <summary>
        /// DrawWeightedSequenceの復元抽選最大回数
        /// </summary>
        private const int DrawWeightedSequenceMaxLoopCount = 1000;

        /// <summary>
        /// シーケンスからweightSelectorで指定された重み付けで復元抽選を実施し、当選した一つの要素を返します。
        /// </summary>
        public static T DrawWeightedFirst<T>(this IEnumerable<T> source, Func<T, int> weightSelector)
        {
            return DrawWeightedSequence(source, weightSelector).First();
        }

        /// <summary>
        /// シーケンスからweightSelectorで指定された重み付けで復元抽選を実施し、当選した要素を返します。
        /// </summary>
        public static IEnumerable<T> DrawWeightedSequence<T>(this IEnumerable<T> source, Func<T, int> weightSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (weightSelector == null)
                throw new ArgumentNullException(nameof(weightSelector));

            return DrawWeightedSequenceCore(source, weightSelector, new Random());
        }

        private static IEnumerable<T> DrawWeightedSequenceCore<T>(IEnumerable<T> source, Func<T, int> weightSelector, Random random)
        {
            var totalWeight = 0;
            var sortedArray = source
                .Select(x =>
                {
                    var weight = weightSelector(x);
                    if (weight <= 0) return null;

                    checked { totalWeight += weight; }
                    return new { Value = x, Bound = totalWeight };
                })
                .Where(x => x != null)
                .ToArray();

            if (!sortedArray.Any()) yield break;

            var loopCounter = 0;
            while (true)
            {
                if (++loopCounter > DrawWeightedSequenceMaxLoopCount)
                    throw new InvalidOperationException(
                        $"[DrawWeightedSequence] 抽選回数が{DrawWeightedSequenceMaxLoopCount}回を超えています。");

                var draw = random.Next(1, totalWeight + 1);

                var lower = -1;
                var upper = sortedArray.Length;
                while (upper - lower > 1)
                {
                    var index = (lower + upper) / 2;
                    if (sortedArray[index].Bound >= draw)
                    {
                        upper = index;
                    }
                    else
                    {
                        lower = index;
                    }
                }

                yield return sortedArray[upper].Value;
            }
        }


        /// <summary>
        /// ランダムにシャッフルした順番で列挙します。
        /// </summary>
        /// <param name="source">対象となる値のシーケンス</param>
        /// <returns>シャッフルされたシーケンス</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return ShuffleCore(source, new Random());
        }

        /// <summary>
        /// ランダムにシャッフルした順番で列挙します。ランダム生成子は渡されたものを用います。
        /// </summary>
        /// <param name="source">対象となる値のシーケンス</param>
        /// <param name="random">シャッフルに使用するランダム生成子</param>
        /// <returns>シャッフルされたシーケンス</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return ShuffleCore(source, random);
        }

        public static IEnumerable<T> ShuffleCore<T>(this IEnumerable<T> source, Random random)
        {
            var buffer = source.ToArray(); // buffer for side effects

            for (var i = buffer.Length - 1; i > 0; i--)
            {
                var j = random.Next(0, i + 1);

                yield return buffer[j];
                buffer[j] = buffer[i];
            }

            // return rest element
            if (buffer.Length != 0)
            {
                yield return buffer[0];
            }
        }

    }
}