using AccessHomes.Domain.Entities;
using AccessHomes.Service.Contract;
using AccessHomes.Service.Exceptions;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccessHomes.Persistence;

namespace AccessHomes.Service.Implementation
{
    public class AttachmentsRepo : IAttachmentsRepo
    {
        private readonly IApplicationDbContext _context;

        public AttachmentsRepo(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAttachments(Attachments attachments)
        {
            if (attachments == null)
            {
                throw new ApiException($"Please enter attachment details");
            }

            await _context.Attachments.AddAsync(attachments);
        }

        public void DeleteAttachments(Attachments attachments)
        {
            if (attachments == null)
            {
                throw new ApiException($"Error deleting Attachments");
            }
            _context.Attachments.Remove(attachments);
        }

        public async Task<IEnumerable<Attachments>> GetAllAttachments()
        {
            return await _context.Attachments.ToListAsync();
        }

        public async Task<Attachments> GetAttachmentsById(int id)
        {
            return await _context.Attachments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Attachments> GetAttachmentsByPropertyId(int id)
        {
            return _context.Attachments.Where(p => p.PropertiesId == id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateAttachments(Attachments attachments)
        {
            //Nothing
        }
    }
}
