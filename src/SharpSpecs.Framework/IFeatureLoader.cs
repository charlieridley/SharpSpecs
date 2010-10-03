using System.Collections.Generic;

namespace SharpSpecs.Framework
{
    public interface IFeatureLoader
    {
        /// <summary>
        /// Gets the features from a DLL.
        /// </summary>
        /// <param name="dllName">Name of the DLL.</param>
        /// <returns></returns>
        IEnumerable<Feature> GetFeaturesFromDll(string dllName);
    }
}