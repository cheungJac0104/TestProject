using System;
namespace TestProject.Policies
{
	public static class PoliciesEnum
	{
        public enum PolicyEnum
        {
            ClientPolicy,
            AdminPolicy,
            StaffPolicy,

            ClientPolicyRequire,
            AdminPolicyRequire,
            StaffPolicyRequire,
        }

        public static readonly Dictionary<PolicyEnum, string> PoliciesDict
            = new Dictionary<PolicyEnum, string>()
            {
                [PolicyEnum.ClientPolicy] = "ClientPolicy",
                [PolicyEnum.StaffPolicy] = "StaffPolicy",
                [PolicyEnum.AdminPolicy] = "AdminPolicy",

                [PolicyEnum.ClientPolicyRequire] = "Client",
                [PolicyEnum.StaffPolicyRequire] = "Staff",
                [PolicyEnum.AdminPolicyRequire] = "Admin",
            };

        public static string Val(this PolicyEnum policyEnum)
            => PoliciesDict[policyEnum];

    }
	
}

