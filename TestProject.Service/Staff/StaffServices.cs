using TestProject.Context;
using TestProject.Models;

namespace TestProject.Services.Staff
{
	public class StaffServices : IStaffServices
	{
		private readonly AppDBContext _db;

		public StaffServices(AppDBContext db)
		{
			_db = db;
		}

		public MStaff? FindStaffAsync(StaffQuery query)
		{
			try
			{
				var _rtn = _db.MStaff.FirstOrDefault(ms => ms.USERNAME == query.username && ms.USERPW == query.userpassword);

				return _rtn;
				
			}
			catch (Exception ex)
			{
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
		}
	}
}

