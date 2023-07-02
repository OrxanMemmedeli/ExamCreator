using DataAccess.Concrete.Context;
using EntityLayer.Concrete.ForRoles;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ExamCreator.Utilities.AreaControllerActionFinder
{
    public static class NameFinder
    {
        //public static async void Find(this IServiceCollection services)
        //{
        //    var serviceProvider = services.BuildServiceProvider();
        //    var actionDescriptorCollectionProvider = serviceProvider.GetService<IActionDescriptorCollectionProvider>();
        //    var actionDescriptors = actionDescriptorCollectionProvider.ActionDescriptors.Items;



        //    var URLList = new List<string>();
        //    var createList = new List<RoleUrl>();
        //    var deleteList = new List<RoleUrl>();

        //    var areaNames = actionDescriptors.OfType<ControllerActionDescriptor>()
        //           .Select(descriptor => descriptor.RouteValues["area"])
        //           .Distinct()
        //           .ToList();


        //    foreach (var area in areaNames)
        //    {
        //        var controllerNames = actionDescriptors.OfType<ControllerActionDescriptor>()
        //            .Where(descriptor => string.Equals(descriptor.RouteValues["area"], area))
        //            .Select(descriptor => descriptor.ControllerName)
        //            .Distinct()
        //            .ToList();


        //        foreach (var controller in controllerNames)
        //        {
        //            var actionNames = actionDescriptors.OfType<ControllerActionDescriptor>()
        //                .Where(descriptor => string.Equals(descriptor.RouteValues["area"], area) &&
        //                                      string.Equals(descriptor.ControllerName, controller))
        //                .Select(descriptor => descriptor.ActionName)
        //                .Distinct()
        //                .ToList();


        //            foreach (var action in actionNames)
        //            {
        //                var url = area != null ? $"/{area}/{controller}/{action}" : $"/{controller}/{action}";
        //                URLList.Add(url);
        //            }
        //        }
        //    }

        //    if (URLList.Count > 0)
        //    {
        //        //var dbContext = serviceProvider.GetRequiredService<ECContext>();
        //        using (ECContext dbContext = new())
        //        {
        //            var oldList = dbContext.RoleUrls.ToList();

        //            foreach (var url in URLList)
        //            {
        //                if (!oldList.Select(x => x.Url).Contains(url))
        //                    createList.Add(new RoleUrl() { Url = url });
        //            }

        //            foreach (var old in oldList)
        //            {
        //                if (!URLList.Contains(old.Url))
        //                    deleteList.Add(old);
        //            }

        //            if (createList.Count > 0)
        //                await dbContext.RoleUrls.AddRangeAsync(createList);

        //            if (deleteList.Count > 0)
        //                dbContext.RoleUrls.RemoveRange(deleteList);

        //            await dbContext.SaveChangesAsync();
        //        }
        //    }
        //}

        public static async void Find(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var actionDescriptorCollectionProvider = serviceProvider.GetService<IActionDescriptorCollectionProvider>();
            var actionDescriptors = actionDescriptorCollectionProvider.ActionDescriptors.Items;

            var URLList = new List<string>();
            var createList = new List<RoleUrl>();
            var deleteList = new List<RoleUrl>();

            var areaNames = actionDescriptors.OfType<ControllerActionDescriptor>()
                .Select(descriptor => descriptor.RouteValues["area"])
                .Distinct()
                .ToList();

            foreach (var area in areaNames)
            {
                var controllerNames = actionDescriptors.OfType<ControllerActionDescriptor>()
                    .Where(descriptor => string.Equals(descriptor.RouteValues["area"], area))
                    .Select(descriptor => descriptor.ControllerName)
                    .Distinct()
                    .ToList();

                foreach (var controller in controllerNames)
                {
                    var actionNames = actionDescriptors.OfType<ControllerActionDescriptor>()
                        .Where(descriptor => string.Equals(descriptor.RouteValues["area"], area) &&
                                              string.Equals(descriptor.ControllerName, controller))
                        .Select(descriptor => descriptor.ActionName)
                        .Distinct()
                        .ToList();

                    foreach (var action in actionNames)
                    {
                        var url = area != null ? $"/{area}/{controller}/{action}" : $"/{controller}/{action}";
                        URLList.Add(url);
                    }
                }
            }

            if (URLList.Count > 0)
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ECContext>();

                    var oldList = dbContext.RoleUrls.ToList();

                    foreach (var url in URLList)
                    {
                        if (!oldList.Select(x => x.Url).Contains(url))
                            createList.Add(new RoleUrl() { Url = url });
                    }

                    foreach (var old in oldList)
                    {
                        if (!URLList.Contains(old.Url))
                            deleteList.Add(old);
                    }

                    if (createList.Count > 0)
                        await dbContext.RoleUrls.AddRangeAsync(createList);

                    if (deleteList.Count > 0)
                        dbContext.RoleUrls.RemoveRange(deleteList);

                    await dbContext.SaveChangesAsync();
                }
            }
        }

    }
}
