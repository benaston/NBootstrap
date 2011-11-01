namespace NBootstrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NServiceLocator;

    /// <summary>
    ///   A simple bootstrapper that grabs a bunch of tasks types binds 
    ///   them to the service locator and then subsequently retrieves them
    ///   and invokes their Execute method. Simples.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        ///   Adding the tasks to the service locator first enables 
        ///   automatic resolution of their constructor parameters.
        /// </summary>
        public static void Run<TActivationContext>(IServiceLocator<TActivationContext> serviceLocator, Func<IEnumerable<Type>> taskRetrievalFunction)
        {
            var taskTypes = taskRetrievalFunction();
            var taskTypesList = taskTypes.ToList();

            foreach (var bootstrapperTaskType in taskTypesList)
            {
                serviceLocator.BindToInterface(bootstrapperTaskType, typeof (IBootstrapperTask));
            }

            var i = serviceLocator.LocateAllImplementorsOf<IBootstrapperTask>().ToList();
            foreach (var task in i)
            {
                task.Execute();
            }
        }
    }
}