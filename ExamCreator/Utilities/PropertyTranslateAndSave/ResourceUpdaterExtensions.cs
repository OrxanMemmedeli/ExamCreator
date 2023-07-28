using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Resources;
using System.IO;
using System.Collections.Generic;
using Google.Cloud.Translation.V2;
using CoreLayer.Constants;

namespace ExamCreator.Utilities.PropertyTranslateAndSave
{
    public static class ResourceUpdaterExtensions
    {
        private static bool _initialized = false;

        public static void UpdateResourceFile(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!_initialized && env.IsDevelopment())
            {
                // Solution path
                string projectFolderPath = GetProjectFolderPath();

                // UI.resx və layerlərin yolu
                string uiResourceFilePath = Path.Combine(projectFolderPath, "Core", "Constants", "UI.resx");
                string entitiesPath = Path.Combine(projectFolderPath, "EntityLayer", "Concrete");
                string dtosPath = Path.Combine(projectFolderPath, "DTOLayer", "DTOs");

                // EntityLayer və DTOLayer klasörlerini gezerek property isimlerini alıyoruz
                List<string> propertyNames = GetPropertyNamesFromCsFiles(projectFolderPath, entitiesPath);
                propertyNames.AddRange(GetPropertyNamesFromCsFiles(projectFolderPath, dtosPath));

                // UI.resx dosyasını yüklüyoruz
                ResourceManager resourceManager = new ResourceManager(typeof(CoreLayer.Constants.UI));
                ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);

                // Google Translate API Client'ı oluşturuyoruz
                TranslationClient translationClient = TranslationClient.Create();

                // UI.resx dosyasını güncelliyoruz
                ResourceWriter resourceWriter = new ResourceWriter(uiResourceFilePath);
                foreach (string propertyName in propertyNames)
                {
                    if (!ResourceExists(propertyName, resourceSet))
                    {
                        // C# camelCase yapısına uygun değeri kelimelere ayırıyoruz
                        string[] words = SplitCamelCase(propertyName);

                        // Property ismi UI.resx dosyasında yoksa, Azerbaycan diline çevirerek ekliyoruz
                        string azerbaijaniValue = GetAzerbaijaniEquivalent(propertyName, translationClient);
                        resourceWriter.AddResource(propertyName, azerbaijaniValue);
                    }
                }

                // Kaynakları kaydediyoruz ve işlemi tamamlıyoruz
                resourceWriter.Generate();
                resourceWriter.Close();
            }
        }

        private static string GetProjectFolderPath()
        {
            // Proyektin ünvanı
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // qovluqlar olan yerə gəlmək üçün 4 dəfə geri cıxılır
            string projectFolderPath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));

            return projectFolderPath;
        }



        private static bool ResourceExists(string resourceName, ResourceSet resourceSet)
        {
            // Check if the given resourceName exists in the ResourceSet
            foreach (DictionaryEntry entry in resourceSet)
            {
                if (entry.Key.ToString() == resourceName)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<string> GetPropertyNamesFromCsFiles(string projectFolderPath, string folderPath)
        {
            List<string> propertyNames = new List<string>();
            string fullFolderPath = Path.Combine(projectFolderPath, folderPath);

            if (!Directory.Exists(fullFolderPath))
                return propertyNames;

            string[] files = Directory.GetFiles(fullFolderPath, "*.cs", SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                // Dosya içeriğini okuyoruz ve property isimlerini alıyoruz
                string fileContent = File.ReadAllText(filePath);
                var properties = fileContent.Split(new[] { ' ', '\n', '\r', '\t', '(', ')', ';', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where((token, index) => token == "public" || token == "private" || token == "protected" || token == "internal")
                    .Select((token, index) => fileContent.Split(new[] { ' ', '\n', '\r', '\t', '(', ')', ';', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)[index + 1])
                    .Where(token => token != "class" && token != "interface" && token != "enum" && token != "struct" && token != "delegate")
                    .ToList();

                //propertyNames.AddRange(test);
            }

            return propertyNames.Distinct().ToList();
        }


        private static string GetAzerbaijaniEquivalent(string propertyName, TranslationClient translationClient)
        {
            // Google Translate API'sini kullanarak propertyName'i Azerbaycan diline çeviriyoruz
            TranslationResult result = translationClient.TranslateText(propertyName, "az");
            return result.TranslatedText;
        }

        private static string[] SplitCamelCase(string input)
        {
            // C# camelCase yapısına uygun değeri kelimelere ayıran fonksiyon
            return Regex.Split(input, @"(?<!^)(?=[A-Z])");

        }
    }
}
