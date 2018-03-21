using System;
using Moq;
using Xunit;

namespace Training.Data.Test
{
    public class IUnitOfWorkTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public IUnitOfWorkTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void Inherit_IDisposable()
        {
            Assert.IsAssignableFrom<IDisposable>(_mockUnitOfWork.Object);
        }
    }
}