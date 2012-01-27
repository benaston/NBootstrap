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

namespace NBootstrap.Test.Fast
{
	using System;
	using Moq;
	using NServiceLocator;
	using NUnit.Framework;

	[TestFixture]
	public class BootstrapperTests
	{
		[Test]
		public void Run_WhenFollowingTheHappyPath_InvokesTheExecuteMethodOfAllTheIBootstrapperTasks()
		{
			var serviceLocator = new Mock<IServiceLocator<IContext>>();
			var task1 = new Mock<IBootstrapperTask>();
			var task2 = new Mock<IBootstrapperTask>();

			serviceLocator.Setup(s => s.LocateAllImplementorsOf<IBootstrapperTask>()).Returns(new[]
			                                                                                  	{
			                                                                                  		task1.Object,
			                                                                                  		task2.Object,
			                                                                                  	});

			Bootstrapper.Run(serviceLocator.Object, () => new Type[0]);

			task1.Verify(t => t.Execute());
			task2.Verify(t => t.Execute());
		}

		[Test]
		public void Run_WhenSuppliedWithGenericBootstrapTask_DoesNotThrowAnException()
		{
			var serviceLocator = new Mock<IServiceLocator<IContext>>();
			var task1 = new Mock<IBootstrapperTask>();
			var task2 = new Mock<IBootstrapperTask>();

			serviceLocator.Setup(s => s.LocateAllImplementorsOf<IBootstrapperTask>()).Returns(new[]
			                                                                                  	{
			                                                                                  		task1.Object,
			                                                                                  		task2.Object,
			                                                                                  	});

			Assert.DoesNotThrow(() => Bootstrapper.Run(serviceLocator.Object, () => new[] {typeof (Task1<>)}));
		}
	}

	public enum TestBootstrapperTask
	{
		Task1,
		Task2,
	}

	public class Task1<T> : IBootstrapperTask
	{
		public void Execute()
		{
			throw new NotImplementedException();
		}
	}

	public interface IContext {}
}