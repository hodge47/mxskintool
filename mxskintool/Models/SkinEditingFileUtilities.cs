using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mxskintool.Models
{
    public class SkinEditingFileUtilities
    {

        public List<string> GetFilesInDirectory(string directory, string extension = "")
        {
            if (Directory.Exists(directory))
                if(!string.IsNullOrEmpty(extension))
                    return Directory.GetFiles(directory, extension).ToList();
                else
                    return Directory.GetFiles(directory).ToList();

            return new List<string>();
        }
    }
}