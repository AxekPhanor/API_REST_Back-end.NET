namespace P7CreateRestApi.Tests
{
    public class CurvePointServiceTests
    {
        private readonly CurvePointService _curvePointService;
        private readonly Mock<ICurvePointRepository> _curvePointRepositoryMock = new();

        public CurvePointServiceTests()
        {
            _curvePointService = new CurvePointService(_curvePointRepositoryMock.Object);
        }

        [Fact]
        public void CreateCurvePoint_ShouldHaveCurvePointOutputModel()
        {
            // Arrange
            var inputModel = new CurvePointInputModel
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                Term = 1.1,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Create(It.IsAny<CurvePoint>()));

            // Act
            var outputModel = _curvePointService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.CurveId, outputModel.CurveId);
            Assert.Equal(inputModel.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(inputModel.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Create(It.IsAny<CurvePoint>()), Times.Once);
        }

        [Fact]
        public void DeleteCurvePoint_ShouldHaveCurvePointOutputModel()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Delete(1)).Returns(curvePointExcepted);

            // Act
            var outputModel = _curvePointService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(curvePointExcepted.CurveId, outputModel.CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }

        [Fact]
        public void DeleteCurvePointDoesntExist_ShouldBeNull()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _curvePointService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _curvePointRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }

        [Fact]
        public void GetCurvePoint_ShouldHaveCurvePointOutputModel()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Get(1)).Returns(curvePointExcepted);

            // Act
            var outputModel = _curvePointService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(curvePointExcepted.CurveId, outputModel.CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }

        [Fact]
        public void GetCurvePointDoesntExist_ShouldBeNull()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _curvePointService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _curvePointRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }

        [Fact]
        public void ListCurvePointWithOneCurvePoint_ShouldHaveOneCurvePointInList()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.List()).Returns(new List<CurvePoint> { curvePointExcepted });

            // Act
            var list = _curvePointService.List();

            // Assert
            Assert.NotEmpty(list);
            Assert.Single(list);
            Assert.Equal(curvePointExcepted.CurveId, list[0].CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, list[0].AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, list[0].CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.List(), Times.Once);
        }

        [Fact]
        public void ListCurvePointEmpty_ShouldHaveListEmpty()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.List()).Returns(new List<CurvePoint>());

            // Act
            var list = _curvePointService.List();

            // Assert
            Assert.Empty(list);
            _curvePointRepositoryMock.Verify(m => m.List(), Times.Once);
        }

        [Fact]
        public void UpdateCurvePoint_ShouldHaveUpdateCurvePoint()
        {
            // Arrange
            var curvePointExcepted = new CurvePoint()
            {
                CurveId = 1,
                AsOfDate = new DateTime(2024, 1, 1),
                Term = 1.1,
                CurvePointValue = 1.1
            };
            var inputModel = new CurvePointInputModel()
            {
                CurveId = 1,
                AsOfDate = new DateTime(2024, 1, 1),
                CurvePointValue = 1.1
            };
            _curvePointRepositoryMock.Setup(m => m.Update(It.IsAny<CurvePoint>())).Returns(curvePointExcepted);

            // Act
            var outputModel = _curvePointService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(curvePointExcepted.CurveId, outputModel.CurveId);
            Assert.Equal(curvePointExcepted.AsOfDate, outputModel.AsOfDate);
            Assert.Equal(curvePointExcepted.CurvePointValue, outputModel.CurvePointValue);
            _curvePointRepositoryMock.Verify(m => m.Update(It.IsAny<CurvePoint>()), Times.Once);
        }

        [Fact]
        public void UpdateCurvePointDoesntExist_ShouldBeNull()
        {
            // Arrange
            _curvePointRepositoryMock.Setup(m => m.Update(It.IsAny<CurvePoint>()));

            // Act
            var outputModel = _curvePointService.Update(1, new CurvePointInputModel
            {
                CurveId = 1,
                AsOfDate = DateTime.Now,
                Term = 1.1,
                CurvePointValue = 1.1
            });

            // Assert
            Assert.Null(outputModel);
            _curvePointRepositoryMock.Verify(m => m.Update(It.IsAny<CurvePoint>()), Times.Once);
        }
    }
}
