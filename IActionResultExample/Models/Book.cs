﻿using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
       // [FromQuery]
        public int ? BookId {get; set; }    
        public string? Author { get; set; }
        public override string ToString()
        {
            return $"Book objcect - Book id:{BookId}, Author:{Author}";
        }
    }
}
