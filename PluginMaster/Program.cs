using Newtonsoft.Json;
using PluginMaster;

const string PLUGINS_DIRECTORY = @"K:\repos\URA-Plugins\";
var plugins = new List<PluginInformation>();
foreach (var path in Directory.EnumerateFiles(PLUGINS_DIRECTORY, "manifest.json", SearchOption.AllDirectories))
{
    if (!path.Contains("bin\\Release\\net8.0")) continue;
    plugins.Add(JsonConvert.DeserializeObject<PluginInformation>(File.ReadAllText(path))!);
}
File.WriteAllText("../../../manifests.json", JsonConvert.SerializeObject(plugins, Formatting.Indented));