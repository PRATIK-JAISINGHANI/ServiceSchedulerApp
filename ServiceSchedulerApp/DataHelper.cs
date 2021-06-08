using Microsoft.AspNetCore.Components.Authorization;
using ServiceSchedulerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSchedulerApp
{
    public static class DataHelper
    {

        public static List<ServiceSchedulerApp.Models.ServiceOperator> GetServiceOperators()
        {
            return ApplicationDbContext.Instance.ServiceOperators.OrderBy(so=>so.Name).ToList();
        }

        public static List<ServiceSchedulerApp.Models.ScheduledAppointments> GetMyAppointments(string userEmail)
        {

            return ApplicationDbContext.Instance.ScheduledAppointments.Where(sa => sa.CustomerId.ToString() == ApplicationDbContext.Instance.Users.Where(u => u.Email == userEmail).FirstOrDefault().Id).ToList();
        }

        public static bool IsAppointmentAlreadyPresent(Guid serviceOperatorId, DateTime appointmentDateTime)
        {
            return ApplicationDbContext.Instance.ScheduledAppointments.Where(sa => sa.ServiceOperatorId == serviceOperatorId && sa.AppointmentDateTime == appointmentDateTime && sa.AppointmentStatus == Models.AppointmentStatus.Booked).Count() > 0;
        }

        public static bool IsAppointmentPresentForCustomer(string userEmail, DateTime appointmentDateTime)
        {
            var context = ApplicationDbContext.Instance;
            var userId = context.Users.Where(u => u.Email == userEmail).FirstOrDefault().Id;
            return ApplicationDbContext.Instance.ScheduledAppointments.Where(sa => sa.CustomerId == Guid.Parse(userId) && sa.AppointmentDateTime.Date == appointmentDateTime.Date && sa.AppointmentStatus == Models.AppointmentStatus.Booked).Count() > 0;
        }

        public static bool CreateAppointment(Guid serviceOperatorId, DateTime appointmentDateTime, string userEmail)
        {
            var context = ApplicationDbContext.Instance;
            var userId = context.Users.Where(u => u.Email == userEmail).FirstOrDefault().Id;
            context.ScheduledAppointments.Add(new Models.ScheduledAppointments() { ServiceOperatorId = serviceOperatorId, AppointmentDateTime = appointmentDateTime, CustomerId = Guid.Parse(userId), AppointmentStatus = Models.AppointmentStatus.Booked });
            return context.SaveChanges() > 0;
        }
    }
}
