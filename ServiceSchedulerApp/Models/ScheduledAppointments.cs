using ServiceSchedulerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSchedulerApp.Models
{
    public class ScheduledAppointments : BaseClass
    {
        public Guid ServiceOperatorId { get; set; }

        public string ServiceOperatorName
        {
            get
            {
                if (ApplicationDbContext.Instance != null)
                    return ApplicationDbContext.Instance.ServiceOperators.Where(p => p.Id == ServiceOperatorId).FirstOrDefault().Name;
                return string.Empty;
            }
        }

        public Guid CustomerId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }
    }

    public enum AppointmentStatus
    {
        Booked,
        Cancelled
    }
}
