using BookSellingWebsite_Assessment_04_.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookSellingWebsite_Assessment_04_.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        Uri baseAddress = new Uri("https://localhost:7286/api");
        HttpClient client;

        public BooksController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        #region GET METHOD
        public ActionResult Get()
        {
            List<Book> bookList = new List<Book>();

            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/Books/").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<Book>>(data);
            }
            return View(bookList);

        }
        #endregion

        #region INDEX METHOD

        public ActionResult Index()
        {
            List<Book> bookList = new List<Book>();

            HttpResponseMessage responseMessage = client.GetAsync(baseAddress + "/Books/").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<Book>>(data);
            }
            return View(bookList);

        }

        #endregion

        #region CREATE METHOD

        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region POST METHOD Using Create

        [HttpPost]
        public ActionResult Create(Book book)
        {
            var postTask = client.PostAsJsonAsync<Book>(baseAddress + "/Books", book);
            postTask.Wait();
            var result = postTask.Result;
            
            
                return RedirectToAction("Get");
            
        }

        #endregion

        #region UPDATE METHOD

        public ActionResult Update(Book book)

        {
            return View("Update",book);
        }


        public ActionResult UpdateBook(Book book)
        {
            var putTask = client.PutAsJsonAsync<Book>(baseAddress + "/Books/" + book.Id.ToString(), book);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }
            return View(book);
        }

        #endregion

        #region DELETE METHOD

        public ActionResult Delete(int id)
        {

            //HTTP DELETE
            var deleteTask = client.DeleteAsync(baseAddress + "/Books/" + id.ToString());
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Get");
            }

            return RedirectToAction("Delete");
        }
        #endregion

        #region DESCRIPTION
        public ActionResult Description()
        {
            return View();
        }
        #endregion

        #region ADD CART METHOD
        public ActionResult AddToCart()
        {
            return View();
        }

        #endregion

        #region SEARCH METHOD
        public ActionResult Search(string searchString)
        {
            List<Book> books = new List<Book>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Books/" + searchString).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(data);
            }
            return View("Get", books);
        }
        #endregion

    }
}