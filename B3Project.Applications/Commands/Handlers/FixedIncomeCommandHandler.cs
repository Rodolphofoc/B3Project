using B3Project.Applications.Services;
using B3Project.Domain;
using MediatR;
using System.Net;


namespace B3Project.Applications.Commands.Handlers
{
    public class FixedIncomeCommandHandler : IRequestHandler<FixedIncomeCommand, Response>
    {

        private readonly IResponse _response;
        private readonly TaxServices _taxServices;

        public FixedIncomeCommandHandler(IResponse response, TaxServices taxServices)
        {
            _response = response;
            _taxServices = taxServices;
        }

        public async Task<Response> Handle(FixedIncomeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if (request.InvestmentValue <= 0)
                    return await _response.CreateErrorResponseAsync("Valor inicial fora do período", HttpStatusCode.BadRequest);

                var totalAmountWithoutTax = await CalculateValues(request.InvestmentValue, request.InvestmentRate);
                var total = await GetTaxValuesForUntilSixMonth(totalAmountWithoutTax, request.InvestmentRate);

                return await _response.CreateSuccessResponseAsync(total.ToString("N2"));

            }
            catch (Exception)
            {
                return await _response.CreateErrorResponseAsync(null, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Calculate the total amount of the investment    
        /// </summary>
        /// <param name="investmentValue"></param>
        /// <param name="investmentRate"></param>
        /// <returns></returns>
        public Task<double> CalculateValues(double investmentValue, int investmentRate)
        {
            var totalAmount = investmentValue;

            var cdi = Convert.ToDouble(_taxServices.Cdi.Value / 100);
            var tb = Convert.ToDouble(_taxServices.TB.Value / 100);

            for (int i = 1; i <= investmentRate; i++)
            {
                totalAmount *= (1 + cdi * tb);
            }

            return Task.FromResult(Math.Round(totalAmount, 2));
        }


        /// <summary>
        /// Calculate tax by period
        /// </summary>
        /// <param name="investmentValue"></param>
        /// <param name="investmentRate"></param>
        /// <returns></returns>
        private Task<double> GetTaxValuesForUntilSixMonth(double totalAmount, int investmentRate)
        {
            if (investmentRate <= 6)
                return Task.FromResult(totalAmount * (1 - (_taxServices.UntilSixMonth.Value/100)));

            if (investmentRate <= 12)
                return Task.FromResult(totalAmount * (1 - (_taxServices.UntilOneYear.Value / 100)));

            if (investmentRate <= 24)
                return Task.FromResult(totalAmount * (1 - (_taxServices.UntilTwoYear.Value / 100)));

            if (investmentRate > 24)
                return Task.FromResult(totalAmount * (1 - (_taxServices.MoreTwoYear.Value / 100)));  

            return Task.FromResult(totalAmount);
        }
    }
}
