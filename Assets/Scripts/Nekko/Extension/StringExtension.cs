using System;

namespace Nekko.Extension
{
    public static class StringExtension
    {
        public static string WithoutFileExtension(this string filePath)
        {
            var fileExtPos = filePath.LastIndexOf(".", StringComparison.Ordinal);
            return fileExtPos >= 0 ? filePath[..fileExtPos] : filePath;
        }
    }
}