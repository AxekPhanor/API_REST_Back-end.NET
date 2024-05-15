﻿namespace P7CreateRestApi.Tests
{
    public class TradeServiceTests
    {
        private readonly TradeService _tradeService;
        private readonly Mock<ITradeRepository> _tradeRepositoryMock = new();

        public TradeServiceTests()
        {
            _tradeService = new TradeService(_tradeRepositoryMock.Object);
        }

        [Fact]  
        public void CreateTrade_ShouldHaveTradeOutputModel()
        {
            // Arrange
            var inputModel = new TradeInputModel
            {
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Create(It.IsAny<Trade>()));

            // Act
            var outputModel = _tradeService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.Account, outputModel.Account);
            Assert.Equal(inputModel.AccountType, outputModel.AccountType);
            Assert.Equal(inputModel.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(inputModel.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(inputModel.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(inputModel.SellPrice, outputModel.SellPrice);
            Assert.Equal(inputModel.Benchmark, outputModel.Benchmark);
            Assert.Equal(inputModel.TradeDate, outputModel.TradeDate);
            Assert.Equal(inputModel.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(inputModel.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(inputModel.Trader, outputModel.Trader);
            Assert.Equal(inputModel.Book, outputModel.Book);
            Assert.Equal(inputModel.CreationName, outputModel.CreationName);
            Assert.Equal(inputModel.RevisionName, outputModel.RevisionName);
            Assert.Equal(inputModel.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(inputModel.DealName, outputModel.DealName);
            Assert.Equal(inputModel.DealType, outputModel.DealType);
            Assert.Equal(inputModel.SourceListId, outputModel.SourceListId);
            Assert.Equal(inputModel.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Create(It.IsAny<Trade>()), Times.Once);
        }

        [Fact]
        public void DeleteTrade_ShouldHaveTradeOutputModel()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Delete(1)).Returns(tradeExcepted);

            // Act
            var outputModel = _tradeService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(tradeExcepted.Account, outputModel.Account);
            Assert.Equal(tradeExcepted.AccountType, outputModel.AccountType);
            Assert.Equal(tradeExcepted.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(tradeExcepted.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(tradeExcepted.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(tradeExcepted.SellPrice, outputModel.SellPrice);
            Assert.Equal(tradeExcepted.Benchmark, outputModel.Benchmark);
            Assert.Equal(tradeExcepted.TradeDate, outputModel.TradeDate);
            Assert.Equal(tradeExcepted.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(tradeExcepted.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(tradeExcepted.Trader, outputModel.Trader);
            Assert.Equal(tradeExcepted.Book, outputModel.Book);
            Assert.Equal(tradeExcepted.CreationName, outputModel.CreationName);
            Assert.Equal(tradeExcepted.RevisionName, outputModel.RevisionName);
            Assert.Equal(tradeExcepted.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(tradeExcepted.DealName, outputModel.DealName);
            Assert.Equal(tradeExcepted.DealType, outputModel.DealType);
            Assert.Equal(tradeExcepted.SourceListId, outputModel.SourceListId);
            Assert.Equal(tradeExcepted.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }

        [Fact]
        public void DeleteTradeDoesntExist_ShouldBeNull()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _tradeService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _tradeRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }

        [Fact]
        public void GetTrade_ShouldHaveTradeOutputModel()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Get(1)).Returns(tradeExcepted);

            // Act
            var outputModel = _tradeService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(tradeExcepted.TradeId, outputModel.TradeId);
            _tradeRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }

        [Fact]
        public void GetTradeDoesntExist_ShouldBeNull()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _tradeService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _tradeRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }

        [Fact]
        public void ListTradeWithOneTrade_ShouldHaveOneTradeInList()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.List()).Returns(new List<Trade> { tradeExcepted });

            // Act
            var list = _tradeService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            _tradeRepositoryMock.Verify(m => m.List(), Times.Once);
        }

        [Fact]
        public void ListTradeEmpty_ShouldHaveNoTradeInList()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.List()).Returns(new List<Trade>());

            // Act
            var list = _tradeService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Empty(list);
            _tradeRepositoryMock.Verify(m => m.List(), Times.Once);
        }

        [Fact]
        public void UpdateTrade_ShouldHaveTradeOutputModel()
        {
            // Arrange
            var tradeExcepted = new Trade()
            {
                TradeId = 1,
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            var inputModel = new TradeInputModel
            {
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            };
            _tradeRepositoryMock.Setup(m => m.Update(It.IsAny<Trade>())).Returns(tradeExcepted);

            // Act
            var outputModel = _tradeService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.Account, outputModel.Account);
            Assert.Equal(inputModel.AccountType, outputModel.AccountType);
            Assert.Equal(inputModel.BuyQuantity, outputModel.BuyQuantity);
            Assert.Equal(inputModel.SellQuantity, outputModel.SellQuantity);
            Assert.Equal(inputModel.BuyPrice, outputModel.BuyPrice);
            Assert.Equal(inputModel.SellPrice, outputModel.SellPrice);
            Assert.Equal(inputModel.Benchmark, outputModel.Benchmark);
            Assert.Equal(inputModel.TradeDate, outputModel.TradeDate);
            Assert.Equal(inputModel.TradeSecurity, outputModel.TradeSecurity);
            Assert.Equal(inputModel.TradeStatus, outputModel.TradeStatus);
            Assert.Equal(inputModel.Trader, outputModel.Trader);
            Assert.Equal(inputModel.Book, outputModel.Book);
            Assert.Equal(inputModel.CreationName, outputModel.CreationName);
            Assert.Equal(inputModel.RevisionName, outputModel.RevisionName);
            Assert.Equal(inputModel.RevisionDate, outputModel.RevisionDate);
            Assert.Equal(inputModel.DealName, outputModel.DealName);
            Assert.Equal(inputModel.DealType, outputModel.DealType);
            Assert.Equal(inputModel.SourceListId, outputModel.SourceListId);
            Assert.Equal(inputModel.Side, outputModel.Side);
            _tradeRepositoryMock.Verify(m => m.Update(It.IsAny<Trade>()), Times.Once);
        }

        [Fact]
        public void UpdateTradeDoesntExist_ShouldBeNull()
        {
            // Arrange
            _tradeRepositoryMock.Setup(m => m.Update(It.IsAny<Trade>()));

            // Act
            var outputModel = _tradeService.Update(1, new TradeInputModel
            {
                Account = "Account",
                AccountType = "Type",
                BuyQuantity = 1,
                SellQuantity = 1,
                BuyPrice = 1.1,
                SellPrice = 1.1,
                Benchmark = "Benchmark",
                TradeDate = new DateTime(2024, 1, 1),
                TradeSecurity = "Security",
                TradeStatus = "Status",
                Trader = "Trader",
                Book = "Book",
                CreationName = "CreationName",
                RevisionName = "RevisionName",
                RevisionDate = new DateTime(2024, 1, 1),
                DealName = "DealName",
                DealType = "DealType",
                SourceListId = "SourceListId",
                Side = "Side"
            });

            // Assert
            Assert.Null(outputModel);
            _tradeRepositoryMock.Verify(m => m.Update(It.IsAny<Trade>()), Times.Once);
        }
    }
}
