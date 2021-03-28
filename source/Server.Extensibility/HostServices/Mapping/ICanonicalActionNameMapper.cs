using System;
using System.Collections.Generic;
using Octopus.Data.Model;
using Octopus.Server.MessageContracts.Projects;

namespace Octopus.Server.Extensibility.HostServices.Mapping
{
    public interface ICanonicalActionNameMapper
    {
        List<string> GetNamesFromIds(ProjectId projectId, ReferenceCollection actionIds);

        /// <summary>
        ///     When action ids are embedded in an object (as opposed to a list of strings) then this method
        ///     allows the action id to be extracted, converted, and passed back as an action name while maintaining the context
        ///     of the source object.
        /// </summary>
        /// <typeparam name="T">The type that holds an action id to be converted to a action name</typeparam>
        /// <param name="projectId">The project id the action belongs to</param>
        /// <param name="source">The objects holding the action ids</param>
        /// <param name="actionIds">A function that returns the action id from the source</param>
        /// <param name="converter">A function that returns an object with action name</param>
        /// <returns>A list of objects with the action id converted to an action name</returns>
        List<T> GetNamesFromIds<T>(ProjectId projectId,
                                   IEnumerable<T> source,
                                   Func<T, string> actionIds,
                                   Func<T, string, T> converter);

        List<string> GetIdsFromReferences(ProjectId projectId, ReferenceCollection actionReferences);

        /// <summary>
        ///     When action names are embedded in an object (as opposed to a list of strings) then this method
        ///     allows the action name to be extracted, converted, and passed back as an action id while maintaining the context
        ///     of the source object.
        /// </summary>
        /// <typeparam name="T">The type that holds an action id to be converted to a action name</typeparam>
        /// <param name="projectId">The project id the action belongs to</param>
        /// <param name="source">The objects holding the action ids</param>
        /// <param name="actionReferences">A function that returns the action name from the source</param>
        /// <param name="converter">A function that returns an object with action id</param>
        /// <returns>A list of objects with the action name converted to an action id</returns>
        List<T> GetIdsFromReferences<T>(ProjectId projectId,
                                        IEnumerable<T> source,
                                        Func<T, string> actionReferences,
                                        Func<T, string, T> converter);
    }
}