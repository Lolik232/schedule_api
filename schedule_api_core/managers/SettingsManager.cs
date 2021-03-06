﻿using Microsoft.Data.SqlClient;
using schedule_api_core.dto_s;
using schedule_api_core.Infrastructure;
using schedule_api_core.Interfaces;
using schedule_api_core.Validators;
using schedule_api_database;
using schedule_api_database.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace schedule_api_core.Managers
{
    public class SettingsManager : ISettingsManager
    {
        private readonly IUnitOfWork _store;
        private readonly TokenValidator _token_validator;
        private readonly HttpClient _client;

        public SettingsManager(IUnitOfWork store, TokenValidator token_validator, IHttpClientFactory clientFactory)
        {
            _store = store;
            _token_validator = token_validator;
            _client = clientFactory.CreateClient("gibbonstudio");
        }

        public async Task<Result> CreateSettingsForUser(string access_token, SettingsDto settings)
        {
            (var userId, var result) = await _token_validator.ValidateAsync(_client, access_token);
            try
            {
                if (result.Succeeded)
                {
                    if (settings.Device == null)
                        settings.Device = "undefined";

                    //var unixtime = (uint)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;
                    //if (Math.Abs(unixtime - settings.SyncTime) > 100)
                    //    settings.SyncTime = unixtime;

                    var userSettings = await _store.SettingsStore.FindByUserId(userId);
                    settings.GibbonAccountId = userId;
                    if (userSettings == null)
                    {
                        var settingsModel = settings.ToModel();
                        await _store.SettingsStore.CreateAsync(settingsModel);
                    }
                    else
                    {
                        userSettings.GroupName = settings.GroupName;
                        userSettings.GroupLink = settings.GroupLink;
                        userSettings.AccentColor = settings.AccentColor;
                        userSettings.CustomAccentColor = settings.CustomAccentColor;
                        userSettings.BackDrop = settings.BackDrop;
                        userSettings.ThemeState = settings.ThemeState;
                        userSettings.LastSyncUnixTime = settings.SyncTime;
                        userSettings.Device = settings.Device;
                        await _store.UpdateAsync(userSettings);
                    }
                    await _store.SaveChangesAsync();
                }
                return result;
            }
            catch (SqlException)
            {
                var error = new Error(ErrorCodes.DataBaseError);
                return Result.Failed(error);
            }
            catch (ArgumentException)
            {
                var error = new Error(ErrorCodes.InvalidParam);
                return Result.Failed(error);
            }
            catch
            {
                var error = new Error(ErrorCodes.UndefinedError);
                return Result.Failed(error);
            }
        }

        public async Task<(SettingsDto, Result)> FindSettingsForUSer(string access_token)
        {
            (var userId, var result) = await _token_validator.ValidateAsync(_client, access_token);
            try
            {
                if (result.Succeeded)
                {
                    var settings = await _store.SettingsStore.FindByUserId(userId);
                    if (settings == null)
                    {
                        var error = new Error(ErrorCodes.UserDontHaveSettings);
                        return (null, Result.Failed(error));
                    }
                    var settingsdto = new SettingsDto(userId,
                        settings.GroupName,
                        settings.GroupLink,
                        settings.AccentColor,
                        settings.CustomAccentColor,
                        settings.ThemeState,
                        settings.BackDrop,
                        settings.LastSyncUnixTime,
                        settings.Device);

                    return (settingsdto, Result.Sucess);
                }
                return (null, result);
            }
            catch (SqlException)
            {
                var error = new Error(ErrorCodes.DataBaseError);
                return (null, Result.Failed(error));
            }
            catch (ArgumentException)
            {
                var error = new Error(ErrorCodes.InvalidParam);
                return (null, Result.Failed(error));
            }
        }
    }
}
