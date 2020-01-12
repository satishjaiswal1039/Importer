using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Parser;
using Import.Model;
using Import.Repository;
using Import.Database;

namespace Import.Importer
{
    class SoftwareadviceSourceImporter : ISourceImporter
    {
        IRepository _repository;
        string _sourcePath;
        IParser _parser;

        public SoftwareadviceSourceImporter(string sourcePath, IDatabase targetDb)
        {
            _sourcePath = sourcePath;
            _parser = new SoftwareadviceParser();
            _repository = new ProductRepository(targetDb);
        }

        public void ImportData()
        {
            List<Product> products = _parser.Parse(_sourcePath).ToList();
            foreach (Product product in products)
            {
                Console.WriteLine($"importing: Name: {product.Title};  Categories: {string.Join(",", product.Categories)}; Twitter: {product.Twitter}");
                _repository.Import(product);
            }
        }
    }
}
