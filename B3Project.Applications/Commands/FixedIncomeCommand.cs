using B3Project.Domain;
using MediatR;

namespace B3Project.Applications.Commands
{
    public class FixedIncomeCommand : IRequest<Response>
    {
        public double InvestmentValue { get; set; }

        public int InvestmentRate { get; set; }
    }
}
