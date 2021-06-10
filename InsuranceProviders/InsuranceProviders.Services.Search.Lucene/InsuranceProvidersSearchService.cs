using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceProviders.Domain;
using InsuranceProviders.Domain.Models;
using InsuranceProviders.Domain.Services;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace InsuranceProviders.Services.Search.Lucene
{
    public class InsuranceProviderSearchService : IInsuranceProviderSearchService
    {
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private readonly string _indexPath;
        private IndexSearcher _indexSearcher;
        public InsuranceProviderSearchService(string indexPath)
        {
            _indexPath = indexPath;
            //var reader = DirectoryReader.Open(FSDirectory.Open(_indexPath));
            //_indexSearcher = new IndexSearcher(reader);
        }

        public Task<InsuranceProviderCollection> SearchInsuranceProviders(InsuranceProviderSearchCriteria criteria)
        {
            var phrase = new MultiPhraseQuery
            {
                new Term("name", criteria.insuranceProviderName)
            };
            var hits = _indexSearcher.Search(phrase, 20 /* top 20 */).ScoreDocs;

            var searchResults = new InsuranceProviderCollection();
            foreach (var hit in hits)
            {
                var foundDoc = _indexSearcher.Doc(hit.Doc);
                searchResults.insuranceProviders.Add(new InsuranceProvider{InsuranceName = foundDoc.Get("name")});
            }

            return Task.FromResult(searchResults);
        }
    }
}