using Business.Context;
using DataAccess.Entities;
using Newtonsoft.Json;
using RestSharp;



namespace DataTransferAppForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Idata = File.ReadAllText("spot.json");
            var Ijsondata = JsonConvert.DeserializeObject<List<Spot>>(Idata);
            var context = new ApplicationDbContext();
            var Data = context.Spot.ToList();
            if (Data == null && Data.Count == 0)
            {
                foreach (var data in Ijsondata)
                {

                    context.Spot.Add(data);
                    context.SaveChanges(); //commitlemek için
                }

            }
            else
            {
                context.Spot.RemoveRange(Data);
                context.SaveChanges();
                foreach (var data in Ijsondata)
                {

                    context.Spot.Add(data);
                    context.SaveChanges(); //commitlemek için
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            string Idata = File.ReadAllText("akisveri.json");
            var Ijsondata = JsonConvert.DeserializeObject<List<Akisveri>>(Idata);
            var context = new ApplicationDbContext();
            var Data = context.Akisveri.ToList();
            if (Data == null && Data.Count == 0)
            {
                foreach (var data in Ijsondata)
                {

                    context.Akisveri.Add(data);
                    context.SaveChanges(); //commitlemek için
                }

            }
            else
            {
                context.Akisveri.RemoveRange(Data);
                context.SaveChanges();
                foreach (var data in Ijsondata)
                {

                    context.Akisveri.Add(data);
                    context.SaveChanges(); //commitlemek için
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string apiKey = "0123ASAFDSFGDSGSGJS231353513DAFASFAFAHOAJDFAFEWOUGHWGFWIGBEWUOGBWEJGWPGWRG46546846";


            List<Device> devices = new List<Device>();
            string urlDevices = "http://10.50.10.14:81/DeviceList";
            Uri uri = new Uri(urlDevices); //URÝ BÝR CLASS
            RestClient restClient = new RestClient(uri);
            RestRequest request = new RestRequest(uri, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", apiKey);
            var response = restClient.Execute(request);
            var Ijsondata = JsonConvert.DeserializeObject<List<Device>>(response.Content);
            var context = new ApplicationDbContext();
            var Data = context.Device.ToList();
            if (Data != null)
            {
                context.Device.RemoveRange(Data);
                context.SaveChanges();

            }



            context.Device.AddRange(Ijsondata);
            context.SaveChanges();







            /*
            string Idata = File.ReadAllText("DeviceList.json");
            var Ijsondata = JsonConvert.DeserializeObject<List<Device>>(Idata);
            var context = new ApplicationDbContext();
            var Data = context.DeviceList.ToList();
            if (Data == null && Data.Count == 0)
            {
                foreach (var data in Ijsondata)
                {

                    context.DeviceList.Add(data);
                    context.SaveChanges(); //commitlemek için
                }

            }
            else
            {
                context.DeviceList.RemoveRange(Data);
                context.SaveChanges();
                foreach (var data in Ijsondata)
                {

                    context.DeviceList.Add(data);
                    context.SaveChanges(); //commitlemek için
                }
            }
            */

        }

        private void button4_Click(object sender, EventArgs e)
        {


            string apiKey = "0123ASAFDSFGDSGSGJS231353513DAFASFAFAHOAJDFAFEWOUGHWGFWIGBEWUOGBWEJGWPGWRG46546846";


            List<Ping> pings = new List<Ping>();
            string urlPingList = "http://10.50.10.14:81/PingList";
            Uri uri = new Uri(urlPingList); //URÝ BÝR CLASS
            RestClient restClient = new RestClient(uri);
            RestRequest request = new RestRequest(uri, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", apiKey);
            var response = restClient.Execute(request);
            var Ijsondata = JsonConvert.DeserializeObject<List<Ping>>(response.Content);
            var context = new ApplicationDbContext();
            var Data = context.Ping.ToList();
            if (Data != null)
            {
                context.Ping.RemoveRange(Data);
                context.SaveChanges();

            }
            context.Ping.AddRange(Ijsondata);
            context.SaveChanges();



            /*
            string Idata = File.ReadAllText("PingList.json");
            var Ijsondata=JsonConvert.DeserializeObject<List<PingList>>(Idata);
            var context = new ApplicationDbContext();
            var Data=context.PingList.ToList();
            if(Data==null && Data.Count == 0)
            {
                foreach(var data in Ijsondata)
                {
                    context.PingList.Add(data);
                    context.SaveChanges();
                }
            }else
            {
                context.PingList.RemoveRange(Data);
                context.SaveChanges() ;
                foreach (var data in Ijsondata)
                {

                    context.PingList.Add(data);
                    context.SaveChanges(); //commitlemek için
                }

            }
            */

        }
    }
}
  

