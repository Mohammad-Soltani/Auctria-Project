﻿using System.ComponentModel.DataAnnotations;

namespace AuctriaProject.Application.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
