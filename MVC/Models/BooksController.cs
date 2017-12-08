using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC.Models
{
    public class BooksController : Controller
    {
        private _44612975 db = new _44612975();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Num,Name,Author,Year,Price,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Num,Name,Author,Year,Price,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /**
         *  My Codes
         */
        public void ReadFile()
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            var v = client.ReadFile();
            Book OneBook;
            foreach (string line in v)
            {
                string[] SplitedLine = line.Split(',');
                OneBook = new Book();
                OneBook.Num = Convert.ToInt32(SplitedLine[0]);
                OneBook.Name = SplitedLine[1];
                OneBook.Author = SplitedLine[2];
                OneBook.Year = Convert.ToInt32(SplitedLine[3]);
                OneBook.Price = Convert.ToDecimal(SplitedLine[4].Remove(0, 1));
                OneBook.Stock = Convert.ToInt32(SplitedLine[5]);
                db.Books.Add(OneBook);
            }
        }

        public void WriteFile(List<String> books)
        {
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
            var b = new MVC.ServiceReference1.ArrayOfString();
            foreach (var v in books)
            {
                b.Add(v);
            }
            client.WriteFile(b);
        }

        public ActionResult Import()
        {
            DeleteAll();
            ReadFile();
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Save()
        {
            var book = new List<String>();
            foreach (Book b in db.Books)
            {
                book.Add(b.Num + "," + b.Name + "," + b.Author + "," + b.Year + "," + b.Price + "," + b.Stock);
            }
            WriteFile(book);

            return RedirectToAction("Index");
        }

        // GET: Books/Search
        public ActionResult Search()
        {
            return View(db.Books.ToList());
        }

        [HttpPost]
        public ActionResult Search(String Index, String Value)
        {
            List<Book> book = db.Books.ToList();
            List<Book> foundBook = new List<Book>();
            foreach (Book b in book)
            {
                if (Index.Equals("Num"))
                {
                    if (b.Num.ToString().Equals(Value))
                    {
                        foundBook.Add(b);
                    }
                }
                else if (Index.Equals("Name"))
                {
                    if (b.Name.Equals(Value))
                    {
                        foundBook.Add(b);
                    }
                }
                else if (Index.Equals("Author"))
                {
                    if (b.Author.Equals(Value))
                    {
                        foundBook.Add(b);
                    }
                }
                else if (Index.Equals("Year"))
                {
                    if (b.Year.ToString().Equals(Value))
                    {
                        foundBook.Add(b);
                    }
                }
            }
            return View(foundBook);
        }

        // POST: Books/DeleteBooks/
        public ActionResult DeleteBooks()
        {
            return View(db.Books.ToList());
        }

        // POST: Books/DeleteBooks/
        [HttpPost]
        public ActionResult DeleteBooks(String Index, String Value)
        {
            List<Book> book = db.Books.ToList();
            List<Book> foundBook = new List<Book>();
            foreach (Book b in book)
            {
                if (Index.Equals("Num"))
                {
                    if (b.Num.ToString().Equals(Value))
                    {
                        db.Books.Remove(b);
                        db.SaveChanges();
                    }
                }
                else if (Index.Equals("Name"))
                {
                    if (b.Name.Equals(Value))
                    {
                        db.Books.Remove(b);
                        db.SaveChanges();
                    }
                }
                else if (Index.Equals("Author"))
                {
                    if (b.Author.Equals(Value))
                    {
                        db.Books.Remove(b);
                        db.SaveChanges();
                    }
                }
                else if (Index.Equals("Year"))
                {
                    if (b.Year.ToString().Equals(Value))
                    {
                        db.Books.Remove(b);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("DeleteBooks");
        }

        public ActionResult DeleteAll()
        {
            foreach (Book b in db.Books)
            {
                db.Books.Remove(b);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
