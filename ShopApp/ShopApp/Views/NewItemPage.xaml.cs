using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ShopApp.Models;

namespace ShopApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            Item item = new Item();
           
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item itm = new Item();
            itm.ItemCode = "0003";
            itm.ItemName = ItemName.Text;
            itm.Qty =Convert.ToInt32(Qty.Text);
            itm.Price = Convert.ToDouble(Price.Text);
            itm.TotalPrice = itm.Qty * itm.Price;
            MessagingCenter.Send(this, "AddItem", itm);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}