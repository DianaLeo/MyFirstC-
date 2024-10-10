// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Try programiz.pro");
        
        var a = new libCoinPaymentsNET.CoinPayments(
            "CB7510eA236e3893eDC0f4F717Eb3f9bA25AFe7fbF7F814B89f8e1656da78Db7",
            "b6ee01187b6e2ef551f99c440bca3d864f26f11761e65c8ae254bb636a82bbef"
            );
            
        var params7 = new SortedList<string,string>();
 
        params7.Add("currency", "BTC");
        params7.Add("version", "1");
        params7.Add("cmd", "get_callback_address");
        params7.Add("key", "b6ee01187b6e2ef551f99c440bca3d864f26f11761e65c8ae254bb636a82bbef");
        params7.Add("format", "json");
        params7.Add("ipn_url","https://payapi.luckiest.dev/api/coinpayments/withdrawcallback");
        
        var result = a.CallAPI("get_callback_address", params7);
        Console.WriteLine(string.Join(", ", result.Select(kvp => $"[{kvp.Key}: {kvp.Value}]")));
    }
}


namespace libCoinPaymentsNET
{
    public class CoinPayments
    {
        private string s_privkey = "";
        private string s_pubkey = "";
        private static readonly Encoding encoding = Encoding.UTF8;

        public CoinPayments(string privkey, string pubkey)
        {
            s_privkey = privkey;
            s_pubkey = pubkey;
            if (s_privkey.Length == 0 || s_pubkey.Length == 0)
            {
                throw new ArgumentException("Private or Public Key is empty");
            }
        }

        public Dictionary<string, dynamic> CallAPI(string cmd, SortedList<string, string> parms = null)
        {
            if (parms == null)
            {
                parms = new SortedList<string, string>();
            }
            parms["version"] = "1";
            parms["key"] = s_pubkey;
            parms["cmd"] = cmd;

            string post_data = "";
            foreach (KeyValuePair<string, string> parm in parms)
            {
                if (post_data.Length > 0) { post_data += "&"; }
                post_data += parm.Key + "=" + Uri.EscapeDataString(parm.Value);
            }

            byte [] keyBytes = encoding.GetBytes(s_privkey);
            byte [] postBytes = encoding.GetBytes(post_data);
            var hmacsha512 = new System.Security.Cryptography.HMACSHA512(keyBytes);
            string hmac = BitConverter.ToString(hmacsha512.ComputeHash(postBytes)).Replace("-", string.Empty);
            
            Console.WriteLine("hmac "+hmac);
            Console.WriteLine(post_data);

            // do the post:
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.WebClient cl = new System.Net.WebClient();
            cl.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            cl.Headers.Add("HMAC", hmac);
            //cl.Encoding = encoding;

            var ret = new Dictionary<string, dynamic>();
            try
            {
                string resp = cl.UploadString("https://www.coinpayments.net/api.php", post_data);
                Console.WriteLine("response "+resp.ToString());
                // var decoder = new System.Web.Script.Serialization.JavaScriptSerializer();
                // ret = decoder.Deserialize<Dictionary<string, dynamic>>(resp);
            }
            catch (System.Net.WebException e)
            {
                ret["error"] = "Exception while contacting CoinPayments.net: " + e.Message;
            }
            catch (Exception e)
            {
                ret["error"] = "Unknown exception: " + e.Message;
            }

            return ret;
        }
    }
}