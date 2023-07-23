using ExamCreator.Attributes;
using ExamCreator.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace ExamCreator.Middlewares
{
    public class AutoGenerateViewMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        public AutoGenerateViewMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_env.IsDevelopment())
            {
                var endpoint = context.GetEndpoint();

                if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() is ControllerActionDescriptor actionDescriptor)
                {
                    var hasControllerAttribute = actionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), true).Any();
                    //var hasActionAttribute = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), true).Any();

                    // New code starts here
                    var methodHasActionAttribute = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), true).Any();
                    var baseControllerType = actionDescriptor.ControllerTypeInfo.BaseType;
                    var baseMethodHasActionAttribute = baseControllerType.GetMethod(actionDescriptor.MethodInfo.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, Type.DefaultBinder, new Type[] { /* Parameter types of the method (if any) */ }, null)?.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), true).Any() ?? false;

                    var hasActionAttribute = methodHasActionAttribute || baseMethodHasActionAttribute;
                    // New code ends here


                    if (hasControllerAttribute && hasActionAttribute)
                    {
                        // View oluşturma işlemleri
                        GenerateViewForAction(actionDescriptor, _env);
                    }
                }
            }

            await _next(context);
        }

        private void GenerateViewForAction(ControllerActionDescriptor actionDescriptor, IWebHostEnvironment env)
        {
            var controllerAttribute = actionDescriptor.ControllerTypeInfo.GetCustomAttribute<AutoGenerateActionViewAttribute>();
            var actionAttribute = actionDescriptor.MethodInfo.GetCustomAttribute<AutoGenerateActionViewAttribute>();

            if (actionAttribute != null && controllerAttribute != null)
            {
                var viewType = actionAttribute.ViewType;

                if (viewType == MethodType.List)
                    GenerateListViewContent(actionDescriptor, env, controllerAttribute.ListDTOType);
                else if (viewType == MethodType.Create)
                    GenerateFormViewContent(actionDescriptor, env, viewType, controllerAttribute.CreateDTOType);
                else if (viewType == MethodType.Edit)
                    GenerateFormViewContent(actionDescriptor, env, viewType, controllerAttribute.EditDTOType);
            }
        }

        private string GetArea(ControllerActionDescriptor actionDescriptor)
        {
            var areaRouteData = actionDescriptor.RouteValues["area"];
            if (!string.IsNullOrEmpty(areaRouteData))
                return areaRouteData;
            return null;
        }


        // List view içeriği oluşturan metot
        private void GenerateListViewContent(ControllerActionDescriptor actionDescriptor, IWebHostEnvironment env, Type listType)
        {
            // Burada actionDescriptor'ü kullanarak model türünü elde edebilir ve tabloya benzeyen view içeriği oluşturabilirsiniz.
            // Örnek olarak, modeldeki property'leri tablo satırları olarak listeleyebilirsiniz.
            var modelType = listType;
            if (modelType != null)
            {
                // Tablo için gerekli C# kodları ve Razor syntax'ı

                var areaName = GetArea(actionDescriptor);
                var controllerName = actionDescriptor.ControllerName.Replace("Controller", "");
                var actionName = actionDescriptor.ActionName;
                var tableHeaders = string.Join("", modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(p => $"<th>{p.Name}</th>"));

                var tableBody = $@"
                    @foreach (var item in Model)
                    {{
                        <tr>
                            {string.Join("", modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(p => $@"<td>@item.{p.Name}</td>"))}
                            <td>
                                @await Html.PartialAsync(""~/Views/Shared/_ToolsButtonPartial.cshtml"", new ToolsButtonViewModel{{ Area=""{areaName}"", Controller=""{controllerName}"", RouteId = @item.Id.ToString()}})
                            </td>                        
                        </tr>
                    }}";

                var viewContent = $@"
                    @{{
                        ViewData[""Title""] = ""{nameof(controllerName).ToUpper()}"";
                        Layout = ""~/Views/Shared/_AdminLayout.cshtml"";
                    }}

                    <h1>""{nameof(controllerName).ToUpper()}""</h1>


                    <p>
                        <a asp-action=""Create"" class=""btn btn-vimeo"" title=""Yeni məlumat"" style=""justify-content: center;"">
                            Yeni ""{nameof(modelType).ToUpper()}""
                            <lord-icon src=""https://cdn.lordicon.com/rfbqeber.json""
                                        trigger=""hover""
                                        style=""width:40px;height:40px"">
                            </lord-icon>
                        </a>
                    </p>
                    <div class=""table-responsive"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    {tableHeaders}
                                </tr>
                            </thead>
                            <tbody>
                                {tableBody}

                            </tbody>
                        </table>
                    </div>";
                SaveViewFile(actionDescriptor, env, viewContent);
            }
        }

        // Create ve Edit form view içeriği oluşturan metot
        private void GenerateFormViewContent(ControllerActionDescriptor actionDescriptor, IWebHostEnvironment env, MethodType viewType, Type type)
        {
            var modelType = type;
            if (modelType != null)
            {
                // Create ve Edit için gerekli C# kodları ve Razor syntax'ı oluşturun
                var properties = modelType.GetProperties().Where(p => p.DeclaringType == modelType).Select(p => $@"
                <div class=""form-group"">
                    <label asp-for=""{p.Name}"" class=""control-label"">{p.Name}</label>
                    <input asp-for=""{p.Name}"" class=""form-control""  value=""@Model?.{p.Name}"" />
                  <span asp-validation-for=""{p.Name}"" class=""text-danger""></span>
                </div>");


                var tittle = viewType == MethodType.Edit ? $"{nameof(modelType).ToUpper()} Yenilə" : $"Yeni {nameof(modelType).ToUpper()}";
                var hiddenID = viewType == MethodType.Edit ? "<input asp-for=\"Id\" hidden value=\"@Model.Id\" />" : "";

                var viewContent = $@"
                @{{
                    ViewData[""Title""] = ""{tittle}"";
                    Layout = ""~/Views/Shared/_AdminLayout.cshtml""; //Layouta  diqqet et
                }}

                <h4>""{tittle}""</h4>
                <hr />

                <div class=""row"">
                    <div class=""col-md-4"">
                        <form asp-action=""{Enum.GetName(typeof(MethodType), viewType)}"" method=""post"">
                            <div asp-validation-summary=""All"" class=""text-danger""></div>
                            {hiddenID}

                            {string.Join("\n\n", properties)}

                            <div class=""form-group"">
                                <input type=""submit"" value=""Əlavə Et"" class=""btn btn-primary"" />
                                <a asp-action=""Index"" class=""btn btn-dark"">Geri</a>
                            </div>
                        </form>
                    </div>
                </div>";
                SaveViewFile(actionDescriptor, env, viewContent);
            }
        }

        private void SaveViewFile(ControllerActionDescriptor actionDescriptor, IWebHostEnvironment env, string viewContent)
        {
            var areaName = GetArea(actionDescriptor) == null ? "" : Path.Combine("Areas", GetArea(actionDescriptor));
            var controllerName = actionDescriptor.ControllerName.Replace("Controller", "");
            var actionName = actionDescriptor.ActionName;

            var viewPathForDirectory = Path.Combine(env.ContentRootPath, areaName, "Views", controllerName);
            var viewPathForFile = Path.Combine(env.ContentRootPath, areaName, "Views", controllerName, $"{actionName}.cshtml");

            if (!Directory.Exists(viewPathForDirectory))
                Directory.CreateDirectory(viewPathForDirectory);


            if (!File.Exists(viewPathForFile))
                File.WriteAllText(viewPathForFile, viewContent);

        }

    }

    public static class AutoGenerateViewMiddlewareExtensions
    {
        public static IApplicationBuilder UseAutoGenerateViewMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AutoGenerateViewMiddleware>();
        }
    }



}
