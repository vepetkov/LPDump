using System.Diagnostics;
using System.IO;

namespace LPDump
{
    public static class Extensions
    {
        public static T Dump<T>(this T source, string description = "", int level = 5)
        {
            var localUrl = Path.GetTempFileName() + ".html";
            using (var writer = LINQPad.Util.CreateXhtmlWriter(true, level, false))
            {
                writer.WriteLine(LINQPad.Util.RawHtml(string.Format("<div style=\"font-weight:bold;background-color: white;color: green;\">{0}</div>", description)));
                writer.Write(source);
                File.WriteAllText(localUrl, writer.ToString());
            }
            Process.Start(localUrl);
            return source;
        }
    }
}
