using CodeChallenge.Models;
using System;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation GetById(String employeeeId);
        Compensation Create(Compensation compensation);
    }
}
