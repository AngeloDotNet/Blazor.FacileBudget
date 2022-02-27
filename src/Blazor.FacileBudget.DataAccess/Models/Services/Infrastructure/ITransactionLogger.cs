using Blazor.FacileBudget.Models.InputModels;
using System.Threading.Tasks;

namespace Blazor.FacileBudget.DataAccess.Models.Services.Infrastructure
{
    public interface ITransactionLogger
    {
        Task LogTransactionAsync(SpeseCreateInputModel inputModel);
    }
}