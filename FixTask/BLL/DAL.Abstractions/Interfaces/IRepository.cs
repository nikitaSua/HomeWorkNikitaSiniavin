using Core.Models;
using System.Collections.Generic;

namespace DAL.Abstractions.Interfaces
{
    public interface IRepository
    {
        List<User> LoadRecords();
    }
}