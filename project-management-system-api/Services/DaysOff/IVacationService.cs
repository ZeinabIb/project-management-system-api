namespace project_management_system_api.Services.DaysOff
{
 

   
        public interface IVacationService
        {
            int CalculateVacationDuration(DateTime fromDate, DateTime toDate);
        }

        public class VacationService : IVacationService
        {
            public int CalculateVacationDuration(DateTime fromDate, DateTime toDate)
            {
               
                TimeSpan duration = toDate - fromDate;
                return duration.Days + 1; 
            }
        }
    

}
