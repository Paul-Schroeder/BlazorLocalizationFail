using Blazored.LocalStorage;
using Humanizer;
using Microsoft.Extensions.Localization;
using SprayCalc.Client.Models;
using SprayCalc.Client.ResourceFiles;
using System;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace SprayCalc.Client.Infrastructure
{
    public class AppState : IAppState
    {
        private bool _isInitialized = false;
        private IStringLocalizer<Resource> _localizer;
        private ILocalStorageService _localStorage;
        private UserProfile _userProfile;

        public AppState(IStringLocalizer<Resource> localizer, ILocalStorageService localStorage)
        {
            _localizer = localizer;
            _localStorage = localStorage;
            AppName = _localizer["AppName"].ToString().Humanize(LetterCasing.Title);
            AppShortName = _localizer["AppShortName"].ToString().Humanize(LetterCasing.Title);
            BreadCrumbHome = _localizer["BreadCrumbHome"].ToString().ToUpper();
        }

        public event Action OnChange;

        public string AppName { get; set; } = string.Empty;

        public string AppShortName { get; set; } = string.Empty;

        public string AppVersion
        {
            get
            {
                string retVal = Assembly.GetExecutingAssembly().
                    GetCustomAttribute<AssemblyInformationalVersionAttribute>().
                    InformationalVersion;

                return retVal;
            }
        }

        public string BreadCrumbHome { get; set; } = string.Empty;

        public bool IsNavMinified
        {
            get
            {
                return UserProfile.IsNavMinified;
            }
            set
            {
                UserProfile.IsNavMinified = value;
            }
        }

        public bool IsNavOpen
        {
            get
            {
                return UserProfile.IsNavOpen;
            }
            set
            {
                UserProfile.IsNavOpen = value;
            }
        }

        public UserProfile UserProfile
        {
            get
            {
                //if (_userProfile == null)
                //{
                //    throw new ApplicationException($"You must call {nameof(InitializeUserProfileAsync)} before accessing the {nameof(UserProfile)} property.");
                //}

                return _userProfile;
            }
        }

        public async Task InitAsync(string caller)
        {
            Console.WriteLine($"AppState Initialized by {caller}.");

            if (!_isInitialized)
            {
                await InitializeUserProfileAsync();
                _isInitialized = true;
            }
        }

        public async Task<UserProfile> InitializeUserProfileAsync()
        {
            var _userProfile = new UserProfile();

            try
            {
                string userProfileJson = await _localStorage.GetItemAsync<string>("userProfile");
                if (!string.IsNullOrEmpty(userProfileJson))
                {
                    _userProfile = JsonSerializer.Deserialize<UserProfile>(userProfileJson);
                }
            }
            catch (Exception)
            {
                //TODO: Logging or exception handling.
            }

            return _userProfile;
        }

        public async Task SaveLastVisitedUriAsync(string uri)
        {
            UserProfile.LastPageVisited = uri;
            await UpdateUserProfileAsync();
            NotifyStateChanged();
        }

        public async Task UpdateUserProfileAsync()
        {
            string userProfileJson = JsonSerializer.Serialize(UserProfile);
            await _localStorage.SetItemAsync<string>("userProfile", userProfileJson);
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}