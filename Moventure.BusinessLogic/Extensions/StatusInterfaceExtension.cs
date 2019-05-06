using Deventure.DataLayer.Interfaces;

namespace UpWorky.DataLayer.Extensions
{
    public static class StatusInterfaceExtension
    {
        public static void AddStatus(this IDataWithStatus t, int status)
        {
            t.Status = t.Status | status;
        }

        public static void RemoveStatus(this IDataWithStatus t, int status)
        {
            t.Status = t.Status & ~status;
        }

        public static bool HasStatus(this IDataWithStatus t, int status)
        {
            return (t.Status & status) != 0;
        }
    }
}
