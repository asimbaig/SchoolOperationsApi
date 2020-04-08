using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEventService
    {
        Task<int> AddEventAsync(EventDTO model);
        Task<EventDTO> UpdateEventAsync(EventDTO model);
        Task<int> RemoveEventAsync(int EventId);
        Task<List<EventDTO>> GetAllEvent();
        bool IsEventExistsById(int EventId);
        Task<EventDTO> SearchSingleEventByNameAsync(string term);
        List<EventDTO> SearchEventsByEventNameAsync(string term);
        Task<EventDTO> SearchSingleEventByIdAsync(int Id);
    }
}
