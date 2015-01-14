﻿// Author:					Joe Audette
// Created:					2014-08-18
// Last Modified:			2015-01-14
// 


using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace cloudscribe.Core.Models
{
    public interface IUserRepository : IDisposable
    {
        Task<bool> ConfirmRegistration(Guid registrationGuid);
        Task<bool> EmailExistsInDB(int siteId, int userId, string email);
        Task<bool> EmailExistsInDB(int siteId, string email);
        Task<ISiteUser> Fetch(int siteId, Guid userGuid);
        Task<ISiteUser> Fetch(int siteId, int userId);
        Task<ISiteUser> Fetch(int siteId, string email);
        Task<ISiteUser> FetchByConfirmationGuid(int siteId, Guid confirmGuid);
        Task<ISiteUser> FetchByLoginName(int siteId, string userName, bool allowEmailFallback);
        Task<ISiteUser> FetchNewest(int siteId);
        Task<bool> Delete(int userId);
        Task<bool> FlagAsDeleted(int userId);
        Task<bool> FlagAsNotDeleted(int userId);
        Task<bool> LockoutAccount(Guid userGuid);
        Task<bool> UnLockAccount(Guid userGuid);
        Task<bool> UpdateFailedPasswordAttemptCount(Guid userGuid, int failedPasswordAttemptCount);
        List<IUserInfo> GetByIPAddress(Guid siteGuid, string ipv4Address);
        List<IUserInfo> GetCrossSiteUserListByEmail(string email);
        int GetCount(int siteId);
        Task<int> GetNewestUserId(int siteId);
        List<IUserInfo> GetNotApprovedUsers(int siteId, int pageNumber, int pageSize, out int totalPages);
        List<IUserInfo> GetPage(int siteId, int pageNumber, int pageSize, string userNameBeginsWith, int sortMode, out int totalPages);
        List<IUserInfo> GetPageLockedUsers(int siteId, int pageNumber, int pageSize, out int totalPages);
        List<IUserInfo> GetUserAdminSearchPage(int siteId, int pageNumber, int pageSize, string searchInput, int sortMode, out int totalPages);
        DataTable GetUserListForPasswordFormatChange(int siteId);
        Task<string> GetUserNameFromEmail(int siteId, string email);
        List<IUserInfo> GetUserSearchPage(int siteId, int pageNumber, int pageSize, string searchInput, int sortMode, out int totalPages);
        bool LoginExistsInDB(int siteId, string loginName);
        bool LoginIsAvailable(int siteId, int userId, string loginName);
        Task<bool> Save(ISiteUser user);
        //bool UpdatePasswordAndSalt(int userId, int passwordFormat, string password, string passwordSalt);
        Task<bool> UpdateTotalRevenue();
        Task<bool> UpdateTotalRevenue(Guid userGuid);
        int UserCount(int siteId, string userNameBeginsWith);
        int UsersOnlineSinceCount(int siteId, DateTime sinceTime);

        //roles
        Task<bool> AddUserToRole(int roleId, Guid roleGuid, int userId, Guid userGuid);
        Task<bool> AddUserToDefaultRoles(ISiteUser siteUser);
        Task<int> CountOfRoles(int siteId, string searchInput);
        int GetRoleMemberCount(int roleId);
        Task<bool> DeleteRole(int roleID);
        Task<bool> DeleteUserRoles(int userId);
        Task<bool> DeleteUserRolesByRole(int roleId);
        Task<bool> RoleExists(int siteId, string roleName);
        Task<ISiteRole> FetchRole(int roleID);
        Task<ISiteRole> FetchRole(int siteId, string roleName);
        Task<IList<ISiteRole>> GetRolesBySite(
            int siteId, 
            string searchInput,
            int pageNumber,
            int pageSize);
        Task<List<string>> GetUserRoles(int siteId, int userId);
        Task<List<int>> GetRoleIds(int siteId, string roleNamesSeparatedBySemiColons);
        IList<ISiteRole> GetRolesUserIsNotIn(int siteId, int userId);
        Task<IList<IUserInfo>> GetUsersInRole(int siteId, int roleId, string searchInput, int pageNumber, int pageSize);
        Task<IList<IUserInfo>> GetUsersNotInRole(int siteId, int roleId, string searchInput, int pageNumber, int pageSize);
        Task<int> CountUsersInRole(int siteId, int roleId, string searchInput);
        Task<int> CountUsersNotInRole(int siteId, int roleId, string searchInput);
        Task<bool> RemoveUserFromRole(int roleId, int userId);
        Task<bool> SaveRole(ISiteRole role);

        //claims
        Task<bool> DeleteClaim(int id);
        Task<bool> DeleteClaimsBySite(Guid siteGuid);
        Task<bool> DeleteClaimsByUser(string userId);
        Task<bool> DeleteClaimByUser(string userId, string claimType);
        Task<IList<IUserClaim>> GetClaimsByUser(string userId);
        Task<bool> SaveClaim(IUserClaim userClaim);

        //logins
        Task<bool> CreateLogin(cloudscribe.Core.Models.IUserLogin userLogin);
        Task<bool> DeleteLogin(string loginProvider, string providerKey, string userId);
        Task<bool> DeleteLoginsBySite(Guid siteGuid);
        Task<bool> DeleteLoginsByUser(string userId);
        Task<IUserLogin> FindLogin(string loginProvider, string providerKey);
        Task<IList<IUserLogin>> GetLoginsByUser(string userId);
    }
}
