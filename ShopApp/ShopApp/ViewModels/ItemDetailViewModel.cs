﻿using System;

using ShopApp.Models;

namespace ShopApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.ItemName;
            Item = item;
        }
    }
}
