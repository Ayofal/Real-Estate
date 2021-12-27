using AccessHomes.Domain.Common;
using AccessHomes.Domain.Entities;
using AccessHomes.Service.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface IAttachmentsRepo
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Attachments>> GetAllAttachments();
        Task<Attachments> GetAttachmentsById(int id);
        IEnumerable<Attachments> GetAttachmentsByPropertyId(int id);
        Task CreateAttachments(Attachments attachment);
        void UpdateAttachments(Attachments attachment);
        void DeleteAttachments(Attachments attachment);
    }
}
