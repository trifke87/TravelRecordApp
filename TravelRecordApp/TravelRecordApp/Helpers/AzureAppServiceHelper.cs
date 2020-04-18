#define OFFLINE_SYNC_ENABLED

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Helpers
{
    public class AzureAppServiceHelper
    {
        public static async Task SyncAsync()
        {
            IReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await App.MobileService.SyncContext.PushAsync();

                await App.postsTable.PullAsync("userPosts", "");
            }
            catch(MobileServicePushFailedException mobServicePushFaildExcep)
            {
                if (mobServicePushFaildExcep.PushResult != null)
                    syncErrors = mobServicePushFaildExcep.PushResult.Errors;
            }
            catch (Exception)
            {
                throw;
            }

            if(syncErrors != null)
            {
                foreach (var syncError in syncErrors)
                {
                    if (syncError.OperationKind == MobileServiceTableOperationKind.Update &&
                        syncError.Result != null)
                    {
                        await syncError.CancelAndUpdateItemAsync(syncError.Result);
                    }
                    else
                    {
                        await syncError.CancelAndDiscardItemAsync();
                    }
                }
            }
        }
    }
}
