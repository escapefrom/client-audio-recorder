using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AudioDialogRecorder.Core
{
    public static class IOReader
    {
        public static T ReadJsonFile<T>(string path)
            => JsonSerializer.Deserialize<T>(File.ReadAllText(path));
    }
}
