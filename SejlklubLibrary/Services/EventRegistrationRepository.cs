using SejlklubLibrary.Data;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class EventRegistrationRepository : IEventRegistrationRepository
    {
        public List<EventRegistration> GetAllParticipants(Event ev)
        {
            return ev.EventRegistrations;
        }

        // Skal kunne tilføje en EventRegistration til listen under Event
        public void AddRegistrationToEvent(Event ev, string comment, DateTime timeOfReg, int guestsAmount, Member member)
        {
            EventRegistration eventRegistration = new EventRegistration(comment, timeOfReg, guestsAmount, member);

            if (!ev.EventRegistrations.Contains(eventRegistration))
            {
                ev.EventRegistrations.Add(eventRegistration);
            }
        }

        // Fjerner en registration fra listen under Event
        public void RemoveMemberFromEvent(Event ev, Member member)
        {
            foreach (EventRegistration registration in ev.EventRegistrations)
            {
                if (registration.Member == member)
                {
                    ev.EventRegistrations.Remove(registration);
                }
            }
        }
    }
}
