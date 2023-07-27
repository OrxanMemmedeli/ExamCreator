using ExamCreator.Attributes;
using ExamCreator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace ExamCreator.Utilities.ViewGenerator
{
    public static class ViewGenerator
    {
        private static bool _initialized = false;

        public static void GenerateViews(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!_initialized && env.IsDevelopment())
            {
                var controllers = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(method => method.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), false).Length > 0)
                                .ToList();

                foreach (var controllerType in controllers)
                {
                    var controllerAreaAttribute = controllerType.GetCustomAttribute<AreaAttribute>();
                    var areaName = controllerAreaAttribute?.RouteValue;


                    var methods = controllerType.GetMethods()
                        .Where(method => method.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), false).Length > 0)
                        .ToList();

                    foreach (var method in methods)
                    {
                        var attribute = (AutoGenerateActionViewAttribute)method.GetCustomAttributes(typeof(AutoGenerateActionViewAttribute), false)[0];
                        var dtoType = attribute.DTOType;
                        var methodType = attribute.ViewType;

                        GenerateViewForMethod(areaName, controllerType, method, attribute, methodType, env);
                    }
                }
                _initialized = true;
            }

        }

        private static void GenerateViewForMethod(string area, Type controllerType, MethodInfo method, AutoGenerateActionViewAttribute attribute, MethodType methodType, IWebHostEnvironment env)
        {
            var propertyNames = attribute.DTOType.GetProperties().Select(property => property.Name).ToList();
            var viewPath = GetViewPath(area, controllerType, method, methodType, env);

            if (!Directory.Exists(viewPath.Item1))
                Directory.CreateDirectory(viewPath.Item1);

            if (!File.Exists(viewPath.Item2))
            {
                string viewContent = GenerateViewContent(area, controllerType.Name, method.Name, methodType, propertyNames, attribute.DTOType.FullName);
                File.WriteAllText(viewPath.Item2, viewContent);
            }
        }

        private static Tuple<string, string> GetViewPath(string area, Type controllerType, MethodInfo method, MethodType methodType, IWebHostEnvironment env)
        {
            var areaName = string.IsNullOrEmpty(area) ? "" : Path.Combine("Areas", area);


            var directory = Path.Combine(env.ContentRootPath, areaName, "Views", controllerType.Name.Replace("Controller", ""));

            var fileName = $"{method.Name}.cshtml";
            var filePath = Path.Combine(directory, fileName);

            return new Tuple<string, string>(directory, filePath);
        }

        public static string GenerateViewContent(string areaName, string controllerName, string actionName, MethodType methodType, List<string> propertyNames, string modelName)
        {
            string content = string.Empty;

            if (methodType == MethodType.List)
            {
                var tableHeaders = string.Join("", propertyNames.Select(prop => $"<th>{prop}</th>\n\r"));
                var tableBody = GenerateListViewBodyContent(areaName, controllerName, propertyNames);

                content = $@"
$@model IEnumerable<{modelName}>

@{{
    ViewData[""Title""] = ""{modelName}"";
                    Layout = ""~/Views/Shared/_AdminLayout.cshtml""; //Layouta  diqqet et
}}

<h1>@ViewData[""Title""]</h1>

<p>
    <a asp-action=""Create"" class=""btn btn-vimeo"" title=""Yeni məlumat"" style=""justify-content: center;"">
        Yeni
        <lord-icon src=""https://cdn.lordicon.com/rfbqeber.json""
                    trigger=""hover""
                    style=""width:40px;height:40px"">
        </lord-icon>
    </a>
</p>

<div class=""table-responsive"">
    <table class=""table table-striped"">
        <thead>
            <tr>
                {tableHeaders}
                <th></th>
            </tr>
        </thead>
        <tbody>
           @foreach (var item in Model)
            {{
                {tableBody}
            }}
        </tbody>
    </table>
</div>";
            }
            else if (methodType == MethodType.Create || methodType == MethodType.Edit)
            {
                var propertyInputs = GeneratePropertyInputsContent(propertyNames);


                var tittle = methodType == MethodType.Edit ? $"{modelName.ToUpper()} Yenilə" : $"Yeni {modelName.ToUpper()}";
                var hiddenID = methodType == MethodType.Edit ? "<input asp-for=\"Id\" hidden value=\"@Model.Id\" />" : "";
                var buttonName = methodType == MethodType.Edit ? "Yenilə" : "Əlavə Et";

                content = $@"
@model {modelName}

@{{
    ViewData[""Title""] = ""{tittle}"";
                    Layout = ""~/Views/Shared/_AdminLayout.cshtml""; //Layouta  diqqet et
}}

<h1>@ViewData[""Title""]</h1>

<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""{actionName}"" method=""post"">
            <div asp-validation-summary=""All"" class=""text-danger""></div>
            {hiddenID}

            {propertyInputs}
            <div class=""form-group"">
                <input type=""submit"" value=""{buttonName}"" class=""btn btn-primary"" />
                <a asp-action=""Index"" class=""btn btn-dark"">Geri</a>
            </div>
        </form>
    </div>
</div>";
            }

            return content;
        }


        private static string GenerateListViewBodyContent(string areaName, string controllerName, List<string> propertyNames)
        {
            var rows = "<tr>";
            foreach (var propName in propertyNames)
                rows += $@"{string.Join("", propertyNames.Select(prop => $@"<td>@item.{prop}</td>"))}";

            rows += $@"
            <td>
                @await Html.PartialAsync(""~/Views/Shared/_ToolsButtonPartial.cshtml"", new ToolsButtonViewModel{{ Area=""{areaName}"", Controller=""{controllerName}"", RouteId = @item.Id.ToString()}})
            </td>
            </tr>";

            return rows;
        }

        private static string GeneratePropertyInputsContent(List<string> propertyNames)
        {
            var propertyInputs = "";
            foreach (var propName in propertyNames)
            {
                propertyInputs += $@"
            <div class=""form-group"">
                <label asp-for=""{propName}"" class=""control-label"">{propName}</label>
                <input asp-for=""{propName}"" class=""form-control"" value=""@Model?.{propName}"" />
                <span asp-validation-for=""{propName}"" class=""text-danger""></span>
            </div>";
            }

            return propertyInputs;
        }
    }
}
