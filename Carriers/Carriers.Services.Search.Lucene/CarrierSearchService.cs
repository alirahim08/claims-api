using System.Collections.Generic;
using System.Threading.Tasks;
using Carriers.Domain;
using Carriers.Domain.Models;
using Carriers.Domain.Services;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Carriers.Services.Search.Lucene
{
    public class CarrierSearchService : ICarrierSearchService
    {
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private readonly string _indexPath;
        private IndexSearcher _indexSearcher;
        public CarrierSearchService(string indexPath)
        {
            _indexPath = indexPath;
            var reader = DirectoryReader.Open(FSDirectory.Open(_indexPath));
            _indexSearcher = new IndexSearcher(reader);
        }

        public Task<CarrierCollection> SearchCarriers(CarrierSearchCriteria criteria)
        {
            var phrase = new MultiPhraseQuery
            {
                new Term("name", criteria.CarrierName)
            };
            var hits = _indexSearcher.Search(phrase, 20 /* top 20 */).ScoreDocs;

            var searchResults = new CarrierCollection();
            foreach (var hit in hits)
            {
                var foundDoc = _indexSearcher.Doc(hit.Doc);
                searchResults.Carriers.Add(new Carrier{CarrierName = foundDoc.Get("name")});
            }

            return Task.FromResult(searchResults);
        }
    }
}