using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Repository;

public class LoanRepository : IRepository<Loan>
{
    public Task<IEnumerable<Loan>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Loan> GetOneAsync(Loan entity)
    {
        throw new NotImplementedException();
    }

    public Task<Loan> CreateAsync(Loan entity)
    {
        throw new NotImplementedException();
    }

    public Task<Loan> UpdateAsync(Loan entity)
    {
        throw new NotImplementedException();
    }

    public Task<Loan> DeleteAsync(Loan entity)
    {
        throw new NotImplementedException();
    }
}