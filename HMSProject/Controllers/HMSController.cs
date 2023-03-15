﻿using System;
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
        public ActionResult Index()
        {
            return View(db.patient_registrations.ToList());
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
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Gender,Age,Date,Mobile,Address,Disease,Room_No,Amount")] patient_registration patient_registration)
        {
            if (ModelState.IsValid)
            {
                db.patient_registrations.Add(patient_registration);
                db.SaveChanges();
                ViewBag.Message = "saved sucessfully";
                //return RedirectToAction("Index");
            }

            return View(patient_registration);
        }

        // GET: HMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patient_registration patient_registration = db.patient_registrations.Find(id);
            if (patient_registration == null)
            {
                return HttpNotFound();
            }
            return View(patient_registration);
        }

        // POST: HMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Gender,Age,Date,Mobile,Address,Disease,Room_No,Amount")] patient_registration patient_registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient_registration);
        }

        // GET: HMS/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    patient_registration patient_registration = db.patient_registrations.Find(id);
        //    if (patient_registration == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient_registration);
        //}

        // POST: HMS/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            patient_registration patient_registration = db.patient_registrations.Find(id);
            db.patient_registrations.Remove(patient_registration);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult Admit([Bind(Include = "Id,PatientId,Name,Doctor_s_Name,CheckIn,RoomNo,BedNo")] Admitdetail admitdetail)
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
        public ActionResult Bill()
        {
            return View();
        }

        // POST: patient_registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bill([Bind(Include = "Billid,Patient_Name,Total_Amount,Amount_Paid,Balance")] BillGeneration billGeneration)
        {
            if (ModelState.IsValid)
            {
                db.BillGenerations.Add(billGeneration);
                db.SaveChanges();
                ViewBag.Message = "saved sucessfully";
                //return RedirectToAction("Index");
            }

            return View(billGeneration);
        }
        public ActionResult Billdetails()
        {
            return View(db.BillGenerations.ToList());
        }


        //-----STAFF------///

        public ActionResult Staff()
        {
            return View();
        }

        // POST: patient_registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Staff([Bind(Include = "Satffid,Name,Address,Speciality,Gender,Date_of_joining")] Staff staff
            )
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                ViewBag.Message = "saved sucessfully";
                //return RedirectToAction("Index");
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
