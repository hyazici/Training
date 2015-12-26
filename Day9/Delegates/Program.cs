using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate Document Filter(IList<Document> documents);

        public delegate bool MyPredicate(Document document);


        static void Main(string[] args)
        {
            IList<Document> documents = new List<Document>()
            {
                new Document()
                {
                    Id = 1,
                    Name = "C# a giriş",
                    Author = "Sefer Algan",
                    PublishDate = new DateTime(2008, 9, 9)
                },
                new Document()
                {
                    Id = 2,
                    Name = "OOP nedir",
                    Author = "Mert Susur",
                    PublishDate = new DateTime(2009, 9, 9)
                },
                new Document()
                {
                    Id = 3,
                    Name = "Derinlemesine WCF",
                    Author = "Deniz İrgin",
                    PublishDate = new DateTime(2010, 9, 9)
                },
                new Document()
                {
                    Id = 4,
                    Name = "WPF öğreniyorum",
                    Author = "Hüseyin yazıcı",
                    PublishDate = new DateTime(2010, 9, 9)
                },
                new Document()
                {
                    Id = 5,
                    Name = "WPF Öğrendim",
                    Author = "Hüseyin yazıcı",
                    PublishDate = new DateTime(2011, 9, 9)
                },
            };

            //Filter filter = new Filter(FilterById);
            //Document document = filter(documents);

            //Console.WriteLine(document.Name);

            //filter = new Filter(FilterByDate);
            //document = filter(documents);

            //Console.WriteLine(document.Name);

            //MyPredicate IsIn2010Pre = IsIn2010;
            //MyPredicate IsAuthourHuseyinPre = IsAuthourHuseyin;
            //MyPredicate mainFilter = IsIn2010Pre + IsAuthourHuseyinPre;

            MyPredicate predicate = delegate(Document document)
                                        {
                                            return document.Id > 2;
                                        };

            predicate = (document => document.Id > 2);

            IList<Document> byFilter = GetByFilter(documents, predicate);
            IEnumerable<Document> enumerable = documents.Where(IsIn2010);

            documents.Where(document => document.Id > 2);

            Func<Document, bool> func = IsIn2010;

            GetByFilter(documents, IsIn2010);
            GetByFilter(documents, delegate(Document document)
            {
                return document.PublishDate.Year == 2010;
            });
            GetByFilter(documents, document => document.PublishDate.Year == 2010);
        }


        static IList<Document> GetByFilter(IList<Document> docsToFilter, MyPredicate myPredicate)
        {
            IList<Document> documents = new List<Document>();

            foreach (Document document in docsToFilter)
            {
                // bool predicate = IsIn2010(document)
                bool predicate = myPredicate(document);

                if (predicate)
                {
                    documents.Add(document);
                }
            }

            return documents;
        }

        static Document FilterById(IList<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.Id == 1)
                {
                    return document;
                }
            }

            return null;
        }

        static Document FilterByDate(IList<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.PublishDate.Year == 2009)
                {
                    return document;
                }
            }

            return null;
        }

        static bool IsIn2010(Document document)
        {
            return document.PublishDate.Year == 2010;
        }

        static bool IsAuthourHuseyin(Document document)
        {
            return document.Author == "Hüseyin yazıcı";
        }
    }

    class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
