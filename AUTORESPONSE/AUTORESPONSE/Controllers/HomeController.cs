using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AUTORESPONSE.Models;
using System.IO;
using System.Net.Mail;
using System.Threading;

namespace AUTORESPONSE.Controllers
{
    public class HomeController : Controller
    {
        private static List<string>  emailTestAfter = new List<string>();
        private static int j = 0;
        private static Random random = new Random();
        public ActionResult Index()
        {
            emailTestAfter.Add("*****@******.net");
          
            return View();
        }


        [HttpPost]
        public ActionResult Index(DropEmails dp)
        {

              try
              {
                StringReader sr = new StringReader(dp.data);
                string line;
                List<string> data = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line);
                }

                SmtpClient client = new SmtpClient("***********", 587);
                client.Credentials = new System.Net.NetworkCredential("replay@******.com", "******");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;


                
            for (int i = 0; i < data.Count; i++)
                {
                    MailMessage message = new MailMessage(""+dp.sendTo+""+ "<replay@******.com>", ""+dp.sendTo+"");
                    message.Subject = dp.subject;
                    message.Body = dp.creative + random.Next().ToString();
                    message.IsBodyHtml = true;
                    if (i == 100 || i == 200 || i == 400 || i == 600 || i == 800 || i == 1000)
                    {
                        message.ReplyToList.Clear();
                        message.ReplyToList.Add(emailTestAfter[j]);
                        client.Send(message);
                        j++;
                    }
                    message.ReplyToList.Clear();
                   message.ReplyToList.Add(data[i]);
                   Thread.Sleep(1000);
                   client.Send(message);
                  
                    
               
                   
                }
            }









            catch (Exception e)
            {
                ViewBag.exception = e.ToString();
            }

            return View(dp);
        }
    }
}