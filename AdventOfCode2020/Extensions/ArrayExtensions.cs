using System;

namespace AdventOfCode2020.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns true if all indices are valid and it's safe to call <c>Array.GetValue</c>.
        /// </summary>
        /// <param name="array">Multidimensional array to check the indices against</param>
        /// <param name="indices">Array with index per dimension</param>
        /// <returns>True if the indices are valid for the multidimensional array</returns>
        public static bool AreIndicesInRange(this Array array, params int[] indices)
        {
            for (var i = 0; i < indices.Length; i++)
            {
                var index = indices[i];
                var min = array.GetLowerBound(i);
                if (index < min) return false;
                var max = array.GetUpperBound(i);
                if (index > max) return false;
            }

            return true;
        }

        /// <summary>
        /// Try to get value of multidimensional array
        /// </summary>
        /// <param name="array">Multidimensional array to get the value of</param>
        /// <param name="value">Value which is filled in case of success</param>
        /// <param name="indices">Array with index per dimension</param>
        /// <returns>True if the value was returned, false if the indices were out of range</returns>
        public static bool TryGetValue(this Array array, out object value, params int[] indices)
        {
            if (array.AreIndicesInRange(indices) == false)
            {
                value = default;
                return false;
            }

            value = array.GetValue(indices);
            return true;
        }

        /// <summary>
        /// Iterate over the multidimensional array and call <paramref name="action"/> for each item with the current value and the index
        /// </summary>
        /// <param name="array">Array to recursively iterate over</param>
        /// <param name="action">Action to call for each item</param>
        public static void ForEach(this Array array, Action<object, int[]> action)
            => array.ForEach(action, Array.Empty<int>());

        /// <summary>
        /// Iterate over the multidimensional array and call <paramref name="selectFunction"/> for each item with the current value and the index.
        /// The result of this function is set in the target array at the same indices.
        /// </summary>
        /// <remarks>
        /// This does not return a new array but works on the passed one.
        /// </remarks>
        /// <param name="array">Array to recursively iterate over</param>
        /// <param name="selectFunction">Function which is applied on each item. The item at the indices will be set to each function's result</param>
        public static void SelectForEach(this Array array, Func<object, int[], object> selectFunction)
        {
            array.ForEach((value, indices) =>
            {
                var newValue = selectFunction(value, indices);
                array.SetValue(newValue, indices);
            });
        }

        private static void ForEach(this Array array, Action<object, int[]> action, int[] indices)
        {
            var dimension = indices.Length;

            // check if we got a full indices array and can apply the action
            if (dimension == array.Rank)
            {
                var currentValue = array.GetValue(indices);
                action(currentValue, indices);
                return;
            }

            // otherwise, iterate over the current dimension and build indices
            var newIndices = new int[indices.Length + 1];
            for (var i = 0; i < indices.Length; i++)
            {
                newIndices[i] = indices[i];
            }

            // go into new dimension
            for (var i = array.GetLowerBound(dimension); i <= array.GetUpperBound(dimension); i++)
            {
                newIndices[^1] = i;
                array.ForEach(action, newIndices);
            }
        }

    }
}
