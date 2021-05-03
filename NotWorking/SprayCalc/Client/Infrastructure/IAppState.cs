using SprayCalc.Client.Models;
using System;
using System.Threading.Tasks;

namespace SprayCalc.Client.Infrastructure
{
    public interface IAppState
    {
        event Action OnChange;

        string AppName { get; set; }

        string AppShortName { get; set; }

        string AppVersion { get; }

        string BreadCrumbHome { get; set; }

        bool IsNavMinified { get; set; }

        bool IsNavOpen { get; set; }

        UserProfile UserProfile { get; }

        Task InitAsync(string caller);

        Task<UserProfile> InitializeUserProfileAsync();

        Task SaveLastVisitedUriAsync(string uri);

        Task UpdateUserProfileAsync();
    }
}