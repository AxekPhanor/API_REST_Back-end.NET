﻿namespace P7CreateRestApi.Tests
{
    public class RatingServiceTests
    {
        private readonly RatingService _ratingService;
        private readonly Mock<IRatingRepository> _ratingRepositoryMock = new();
        public RatingServiceTests()
        {
            _ratingService = new RatingService(_ratingRepositoryMock.Object);
        }

        [Fact]
        public void CreateRating_ShouldHaveRatingOutputModel()
        {
            // Arrange
            var inputModel = new RatingInputModel
            {
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Create(new Rating()));

            // Act
            var outputModel = _ratingService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(inputModel.SandPRating, outputModel.SandPRating);
            Assert.Equal(inputModel.FitchRating, outputModel.FitchRating);
            Assert.Equal(inputModel.OrderNumber, outputModel.OrderNumber);
            _ratingRepositoryMock.Verify(m => m.Create(It.IsAny<Rating>()), Times.Once);
        }

        [Fact]
        public void DeleteRating_ShouldHaveRatingOutputModel()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Delete(1)).Returns(ratingExcepted);

            // Act
            var outputModel = _ratingService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ratingExcepted.Id, outputModel.Id);
            Assert.Equal(ratingExcepted.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(ratingExcepted.SandPRating, outputModel.SandPRating);
            Assert.Equal(ratingExcepted.FitchRating, outputModel.FitchRating);
            Assert.Equal(ratingExcepted.OrderNumber, outputModel.OrderNumber);
            _ratingRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }

        [Fact]
        public void DeleteRatingDoesntExist_ShouldBeNull()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _ratingService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _ratingRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }

        [Fact]
        public void GetRating_ShouldHaveRatingOutputModel()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Get(1)).Returns(ratingExcepted);

            // Act
            var outputModel = _ratingService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ratingExcepted.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(ratingExcepted.SandPRating, outputModel.SandPRating);
            Assert.Equal(ratingExcepted.FitchRating, outputModel.FitchRating);
            Assert.Equal(ratingExcepted.OrderNumber, outputModel.OrderNumber);
        }

        [Fact]
        public void GetRatingDoesntExist_ShouldBeNull()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _ratingService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _ratingRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }

        [Fact]
        public void UpdateRating_ShouldHaveUpdateRating()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            var inputModel = new RatingInputModel()
            {
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.Update(It.IsAny<Rating>())).Returns(ratingExcepted);

            // Act
            var outputModel = _ratingService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(1, outputModel.Id);
            Assert.Equal(inputModel.MoodysRating, outputModel.MoodysRating);
            Assert.Equal(inputModel.SandPRating, outputModel.SandPRating);
            Assert.Equal(inputModel.FitchRating, outputModel.FitchRating);
            Assert.Equal(inputModel.OrderNumber, outputModel.OrderNumber);
            _ratingRepositoryMock.Verify(m => m.Update(It.IsAny<Rating>()), Times.Once);
        }

        [Fact]
        public void UpdateRatingDoesntExist_ShouldBeNull()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.Update(It.IsAny<Rating>()));

            // Act
            var outputModel = _ratingService.Update(1, new RatingInputModel()
            {
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            });

            // Assert
            Assert.Null(outputModel);
            _ratingRepositoryMock.Verify(m => m.Update(It.IsAny<Rating>()), Times.Once);
        }

        [Fact]
        public void ListRatingWithOneRating_ShouldHaveOneRatingInList()
        {
            // Arrange
            var ratingExcepted = new Rating()
            {
                Id = 1,
                MoodysRating = "A1",
                SandPRating = "A+",
                FitchRating = "A+",
                OrderNumber = 1
            };
            _ratingRepositoryMock.Setup(m => m.List()).Returns(new List<Rating> { ratingExcepted });

            // Act
            var list = _ratingService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            _ratingRepositoryMock.Verify(m => m.List(), Times.Once);
        }

        [Fact]
        public void ListBidListEmpty_ShouldHaveEmptyBidList()
        {
            // Arrange
            _ratingRepositoryMock.Setup(m => m.List()).Returns(new List<Rating>());

            // Act
            var list = _ratingService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            _ratingRepositoryMock.Verify(repo => repo.List(), Times.Once);
        }
    }
}
