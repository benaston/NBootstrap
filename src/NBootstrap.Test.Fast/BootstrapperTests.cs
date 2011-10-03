namespace NBootstrap.Test.Fast
{
    using System;
    using Moq;
    using NServiceLocator;
    using NUnit.Framework;

    /// <summary>
    ///   WIP. TODO: BA; test for ordering.
    /// </summary>
    [TestFixture]
    public class BootstrapperTests
    {
        [Test]
        public void Run_WhenFollowingTheHappyPath_InvokesTheExecuteMethodOfAllTheIBootstrapperTasks()
        {
            var serviceLocator = new Mock<IServiceLocator>();
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
    }

    public enum TestBootstrapperTask
    {
        Task1,
        Task2,
    }
}