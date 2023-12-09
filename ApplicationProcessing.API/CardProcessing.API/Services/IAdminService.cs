using ApplicationProcessing.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationProcessing.API.Services
{
    public interface IAdminService
    {
        public Task<IActionResult> AddStatus(Status status);
        public Task<IActionResult> RenameStatus(int id, Status status);
    }
}
