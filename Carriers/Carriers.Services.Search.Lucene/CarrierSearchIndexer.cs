using System;
using System.Threading.Tasks;
using Carriers.Domain.Models;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Carriers.Services.Search.Lucene
{
    public class CarrierSearchIndexer
    {
        private readonly string _indexPath;
        const LuceneVersion AppLuceneVersion = LuceneVersion.LUCENE_48;
        private readonly StandardAnalyzer _analyzer;
        private readonly IndexWriterConfig _indexConfig;
        
        public CarrierSearchIndexer(string indexPath)
        {
            _indexPath = indexPath;
            _analyzer = new StandardAnalyzer(AppLuceneVersion);
            _indexConfig = new IndexWriterConfig(AppLuceneVersion, _analyzer);
        }

        public void IndexCarrier(Carrier carrier)
        {
            using var dir = FSDirectory.Open(_indexPath);
            {
                // Create an analyzer to process the text
                
                using var writer = new IndexWriter(dir, _indexConfig);
                
                var doc = new Document
                {
                    // StringField indexes but doesn't tokenize
                    new Int32Field("id",carrier.CarrierId,Field.Store.YES),
                    new StringField("name",carrier.CarrierName,Field.Store.YES),
                    new StringField("code",carrier.CarrierCode,Field.Store.YES),
                    new StringField("city",carrier.City,Field.Store.YES),
                    new StringField("state",carrier.State,Field.Store.YES),
                    new StringField("location",carrier.Location,Field.Store.YES),
                    new StringField("email",carrier.Email,Field.Store.YES),
                    new StringField("country",carrier.Country,Field.Store.YES)
                };

                writer.AddDocument(doc);
                writer.Flush(triggerMerge: false, applyAllDeletes: false);
            }
        }
    }
}