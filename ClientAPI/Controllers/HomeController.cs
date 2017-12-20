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


        public ActionResult EditPrize(string date="2017-12-20")
        {

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
                        CreatePrizeModel createPrizeModel = new CreatePrizeModel
                        {
                            GetFirstPrize = new Models.DetailPrize.FirstPrize
                            {
                                First = kq.FirstPrize.FirstOrDefault()
                            },
                            GetSecondPrize = new Models.DetailPrize.SecondPrize
                            {
                                First = kq.SecondPrize[0],
                                Second = kq.SecondPrize[1]
                            },
                            GetThirdPrize = new Models.DetailPrize.ThirdPrize
                            {
                                First = kq.ThirdPrize[0],
                                Second = kq.ThirdPrize[1],
                                Third = kq.ThirdPrize[2],
                                Four = kq.ThirdPrize[3],
                                Fifth = kq.ThirdPrize[4],
                                Sixth = kq.ThirdPrize[5]

                            },
                            GetFourthPrize = new Models.DetailPrize.FourthPrize
                            {
                                First = kq.FourthPrize[0],
                                Second = kq.FourthPrize[1],
                                Third = kq.FourthPrize[2],
                                Fourth = kq.FourthPrize[3]

                            },
                            GetFifthPrize = new Models.DetailPrize.FifthPrize
                            {
                                First = kq.FifthPrize[0],
                                Second = kq.FifthPrize[1],
                                Third = kq.FifthPrize[2],
                                Four = kq.FifthPrize[3],
                                Fifth = kq.FifthPrize[4],
                                Sixth = kq.FifthPrize[5]



                            },
                            GetSixthPrize = new Models.DetailPrize.SixthPrize
                            {
                                First = kq.SixthPrize[0],
                                Second = kq.SixthPrize[1],
                                Third = kq.SixthPrize[2]
                            },
                            GetSeventhPrize = new Models.DetailPrize.SeventhPrize
                            {
                                First = kq.SeventhPrize[0],
                                Second = kq.SeventhPrize[1],
                                Third = kq.SeventhPrize[2],
                                Fourth = kq.SeventhPrize[3]
                            },
                            GetSpecialPrize = new Models.DetailPrize.SpecialPrize
                            {
                                First = kq.SpecialPrize[0]
                            }

                        };
                        return View(createPrizeModel);
                    }

                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditPrize(CreatePrizeModel createPrizeModel,string date = "2017-12-20")
        {
            ViewModelPrize viewModelPrize = new ViewModelPrize
            {
                date = date,
                SpecialPrize = new List<string>
                {
                    createPrizeModel.GetSpecialPrize.First
                },
                FirstPrize = new List<string>
                {
                    createPrizeModel.GetFirstPrize.First
                },
                SecondPrize = new List<string>
                {
                    createPrizeModel.GetSecondPrize.First,
                    createPrizeModel.GetSecondPrize.Second

                },
                ThirdPrize = new List<string>
                {
                    createPrizeModel.GetThirdPrize.First,
                    createPrizeModel.GetThirdPrize.Second,
                    createPrizeModel.GetThirdPrize.Third,
                    createPrizeModel.GetThirdPrize.Four,
                    createPrizeModel.GetThirdPrize.Fifth,
                    createPrizeModel.GetThirdPrize.Sixth
                },
                FourthPrize = new List<string>
               {
                   createPrizeModel.GetFourthPrize.First,
                   createPrizeModel.GetFourthPrize.Second,
                   createPrizeModel.GetFourthPrize.Third,
                   createPrizeModel.GetFourthPrize.Fourth

               },
                FifthPrize = new List<string>
              {
                  createPrizeModel.GetFifthPrize.First,
                  createPrizeModel.GetFifthPrize.Second,
                  createPrizeModel.GetFifthPrize.Third,
                  createPrizeModel.GetFifthPrize.Four,
                  createPrizeModel.GetFifthPrize.Fifth,
                  createPrizeModel.GetFifthPrize.Sixth

              },
                SixthPrize = new List<string>
              {
                  createPrizeModel.GetSixthPrize.First,
                  createPrizeModel.GetSixthPrize.Second,
                  createPrizeModel.GetSixthPrize.Third

              },
                SeventhPrize = new List<string>
              {
                  createPrizeModel.GetSeventhPrize.First,
                  createPrizeModel.GetSeventhPrize.Second,
                  createPrizeModel.GetSeventhPrize.Third,
                  createPrizeModel.GetSeventhPrize.Fourth
              }


            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50132/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var postTask = client.PutAsJsonAsync<ViewModelPrize>("lottezy/1", viewModelPrize);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var KQ = result.Content.ReadAsAsync<ResponsePrize>();
                    KQ.Wait();
                    if (KQ.Result.code == 0)
                    {
                        return RedirectToAction("Index");
                    }

                }
                return View("that bai");
            }

            return View();
        }



        /// <summary>
        /// giao dien them moi
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatePrize()
        {
            return View();
        }
      
        /// <summary>
        /// them moi giai
        /// </summary>
        /// <param name="createPrizeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreatePrize(CreatePrizeModel createPrizeModel)
        {
            ViewModelPrize viewModelPrize = new ViewModelPrize
            {
                SpecialPrize = new List<string>
                {
                    createPrizeModel.GetSpecialPrize.First
                },
                FirstPrize = new List<string>
                {
                    createPrizeModel.GetFirstPrize.First
                },
                SecondPrize = new List<string>
                {
                    createPrizeModel.GetSecondPrize.First,
                    createPrizeModel.GetSecondPrize.Second

                },
                ThirdPrize = new List<string>
                {
                    createPrizeModel.GetThirdPrize.First,
                    createPrizeModel.GetThirdPrize.Second,
                    createPrizeModel.GetThirdPrize.Third,
                    createPrizeModel.GetThirdPrize.Four,
                    createPrizeModel.GetThirdPrize.Fifth,
                    createPrizeModel.GetThirdPrize.Sixth
                },
                FourthPrize = new List<string>
               {
                   createPrizeModel.GetFourthPrize.First,
                   createPrizeModel.GetFourthPrize.Second,
                   createPrizeModel.GetFourthPrize.Third,
                   createPrizeModel.GetFourthPrize.Fourth

               },
                FifthPrize = new List<string>
              {
                  createPrizeModel.GetFifthPrize.First,
                  createPrizeModel.GetFifthPrize.Second,
                  createPrizeModel.GetFifthPrize.Third,
                  createPrizeModel.GetFifthPrize.Four,
                  createPrizeModel.GetFifthPrize.Fifth,
                  createPrizeModel.GetFifthPrize.Sixth

              },
                SixthPrize = new List<string>
              {
                  createPrizeModel.GetSixthPrize.First,
                  createPrizeModel.GetSixthPrize.Second,
                  createPrizeModel.GetSixthPrize.Third

              },
                SeventhPrize = new List<string>
              {
                  createPrizeModel.GetSeventhPrize.First,
                  createPrizeModel.GetSeventhPrize.Second,
                  createPrizeModel.GetSeventhPrize.Third,
                  createPrizeModel.GetSeventhPrize.Fourth
              }


            };
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
        

        /// <summary>
        /// hien danh muc
        /// </summary>
        /// <returns></returns>
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
        [HttpGet]
        public ActionResult HomeHome()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Login(string username,string pass)
        {
            return View();
        }
    }
}