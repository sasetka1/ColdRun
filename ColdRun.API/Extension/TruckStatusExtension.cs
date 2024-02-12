using ColdRun.API.Models;

namespace ColdRun.API.Extension
{
    public static class TruckStatusExtension
    {
        private static bool IsValidStatusTransition(this TruckStatus currentStatus, TruckStatus newStatus)
        {
            switch (newStatus)
            {
                case TruckStatus.OutOfService:
                    return true;

                case TruckStatus.Loading:
                    return currentStatus == TruckStatus.OutOfService;

                case TruckStatus.ToJob:
                    return currentStatus == TruckStatus.Loading;

                case TruckStatus.AtJob:
                    return currentStatus == TruckStatus.ToJob;

                case TruckStatus.Returning:
                    return currentStatus == TruckStatus.AtJob || currentStatus == TruckStatus.Returning;

                default:
                    return false;
            }
        }
    }
}
