using Dot.Net.WebApi.Controllers;
using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Data;

namespace P7CreateRestApi.Repositories
{
    public class RuleNameRepository : IRuleNameRepository
    {
        private readonly LocalDbContext _dbContext;
        public RuleNameRepository(LocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(RuleName ruleName)
        {
            _dbContext.Rules.Add(ruleName);
            _dbContext.SaveChanges();
        }

        public RuleName? Delete(int id)
        {
            var ruleName = _dbContext.Rules.FirstOrDefault(r => r.Id == id);
            if (ruleName is not null)
            {
                _dbContext.Rules.Remove(ruleName);
                _dbContext.SaveChanges();
            }
            return ruleName;
        }

        public RuleName? Get(int id) => _dbContext.Rules.FirstOrDefault(r => r.Id == id);

        public List<RuleName> List() => _dbContext.Rules.ToList();

        public RuleName? Update(RuleName ruleName)
        {
            var ruleNameAModifier = _dbContext.Rules.FirstOrDefault(r => r.Id == ruleName.Id);
            if (ruleNameAModifier is not null)
            {
                ruleNameAModifier.Name = ruleName.Name;
                ruleNameAModifier.Description = ruleName.Description;
                ruleNameAModifier.Json = ruleName.Json;
                ruleNameAModifier.Template = ruleName.Template;
                ruleNameAModifier.SqlStr = ruleName.SqlStr;
                ruleNameAModifier.SqlPart = ruleName.SqlPart;
                _dbContext.SaveChanges();
            }
            return ruleNameAModifier;
        }
    }
}
