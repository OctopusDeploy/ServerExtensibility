using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public static class LinkCollectionExtensions
    {
        public static LinkCollection Pagination(this LinkCollection collection, Func<int, int, string> formatWithSkipAndTake, int currentOffset, int perPage, int total)
        {
            if (currentOffset > 0)
            {
                collection.Add("Page.Previous", formatWithSkipAndTake(Math.Max(currentOffset - perPage, 0), perPage));
            }

            if (total > currentOffset + perPage)
            {
                collection.Add("Page.Next", formatWithSkipAndTake(currentOffset + perPage, perPage));
            }

            collection.Add("Page.Current", formatWithSkipAndTake(currentOffset, perPage));

            var lastPage = (int)Math.Ceiling((double)total / perPage);
            for (var i = 0; i < lastPage; i++)
            {
                collection.Add("Page." + i, formatWithSkipAndTake(i * perPage, perPage));
            }

            return collection;
        }
    }
}