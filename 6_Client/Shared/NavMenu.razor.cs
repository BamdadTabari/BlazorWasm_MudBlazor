using illegible.Client.Extensions.TelerikBlazorExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace illegible.Client.Shared
{
    public partial class NavMenu
    {
        #region Drawer Data

        public TelerikDrawer<DrawerItem> Drawer { get; set; }
        public DrawerItem SelectedItem { get; set; }
        public IEnumerable<DrawerItem> Data { get; set; } =
            new List<DrawerItem>
            {
            new DrawerItem
            {
                Text = "Home",
                Icon = "home",
                Url = "/"
            },
            //new DrawerItem { Separator = true},
            new DrawerItem
            {
                Text = "AllPost",
                Icon = "paperclip",
                Url = "/AllPost"
            },
            //new DrawerItem { Separator = true},
            new DrawerItem
            {
                Text = "addBlogPost",
                Icon = "grid",
                Url = "/addBlogPost"
            },
             new DrawerItem
            {
                Text = "createPost",
                Icon = "star",
                Url = "/createPost"
            },
            //new DrawerItem { Separator = true},
            new DrawerItem
            {
                Text = "PagedBlogPosts",
                Icon = "globe",
                Url = "/PagedBlogPosts"
            },
            //new DrawerItem { Separator = true},
            new DrawerItem
            {
                Text = "register",
                Icon = "hand",
                Url = "/register"
            },
            //new DrawerItem { Separator = true},
            new DrawerItem
            {
                Text = "login",
                Icon = "login",
                Url = "/login"
            },
            //new DrawerItem { Separator = true},
            new DrawerItem
            {
                Text = "logout",
                Icon = "logout",
                Url = "/logout"
            },
            
            };

        #endregion

        #region Drawer Methods

        protected override Task OnInitializedAsync()
        {
            SelectedItem = Data.First();

            return base.OnInitializedAsync();
        }

        public async Task ToggleDrawer() => await Drawer.ToggleAsync();

        #endregion
    }
}
