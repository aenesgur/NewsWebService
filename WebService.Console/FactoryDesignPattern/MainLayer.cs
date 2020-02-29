using WebService.Console.Emlak;
using WebService.Console.Mahmure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml.Linq;
using WebService.ClassLibrary;

namespace WebService.Console
{

    public interface IType
    {
        void Olustur();
    }

    public class JsonTypeBigPara : IType
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].
             ConnectionString;

        public void Olustur()
        {

            var url = ConfigurationSettings.AppSettings["BigParaUrl"];

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Credentials = CredentialCache.DefaultCredentials;

            httpRequest.Timeout = Timeout.Infinite;

            var httpResponse = httpRequest.GetResponse();

            string result = null;

            using (var stream = ((HttpWebResponse)httpResponse).GetResponseStream())
            {
                result = stream != null ? new StreamReader(stream).ReadToEnd() : null;
            }
            List<BigParaEntities> bigPara = JsonConvert.DeserializeObject<List<BigParaEntities>>(result);

            SqlHelper sqlHelper = new SqlHelper();
            
            int OrderOfAdding = 1;
            foreach (var item in bigPara)
            {
                sqlHelper.InsertEntity(item.Title, item.Spot, item.ImagePath, item.Link, (int)CategoryType.BigPara,OrderOfAdding );
                OrderOfAdding=OrderOfAdding+1;
            }

           System.Console.WriteLine("bigpara.json deserialize edildi ve veritabanına kaydedildi");
        }
    }

    public class XmlTypeEmlak : IType
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].
       ConnectionString;
        public void Olustur()
        {
            var path = Path.Combine(ConfigurationSettings.AppSettings["EmlakUrl"]);
            XDocument xDoc = XDocument.Load(path);
            List<EmlakEntities> hurriyetEmlaks = xDoc.Elements().Elements()
                            .Select(url =>
                            {
                                EmlakEntities data = new EmlakEntities();
                                foreach (var item in url.Elements())
                                {
                                    switch (item.Name.LocalName)
                                    {
                                        case "adv_city_id":
                                            data.adv_city_id = item.Value;
                                            break;
                                        case "adv_def_link":
                                            data.adv_def_link = item.Value;
                                            break;
                                        case "adv_image":
                                            data.adv_image = item.Value;
                                            break;
                                        case "adv_imagename":
                                            data.adv_imagename = item.Value;
                                            break;
                                        case "adv_location":
                                            data.adv_location = item.Value;
                                            break;
                                        case "adv_price":
                                            data.adv_price = item.Value;
                                            break;
                                        case "adv_text":
                                            data.adv_text = item.Value;
                                            break;
                                        case "adv_title":
                                            data.adv_title = item.Value;
                                            break;
                                    }
                                    var s = item.Name.LocalName;
                                }
                                return data;
                            }).ToList();

            SqlHelper sqlHelper = new SqlHelper();
            int OrderOfAdding = 1;
            foreach (var item in hurriyetEmlaks)
            {
                sqlHelper.InsertEntity(item.adv_title, item.adv_text, item.adv_image, item.adv_def_link, (int)CategoryType.Emlak, OrderOfAdding);
                OrderOfAdding = OrderOfAdding + 1;
            }
            System.Console.WriteLine("emlak.xml deserialize edildi ve veritabanına kaydedildi");
        }
    }

    public class XmlTypeMahmure : IType
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].
             ConnectionString;

        public void Olustur()
        {
            var url = ConfigurationSettings.AppSettings["MahmureUrl"];

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Credentials = CredentialCache.DefaultCredentials;

            httpRequest.Timeout = Timeout.Infinite;

            var httpResponse = httpRequest.GetResponse();

            string result = null;

            var stream = ((HttpWebResponse)httpResponse).GetResponseStream();

            XDocument xDoc = XDocument.Load(url);
            List<MahmureEntities> mahmureEntities = xDoc.Elements().Elements()
                            .Select(x =>
                            {
                                MahmureEntities data2 = new MahmureEntities();
                                foreach (var item in x.Elements())
                                {
                                    switch (item.Name.LocalName)
                                    {
                                        case "BASLIK":
                                            data2.BASLIK = item.Value;
                                            break;
                                        case "LINK":
                                            data2.LINK = item.Value;
                                            break;
                                        case "METIN":
                                            data2.METIN = item.Value;
                                            break;
                                        case "RESIM":
                                            data2.RESIM = item.Value;
                                            break;
                                        case "RESIMADI":
                                            data2.RESIMADI = item.Value;
                                            break;
                                        case "TARIH":
                                            data2.TARIH = item.Value;
                                            break;
                                    }
                                    var s = item.Name.LocalName;
                                }
                                return data2;
                            }).ToList();

            SqlHelper sqlHelper = new SqlHelper();
            int OrderOfAdding = 1;
            foreach (var item in mahmureEntities)
            {
                sqlHelper.InsertEntity(item.BASLIK, item.METIN, item.RESIM, item.LINK, (int)CategoryType.Mahmure, OrderOfAdding);
                OrderOfAdding = OrderOfAdding + 1;
            }

            System.Console.WriteLine("mahmure.xml deserialize edildi ve veritabanına kaydedildi");
        }
    }
}



