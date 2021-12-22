using System.Collections.Generic;
using System.Threading.Tasks;
using XCore.Entities.Models.Rentals;

namespace XCore.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        Task<IEnumerable<Media>> GetMediasAsync(bool trackChanges);
        Task<Media> GetMediaAsync(int mediaId, bool trackChanges);
        void CreateMedia(Media media);
        void UpdateMedia(Media media);
        void DeleteMedia(Media media);
    }
}
