using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Runtime.Session;

namespace Niue.Core.Entities.Agents
{
    public class AgentManager : IAgentManager
    {
        public IAbpSession AbpSession { get; set; }
        private readonly IRepository<Agent, int> _agentRepository;

        public AgentManager(IRepository<Agent, int> agentRepository)
        {
            AbpSession = NullAbpSession.Instance;
            _agentRepository = agentRepository;
        }

        public async Task<List<Agent>> FindAsync(Expression<Func<Agent, bool>> expression)
        {
            var agents = await _agentRepository.GetAllListAsync();
            return agents.Where(expression.Compile()).OrderBy(o => o.UserId).ToList();
        }

        public async Task<Agent> FindByIdAsync(int id)
        {
            return await _agentRepository.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Agent> InsertAsync(Agent agent)
        {
            return await _agentRepository.InsertAsync(agent);
        }

        public async Task<Agent> UpdateAsync(Agent agent)
        {
            return await _agentRepository.UpdateAsync(agent);
        }

        public async Task<bool> DeleteAsync(Agent agent)
        {
            await _agentRepository.DeleteAsync(agent);
            return true;
        }
    }
}
