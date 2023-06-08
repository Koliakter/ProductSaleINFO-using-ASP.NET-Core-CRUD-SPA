using Microsoft.AspNetCore.Mvc;
using ProductSaleINFO.Data;
using ProductSaleINFO.Models;

namespace ProductSaleINFO.Controllers
{
    public class SaleController : Controller
    {
        public readonly SaleDBContext db;
        public SaleController(SaleDBContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int? id)
        {
            VmSale oSale = null;
            var oSM = db.SaleMasters.Where(x => x.SaleId == id).FirstOrDefault();
            if (oSM != null)
            {
                oSale = new VmSale();
                oSale.SaleId = oSM.SaleId;
                oSale.CustomerName = oSM.CustomerName;
                oSale.CreateDate = oSM.CreateDate;
                oSale.Gender = oSM.Gender;
                oSale.Email = oSM.Email;
                oSale.Phone = oSM.Phone;
                oSale.Photo = oSM.Photo;

                var listSaleDetail = new List<VmSale.VmSaleDetail>();
                var listSD = db.SaleDetails.Where(x => x.SaleId == id).ToList();
                foreach (var oSD in listSD)
                {
                    var lvmd = new VmSale.VmSaleDetail();
                    lvmd.SaleId = oSD.SaleId;
                    lvmd.ProductName = oSD.ProductName;
                    lvmd.Color = oSD.Color;
                    lvmd.Price = oSD.Price;
                    lvmd.Qty = oSD.Qty;
                    listSaleDetail.Add(lvmd);
                }
                oSale.Details = listSaleDetail;
            }
            oSale = oSale == null ? new VmSale() : oSale;
            ViewData["list"] = db.SaleMasters.ToList();
            return View(oSale);
        }
        [HttpPost]
        public IActionResult Index(VmSale model)
        {
            var oMS = db.SaleMasters.Find(model.SaleId);
            if (oMS == null)
            {
                oMS = new SaleMaster();
                oMS.SaleId = model.SaleId;
                oMS.CustomerName = model.CustomerName;
                oMS.CreateDate = model.CreateDate;
                oMS.Gender = model.Gender;
                oMS.Email = model.Email;
                oMS.Phone = model.Phone;
                oMS.Photo = model.Photo;
                db.SaleMasters.Add(oMS);
            }
            else
            {
                oMS.SaleId = model.SaleId;
                oMS.CustomerName = model.CustomerName;
                oMS.CreateDate = model.CreateDate;
                oMS.Gender = model.Gender;
                oMS.Email = model.Email;
                oMS.Phone = model.Phone;
                oMS.Photo = model.Photo;
                var listRem = db.SaleDetails.Where(x => x.SaleId == oMS.SaleId).ToList();
                db.SaleDetails.RemoveRange(listRem);
            }
            db.SaveChanges();
            var listDetail = new List<SaleDetail>();
            for (var i = 0; i < model.ProductName.Length; i++)
            {
                if (!string.IsNullOrEmpty(model.ProductName[i]))
                {
                    var sdd = new SaleDetail();
                    sdd.SaleId = oMS.SaleId;
                    sdd.ProductName = model.ProductName[i];
                    sdd.Color = model.Color[i];
                    sdd.Price = model.Price[i];
                    sdd.Qty = model.Qty[i];
                    listDetail.Add(sdd);
                }
            }
            db.SaleDetails.AddRange(listDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delele(int id)
        {
            var oMS = db.SaleMasters.Where(x => x.SaleId == id).FirstOrDefault();
            var oSD = db.SaleDetails.Where(x => x.SaleId == id).ToList();
            if (oMS != null)
            {
                db.SaleMasters.Remove(oMS);
                db.SaleDetails.RemoveRange(oSD);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
