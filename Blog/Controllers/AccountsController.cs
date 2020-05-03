using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class AccountsController : Controller
    {
        private SampleDBContext model = new SampleDBContext();
        public ActionResult Login(string name, string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                Random random = new Random();
                byte[] randomData = new byte[sizeof(long)];
                random.NextBytes(randomData);
                string newNonce = BitConverter.ToInt64(randomData, 0).ToString("X16");
                Session["Nonce"] = newNonce;
                return View(model:newNonce);

            }

            Administrator administrator = model.Administrators.Where(x => x.Name == name).FirstOrDefault();
            string nonce = Session["Nonce"] as string;

            if (administrator == null || string.IsNullOrWhiteSpace(nonce))
            {
                return RedirectToAction("Index", "Posts");
            }
            string computedHash;

            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] hashInput = Encoding.ASCII.GetBytes(administrator.Password + nonce);
                byte[] hashData = sHA256.ComputeHash(hashInput);
                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte value in hashData)
                {
                    stringBuilder.AppendFormat("{0:X2}", value);
                }
                computedHash = stringBuilder.ToString();
            }

            Session["IsAdmin"] = (computedHash.ToLower() ==hash.ToLower());
            return RedirectToAction("Index", "Posts");

        }

        public ActionResult Logout()
        {
            Session["Nonce"] = null;
            Session["IsAdmin"] = null;
            return RedirectToAction("Index", "Posts");
        }
    }
}