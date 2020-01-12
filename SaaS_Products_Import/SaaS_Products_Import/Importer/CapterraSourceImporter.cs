using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Parser;
using Import.Repository;
using Import.Model;
using Import.Database;

namespace Import.Importer
{
    /// <summary>
    /// It has own parser and source file path and target database s 
    /// </summary>
    class CapterraSourceImporter : ISourceImporter
    {
        IRepository _repository;
        IParser _parser;
        string _sourcePath;
        public CapterraSourceImporter(string sourcePath, IDatabase targetDb)
        {
            _sourcePath = sourcePath;
            _parser = new CapterraParser();
            _repository = new ProductRepository(targetDb);
        }

        public void ImportData()
        {
            List<Product> products = _parser.Parse(_sourcePath).ToList();
            foreach (Product product in products)
            {
                Console.WriteLine($"importing: Name: {product.Title};  Tags: {string.Join(", ", product.Categories)}; Twitter: {product.Twitter}");
                _repository.Import(product);
            }

        }
    }
}
