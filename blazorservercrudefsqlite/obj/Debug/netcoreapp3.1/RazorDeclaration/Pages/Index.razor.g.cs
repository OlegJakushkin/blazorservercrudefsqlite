// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace blazorservercrudefsqlite.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using blazorservercrudefsqlite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using blazorservercrudefsqlite.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\_Imports.razor"
using blazorservercrudefsqlite.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 181 "C:\Users\panda\Documents\GitHub\blazorservercrudefsqlite\blazorservercrudefsqlite\Pages\Index.razor"
       
    List<Org> Orgs = new List<Org>();
    List<User> Users = new List<User>();
    List<Relation> Relations = new List<Relation>();

    protected override async Task OnInitializedAsync()
    {
        await RefreshProducts();
    }

    private async Task RefreshProducts()
    {
        Orgs = await service.GetOrgsAsync();
        Users = await service.GetUsersAsync();
        Relations = await service.GetRelationsAsync();
    }


    public Org NewOrg { get; set; } = new Org();
    public User NewUser { get; set; } = new User();

    private async Task AddNewProduct()
    {
        await service.AddOrgAsync(NewOrg);
        NewOrg = new Org();
        await RefreshProducts();
    }

    Org _updateOrg = new Org();

    private void SetProductForUpdate(Org org)
    {
        _updateOrg = org;
    }

    private async Task UpdateProductData()
    {
        await service.UpdateOrgAsync(_updateOrg);
        await RefreshProducts();
    }

    private async Task DeleteProduct(Org org)
    {
        await service.DeleteOrgAsync(org);
        await RefreshProducts();
    }

    // ------------------ Users ----------
    private async Task AddNewUser()
    {
        await service.AddUserAsync(NewUser);
        NewUser = new User();
        await RefreshProducts();
    }

    User _updateUser = new User();

    private void SetUserForUpdate(User org)
    {
        _updateUser = org;
    }

    private async Task UpdateUserData()
    {
        await service.UpdateUserAsync(_updateUser);
        await RefreshProducts();
    }

    private async Task AddUserOrgData()
    {
        await service.UpdateUserOrgAsync(_updateUser, _updateOrg);
        await RefreshProducts();
    }

    private async Task DeleteUser(User org)
    {
        await service.DeleteUserAsync(org);
        await RefreshProducts();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DbController service { get; set; }
    }
}
#pragma warning restore 1591
