using TestProject.Models;

namespace TestProject.Services.Staff
{
	public interface IStaffServices
	{
        MStaff? FindStaffAsync(StaffQuery query);

    }
}

