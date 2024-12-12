using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IEventRegistrationRepository
    {
        List<EventRegistration> GetAllParticipants(Event ev);
        void AddRegistrationToEvent(Event ev, string comment, DateTime timeOfReg, int guestsAmount, Member member);
        void RemoveMemberFromEvent(Event ev, Member member);
    }
}
