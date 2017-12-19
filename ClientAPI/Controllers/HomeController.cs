using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ClientAPI.Models;


namespace ClientAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var cliet = new HttpClient())
            {

                cliet.BaseAddress = new Uri("http://localhost:50132/");

                cliet.DefaultRequestHeaders.Accept.Clear();
                cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = cliet.GetAsync("lottezy/1");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponseLottezy>();

                    KQ.Wait();
                    ResponseLottezy  res = KQ.Result;
                    if (res.code == 0)
                    {
                        ViewModelPrize kq = res.data;
                        return View(kq);
                    }

                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult CreatePrize(ViewModelPrize viewModelPrize)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50132/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
             
                var postTask = client.PostAsJsonAsync<ViewModelPrize>("lottezy/1", viewModelPrize);
                postTask.Wait();
                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponseLottezy>();
                    KQ.Wait();
                    if(KQ.Result.code == 0)
                    {
                        return View("thanh cong");
                    }
                   
                }
                return View("that bai");
            }

        }
        
        public ActionResult _DanhMuc()
        {
            using (var cliet = new HttpClient())
            {

                cliet.BaseAddress = new Uri("http://localhost:50132/");

                cliet.DefaultRequestHeaders.Accept.Clear();
                cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = cliet.GetAsync("lottezies");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponseLocationPrize>();

                    KQ.Wait();
                    ResponseLocationPrize res = KQ.Result;
                    if(res.code == 0) // thanh cong 
                    {
                        List<ViewModelLocationPrize> kq = res.data;
                        return PartialView(kq);
                    }
                  
                }

            }
            return View();

        }
        public ActionResult SXMN()
        {
            using (var cliet = new HttpClient())
            {

                cliet.BaseAddress = new Uri("http://localhost:50132/");

                cliet.DefaultRequestHeaders.Accept.Clear();
                cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = cliet.GetAsync("lottezy/1");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponseLocationPrize>();

                    KQ.Wait();
                    ResponseLocationPrize res = KQ.Result;
                    if (res.code == 0)
                    {
                        List<ViewModelLocationPrize> kq = res.data;
                        return View(kq);
                    }

                }

            }
            return View();
        }
    }
}