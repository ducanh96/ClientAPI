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
        public ActionResult Index(int id=1)
        {
            

        using (var cliet = new HttpClient())
            {

                cliet.BaseAddress = new Uri("http://localhost:50132/");

                cliet.DefaultRequestHeaders.Accept.Clear();
                cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = cliet.GetAsync(string.Format("lottezy/{0}",id));
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponsePrize>();

                    KQ.Wait();
                    ResponsePrize  res = KQ.Result;
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
                    var KQ = result.Content.ReadAsAsync<ResponsePrize>();
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
        [HttpGet]
        public ActionResult SXMN(int id=2)
        {
            
                using (var cliet = new HttpClient())
                {

                    cliet.BaseAddress = new Uri("http://localhost:50132/");

                    cliet.DefaultRequestHeaders.Accept.Clear();
                    cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = cliet.GetAsync(string.Format("lottezy/{0}", id));
                    response.Wait();

                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var KQ = result.Content.ReadAsAsync<ResponsePrize>();

                        KQ.Wait();
                        ResponsePrize res = KQ.Result;
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
        public ActionResult SXMN(string date)
        {
   
        ViewBag.date = date;
            using (var cliet = new HttpClient())
            {

                cliet.BaseAddress = new Uri("http://localhost:50132/");

                cliet.DefaultRequestHeaders.Accept.Clear();
                cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = cliet.GetAsync(string.Format("lottezy/1?date={0}",date));
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponsePrize>();

                    KQ.Wait();
                    ResponsePrize res = KQ.Result;
                    if (res.code == 0)
                    {
                        ViewModelPrize kq = res.data;
                        return View(kq);
                    }
                    
                   
                }

            }
            
          
            return View();
        }
        [HttpGet]
        public ActionResult SXMN_TachCuoi(string date)
        {

            ViewBag.date = date;
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
                    var KQ = result.Content.ReadAsAsync<ResponsePrize>();

                    KQ.Wait();
                    ResponsePrize res = KQ.Result;
                    if (res.code == 0)
                    {
                        ViewModelPrize kq = res.data;
                        return View(kq);
                    }

                }

            }


            return View();
        }

        [HttpGet]
        public ActionResult ThongKe()
        {
         
            return View();

        }
        [HttpPost]
        public ActionResult ThongKe(string from, string to)
        {
            using (var cliet = new HttpClient())
            {

                cliet.BaseAddress = new Uri("http://localhost:50132/");

                cliet.DefaultRequestHeaders.Accept.Clear();
                cliet.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = cliet.GetAsync(string.Format("lottezy/1/statistical?from={0}&to={1}",from,to));
                response.Wait();
                ViewBag.from = from;
                ViewBag.to = to;
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponseStatiscal>();

                    KQ.Wait();
                    ResponseStatiscal res = KQ.Result;
                    if (res.code == 0)
                    {
                        List<ViewModelStatiscal> kq = res.data;
                        return View(kq);
                    }

                }

            }
            return View();

        }
    }
}