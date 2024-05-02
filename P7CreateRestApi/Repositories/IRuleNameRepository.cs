using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface IRuleNameRepository
    {
        public List<RuleName> List();
        public void Create(RuleName ruleName);
        public RuleName? Get(int id);
        public RuleName? Update(RuleName ruleName);
        public RuleName? Delete(int id);
    }
}
