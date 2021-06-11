using System;
using System.Threading.Tasks;
using InsuranceProviders.Domain.Models;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace InsuranceProviders.Services.Search.Lucene
{
    public class InsuranceProviderSearchIndexer
    {
        private readonly string _indexPath;
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private readonly StandardAnalyzer _analyzer;
        private readonly IndexWriterConfig _indexConfig;
        
        public InsuranceProviderSearchIndexer(string indexPath)
        {
            _indexPath = indexPath;
            _analyzer = new StandardAnalyzer(AppLuceneVersion);
            _indexConfig = new IndexWriterConfig(AppLuceneVersion, _analyzer);
        }

        public void IndexInsuranceProvider(InsuranceProvider insuranceProvider)
        {
            using var dir = FSDirectory.Open(_indexPath);
            {
                // Create an analyzer to process the text
                
                using var writer = new IndexWriter(dir, _indexConfig);
                
                var doc = new Document
                {
                    // StringField indexes but doesn't tokenize
                    new Int32Field("id",insuranceProvider.InsuranceId,Field.Store.YES),
                    new StringField("code",insuranceProvider.InsuranceCode,Field.Store.YES),
                    new StringField("name",insuranceProvider.InsuranceName,Field.Store.YES),
                    new StringField("policynumber",insuranceProvider.PolicyNumber,Field.Store.YES),
                    new StringField("corporate",insuranceProvider.Corporate,Field.Store.YES),
                    new StringField("address",insuranceProvider.Address,Field.Store.YES),
                    new StringField("location",insuranceProvider.Location,Field.Store.YES),
                    new StringField("phone",insuranceProvider.Phone,Field.Store.YES),
                    new StringField("fax",insuranceProvider.Fax,Field.Store.YES),
                    new StringField("email",insuranceProvider.Email,Field.Store.YES),
                    new StringField("website",insuranceProvider.Website,Field.Store.YES)
                };

                writer.AddDocument(doc);
                writer.Flush(triggerMerge: false, applyAllDeletes: false);
            }
        }
    }
}