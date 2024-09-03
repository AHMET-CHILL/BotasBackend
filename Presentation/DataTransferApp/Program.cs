
using Business.Context;
using DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;


//string Idata = File.ReadAllText("spot.json");
//var Ijsondata = JsonConvert.DeserializeObject<List<Spot>>(Idata);
//Bu islemden sonra akis verilerini msqle gonderildi
string Idata = File.ReadAllText("akisveri.json");
var Ijsondata = JsonConvert.DeserializeObject<List<Akisveri>>(Idata);

foreach (var data in Ijsondata)
{
    var context = new ApplicationDbContext();
    context.Akisveri.Add(data);
    context.SaveChanges(); //commitlemek için
}


