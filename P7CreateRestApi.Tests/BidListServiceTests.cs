namespace P7CreateRestApi.Tests
{
    public class BidListServiceTests
    {
        private readonly BidListService _bidListService;
        private readonly Mock<IBidListRepository> mock = new();
        public BidListServiceTests()
        {
            _bidListService = new BidListService(mock.Object);
        }

        [Fact]
        public void CreateBidList_ShouldHaveBidListOutputModel()
        {
            // Arrange
            mock.As<IBidListRepository>().Setup(m => m.Create(new BidList()));
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
        }
    }
}