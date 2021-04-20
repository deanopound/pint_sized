using System.Collections.Generic;
using PintSized.Api.Models;
using PintSized.Api.Models.Request;
using PintSized.Api.Models.Response;
using PintSized.Api.Services.Utilities;
using Repository;

namespace PintSized.Api.Services
{
    public class ShortURLService : IShortURLService
    {
        private IShortURLRepository _shortURLRepository;
        public ShortURLService(IShortURLRepository shortURLRepository)
        {
            _shortURLRepository = shortURLRepository;
        }

        public IEnumerable<ShortURLModel> GetCollectionFromDataStore()
        {
            return _shortURLRepository.GetCollectionFromDataStore();
        }

        public ShortURLModel GetItemFromDataStore(string shortUrl)
        {
            return _shortURLRepository.GetItemFromDataStoreByShortUrl(shortUrl);
        }

        public ShortURLResponse SaveItemToDataStore(ShortURLRequest model)
        {
            ShortURLModel previouslySaved = _shortURLRepository.GetItemFromDataStoreByLongUrl(model.LongURL);

            if(previouslySaved != null)
            {
                return new ShortURLResponse {
                    Model = previouslySaved,
                    Success = true,
                    Message = "This URL has already been pint-sized!"
                };
            }
            else
            {
                ShortURLModel savedModel = _shortURLRepository.SaveItemToDataStore(ShortURLMapper.MapRequestModelToDBModel(model));

                return new ShortURLResponse
                {
                    Model = savedModel,
                    Success = true,
                    Message = "Pint of URL poured successfully!"
                };
            }

        }
    }
}