using ApplicationProcessing.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationProcessing.API.Services
{
    public class AdminService : IAdminService
    {

        private readonly IHttpContextAccessor _contextAccessor;
        public Task<IActionResult> AddStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RenameStatus(int id, Status status)
        {
            throw new NotImplementedException();
        }
    }
}
