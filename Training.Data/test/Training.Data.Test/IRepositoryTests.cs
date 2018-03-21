using System.Collections.Generic;
using Moq;
using Training.Data.Test.Fakes;
using Xunit;

namespace Training.Data.Test
{
    public class IRepositoryTests
    {
        private readonly Mock<IRepository<FakeEntity>> _mockRepository;

        public IRepositoryTests()
        {
            _mockRepository = new Mock<IRepository<FakeEntity>>(MockBehavior.Strict);
        }

        [Fact]
        public void Get_ById_ReturnEntity()
        {
            var entity = new FakeEntity();
            const int id = 1;
            entity.Id = id;

            _mockRepository.Setup(m => m.GetById(id)).Returns(entity);

            Assert.Equal(entity, _mockRepository.Object.GetById(id));
        }

        [Fact]
        public void GetEntities_ReturnListOfEntities()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.GetAll()).Returns(new List<FakeEntity> {entity});

            Assert.Contains(entity, _mockRepository.Object.GetAll());
        }

        [Fact]
        public void Insert_Entity_Success()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Insert(entity)).Returns(entity);

            Assert.Equal(entity, _mockRepository.Object.Insert(entity));
        }

        [Fact]
        public void Update_Entity_Success()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Update(entity)).Returns(entity);

            Assert.Equal(entity, _mockRepository.Object.Update(entity));
        }

        [Fact]
        public void Delete_ByEntity_Success()
        {
            var entity = new FakeEntity();

            _mockRepository.Setup(m => m.Delete(entity)).Verifiable();

            _mockRepository.Object.Delete(entity);

            _mockRepository.Verify();
        }
    }
}