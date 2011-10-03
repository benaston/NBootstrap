namespace NBootstrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class BootstrapperHelper
    {
        /// <summary>
        ///   A default implementation for the retrieval of bootstrapper tasks.
        ///   Returns all of the types implementing the IBootstrapperTask interface in the
        ///   assembly of TBootstrapperTaskEnum in the order they are defined in 
        ///   TBootstrapperTaskEnum.
        /// </summary>
        /// <typeparam name = "TBootstrapperTaskEnum">Must be an enumeration.</typeparam>
        public static IEnumerable<Type> DefaultTaskRetrievalFunction<TBootstrapperTaskEnum>()
        {
            try
            {
                var tasks = Assembly.GetAssembly(typeof (TBootstrapperTaskEnum)).GetTypes()
                    .Where(type => typeof (IBootstrapperTask).IsAssignableFrom(type))
                    .OrderBy(t => (int) (Enum.Parse(typeof (TBootstrapperTaskEnum),
                                                    t.Name.Replace(NBootstrapConventions.BootstrapperTaskSuffix,
                                                                   String.Empty).Split('`')[0])));
                //the split is to remove the ` character used when generics are used

                if (tasks.Count() == 0)
                {
                    throw new BootstrapperException("No bootstrapper tasks found.");
                }

                return tasks;
            }
            catch (Exception e)
            {
                throw new BootstrapperException(innerException: e);
            }
        }
    }
}