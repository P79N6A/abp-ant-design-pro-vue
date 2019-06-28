using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;

namespace Niue.Core.Entities.Agents
{
    public interface IAgentManager : IDomainService
    {
        Task<List<Agent>> FindAsync(Expression<Func<Agent, bool>> expression);
        Task<Agent> FindByIdAsync(int id);
        Task<Agent> InsertAsync(Agent agent);
        Task<Agent> UpdateAsync(Agent agent);
        Task<bool> DeleteAsync(Agent agent);
    }
}
