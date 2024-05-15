namespace P7CreateRestApi.Tests
{
    public class BidListServiceTests
    {
        private readonly BidListService _bidListService;
        private readonly Mock<IBidListRepository> _bidListRepositoryMock = new();
        public BidListServiceTests()
        {
            _bidListService = new BidListService(_bidListRepositoryMock.Object);
        }

        [Fact]
        public void CreateBidList_ShouldHaveBidListOutputModel()
        {
            // Arrange
            _bidListRepositoryMock.Setup(m => m.Create(new BidList()));
            var inputModel = new BidListInputModel()
            {
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };

            // Act
            var outputModel = _bidListService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.Account, outputModel.Account);
            Assert.Equal(inputModel.Ask, outputModel.Ask);
            Assert.Equal(inputModel.AskQuantity, outputModel.AskQuantity);
            Assert.Equal(inputModel.Benchmark, outputModel.Benchmark);
            Assert.Equal(inputModel.Bid, outputModel.Bid);
            Assert.Equal(inputModel.BidListDate, outputModel.BidListDate);
            Assert.Equal(inputModel.BidQuantity, outputModel.BidQuantity);
            Assert.Equal(inputModel.BidSecurity, outputModel.BidSecurity);
            Assert.Equal(inputModel.BidStatus, outputModel.BidStatus);
            Assert.Equal(inputModel.BidType, outputModel.BidType);
            Assert.Equal(inputModel.Book, outputModel.Book);
            Assert.Equal(inputModel.Commentary, outputModel.Commentary);
            Assert.Equal(inputModel.CreationName, outputModel.CreationName);
            Assert.Equal(inputModel.DealName, outputModel.DealName);
            Assert.Equal(inputModel.DealType, outputModel.DealType);
            Assert.Equal(inputModel.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(inputModel.RevisionName, outputModel.RevisionName);
            Assert.Equal(inputModel.Side, outputModel.Side);
            Assert.Equal(inputModel.SourceListId, outputModel.SourceListId);
            Assert.Equal(inputModel.Trader, outputModel.Trader);
            _bidListRepositoryMock.Verify(repo => repo.Create(It.IsAny<BidList>()), Times.Once);
        }

        [Fact]
        public void DeleteBidList_ShouldHaveBidListOutputModel()
        {
            // Arrange
            var bidList = new BidList()
            {
                BidListId = 1,
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            _bidListRepositoryMock.Setup(m => m.Delete(1)).Returns(bidList);

            // Act
            var outputModel = _bidListService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            _bidListRepositoryMock.Verify(repo => repo.Delete(1), Times.Once);
        }

        [Fact]
        public void DeleteBidListDoesntExist_ShouldBeNull()
        {
            // Arrange
            _bidListRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _bidListService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _bidListRepositoryMock.Verify(repo => repo.Delete(1), Times.Once);
        }

        [Fact]
        public void GetBidList_ShouldHaveBidList()
        {
            // Arrange
            var bidListExcepted = new BidList()
            {
                BidListId = 1,
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            _bidListRepositoryMock.Setup(m => m.Get(1)).Returns(bidListExcepted);

            // Act
            var outputModel = _bidListService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(1, bidListExcepted.BidListId);
            _bidListRepositoryMock.Verify(repo => repo.Get(1), Times.Once);
        }

        [Fact]
        public void GetBidListDoesntExist_ShouldBeNull()
        {
            // Arrange
            _bidListRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _bidListService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _bidListRepositoryMock.Verify(repo => repo.Get(1), Times.Once);
        }

        [Fact]
        public void ListBidListWithOneBidList_ShouldHaveOneBidListInList()
        {
            // Arrange
            var bidListExcepted = new BidList()
            {
                BidListId = 1,
                Account = "Account",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            _bidListRepositoryMock.Setup(m => m.List()).Returns(new List<BidList> { bidListExcepted });

            // Act
            var list = _bidListService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            Assert.Equal(bidListExcepted.BidListId, list.First().BidListId);
            _bidListRepositoryMock.Verify(repo => repo.List(), Times.Once);
        }

        [Fact]
        public void ListBidListEmpty_ShouldHaveEmptyBidList()
        {
            // Arrange
            _bidListRepositoryMock.Setup(m => m.List()).Returns(new List<BidList>());

            // Act
            var list = _bidListService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            _bidListRepositoryMock.Verify(repo => repo.List(), Times.Once);
        }

        [Fact]
        public void BidListUpdate_ShouldHaveUpdateBidList()
        {
            // Arrange
            var bidListExpected = new BidList()
            {
                BidListId = 1,
                Account = "AccountUpdated",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = new DateTime(2024, 1, 1),
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            var inputModel = new BidListInputModel()
            {
                Account = "AccountUpdated",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = new DateTime(2024, 1, 1),
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = new DateTime(2024, 1, 1),
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            };
            _bidListRepositoryMock.Setup(repo => repo.Update(It.IsAny<BidList>())).Returns(bidListExpected);

            // Act
            var outputModel = _bidListService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(1, outputModel.BidListId);
            Assert.Equal(inputModel.Account, outputModel.Account);
            _bidListRepositoryMock.Verify(repo => repo.Update(It.IsAny<BidList>()), Times.Once);
        }

        [Fact]
        public void BidListUpdateDoesntExist_ShouldBeNull()
        {
            // Arrange
            _bidListRepositoryMock.Setup(repo => repo.Update(It.IsAny<BidList>()));

            // Act
            var outputModel = _bidListService.Update(1, new BidListInputModel()
            {
                Account = "AccountUpdated",
                Ask = 1,
                AskQuantity = 1,
                Benchmark = "Benchmark",
                Bid = 1,
                BidListDate = DateTime.Now,
                BidQuantity = 1,
                BidSecurity = "BidSecurity",
                BidStatus = "BidStatus",
                BidType = "BidType",
                Book = "Book",
                Commentary = "Commentary",
                CreationName = "CreationName",
                DealName = "DealName",
                DealType = "DealType",
                RevisionDate = DateTime.Now,
                RevisionName = "RevisionName",
                Side = "Side",
                SourceListId = "1",
                Trader = "Trader"
            });

            // Assert
            Assert.Null(outputModel);
            _bidListRepositoryMock.Verify(repo => repo.Update(It.IsAny<BidList>()), Times.Once);
        }
    }
}