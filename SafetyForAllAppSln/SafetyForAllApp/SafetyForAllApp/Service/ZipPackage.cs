using SafetyForAllApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace SafetyForAllApp.Service
{
   public class ZipPackage : IContentPackage
   {
        public void ExtractResourceFiles(string source, string destination, string zipFileName)
        {
            var sourcePath = Path.Combine(source, zipFileName);

            try
            {
                Directory.Delete(destination, true);

                if (File.Exists(sourcePath))
                {
                    using (var zip = ZipFile.Open(sourcePath, ZipArchiveMode.Read))
                    {
                        //  var resourceContentPath = GetContentResourceStorePath();

                        foreach (var entry in zip.Entries)
                        {
                            var fullName = Path.Combine(destination, entry.FullName);

                            if (string.IsNullOrEmpty(entry.Name))
                                Directory.CreateDirectory(fullName);
                         //   else
                         //       entry.ExtractToFile(fullName,true);
                        }

                        foreach (var entry in zip.Entries)
                        {
                            var fullName = Path.Combine(destination, entry.FullName);

                            if (!string.IsNullOrEmpty(entry.Name))
                                   entry.ExtractToFile(fullName,true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
