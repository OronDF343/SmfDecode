using System;
using SmfDecode.Chunks;

namespace SmfDecode
{
    /// <summary>
    /// Misc. utilities.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Calculates the length of a <see cref="TrackEventCollection"/>, in bytes.
        /// </summary>
        /// <param name="events">The <see cref="TrackEventCollection"/>.</param>
        /// <returns>The length of <paramref name="events"/>, in bytes.</returns>
        public static uint Length(TrackEventCollection events)
        {
            throw new NotImplementedException();
        }
    }
}