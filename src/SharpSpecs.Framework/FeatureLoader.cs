using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SharpSpecs.Framework
{
    public class FeatureLoader : IFeatureLoader
    {
        /// <summary>
        /// Gets the features from a DLL.
        /// </summary>
        /// <param name="dllName">Name of the DLL.</param>
        /// <returns></returns>
        public IEnumerable<Feature> GetFeaturesFromDll(string dllName)
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += ReflectionOnlyAssemblyResolve;
            Assembly assembly = Assembly.LoadFrom(dllName);
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> featuresTypes = types.Where(x => x.GetCustomAttributes(typeof(FeatureAttribute), true).Count() > 0);
            return featuresTypes.Select(featureType => (Feature) Activator.CreateInstance(featureType)).ToList();
        }

        /// <summary>
        /// Resolves assemblies
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.ResolveEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private static Assembly ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
}
