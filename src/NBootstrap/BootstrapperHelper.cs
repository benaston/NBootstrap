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
	using System.Reflection;

	public class BootstrapperHelper
	{
		/// <summary>
		/// 	A default implementation for the retrieval of bootstrapper tasks. Returns all of the types implementing the IBootstrapperTask interface in the assembly of TBootstrapperTaskEnum in the order they are defined in TBootstrapperTaskEnum.
		/// </summary>
		/// <typeparam name="TBootstrapperTaskEnum"> Must be an enumeration. </typeparam>
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