﻿using Medicoz.Application.Models.Identity;

namespace Medicoz.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetEmployeesAsync();
        Task<User> GetEmployeeAsync(string userId);
        public string UserId { get; }
        Task<User> GetCurrentUserAsync();
    }
}