using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Extention
{
    public class MyValid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool) value;
        }
    }
}