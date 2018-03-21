using Moq;
using Xunit;

namespace Training.Data.Test
{
    public class IEntityTests
    {
        private readonly Mock<IEntity> _mockEntity;

        public IEntityTests()
        {
            _mockEntity = new Mock<IEntity>(MockBehavior.Strict);
        }

        [Fact]
        public void Id_Get_Success()
        {
            const int id = 1;

            _mockEntity.SetupGet(m => m.Id).Returns(id);

            Assert.Equal(id, _mockEntity.Object.Id);
        }

        [Fact]
        public void Id_Set_Success()
        {
            var result = 0;

            const int id = 1;

            _mockEntity.SetupSet(m=>m.Id = It.IsAny<int>()).Callback((int value) => { result = value; });

            _mockEntity.Object.Id = id;

            Assert.Equal(id, result);
        }
    }
}