using AppBanca.Models.Domain;
using AppBanca.Models.Dtos;
using AppBanca.Web.Services.Intefaces;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Grids;
using Action = Syncfusion.Blazor.Grids.Action;

namespace AppBanca.Web.Pages.Bases;

public class ProdutosBase : ComponentBase
{
    [Inject]
    public IBancaService<ProductDto>? ProductService { get; set; }
    [Inject]
    public IBancaService<SupplierDto>? SupplierService { get; set; }
    [Inject]
    public IBancaService<CategoryDto>? CategoryService { get; set; }
    //[Inject]
    public IEnumerable<ProductDto>? ProductsDto { get; set; }
    public IEnumerable<SupplierDto>? SuppliersDto { get; set; }
    public IEnumerable<CategoryDto>? CategoriesDto { get; set; }
    public SfGrid<ProductDto>? SfProductsGrid { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ProductsDto = await ProductService.GetItems("/produtos");
        SuppliersDto = await SupplierService.GetItems("/fornecedores");
        CategoriesDto = await CategoryService.GetItems("/categorias");
         
    }

    public async void ActionBeginHandler(ActionEventArgs<ProductDto> args)
    {
        var item = args.Data;

        if (args.RequestType.Equals(Action.Save))
        {
            if (args.Action == "Add")
            {
                
                await ProductService.AddItem(item, "/produtos");
            }
            if(args.Action == "Edit")
            {
                await ProductService.UpdateItem(item, "/produtos");                
            }
        }
        else if (args.RequestType.Equals(Action.Delete))
        {
            await ProductService.DeleteItem($"/produtos/{item.Id}");
        }
    }
    public async void ActionCompleteHandler(ActionEventArgs<ProductDto> args)
    {
        if (args.RequestType.Equals(Action.Save))
        {
            if (args.Action == "Add" || args.Action =="Edit")
            {
                ProductsDto = await ProductService.GetItems("/produtos");
                SfProductsGrid?.Refresh();

            }
        }
    }
}
