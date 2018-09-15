using GymWebDeploy.Models.Dao;
using System;
namespace GymWebDeploy.Controllers.utils
{
    public class Utils
    {
        public static string FormatDates(DateTime date)
        {
            string[] dates = (date.ToString().Split(' '));
            string[] datesEnd = dates[0].Split('/');
            return datesEnd[2] + "-" + datesEnd[0] + "-" + datesEnd[1] + " 00:00:00.000";
        }
        public static bool Execute(string query)
        {
            return new GenericBaseDao().ExecuteQuery(query);
        }
    }
}