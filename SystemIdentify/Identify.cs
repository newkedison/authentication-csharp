using System.Management;

// Reference
// https://msdn.microsoft.com/en-us/library/aa389273(v=vs.85).aspx
// http://www.codeproject.com/Articles/17973/How-To-Get-Hardware-Information-CPU-ID-MainBoard-I

namespace SystemIdentify
{
    public static class Identify
    {
        public static string CPUIdentify()
        {
            var searcher = new ManagementObjectSearcher(
                "select * from Win32_processor");
            var objects = searcher.Get();
            if (objects.Count == 0) return "";
            foreach (var obj in objects)
            {
                var value = obj["ProcessorID"];
                if (value != null)
                {
                    return value.ToString();
                }
            }
            return "";
        }

        public static string MainBoardIdentify()
        {
            var searcher = new ManagementObjectSearcher(
                "select * from Win32_BaseBoard");
            var objects = searcher.Get();
            if (objects.Count == 0) return "";
            foreach (var obj in objects)
            {
                var value = obj["SerialNumber"];
                if (value != null)
                {
                    return value.ToString();
                }
            }
            return "";
        }

        public static string MACIdentify()
        {
            var searcher = new ManagementObjectSearcher(
                "select * from Win32_NetworkAdapterConfiguration");
            var objects = searcher.Get();
            if (objects.Count == 0) return "";
            foreach (var obj in objects)
            {
                if (obj["IPEnabled"] != null
                    && obj["IPEnabled"].ToString() == "True")
                {
                    var value = obj["MacAddress"];
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }
            return "";
        }


    }
}
