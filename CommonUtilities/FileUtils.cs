namespace CommonUtilities
{
    public static class FileUtils
    {
        public static string GetTempFilePath(string extension)
        {
            string tempFileName = Path.GetRandomFileName();
            string tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);

            return Path.ChangeExtension(tempFilePath, extension);
        }

        public static void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        // Add more utility methods here as needed
    }
}