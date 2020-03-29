using AmigoInvisible.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmigoInvisible.Logic
{
    public static class SecretSantaGenerator
    {
        public static IDictionary<T, T> Generate<T>(IList<T> participants)
        {
            //return Generate(participants, new Dictionary<T, T>());
            return Generate(participants, new List<KeyValuePair<T, T>>());
        }

        //public static IDictionary<T, T> Generate<T>(IList<T> participants, IDictionary<T, T> bannedPairings)
        public static IDictionary<T, T> Generate<T>(IList<T> participants, IEnumerable<KeyValuePair<T, T>> bannedPairings)
        {
            for (int iPos = 0; iPos < 10; iPos++)
            {
                var to = participants.GetShuffle();
                foreach (var from in participants.GetShuffle().GetPermutations())
                {
                    var result = to.ZipToKV(from);

                    if (PairingIsValid(bannedPairings, result))
                        return result.ToDictionary();
                }
            }
            throw new ApplicationException("No valid santa list can be generated");
        }

        //private static bool PairingIsValid<T>(IDictionary<T, T> bannedPairings, IEnumerable<KeyValuePair<T, T>> result)
        private static bool PairingIsValid<T>(IEnumerable<KeyValuePair<T, T>> bannedPairings, IEnumerable<KeyValuePair<T, T>> result)
        {
            var bannedPairingsEx = new List<KeyValuePair<T, T>>(bannedPairings);

            foreach (var itemResult in result)
            {
                //if (itemResult.Key.Equals(itemResult.Value) || bannedPairings.Contains(itemResult))
                //    return false;
                if (itemResult.Key.Equals(itemResult.Value))
                    return false;
                if (bannedPairingsEx.Contains(itemResult))
                    return false;
            }
            return true;
        }

        public static IEnumerable<IDictionary<T, T>> GenerateAll<T>(IList<T> participants)
        {
            return GenerateAll(participants, new Dictionary<T, T>());
        }

        //public static IEnumerable<IDictionary<T, T>> GenerateAll<T>(IList<T> participants, IDictionary<T, T> bannedPairings)
        public static IEnumerable<IDictionary<T, T>> GenerateAll<T>(IList<T> participants, IEnumerable<KeyValuePair<T, T>> bannedPairings)
        {
            var to = participants.GetShuffle();

            foreach (var from in participants.GetShuffle().GetPermutations())
            {
                var result = to.ZipToKV(from);

                if (PairingIsValid(bannedPairings, result))
                    yield return result.ToDictionary();
            }
        }
    }
}
