using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SharpSpecs.UI.Helpers
{
    public static class ListHelper
    {
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="value">The value.</param>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> value)
        {
            foreach (T item in value)
            {
                collection.Add(item);
            }
        }
    }
}
