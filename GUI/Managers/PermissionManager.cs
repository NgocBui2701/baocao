using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baocao.GUI.Managers
{
    public static class PermissionManager
    {
        public static string CurrentUserRole { get; private set; }
        public static void SetRole(string role)
        {
            CurrentUserRole = role;
        }
        public static class Permissions
        {
            public const string ManagePermissions = "ManagePermissions";
            public const string ManageContracts = "ManageContracts";
            public const string ManageCustomers = "ManageCustomers";
            public const string ManageOrders = "ManageOrders";
            public const string ManageTSMT = "ManageTSMT";
            public const string ManageReports = "ManageReports";
            public const string ManageResults_HT = "ManageResults_HT";
            public const string ManageResults_PTN = "ManageResults_PTN";
        }
        private static readonly Dictionary<string, List<string>> _rolePermissions = new Dictionary<string, List<string>>
        {
            { "Phòng kinh doanh", new List<string>
                {
                    Permissions.ManageContracts,
                    Permissions.ManageCustomers
                } },
            { "Phòng kế hoạch", new List<string>
                {
                    Permissions.ManageOrders,
                    Permissions.ManageTSMT,
                    Permissions.ManageContracts, 
                    Permissions.ManageCustomers
                } },
            { "Phòng quan trắc", new List<string>
                {
                    Permissions.ManageResults_HT
                } },
            { "Phòng phân tích", new List<string>
                {
                    Permissions.ManageResults_PTN
                } },
            { "Phòng xuất kết quả", new List<string>
                {
                    Permissions.ManageReports
                } },
        };
        public static bool HasPermission(string permission)
        {
            if (string.IsNullOrEmpty(CurrentUserRole)) return false;
            if (CurrentUserRole == "Quản trị viên")
                return true;
            return _rolePermissions.ContainsKey(CurrentUserRole) &&
                   _rolePermissions[CurrentUserRole].Contains(permission);
        }
    }
}
