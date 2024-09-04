using B3Project.Applications.Commands;
using B3Project.Applications.Commands.Handlers;
using B3Project.Applications.Services;
using B3Project.Domain;
using MediatR;
using Moq;
using System.Net;

namespace B3Project.ApplicationsTest
{
    public class FixedIncomeCommandHandlerTest
    {


        public FixedIncomeCommandHandlerTest()
        {
        }


        /// <summary>
        /// Return error when investment value is less than 0
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Return_Error_When_Investment_Less_Than_0()
        {
            var request = new FixedIncomeCommand()
            {
                InvestmentValue = -1,
                InvestmentRate = 6
            };

            var mediator = new Mock<IMediator>();
            var response = new Mock<IResponse>();
            var taxService = TaxServiceFactory();


            response.Setup(x => x.CreateErrorResponseAsync(It.IsAny<string>(), It.IsAny<HttpStatusCode>()))
                .ReturnsAsync(new Response());

            var handler = new FixedIncomeCommandHandler(new Response(), taxService);

            var result = await handler.Handle(request, new CancellationToken());
            
        }



        [Fact]
        public async Task Should_Return_Correct_Value_For_Until_6_Month()
        {
            var request = new FixedIncomeCommand()
            {
                InvestmentValue = 100,
                InvestmentRate = 5
            };

            var mediator = new Mock<IMediator>();
            var response = new Mock<IResponse>();
            var taxService = TaxServiceFactory();


            response.Setup(x => x.CreateSuccessResponseAsync(It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(new Response());

            var handler = new FixedIncomeCommandHandler(new Response(), taxService);

            var result = await handler.Handle(request, new CancellationToken());

            Assert.Equal("81,34", result?.Data?.ToString());

        }


        [Fact]
        public async Task Should_Return_Correct_Value_For_Until_12_Month()
        {
            var request = new FixedIncomeCommand()
            {
                InvestmentValue = 100,
                InvestmentRate = 8
            };

            var mediator = new Mock<IMediator>();
            var response = new Mock<IResponse>();
            var taxService =  TaxServiceFactory();


            response.Setup(x => x.CreateSuccessResponseAsync(It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(new Response());

            var handler = new FixedIncomeCommandHandler(new Response(), taxService);

            var result = await handler.Handle(request, new CancellationToken());

            Assert.Equal("86,44", result?.Data?.ToString());

        }


        [Fact]
        public async Task Should_Return_Correct_Value_For_Until_24_Month()
        {
            var request = new FixedIncomeCommand()
            {
                InvestmentValue = 100,
                InvestmentRate = 17
            };

            var mediator = new Mock<IMediator>();
            var response = new Mock<IResponse>();
            var taxService =  TaxServiceFactory();


            response.Setup(x => x.CreateSuccessResponseAsync(It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(new Response());

            var handler = new FixedIncomeCommandHandler(new Response(), taxService);

            var result = await handler.Handle(request, new CancellationToken());

            Assert.Equal("97,24", result?.Data?.ToString());

        }



        [Fact]
        public async Task Should_Return_Correct_Value_For_More_24_Months()
        {
            var request = new FixedIncomeCommand()
            {
                InvestmentValue = 100,
                InvestmentRate = 32
            };

            var mediator = new Mock<IMediator>();
            var response = new Mock<IResponse>();
            var taxService = TaxServiceFactory();


            response.Setup(x => x.CreateSuccessResponseAsync(It.IsAny<object>(), It.IsAny<string>()))
                .ReturnsAsync(new Response());

            var handler = new FixedIncomeCommandHandler(new Response(), taxService);

            var result = await handler.Handle(request, new CancellationToken());

            Assert.Equal("115,84", result?.Data?.ToString());

        }



        private static TaxServices TaxServiceFactory()
        {
            return new TaxServices()
            {
                 Cdi = 0.9,
                 TB = 108,
                 UntilSixMonth = 22.5,
                 MoreTwoYear = 15,
                 UntilOneYear = 20,
                 UntilTwoYear = 17.5
            };
        }
    }
}