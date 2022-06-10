using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniqueIdentifier.Data;
using UniqueIdentifier.DTOs;
using UniqueIdentifier.Entities;
using UniqueIdentifier.Serivices;

namespace UniqueIdentifier.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentifierContext _context;
        private readonly Random _rand;
        private readonly IUniqueIDService _service;
        private readonly IMapper _mapper;
        public IdentityRepository(IdentifierContext context, IUniqueIDService service, IMapper mapper)
        {
            _context = context;
            _rand = new Random();
            _service = service;
            _mapper = mapper;
        }

        public async Task<IdentityDTO> CreateIdentifier()
        {
            var disabledIds = await _context.Identities.Where(x => x.IsEnabled.Equals(false)).ToListAsync();

            if (disabledIds != null && disabledIds.Count > 0)
            {
                var existingId = disabledIds[_rand.Next(disabledIds.Count)];
                await ToggleId(existingId);
                return _mapper.Map<IdentityDTO>(existingId);
            }

            var id = new Identity()
            {
                Identifier = _service.GenerateUniqueId(),
                IsEnabled = true,
                CreatedDate = DateTime.UtcNow,
            };

            _context.Identities.Add(id);
            await _context.SaveChangesAsync();

            return _mapper.Map<IdentityDTO>(id);
        }

        public async Task<bool> DisableIdentifier(string id)
        {
            var idToDisable = await _context.Identities.Where(x => x.Identifier.Equals(id)).FirstOrDefaultAsync();

            if (idToDisable == null || !idToDisable.IsEnabled)
            {
                return false;
            }

            await ToggleId(idToDisable);
            return true;
        }

        private async Task ToggleId(Identity id)
        {
            id.IsEnabled = !id.IsEnabled;
            _context.Update(id);
            await _context.SaveChangesAsync();
        }
    }
}
