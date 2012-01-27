// Copyright 2011, Ben Aston (ben@bj.ma).
// 
// This file is part of NBootstrap.
// 
// NBootstrap is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NBootstrap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NBootstrap.  If not, see <http://www.gnu.org/licenses/>.

namespace NBootstrap
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using NServiceLocator;

	/// <summary>
	/// 	A simple bootstrapper that grabs a bunch of tasks types binds them to the service locator and then subsequently retrieves them and invokes their Execute method. Simples.
	/// </summary>
	public class Bootstrapper
	{
		/// <summary>
		/// 	Adding the tasks to the service locator first enables automatic resolution of their constructor parameters.
		/// </summary>
		public static void Run<TActivationContext>(IServiceLocator<TActivationContext> serviceLocator,
		                                           Func<IEnumerable<Type>> taskRetrievalFunction)
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