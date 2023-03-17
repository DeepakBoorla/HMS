using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMSProject.Models;

namespace HMSProject.Controllers
{
    public class HMSController : Controller
    {
        private HMSEntities db = new HMSEntities();

        // GET: HMS
        public ActionResult Index( string searching)
        {
            return View(db.Patient_Registration1.Where(s => s.FirstName.Contains(searching) || searching == null).ToList());
          //  return View(db.patient_registrations.ToList());

        }

        // GET: HMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patient_registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Gender,Age,Date,Mobile,Address,Disease,Amount")] Patient_Registration1 patient_registration1)
        {
            if (ModelState.IsValid)
            {
                db.Patient_Registration1.Add(patient_registration1);
                db.SaveChanges();
                ViewBag.Message = "saved sucessfully";
                //return RedirectToAction("Index");
            }

            return View(patient_registration1);
        }

        // GET: HMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Registration1 patient_registration1 = db.Patient_Registration1.Find(id);
            if (patient_registration1 == null)
            {
                return HttpNotFound();
            }
            return View(patient_registration1);
        }

        // POST: HMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Gender,Age,Date,Mobile,Address,Disease,Amount")] Patient_Registration1 patient_registration1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_registration1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient_registration1);
        }

       
        //------Admit----//
        // GET: Admitdetails/Create
        public ActionResult Admit()
        {
            return View();
        }

        // POST: Admitdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admit([Bind(Include = "ID,PatientId,Name,Doctor_sName,CheckIn,RoomNo,BedNo")] Admitdetail admitdetail)
        {
            if (ModelState.IsValid)
            {
                db.Admitdetails.Add(admitdetail);
                db.SaveChanges();
                ViewBag.Message = "Record saved sucessfully";
                //return RedirectToAction("Index");
            }

            return View(admitdetail);
        }
        public ActionResult Admitdetails()
        {
            return View(db.Admitdetails.ToList());
        }
        // GET: Admitdetails/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Admitdetail admitdetail = db.Admitdetails.Find(id);
        //    if (admitdetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(admitdetail);
        //}         // POST: Admitdetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Admitdetail admitdetail = db.Admitdetails.Find(id);
        //    db.Admitdetails.Remove(admitdetail);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        //--------Bill Geneartion------------//


        public ActionResult Billdetails()
        {
            return View(db.Bill_demoes.ToList());
        }

    
        // GET: Bill_demo/Create
        public ActionResult Bill()
        {
            return View();
        }

        // POST: Bill_demo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bill([Bind(Include = "C_Patient_Id,Patient_Name,Mobile,Payment_type,Doctor_s_Name,Desgination,Department,Consulation,Regulation,Total_Amount")] Bill_demo bill_demo)
        {
            if (ModelState.IsValid)
            {
                db.Bill_demoes.Add(bill_demo);
                db.SaveChanges();
                ViewBag.Message = "Record Saved Successfully";
            }

            return View(bill_demo);
        }

        //-----STAFF------///

        public ActionResult Staff()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Staff([Bind(Include = "Id,speciality,FirstName,LastName,Gender,Date_of_Birth,Mobile,Email,Designation,Department,Date_of_joining,Address,City,State")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                ViewBag.Message = "Record is saved successfully";
            }

            return View(staff);
        }
        public ActionResult Staffdetails()
        {
            return View(db.Staffs.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
