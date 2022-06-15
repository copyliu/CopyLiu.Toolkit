﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CopyLiu.Toolkit.Linq
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
        {
            if (chunkSize <= 0) throw new ArgumentException("chunkSize must be greater than 0.");

            while (list.Any())
            {
                yield return list.Take(chunkSize);
                list = list.Skip(chunkSize);
            }
        }
    }
}