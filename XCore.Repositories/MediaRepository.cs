using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.Entities.Models.Rentals;
using XCore.Repositories.Interfaces;

namespace XCore.Repositories
{
    public class MediaRepository : RepositoryBase<Media>, IMediaRepository
    {
        public MediaRepository(XCoreDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<Media>> GetMediasAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .OrderBy(c => c.ItemTitle)
            .Include(c => c.ItemCategory)
            .ToListAsync();

        public async Task<Media> GetMediaAsync(int mediaId, bool trackChanges) => 
            await FindByCondition(c => c.MediaId.Equals(mediaId), (trackChanges ? 1 : 0) != 0)
            .Include(c => c.ItemCategory)
            .SingleOrDefaultAsync();

        public void CreateMedia(Media media) => 
            Create(media);

        public void UpdateMedia(Media media) => 
            Update(media);

        public void DeleteMedia(Media media) => 
            Delete(media);
    }
}
