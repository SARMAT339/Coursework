﻿using System;
using CaesarCipherApp.Models;
using Coursework.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaesarCipherApp.Controllers
{
    public class CaesarController : Controller
    {
        public ActionResult Index()
        {
            return View(new Caesar());
        }

        [HttpPost]
        public ActionResult Index(Caesar model, string action)
        {
            if (action == "encrypt")
            {
                model.OutputText = CaesarCipher.Encrypt(model.InputText, model.Key);
            }
            else if (action == "decrypt")
            {
                model.OutputText = CaesarCipher.Decrypt(model.InputText, model.Key);
            }
            else
            {
                model.OutputText = "Ошибка: выберите действие.";
            }

            return View(model);
        }

    }
}